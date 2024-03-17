using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalInformationSystemFrom
{
    public partial class FrmWorkBench : Form
    {
        public FrmWorkBench()
        {
            InitializeComponent();
        }
        public string RoleID = "";
        public UserInfo UserInfo = new UserInfo();
        public Login login = new Login();

        private void FrmWorkBench_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = FrmLogin.OperatorName;
            switch (RoleID)
            {
                case "0":
                    门诊医生站ToolStripMenuItem.Visible = true;
                    患者病历查询ToolStripMenuItem.Visible = true;
                    系统管理ToolStripMenuItem.Visible = true;
                    预约管理ToolStripMenuItem.Visible = true;
                    break;
                case "1":
                    系统管理ToolStripMenuItem.Visible = true;
                    预约管理ToolStripMenuItem.Visible = true;
                    break;
                case "2":
                    门诊医生站ToolStripMenuItem.Visible = true;
                    break;
                case "3":
                    患者病历查询ToolStripMenuItem.Visible = true;
                    break;
                case "4":
                    break;
                default:
                    break;
            }
        }

        private void 患者登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegistration frm = new FrmRegistration();
                frm.MdiParent = this;
                frm.WindowState= FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }

        }

        private void 患者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegister frm = new FrmRegister();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }

        private void 病历查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOrderShow frm = new FrmOrderShow();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }

        private void 门诊医生站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOrder frm = new FrmOrder();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }

        private void 就诊预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAppointment frm = new FrmAppointment();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }

        private void 医生排班ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDoctorSchedule frm = new FrmDoctorSchedule();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }

        private void 用户登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUserRegistration frm = new FrmUserRegistration();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch
            {

            }
        }
    }
}
