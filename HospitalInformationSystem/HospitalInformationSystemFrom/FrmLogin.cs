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

namespace HospitalInformationSystemFrom
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private async void button1_Click(object sender, EventArgs e)
        {
            // 创建一个 HttpClient 实例
            var httpClient = new HttpClient();
            //string apiUrl = "http://localhost:5250/api/User/GetLogin";
            //try
            //{

            //    // 发送 GET 请求
            //    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);


            //    // 检查响应状态码
            //    if (response.IsSuccessStatusCode)
            //    {
            //        // 读取响应内容
            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        // 使用 System.Text.Json 反序列化 JSON 数据
            //        List<UserInfo> users = JsonConvert.DeserializeObject<List<UserInfo>>(responseBody);
            //        users.Where(t => t.Name == textBoxUserID.Text).ToList();
            //    }
            //    else
            //    {
            //        MessageBox.Show("提示", "网络故障请稍后再试!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (HttpRequestException ex)
            //{
            //    Logger.Error(ex, "FrmLogin-butLogin");
            //}

            if (!LocalCheck())
            {
                return;
            }

            string apiUrl = "http://localhost:5250/api/User/GetLogin"; // 替换为您的API地址

            // 准备要发送的数据，这里使用 JSON 格式的数据
            string jsonContent = "{\"username\": \""+textBoxUserID.Text+"\", \"password\": \""+ textBoxPassword.Text + "\"}";

            // 设置请求内容的编码和类型
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

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

                        }
                        else
                        {
                            textBoxUserID.Text = "";
                            textBoxPassword.Text = "";
                            textBoxPassword.Focus();
                            MessageBox.Show("提示", "用户名或密码不正确，请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("提示", "网络故障请稍后再试!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "FrmLogin-butLogin");
            }

        }

        public bool LocalCheck()
        {
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxUserID.Text = "";
            textBoxPassword.Text = "";
            textBoxPassword.Focus();
        }
    }
}
