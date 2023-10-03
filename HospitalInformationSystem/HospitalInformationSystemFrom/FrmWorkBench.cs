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
            switch (RoleID)
            {
                case "0":
                    门诊医生站ToolStripMenuItem.Visible = true;
                    患者病历查询ToolStripMenuItem.Visible = true;
                    系统管理ToolStripMenuItem.Visible = true;
                    预约管理ToolStripMenuItem.Visible = true;
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
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
    }
}
