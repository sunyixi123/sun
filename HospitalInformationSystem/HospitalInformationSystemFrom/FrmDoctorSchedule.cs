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
    public partial class FrmDoctorSchedule : Form
    {
        public FrmDoctorSchedule()
        {
            InitializeComponent();
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        HttpClient httpClient = new HttpClient();
        HttpHelper httpHelper = null;

        private async void FrmDoctorSchedule_LoadAsync(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Now.Year;
            numericUpDown2.Value = DateTime.Now.Month;
            InitializeCalendar(DateTime.Now.Year, DateTime.Now.Month);

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
                    foreach (var s in users.Where(t=>t.RoleID=="2"))
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

        private void InitializeCalendar(int Year, int Month)
        {
            // 创建一个新的DataTable以存储日历数据
            var calendarTable = new System.Data.DataTable();
            calendarTable.Columns.Add("Sunday", typeof(string));
            calendarTable.Columns.Add("Monday", typeof(string));
            calendarTable.Columns.Add("Tuesday", typeof(string));
            calendarTable.Columns.Add("Wednesday", typeof(string));
            calendarTable.Columns.Add("Thursday", typeof(string));
            calendarTable.Columns.Add("Friday", typeof(string));
            calendarTable.Columns.Add("Saturday", typeof(string));

            // 获取当前月份的第一天
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(Year, Month, 1);

            // 获取当前月份的最后一天
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // 创建一个DataRow来表示每一天
            var row = calendarTable.NewRow();

            // 从第一天开始循环，直到最后一天
            for (DateTime day = firstDayOfMonth; day <= lastDayOfMonth; day = day.AddDays(1))
            {
                // 在DataGridView中显示日期
                row[day.DayOfWeek.ToString()] = day.Day.ToString();

                // 如果是星期六，将该行添加到DataTable中并创建新行
                if (day.DayOfWeek == DayOfWeek.Saturday)
                {
                    calendarTable.Rows.Add(row);
                    row = calendarTable.NewRow();
                }
            }

            // 如果最后一行不完整，将其添加到DataTable中
            if (row[0] != DBNull.Value)
            {
                calendarTable.Rows.Add(row);
            }

            // 将DataTable绑定到DataGridView
            dataGridView2.DataSource = calendarTable;

            // 调整DataGridView的列宽，使日历显示更美观
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = 40;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            InitializeCalendar((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            InitializeCalendar((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[0].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[0].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox2.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[1].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[1].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox3.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[2].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[2].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[2].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox4.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[3].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[3].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[3].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox5.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[4].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[4].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[4].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox6.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[5].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[5].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[5].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
            if (checkBox7.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[6].Value?.ToString() != "")
                    {
                        dataGridView2.Rows[i].Cells[6].Tag = Color.Blue;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[6].Tag = Color.White;
                    }
                    dataGridView2.InvalidateRow(i);
                }

            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Tag != null)
                {
                    // 获取单元格的 Tag 值
                    e.CellStyle.BackColor = (Color)cell.Tag;
                    // 在这里使用 tagValue，可以根据需要执行操作
                    // 例如，将 tagValue 转换为特定类型并进行处理
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[0].Tag = Color.White;

                    dataGridView2.InvalidateRow(i);
                }

            }
            if (!checkBox2.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[1].Tag = Color.White;

                    dataGridView2.InvalidateRow(i);
                }

            }
            if (!checkBox3.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[2].Tag = Color.White;

                    dataGridView2.InvalidateRow(i);
                }

            }
            if (!checkBox4.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[3].Tag = Color.White;

                }

            }
            if (!checkBox5.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[4].Tag = Color.White;

                    dataGridView2.InvalidateRow(i);
                }

            }
            if (!checkBox6.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[5].Tag = Color.White;

                }

            }
            if (!checkBox7.Checked)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].Cells[6].Tag = Color.White;

                    dataGridView2.InvalidateRow(i);
                }

            }
        }
        int selectDoctorID ;
        private async void button2_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:5250/api/User/SetDoctorSchedules"; // 替换为您的API地址

            List<DoctorSchedule> DoctorSchedules = new List<DoctorSchedule>();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                DoctorSchedule doctorSchedule = new DoctorSchedule();
                for (int j = 0; j < dataGridView2.Rows[i].Cells.Count; j++)
                {
                    
                    if(dataGridView2.Rows[i].Cells[j].Tag!=null&&(Color)dataGridView2.Rows[i].Cells[j].Tag == Color.Blue)
                    {
                        doctorSchedule.ScheduleDate = DateTime.Parse(numericUpDown1.Value.ToString() + "-" + numericUpDown2.Value.ToString() + "-" + dataGridView2.Rows[i].Cells[j].Value.ToString());
                        doctorSchedule.DoctorID = selectDoctorID;
                        doctorSchedule.CreateTime = DateTime.Now;
                        doctorSchedule.CreateOperator = FrmLogin.OperatorName;
                        doctorSchedule.UpdaterOperator = FrmLogin.OperatorName;
                        doctorSchedule.StartTime = TimeSpan.Zero;
                        doctorSchedule.EndTime = TimeSpan.Zero;
                        doctorSchedule.IsActive = "1";
                        doctorSchedule.MaxAppointmentCount = (int)numericUpDown3.Value;
                    }
                    else
                    {
                        doctorSchedule.ScheduleDate = DateTime.Parse(numericUpDown1.Value.ToString() + "-" + numericUpDown2.Value.ToString() + "-" + dataGridView2.Rows[i].Cells[j].Value.ToString());
                        doctorSchedule.DoctorID = selectDoctorID;
                        doctorSchedule.CreateTime = DateTime.Now;
                        doctorSchedule.CreateOperator = FrmLogin.OperatorName;
                        doctorSchedule.UpdaterOperator = FrmLogin.OperatorName;
                        doctorSchedule.StartTime = TimeSpan.Zero;
                        doctorSchedule.EndTime = TimeSpan.Zero;
                        doctorSchedule.IsActive = "0";
                        doctorSchedule.MaxAppointmentCount = (int)numericUpDown3.Value;
                    }
                    DoctorSchedules.Add(doctorSchedule);
                }
                
            }
            
            // 将 Person 对象序列化为 JSON 字符串
            string json = JsonConvert.SerializeObject(DoctorSchedules);
            if (DoctorSchedules == null)
            {
                return;
            }
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
                    MessageBox.Show("排班成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
    public class DoctorDTO
    {
        public string name { get; set; }
        public int ID { get; set; }
    }
}
