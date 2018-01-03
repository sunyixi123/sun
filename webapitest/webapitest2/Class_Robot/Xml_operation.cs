using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Class_Robot
{
   public class Xml_operation
    {
        /// <summary>
        /// 储存XML
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
        /// XML赋值
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="value"></param>
        public void setXmlValue(string xmlPath, string nodeName, string value)
        {
            lock (this)
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(xmlPath);//装载XML文档 
                XmlNodeList ErrorMsgList = dom.GetElementsByTagName(nodeName); //取得节点名为row的XmlNode集合
                foreach (XmlNode xxNode in ErrorMsgList)
                {
                    xxNode.InnerText = value;
                }
                dom.Save(xmlPath);
            }
        }
    }
}
