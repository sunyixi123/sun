using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Class_Robot
{
    public class Trans : IDisposable
    {
        //初始化
        private DbConnection conn;
        private DbTransaction dbTrans;
        public DbConnection DbConnection
        {
            get { return this.conn; }
        }
        public DbTransaction DbTrans
        {
            get { return this.dbTrans; }
        }
        /// <summary>
        /// 构造函数声明
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderName"></param>
        public Trans(DbConnection conn)
        {
            this.conn = conn;
            dbTrans = conn.BeginTransaction();
        }

        public void Commit()
        {
            dbTrans.Commit();
            this.Colse();
        }

        public void RollBack()
        {
            dbTrans.Rollback();
            this.Colse();
        }

        public void Dispose()
        {
            this.Colse();
        }

        public void Colse()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
