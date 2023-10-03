using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NLog.Config;
using NLog.Targets;
using NLog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalInformationSystemFrom
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }
        public static string OperatorName = string.Empty;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private async void button1_Click(object sender, EventArgs e)
        {
            // 创建一个 HttpClient 实例
            var httpClient = new HttpClient();


            if (!LocalCheck())
            {
                return;
            }

            string apiUrl = "http://localhost:5250/api/User/GetLogin"; // 替换为您的API地址



            // 准备要发送的数据，这里使用 JSON 格式的数据
            string jsonContent = "{ \"Username\": \"" + textBoxUserName.Text + "\",\"Password\": \"" + textBoxPassword.Text + "\"}";

            // 设置请求内容的编码和类型
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            List<UserInfo> users = new List<UserInfo>();
            List<Login> Logins = new List<Login>();
            try
            {
                // 发送 POST 请求
                var response = await httpClient.PostAsync(apiUrl, content);

                // 检查响应状态码
                if (response.IsSuccessStatusCode)
                {
                    // 解析响应内容
                    string responseContent = await response.Content.ReadAsStringAsync();
                    bool retString = false;
                    if (Boolean.TryParse(responseContent, out retString))
                    {
                        if (retString)
                        {
                            string apiUrlGetUsers = "http://localhost:5250/api/User/GetUsers";
                            try
                            {

                                // 发送 GET 请求
                                HttpResponseMessage responseGetUsers = await httpClient.GetAsync(apiUrlGetUsers);


                                // 检查响应状态码
                                if (responseGetUsers.IsSuccessStatusCode)
                                {
                                    // 读取响应内容
                                    string responseBody = await responseGetUsers.Content.ReadAsStringAsync();
                                    // 使用 System.Text.Json 反序列化 JSON 数据
                                    users = JsonConvert.DeserializeObject<List<UserInfo>>(responseBody);

                                }
                                else
                                {
                                    MessageBox.Show( "网络故障请稍后再试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                Logger.Error(ex, "FrmLogin-butLogin");
                            }

                            string apiUrlGetLogins = "http://localhost:5250/api/User/GetLogins";
                            try
                            {

                                // 发送 GET 请求
                                HttpResponseMessage responseGetLogins = await httpClient.GetAsync(apiUrlGetLogins);


                                // 检查响应状态码
                                if (responseGetLogins.IsSuccessStatusCode)
                                {
                                    // 读取响应内容
                                    string responseBody = await responseGetLogins.Content.ReadAsStringAsync();
                                    // 使用 System.Text.Json 反序列化 JSON 数据
                                    Logins = JsonConvert.DeserializeObject<List<Login>>(responseBody);

                                }
                                else
                                {
                                    MessageBox.Show("网络故障请稍后再试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                Logger.Error(ex, "FrmLogin-butLogin");
                            }
                            FrmWorkBench frmWorkBench = new FrmWorkBench();
                            //角色
                            switch (users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID)
                            {
                                case "0":
                                    frmWorkBench = new FrmWorkBench();
                                    frmWorkBench.UserInfo = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault();
                                    frmWorkBench.login = Logins.Where(t => t.Username == textBoxUserName.Text.Trim()).FirstOrDefault();
                                    frmWorkBench.RoleID = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID;
                                    OperatorName = users.FirstOrDefault(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).Name;
                                    this.Hide();
                                    frmWorkBench.Show();
                                    break;
                                case "1":
                                    frmWorkBench = new FrmWorkBench();
                                    frmWorkBench.UserInfo = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault();
                                    frmWorkBench.login = Logins.Where(t => t.Username == textBoxUserName.Text.Trim()).FirstOrDefault();
                                    frmWorkBench.RoleID = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID;
                                    this.Hide();
                                    frmWorkBench.Show();
                                    break;
                                case "2":
                                    frmWorkBench = new FrmWorkBench();
                                    frmWorkBench.UserInfo = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault();
                                    frmWorkBench.login = Logins.Where(t => t.Username == textBoxUserName.Text.Trim()).FirstOrDefault();
                                    frmWorkBench.RoleID = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID;
                                    this.Hide();
                                    frmWorkBench.Show();
                                    break;
                                case "3":
                                    frmWorkBench = new FrmWorkBench();
                                    frmWorkBench.UserInfo = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault();
                                    frmWorkBench.login = Logins.Where(t => t.Username == textBoxUserName.Text.Trim()).FirstOrDefault();
                                    frmWorkBench.RoleID = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID;
                                    this.Hide();
                                    frmWorkBench.Show();
                                    break;
                                case "4":
                                    frmWorkBench = new FrmWorkBench();
                                    frmWorkBench.UserInfo = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault();
                                    frmWorkBench.login = Logins.Where(t => t.Username == textBoxUserName.Text.Trim()).FirstOrDefault();
                                    frmWorkBench.RoleID = users.Where(t => Logins.Select(s => s.UserID).ToList().Contains(t.UserID)).FirstOrDefault().RoleID;
                                    this.Hide();
                                    frmWorkBench.Show();
                                    break;
                                default:
                                    textBoxUserName.Text = "";
                                    textBoxPassword.Text = "";
                                    textBoxUserName.Focus();
                                    MessageBox.Show("用户名或密码不正确，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                            }

                        }
                        else
                        {
                            textBoxUserName.Text = "";
                            textBoxPassword.Text = "";
                            textBoxUserName.Focus();
                            MessageBox.Show("用户名或密码不正确，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("网络故障请稍后再试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "FrmLogin-butLogin");
            }

        }

        public bool LocalCheck()
        {
            if (textBoxUserName.Text.Trim() == "" || textBoxPassword.Text.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else { return true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
            textBoxPassword.Focus();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(sender, e);
            }
        }
    }
}
