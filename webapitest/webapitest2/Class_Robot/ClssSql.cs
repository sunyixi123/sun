using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Robot
{
   public class ClssSql
    {
        string pvitemName;//拼接语句的名字
        string pvsSql;//sql语句
        string pvNewId;//生成的NewID

        public string itemName
        {

            get { return pvitemName; }
            set { pvitemName = value; }
        }

        public string sSql
        {

            get { return pvsSql; }
            set { pvsSql = value; }
        }

        public string newId
        {
            get { return pvNewId; }
            set { pvNewId = value; }
        }
    }
}
