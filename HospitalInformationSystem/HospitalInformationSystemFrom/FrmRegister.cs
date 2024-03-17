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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalInformationSystemFrom
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        HttpClient httpClient = new HttpClient();
        HttpHelper httpHelper = null;
        private async void button2_Click(object sender, EventArgs e)
        {
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiGetDoctorAppointments = "http://localhost:5250/api/User/GetDoctorAppointments";
            // 创建一个 HttpClient 实例
            List<DoctorAppointment> DoctorAppointments = new List<DoctorAppointment>();
            List<UserInfo> tempUserInfos = new List<UserInfo>();
            List<DoctorSchedule> tempDoctorSchedules = new List<DoctorSchedule>();

            string apiUrlGetMedicalVisits = "http://localhost:5250/api/User/GetMedicalVisits";
            // 创建一个 HttpClient 实例
            MedicalVisits = new List<MedicalVisit>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetMedicalVisits = await httpClient.GetAsync(apiUrlGetMedicalVisits);

                // 检查响应状态码
                if (responseGetMedicalVisits.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyGetMedicalVisits = await responseGetMedicalVisits.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    MedicalVisits = JsonConvert.DeserializeObject<List<MedicalVisit>>(responseBodyGetMedicalVisits);
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

            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetDoctorAppointments = await httpClient.GetAsync(apiGetDoctorAppointments);

                // 检查响应状态码
                if (responseGetDoctorAppointments.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyGetDoctorAppointments = await responseGetDoctorAppointments.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    DoctorAppointments = JsonConvert.DeserializeObject<List<DoctorAppointment>>(responseBodyGetDoctorAppointments);
                    List<int> UserIDlist = new List<int>();
                    List<int> ScheduleIDlist = new List<int>();
                    UserIDlist = users.Where(t => t.Name == textBoxName.Text.Trim() && t.RoleID == "3").Select(t => t.UserID).ToList();
                    DoctorAppointments = DoctorAppointments.Where(t => UserIDlist.Contains(t.PatientID)&&t.AppointmentDate.ToString("yyyy-MM-dd")==DateTime.Now.ToString("yyyy-MM-dd")).ToList();
                    ScheduleIDlist = DoctorAppointments.Select(t => t.ScheduleID).ToList();
                    tempDoctorSchedules = DoctorSchedules.Where(t => ScheduleIDlist.Contains(t.ScheduleID)).ToList();

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
            List<DoctorAppointmentMedicalVisit> doctorAppointmentMedicalVisits = new List<DoctorAppointmentMedicalVisit>();
            foreach (var s in DoctorAppointments)
            {
                doctorAppointmentMedicalVisits.Add(new DoctorAppointmentMedicalVisit
                {
                    AppointmentID = s.AppointmentID,
                    DoctorAppointmentStatus = s.Status,
                    AppointmentDate = s.AppointmentDate,
                    DoctorID = s.DoctorID,
                    IDNumber = users.FirstOrDefault(t => t.UserID == s.PatientID)?.IDNumber,
                    MedicalVisitStatus = MedicalVisits.FirstOrDefault(t => t.AppointmentID == s.AppointmentID) == null ? "未登记" : MedicalVisits.FirstOrDefault(t => t.AppointmentID == s.AppointmentID).Status,
                    Name = users.FirstOrDefault(t => t.UserID == s.PatientID)?.Name,
                    VisitID = MedicalVisits.FirstOrDefault(t => t.AppointmentID == s.AppointmentID)!=null ? MedicalVisits.FirstOrDefault(t => t.AppointmentID == s.AppointmentID).VisitID : 0,
                    PatientID=s.PatientID
                });
            }
            dataGridView2.DataSource = doctorAppointmentMedicalVisits;
        }
        List<UserInfo> users = new List<UserInfo>();
        List<DoctorSchedule> DoctorSchedules = new List<DoctorSchedule>();
        List<MedicalVisit> MedicalVisits = new List<MedicalVisit>();
        List<DoctorAppointment> DoctorAppointments = new List<DoctorAppointment>();
        private async void FrmRegister_Load(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetUsers = "http://localhost:5250/api/User/GetUsers";
            // 创建一个 HttpClient 实例
            users = new List<UserInfo>();
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

                    users = users.Where(t => t.RoleID == "3").ToList();

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
            string apiUrlGetDoctorAppointments = "http://localhost:5250/api/User/GetDoctorAppointments";
            // 创建一个 HttpClient 实例
            DoctorSchedules = new List<DoctorSchedule>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetDoctorAppointments = await httpClient.GetAsync(apiUrlGetDoctorAppointments);

                // 检查响应状态码
                if (responseGetDoctorAppointments.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyGetUsers = await responseGetDoctorAppointments.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    DoctorAppointments = JsonConvert.DeserializeObject<List<DoctorAppointment>>(responseBodyGetUsers);
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

        private async void button3_Click(object sender, EventArgs e)
        {
            int AppointmentID = 0;
            int PatientID = 0;
            int DoctorID = 0;
            DateTime VisitDate = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {

                AppointmentID = (int)row.Cells["AppointmentID"].Value;
                PatientID = (int)row.Cells["PatientID"].Value;
                DoctorID = (int)row.Cells["DoctorID"].Value;
                VisitDate = (DateTime)row.Cells["AppointmentDate"].Value;
            }

            MedicalVisit medicalVisit = new MedicalVisit
            {

                AppointmentID = AppointmentID,

                PatientID = PatientID,

                DoctorID = DoctorID,

                VisitDate = VisitDate,

                VisitTime = new TimeSpan(8, 0, 0),

                Status = "已登记",

                CreateTime = DateTime.Now,

                CreateOperator = "管理员",

                UpdaterTime = DateTime.Now,

                UpdaterOperator = "管理员",

                IsActive = "1",

                DiagnosisID="",
            };
            string apiUrl = "http://localhost:5250/api/User/SetMedicalVisit"; // 替换为您的API地址
                                                                              // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(medicalVisit);

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
                    MessageBox.Show("挂号登记成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            button2_Click(sender, e);
        }
    }
    public class DoctorAppointmentMedicalVisit
    {
        public DateTime AppointmentDate { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string DoctorAppointmentStatus { get; set; }
        public string MedicalVisitStatus { get; set; }
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int VisitID { get; set; }
        public int PatientID { get; set; }
    }
}
