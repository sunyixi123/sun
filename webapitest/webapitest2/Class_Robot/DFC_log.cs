using System;
using System.IO;
using System.Text;

namespace Class_Robot
{

    /// <summary>
    /// [DFC] 综合处理日志信息，创建、更改日志文件。
    /// </summary>
    public class DFC_log
    {
        //edit by JD on 20091206 private System.IO.StreamWriter lIOsw_logfile;
        private string slogfilename;

        /// <summary>
        ///  log 字段分隔符
        /// </summary>
        private char delimitate = (char)9;

        /// <summary>
        ///  是否按日期自动生成文件
        /// </summary>
        private bool autodate = false;

        /// <summary>
        ///  是否自动拆分大于10MB的文件
        /// </summary>
        private bool autoSplit = true;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="str_logfileformat">日志文件名的生成格式</param>
        /// <param name="bool_autodatet">日志文件名的生成是否按日期生成</param>
        public DFC_log(string str_logfileformat, bool bool_autodatet)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            slogfilename = str_logfileformat;
            autodate = bool_autodatet;

            delimitate = (char)9;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="str_logfile">日志文件名</param>
        public DFC_log(string str_logfile)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            slogfilename = str_logfile;
            autodate = false;

            delimitate = (char)9;
            //			if (!File.Exists(slogfilename) )
            //			{
            //				this.lIOsw_logfile  = new System.IO.StreamWriter( this.slogfilename ,true );
            //				string ls_logmessage = DateTime.Now.ToString("u")
            //					+ " "
            //					+ "创建日志文件";
            //				this.lIOsw_logfile.WriteLine(ls_logmessage);
            //				this.lIOsw_logfile.Close();
            //			}
        }
        #endregion

        #region 日志信息写入日志文件
        /// <summary>
        /// 定义private static 对象变量，用于lock ，来保护所有实例所共有的数据。
        ///<remarks> 
        /// lock 确保当一个线程位于PutLog代码的临界区时，另一个线程不进入PutLog临界区。如果其他线程试图进入锁定的代码，则它将一直等待（即被阻止），直到该thisLock对象被释放。
        /// </remarks>
        /// </summary>
        private Object thisLock = new Object();

        /// <summary>将日志信息 <paramref name="str_logmessage"/> 写入日志文件 </summary>
        /// <param name="str_logmessage">日志内容（日期时间由函数自动生成）</param>
        /// <returns>成功返回“OK”，否则返回出错信息</returns>
        public string PutLog(string str_logmessage)
        {
            string ls_logmessage;
            string ls_logfilename;
            string ret = "OK";
            try
            {
                lock (thisLock)
                {
                    if (this.autodate == true)
                    {
                        ls_logfilename = string.Format(this.slogfilename, DateTime.Now.ToString("yyyyMMdd "));
                    }
                    else
                    {
                        ls_logfilename = this.slogfilename;
                    }
                    try
                    {
                        ls_logmessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")
                            + delimitate
                            + str_logmessage.Trim();

                        File.AppendAllText(ls_logfilename, ls_logmessage + (char)13 + (char)10, Encoding.UTF8);

                        //// edit by JD on 20140917 start
                        if (this.autoSplit)
                        {
                            FileInfo fi = new FileInfo(ls_logfilename);
                            if (fi.Length > ((1024 * 1024) * 10))
                            {
                                #region  20140820 sun start
                                string s = System.IO.Path.GetDirectoryName(ls_logfilename);
                                // 用一句rename原来的文件名就可以了,既快又省
                                File.Move(ls_logfilename, ls_logfilename + "." + DateTime.Now.ToString("HHmmss") + ".splt");
                                #endregion 20140820 sun end
                            }
                        }
                        //// edit by JD on 20140917 end

                    }
                    catch (Exception e)
                    {
                        ret = e.Message.Trim();
                    }
                }
            }
            catch (Exception e)
            {
                ret = e.Message.Trim();
            }
            return ret;
        }
        #endregion
    }

}
