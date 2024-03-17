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
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        HttpClient httpClient = new HttpClient();
        HttpHelper httpHelper = null;
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            dateTimePickerDOB.Value = DateTime.Now;
            getMedicalVisit(dateTimePickerDOB.Value);
        }

        private async void getMedicalVisit(DateTime dateTime)
        {
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetMedicalVisits = "http://localhost:5250/api/User/GetMedicalVisits";
            // 创建一个 HttpClient 实例
            List<MedicalVisit> MedicalVisits = new List<MedicalVisit>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetMedicalVisits = await httpClient.GetAsync(apiUrlGetMedicalVisits);

                // 检查响应状态码
                if (responseGetMedicalVisits.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyMedicalVisits = await responseGetMedicalVisits.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    MedicalVisits = JsonConvert.DeserializeObject<List<MedicalVisit>>(responseBodyMedicalVisits);
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
            List<MedicalVisitsDTO> MedicalVisitsDTOs = new List<MedicalVisitsDTO>();
            foreach (MedicalVisit s in MedicalVisits.Where(t => t.VisitDate.ToString("yyyy-MM-dd") == dateTime.ToString("yyyy-MM-dd")))
            {

                MedicalVisitsDTOs.Add(new MedicalVisitsDTO
                {
                    UserID = s.PatientID,
                    Name = users.FirstOrDefault(t => t.UserID == s.PatientID)?.Name,
                    VisitID = s.VisitID,
                    MedicalVisitsStatus = s.Status,
                    VisitDate = s.VisitDate,
                });
            }
            dataGridView1.DataSource = MedicalVisitsDTOs;
        }

        private void dateTimePickerDOB_ValueChanged(object sender, EventArgs e)
        {
            getMedicalVisit(dateTimePickerDOB.Value);
        }
        int selectVisitID = 0;
        int PatientID = 0;
        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            httpHelper = new HttpHelper(httpClient);
            string apiUrlGetMedicalVisits = "http://localhost:5250/api/User/GetMedicalVisits";
            // 创建一个 HttpClient 实例
            List<MedicalVisit> MedicalVisits = new List<MedicalVisit>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetMedicalVisits = await httpClient.GetAsync(apiUrlGetMedicalVisits);

                // 检查响应状态码
                if (responseGetMedicalVisits.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyMedicalVisits = await responseGetMedicalVisits.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    MedicalVisits = JsonConvert.DeserializeObject<List<MedicalVisit>>(responseBodyMedicalVisits);
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

            string apiUrlGetMedicalRecords = "http://localhost:5250/api/User/GetMedicalRecords";
            // 创建一个 HttpClient 实例
            List<MedicalRecord> MedicalRecords = new List<MedicalRecord>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetMedicalRecords = await httpClient.GetAsync(apiUrlGetMedicalRecords);

                // 检查响应状态码
                if (responseGetMedicalRecords.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyMedicalVisits = await responseGetMedicalRecords.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    MedicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(responseBodyMedicalVisits);
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

            string apiUrlGetPrescriptions = "http://localhost:5250/api/User/GetPrescriptions";
            // 创建一个 HttpClient 实例
            List<Prescription> Prescriptions = new List<Prescription>();
            try
            {

                // 发送 GET 请求
                HttpResponseMessage responseGetPrescriptions = await httpClient.GetAsync(apiUrlGetPrescriptions);

                // 检查响应状态码
                if (responseGetPrescriptions.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseBodyMedicalVisits = await responseGetPrescriptions.Content.ReadAsStringAsync();
                    // 使用 System.Text.Json 反序列化 JSON 数据
                    Prescriptions = JsonConvert.DeserializeObject<List<Prescription>>(responseBodyMedicalVisits);
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

            string name = "";
            selectVisitID = 0;
            PatientID = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                selectVisitID = (int)row.Cells["VisitID"].Value;
                name = row.Cells["UserName"].Value?.ToString();
                PatientID = (int)row.Cells["UserID"].Value;
            }
            textBoxDiagnosis.Text = MedicalRecords.FirstOrDefault(t => t.VisitID == selectVisitID)?.Diagnosis;
            textBoxName.Text = name;
            richTextBoxTreatmentPlan.Text = MedicalRecords.FirstOrDefault(t => t.VisitID == selectVisitID)?.TreatmentPlan;

            List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();
            foreach (var s in Prescriptions.Where(t => t.VisitID == selectVisitID))
            {
                prescriptionDTOs.Add(new PrescriptionDTO
                {
                    Dosage = s.Dosage,
                    DosagePerUse = s.DosagePerUse,
                    PrescriptionDate = s.PrescriptionDate,
                    Frequency = s.Frequency,
                    Medications = s.Medications,
                    PerUnit = s.PerUnit,
                    Route = s.Route,
                    Unit = s.Unit,

                });
            }
            dataGridView2.DataSource = prescriptionDTOs;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MedicalRecord tempMedicalRecord = new MedicalRecord
            {
                DoctorID = FrmLogin.OperatorID,
                Diagnosis = textBoxDiagnosis.Text,
                PatientID = PatientID,
                TreatmentPlan = richTextBoxTreatmentPlan.Text,
                VisitID = selectVisitID,
                CreateOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                UpdaterOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                IsActive = "1",
                CreateTime = DateTime.Now,
                UpdaterTime = DateTime.Now,
            };

            string apiUrl = "http://localhost:5250/api/User/SetMedicalRecord"; // 替换为您的API地址
                                                                               // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(tempMedicalRecord);

            Task<string> responseMedicalRecord = httpHelper.SendPostRequestAsync(apiUrl, json);
            // 使用 await 等待异步任务完成，并获取其结果
            string setResult = await responseMedicalRecord;
            returnMessage re = JsonConvert.DeserializeObject<returnMessage>(setResult);
            if (re != null)
            {
                if (re.isSucceed != true)
                {
                    MessageBox.Show(re.errorManger, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("添加病历成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Prescription tempPrescription = new Prescription
            {
                DoctorID = FrmLogin.OperatorID,
                PatientID = PatientID,
                VisitID = selectVisitID,
                Dosage = numericUpDownDosage.Value,
                DosagePerUse = comboBoxDosagePerUse.SelectedIndex.ToString(),
                Frequency = comboBoxFrequency.Text,
                Medications = textBoxMedications.Text,
                PrescriptionDate = DateTime.Now,
                PerUnit = numericUpDownPerUnit.Value,
                Route = comboBoxRoute.Text,
                Unit = comboBoxUnit.Text,
                Notes = string.Empty,
                CreateOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                UpdaterOperator = FrmLogin.OperatorName == "" ? "管理员" : FrmLogin.OperatorName,
                IsActive = "1",
                CreateTime = DateTime.Now,
                UpdaterTime = DateTime.Now,
            };

            string apiUrl = "http://localhost:5250/api/User/SetPrescription"; // 替换为您的API地址
                                                                              // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(tempPrescription);

            Task<string> responsePrescription = httpHelper.SendPostRequestAsync(apiUrl, json);
            // 使用 await 等待异步任务完成，并获取其结果
            string setResult = await responsePrescription;
            returnMessage re = JsonConvert.DeserializeObject<returnMessage>(setResult);
            if (re != null)
            {
                if (re.isSucceed != true)
                {
                    MessageBox.Show(re.errorManger, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("添加病历成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            button3_Click(sender, e);
            dataGridView1_SelectionChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxMedications.Text = string.Empty;
            comboBoxFrequency.SelectedIndex = -1;
            comboBoxRoute.SelectedIndex = -1;
            numericUpDownDosage.Value = 0;
            comboBoxUnit.SelectedIndex = -1;
            numericUpDownPerUnit.Value = 0;
            comboBoxDosagePerUse.SelectedIndex = -1;

        }
    }

    public class MedicalVisitsDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int VisitID { get; set; }
        public string MedicalVisitsStatus { get; set; }
        public DateTime VisitDate { get; set; }
    }

    public class PrescriptionDTO
    {
        public DateTime PrescriptionDate { get; set; }

        public string Frequency { get; set; }

        public string Route { get; set; }

        public string Medications { get; set; }

        public decimal? Dosage { get; set; }

        public string Unit { get; set; }

        public decimal? PerUnit { get; set; }

        public string DosagePerUse { get; set; }
    }
}
