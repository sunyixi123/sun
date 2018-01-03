using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
//using System.Data.OracleClient;

namespace Class_Robot
{
    public class DbHelperCon
    {
        /// <summary>
        /// 调用数据
        /// </summary>
        private string dbProviderName = "";
        private string dbConnectionString = "";

        #region 创建 Connection

        public DbConnection CreateConnection()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            dbconn.ConnectionString = dbConnectionString;
            return dbconn;
        }
        #endregion

        private DbConnection connection;
        /// <summary>
        /// 构造函数初始化连接
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderName"></param>
        public DbHelperCon(string connectionString, string dbProviderName)
        {
            this.dbConnectionString = connectionString;
            this.dbProviderName = dbProviderName;
            this.connection = CreateConnection();
        }

        #region 获得 command
        /// <summary>
        /// 存储过程Command
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        public DbCommand GetStoredProcCommand(string storedProcedure)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = storedProcedure;
            dbCommand.CommandType = CommandType.StoredProcedure;
            return dbCommand;
        }
        /// <summary>
        /// sql语句Command
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommand(string sqlQuery)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            dbCommand.CommandType = CommandType.Text;
            return dbCommand;
        }
        #endregion
        /// <summary>
        /// sql语句Command
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommand(DbTransaction Trans)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.Transaction = Trans;
            dbCommand.CommandType = CommandType.Text;
            return dbCommand;
        }
        #region 增加参数
        public void AddParameterCollection(DbCommand cmd, DbParameterCollection dbParameterCollection)
        {
            foreach (DbParameter dbParameter in dbParameterCollection)
            {
                cmd.Parameters.Add(dbParameter);
            }
        }

        public void AddOutParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Size = size;
            dbParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dbParameter);
        }
        public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(dbParameter);
        }
        public void AddReturnParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(dbParameter);
        }
        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return cmd.Parameters[parameterName];
        }

        #endregion


        #region 执行
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sqlQuery)
        {

            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DbCommand com = null;
            com = GetSqlStringCommand(sqlQuery);
            dbDataAdapter.SelectCommand = com;
            DataSet ds = new DataSet();
            try
            {
                if (com.Connection.State == ConnectionState.Closed)
                {
                    com.Connection.Open();
                }

                dbDataAdapter.Fill(ds);


            }
            catch (Exception ex)
            {

            }
            finally
            {


                    com.Connection.Close();
            }
            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="exception"></param>
        /// <param name="falg"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sqlQuery, out Exception exception, out int falg)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DbCommand com = null;
            com = GetSqlStringCommand(sqlQuery);
            dbDataAdapter.SelectCommand = com;
            exception = null;
            falg = 0;
            DataTable dt = new DataTable();
            try
            {
                if (com.Connection.State == ConnectionState.Closed)
                {
                    com.Connection.Open();
                }

                dbDataAdapter.Fill(dt);


            }
            catch (Exception ex)
            {
                exception = ex;
                falg = 1;
            }
            finally
            {

                
                    com.Connection.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="exception"></param>
        /// <param name="falg"></param>
        /// <param name="DbParameter">存储过程参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sqlQuery, out Exception exception, out int falg, params DbParameter[] ps)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DbCommand com = null;
            com = GetStoredProcCommand(sqlQuery);
            dbDataAdapter.SelectCommand = com;
            exception = null;
            falg = 0;
            DataTable dt = new DataTable();
            try
            {
                if (com.Connection.State == ConnectionState.Closed)
                {
                    com.Connection.Open();
                }
                //传递参数给Oracle命令       
                for (int i = 0; i < ps.Length; i++)
                {
                    com.Parameters.Add(ps[i]);
                }

                dbDataAdapter.Fill(dt);


            }
            catch (Exception ex)
            {
                exception = ex;
                falg = 1;
            }
            finally
            {

                    com.Connection.Close();

            }
            return dt;
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.Connection.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sqlQuery"></param>
        ///  <param name="exception"></param>
        ///  <param name="falg"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlQuery, out Exception exception, out int falg)
        {
            DbCommand com = null;
            com = GetSqlStringCommand(sqlQuery);

            exception = null;
            falg = 0;
            int ret = 0;
            try
            {
                if (com.Connection.State == ConnectionState.Closed)
                {
                    com.Connection.Open();
                }

                ret = com.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                exception = ex;
                falg = 1;
            }
            finally
            {


                    com.Connection.Close();

            }
            return ret;
        }
        /// <summary>
        /// 返回首行
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="exception"></param>
        /// <param name="falg"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlQuery, out Exception exception, out int falg)
        {
            DbCommand com = null;
            com = GetSqlStringCommand(sqlQuery);

            exception = null;
            falg = 0;
            object ret = null;
            try
            {
                if (com.Connection.State == ConnectionState.Closed)
                {
                    com.Connection.Open();
                }

                ret = com.ExecuteScalar();


            }
            catch (Exception ex)
            {
                exception = ex;
                falg = 1;
            }
            finally
            {

                    com.Connection.Close();

            }
            return ret;
        }
        #endregion

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sqlQuery"></param>
        ///  <param name="exception"></param>
        ///  <param name="falg"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(List<string> lisSqlQuery, out Exception exception, out int falg)
        {


            DbCommand com = null;

            exception = null;
            falg = 0;
            int ret = 0;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                DbTransaction Trans = connection.BeginTransaction();
                com = GetSqlStringCommand(Trans);


                foreach (string sql in lisSqlQuery)
                {
                    com.CommandText = sql;
                    ret += com.ExecuteNonQuery();
                }
                Trans.Commit();

            }
            catch (Exception ex)
            {
                exception = ex;
                falg = 1;
            }
            finally
            {


                    com.Connection.Close();

            }
            return ret;
        }


        #region 执行事务
        public DataSet ExecuteDataSet(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            return ds;
        }

        public DataTable ExecuteDataTable(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dbDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DbDataReader ExecuteReader(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            return reader;
        }

        public int ExecuteNonQuery(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            int ret = cmd.ExecuteNonQuery();
            return ret;
        }

        public object ExecuteScalar(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            object ret = cmd.ExecuteScalar();
            return ret;
        }
        #endregion
    }
}
