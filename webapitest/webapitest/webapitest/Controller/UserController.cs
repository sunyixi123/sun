using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapitest.Model;

namespace webapitest.Controller
{
    public class UserController : ApiController
    {
        public List<Users> getUser()
        {
            var userList = new List<Users>
           {
               new Users {Id=1,UName="张三",UAge=12,UAddress="浦东" }

            };
            var temp = (from u in userList select u).ToList();
            return temp;

        }

    }
}