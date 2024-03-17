using HospitalInformationSystemFrom.PublicClass;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FrmAppointment : Form
    {
        public FrmAppointment()
        {
            InitializeComponent();
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        HttpClient httpClient = new HttpClient();
        HttpHelper httpHelper = null;
        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectDoctorID = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                selectDoctorID = (int)row.Cells["Column9"].Value;
            }
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetUsers = "http://localhost:5250/api/User/GetDoctorSchedules";

            string apiUrlDoctorAppointments = "http://localhost:5250/api/User/GetDoctorAppointments";
            // 创建一个 HttpClient 实例
            List<DoctorAppointment> DoctorAppointments = new List<DoctorAppointment>();
            List<int> ScheduleID = new List<int>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetUsers = await httpClient.GetAsync(apiUrlDoctorAppointments);

                // 检查响应状态码
                if (responseGetUsers.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyGetUsers = await responseGetUsers.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    DoctorAppointments = JsonConvert.DeserializeObject<List<DoctorAppointment>>(responseBodyGetUsers);

                    ScheduleID = DoctorAppointments.Where(t => t.PatientID == FrmLogin.OperatorID).Select(t => t.ScheduleID).ToList();


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

            // 创建一个 HttpClient 实例
            List<DoctorSchedule> DoctorSchedules = new List<DoctorSchedule>();
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
                    DoctorSchedules = JsonConvert.DeserializeObject<List<DoctorSchedule>>(responseBodyGetUsers);

                    // 获取当前日期和时间的DateTime对象  
                    DateTime now = DateTime.Now;

                    List<DoctorScheduleApppointmentDTO> doctorScheduleApppointmentDTOs = new List<DoctorScheduleApppointmentDTO>();
                    foreach (var s in DoctorSchedules.Where(t => t.DoctorID == selectDoctorID && t.IsActive == "1" && !ScheduleID.Contains(t.ScheduleID) && t.ScheduleDate >= new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)))
                    {
                        doctorScheduleApppointmentDTOs.Add(new DoctorScheduleApppointmentDTO
                        {
                            DoctorID = selectDoctorID,
                            ScheduleDate = s.ScheduleDate,
                            ScheduleID = s.ScheduleID,
                            EndTime = s.EndTime,
                            StartTime = s.StartTime,
                            MaxAppointmentCount = s.MaxAppointmentCount,
                        });
                    }
                    dataGridView2.DataSource = doctorScheduleApppointmentDTOs;
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
            dataGridView2.ClearSelection();
        }

        private async void FrmAppointment_Load(object sender, EventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBoxName.Text = FrmLogin.OperatorName;
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetUsers = "http://localhost:5250/api/User/GetUsers";
            // 创建一个 HttpClient 实例
            List<UserInfo> users = new List<UserInfo>();
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

                    List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();
                    foreach (var s in users.Where(t => t.RoleID == "2"))
                    {
                        doctorDTOs.Add(new DoctorDTO { name = s.Name, ID = s.UserID });
                    }
                    dataGridView1.DataSource = doctorDTOs;
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
        int selectDoctorID;
        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_SelectionChanged(sender, e);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int ScheduleID = 0;
            int DoctorID = 0;
            DateTime AppointmentDate = DateTime.Now;
            TimeSpan AppointmentTime = new TimeSpan(8, 0, 0);


            foreach (DataGridViewRow r in dataGridView2.SelectedRows)
            {
                ScheduleID = Convert.ToInt32(r.Cells["ScheduleID"].Value);
                DoctorID = Convert.ToInt32(r.Cells["DoctorID"].Value);
                AppointmentDate = (DateTime)r.Cells["ScheduleDate"].Value;
            }
            DoctorAppointment doctorSchedule = new DoctorAppointment
            {
                PatientID = FrmLogin.OperatorID,


                ScheduleID = ScheduleID,

                DoctorID = DoctorID,

                AppointmentDate = AppointmentDate,

                AppointmentTime = AppointmentTime,

                Status = "待确认",

                Notes = "",

                CreateOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                UpdaterOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                IsActive = "1",
                CreateTime = DateTime.Now,
                UpdaterTime = DateTime.Now,

            };


            string apiUrl = "http://localhost:5250/api/User/SetDoctorAppointments"; // 替换为您的API地址
                                                                                    // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(doctorSchedule);

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
                    MessageBox.Show("预约成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    label3.Text = AppointmentDate.ToString("yyyy-MM-dd") + "预约成功";
                }
            }
            dataGridView1_SelectionChanged(sender, e);
        }
    }
    public class DoctorScheduleApppointmentDTO
    {
        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxAppointmentCount { get; set; }

    }
}
