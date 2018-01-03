using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Class_Robot
{
   public class Xml_operation
    {
        /// <summary>
        /// ����XML
        /// </summary>
        /// <param name="dtYhm"></param>
        /// <param name="sDSName"></param>
        /// <param name="sXMLPath"></param>
        public void SaveXML(System.Data.DataTable dtYhm, string sDSName, string sXMLPath)
        {
            lock (this)
            {
                System.Data.DataSet set = new System.Data.DataSet(sDSName);
                set.Tables.Add(dtYhm.Copy());
                set.WriteXml(sXMLPath);
            }
        }
        /// <summary>
        /// XML��ֵ
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="value"></param>
        public void setXmlValue(string xmlPath, string nodeName, string value)
        {
            lock (this)
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(xmlPath);//װ��XML�ĵ� 
                XmlNodeList ErrorMsgList = dom.GetElementsByTagName(nodeName); //ȡ�ýڵ���Ϊrow��XmlNode����
                foreach (XmlNode xxNode in ErrorMsgList)
                {
                    xxNode.InnerText = value;
                }
                dom.Save(xmlPath);
            }
        }
    }
}
