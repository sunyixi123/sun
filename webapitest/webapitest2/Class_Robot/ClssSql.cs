using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Robot
{
   public class ClssSql
    {
        string pvitemName;//ƴ����������
        string pvsSql;//sql���
        string pvNewId;//���ɵ�NewID

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
