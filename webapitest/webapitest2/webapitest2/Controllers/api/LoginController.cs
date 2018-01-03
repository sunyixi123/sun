using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapitest2.Models;
using System.Data.SqlClient;
using System.Data;
using webapitest2.Bll;
using System.Text;

namespace webapitest2.Controllers.api
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        Class_Robot.DbHelperCon DbHelperCon = new Class_Robot.DbHelperCon("Data Source=127.0.0.1;Initial Catalog=GaryWeb;Integrated Security=True;User Id=sa;Password=123456", "System.Data.SqlClient");

        [HttpPost]
        // POST: api/Login
        public HttpResponseMessage Login(userLogin value)
        {
            var login = LoginBll.getLogin(value);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(login);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };//这里是去掉反斜杠再放回出去，json就只剩下双引号。
            return result;
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
