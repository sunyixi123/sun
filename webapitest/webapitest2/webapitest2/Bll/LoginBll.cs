using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webapitest2.Models;

namespace webapitest2.Bll
{
    public class LoginBll
    {
        static Class_Robot.DbHelperCon  DbHelperCon = new Class_Robot.DbHelperCon("data source=59.80.30.160,44433;initial catalog=HealthExam;user id=sa;password=1qazxsw2#;", "System.Data.SqlClient");

        public static ReturnMsg getLogin(userLogin value)
        {
            ReturnMsg returnMsg = new ReturnMsg();
            Exception exc = null;
            int flag = 0;
            string sql = string.Format(@"select count(1) count from [User] where [userName]='{0}'
      and [pwd]='{1}'", value.name, value.password);
            DataTable dt = new DataTable();
            dt = DbHelperCon.ExecuteDataTable(sql, out exc, out flag);

            returnMsg.status = "ok";
            returnMsg.message = dt;
            return returnMsg;
        }
    }
}