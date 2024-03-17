using HospitalInformationSystemFrom.PublicClass;
using Newtonsoft.Json;
using NLog;
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

namespace HospitalInformationSystemFrom
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        UserInfo setUserInfo = new UserInfo();
        Login setLogin = new Login();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyChar)
            {
                select();
            }
        }
        UserInfo setUserValues(UserInfo userInfo)
        {
            if (userInfo.IDNumber == null)
            {
                userInfo.Name = textBoxName.Text.Trim();
                userInfo.Gender = comboBoxGender.SelectedIndex.ToString();
                userInfo.Email = textBoxEmail.Text.Trim();
                userInfo.DateOfBirth = dateTimePickerDOB.Value;
                userInfo.Address = textBoxAddress.Text.Trim();
                userInfo.IsActive = comboBoxIsActive.SelectedIndex.ToString();
                userInfo.CreateTime = DateTime.Now;
                userInfo.CreateOperator = FrmLogin.OperatorName;
                userInfo.RoleID = "3";
                userInfo.PhoneNumber = textBoxPhoneNumber.Text.Trim();
                userInfo.UpdaterOperator = FrmLogin.OperatorName;
                userInfo.IDNumber = textBoxIDNumber.Text.Trim();
            }
            else
            {
                textBoxName.Text = userInfo.Name;
                comboBoxGender.SelectedIndex = Convert.ToInt32(userInfo.Gender);
                textBoxEmail.Text = userInfo.Email;
                dateTimePickerDOB.Value = (DateTime)userInfo.DateOfBirth;
                textBoxAddress.Text = userInfo.Address;
                comboBoxIsActive.SelectedIndex = Convert.ToInt32(userInfo.IsActive);
                textBoxIDNumber.Text = userInfo.IDNumber;
                userInfo.UpdaterTime = DateTime.Now;
                userInfo.UpdaterOperator = FrmLogin.OperatorName;
                userInfo.RoleID = "3";
            }
            return userInfo;
        }

        Login setLoginValues(Login login)
        {
            if (login.Username == null)
            {
                login.Username = textBoxUserName.Text;
                login.Password = "111111";
                login.CreateOperator = FrmLogin.OperatorName;
                login.CreateTime = DateTime.Now;
                login.IsActive = "1";
                login.UpdaterOperator = FrmLogin.OperatorName;
            }
            else
            {

            }
            return login;
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            UserLoginDTO userLoginDTO = new UserLoginDTO();
            setLogin = new Login();
            setUserInfo = new UserInfo();

            string apiUrlGetLogins = "http://localhost:5250/api/User/GetLogins";
            Task<string> responseGetLogins = httpHelper.SendGetRequestAsync(apiUrlGetLogins);
            // 使用 await 等待异步任务完成，并获取其结果
            string result = await responseGetLogins;
            List<Login> tepLogins = JsonConvert.DeserializeObject<List<Login>>(result);

            if (tepLogins.FirstOrDefault(t => t.Username == textBoxUserName.Text.Trim()) != null)
            {
                userLoginDTO.Login = tepLogins.FirstOrDefault(t => t.Username == textBoxUserName.Text.Trim());
                userLoginDTO.UserInfo = setUserValues(setUserInfo);
                userLoginDTO.UserInfo.UserID = userLoginDTO.Login.UserID;
            }
            else
            {
                userLoginDTO.Login = setLoginValues(setLogin);
                userLoginDTO.UserInfo = setUserValues(setUserInfo);
            }

            string apiUrl = "http://localhost:5250/api/User/setUserInfo"; // 替换为您的API地址
            // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(userLoginDTO);

            Task<string> responseSetLogins = httpHelper.SendPostRequestAsync(apiUrl, json);
            // 使用 await 等待异步任务完成，并获取其结果
            string setResult = await responseSetLogins;
            returnMessage re = JsonConvert.DeserializeObject<returnMessage>(setResult);
            if (re != null)
            {
                if (re.isSucceed != true)
                {
                    MessageBox.Show(re.errorManger, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("登记成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        HttpClient httpClient = new HttpClient();
        HttpHelper httpHelper = null;
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            comboBoxIsActive.SelectedIndex = 1;

        }
        async void select()
        {
            string apiUrlGetLogins = "http://localhost:5250/api/User/GetLogins";
            // 创建一个 HttpClient 实例
            var httpClient = new HttpClient();

            List<Login> Logins = new List<Login>();
            List<UserInfo> users = new List<UserInfo>();
            try
            {

                Task<string> responseGetLogins = httpHelper.SendGetRequestAsync(apiUrlGetLogins);
                // 使用 await 等待异步任务完成，并获取其结果
                string result = await responseGetLogins;
                Logins = JsonConvert.DeserializeObject<List<Login>>(result);
                if (Logins.FirstOrDefault(t => t.Username == textBoxUserName.Text.Trim()) != null)
                {
                    Login tempLogin = Logins.FirstOrDefault(t => t.Username == textBoxUserName.Text.Trim());
                    setLoginValues(Logins.FirstOrDefault(t => t.Username == textBoxUserName.Text.Trim()));
                    string apiUrlGetUsers = "http://localhost:5250/api/User/GetUsers";
                    try
                    {

                        // 发送 GET 请求
                        HttpResponseMessage responseGetUsers = await httpClient.GetAsync(apiUrlGetUsers);

                        // 检查响应状态码
                        if (responseGetUsers.IsSuccessStatusCode)
                        {
                            // 读取响应内容
                            string responseBodyGetUsers = await responseGetUsers.Content.ReadAsStringAsync();
                            // 使用 System.Text.Json 反序列化 JSON 数据
                            users = JsonConvert.DeserializeObject<List<UserInfo>>(responseBodyGetUsers);

                            setUserInfo = users.Where(t => tempLogin.UserID == t.UserID).FirstOrDefault();
                            if (setUserInfo.RoleID != "3")//判断是否被非患者占用用户名
                            {
                                MessageBox.Show("该用户名已经被占用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            setUserValues(setUserInfo);

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

                }
                else
                {
                    setUserInfo = setUserValues(setUserInfo);
                    setLogin = setLoginValues(setLogin);

                }

            }
            catch (HttpRequestException ex)
            {
                Logger.Error(ex, "FrmLogin-butLogin");
            }
        }
        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            select();
        }
    }
    public class UserLoginDTO
    {
        public UserInfo UserInfo { get; set; }
        public Login Login { get; set; }
    }
}
