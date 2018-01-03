using System;
using System.IO;
using System.Text;

namespace Class_Robot
{

    /// <summary>
    /// [DFC] �ۺϴ�����־��Ϣ��������������־�ļ���
    /// </summary>
    public class DFC_log
    {
        //edit by JD on 20091206 private System.IO.StreamWriter lIOsw_logfile;
        private string slogfilename;

        /// <summary>
        ///  log �ֶηָ���
        /// </summary>
        private char delimitate = (char)9;

        /// <summary>
        ///  �Ƿ������Զ������ļ�
        /// </summary>
        private bool autodate = false;

        /// <summary>
        ///  �Ƿ��Զ���ִ���10MB���ļ�
        /// </summary>
        private bool autoSplit = true;

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="str_logfileformat">��־�ļ��������ɸ�ʽ</param>
        /// <param name="bool_autodatet">��־�ļ����������Ƿ���������</param>
        public DFC_log(string str_logfileformat, bool bool_autodatet)
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            slogfilename = str_logfileformat;
            autodate = bool_autodatet;

            delimitate = (char)9;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="str_logfile">��־�ļ���</param>
        public DFC_log(string str_logfile)
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            slogfilename = str_logfile;
            autodate = false;

            delimitate = (char)9;
            //			if (!File.Exists(slogfilename) )
            //			{
            //				this.lIOsw_logfile  = new System.IO.StreamWriter( this.slogfilename ,true );
            //				string ls_logmessage = DateTime.Now.ToString("u")
            //					+ " "
            //					+ "������־�ļ�";
            //				this.lIOsw_logfile.WriteLine(ls_logmessage);
            //				this.lIOsw_logfile.Close();
            //			}
        }
        #endregion

        #region ��־��Ϣд����־�ļ�
        /// <summary>
        /// ����private static �������������lock ������������ʵ�������е����ݡ�
        ///<remarks> 
        /// lock ȷ����һ���߳�λ��PutLog������ٽ���ʱ����һ���̲߳�����PutLog�ٽ�������������߳���ͼ���������Ĵ��룬������һֱ�ȴ���������ֹ����ֱ����thisLock�����ͷš�
        /// </remarks>
        /// </summary>
        private Object thisLock = new Object();

        /// <summary>����־��Ϣ <paramref name="str_logmessage"/> д����־�ļ� </summary>
        /// <param name="str_logmessage">��־���ݣ�����ʱ���ɺ����Զ����ɣ�</param>
        /// <returns>�ɹ����ء�OK�������򷵻س�����Ϣ</returns>
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
                                // ��һ��renameԭ�����ļ����Ϳ�����,�ȿ���ʡ
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
