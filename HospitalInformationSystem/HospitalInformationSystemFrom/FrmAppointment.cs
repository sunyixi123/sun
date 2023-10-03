using HospitalInformationSystemFrom.PublicClass;
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
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetUsers = "http://localhost:5250/api/User/GetDoctorAppointments";
            // 创建一个 HttpClient 实例
            List<DoctorAppointment> DoctorAppointments = new List<DoctorAppointment>();
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
                    DoctorAppointments = JsonConvert.DeserializeObject<List<DoctorAppointment>>(responseBodyGetUsers);

                    List<DoctorAppointmentDTO> doctorAppointmentDTOs = new List<DoctorAppointmentDTO>();
                    foreach (var s in DoctorAppointments.Where(t => t.DoctorID ==0 ))
                    {
                        doctorAppointmentDTOs.Add(new DoctorAppointmentDTO());
                    }
                    dataGridView2.DataSource = doctorAppointmentDTOs;
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

        private async void FrmAppointment_Load(object sender, EventArgs e)
        {
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

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 创建一个 HttpClient 实例
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetUsers = "http://localhost:5250/api/User/GetDoctorAppointments";
            // 创建一个 HttpClient 实例
            List<DoctorAppointment> DoctorAppointments = new List<DoctorAppointment>();
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
                    DoctorAppointments = JsonConvert.DeserializeObject<List<DoctorAppointment>>(responseBodyGetUsers);

                    List<DoctorAppointmentDTO> doctorAppointmentDTOs = new List<DoctorAppointmentDTO>();
                    foreach (var s in DoctorAppointments.Where(t => t.DoctorID == 0))
                    {
                        doctorAppointmentDTOs.Add(new DoctorAppointmentDTO());
                    }
                    dataGridView2.DataSource = doctorAppointmentDTOs;
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
    }
    public class DoctorAppointmentDTO {
        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxAppointmentCount { get; set; }

    }
}
