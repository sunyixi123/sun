using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace webapitest
{
    public class WebAPIConfig
    {
        public static void Register(HttpConfiguration cofig) {
            //注册路由映射
            cofig.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{action}/{id}",
                defaults: new {id=RouteParameter.Optional}
                );

        }
    }
}