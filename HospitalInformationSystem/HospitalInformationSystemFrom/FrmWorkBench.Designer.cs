namespace HospitalInformationSystemFrom
{
    partial class FrmWorkBench
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医生排班ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预约管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门诊医生站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者病历查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.就诊预约ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病历查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.用户登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.预约管理ToolStripMenuItem,
            this.门诊医生站ToolStripMenuItem,
            this.患者病历查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1227, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户登记ToolStripMenuItem,
            this.医生排班ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            this.系统管理ToolStripMenuItem.Visible = false;
            // 
            // 医生排班ToolStripMenuItem
            // 
            this.医生排班ToolStripMenuItem.Name = "医生排班ToolStripMenuItem";
            this.医生排班ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.医生排班ToolStripMenuItem.Text = "医生排班";
            this.医生排班ToolStripMenuItem.Click += new System.EventHandler(this.医生排班ToolStripMenuItem_Click);
            // 
            // 预约管理ToolStripMenuItem
            // 
            this.预约管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.患者登记ToolStripMenuItem,
            this.患者ToolStripMenuItem});
            this.预约管理ToolStripMenuItem.Name = "预约管理ToolStripMenuItem";
            this.预约管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.预约管理ToolStripMenuItem.Text = "预约管理";
            this.预约管理ToolStripMenuItem.Visible = false;
            // 
            // 患者登记ToolStripMenuItem
            // 
            this.患者登记ToolStripMenuItem.Name = "患者登记ToolStripMenuItem";
            this.患者登记ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.患者登记ToolStripMenuItem.Text = "患者信息录入";
            this.患者登记ToolStripMenuItem.Click += new System.EventHandler(this.患者登记ToolStripMenuItem_Click);
            // 
            // 患者ToolStripMenuItem
            // 
            this.患者ToolStripMenuItem.Name = "患者ToolStripMenuItem";
            this.患者ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.患者ToolStripMenuItem.Text = "患者挂号登记";
            this.患者ToolStripMenuItem.Click += new System.EventHandler(this.患者ToolStripMenuItem_Click);
            // 
            // 门诊医生站ToolStripMenuItem
            // 
            this.门诊医生站ToolStripMenuItem.Name = "门诊医生站ToolStripMenuItem";
            this.门诊医生站ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.门诊医生站ToolStripMenuItem.Text = "门诊医生站";
            this.门诊医生站ToolStripMenuItem.Visible = false;
            this.门诊医生站ToolStripMenuItem.Click += new System.EventHandler(this.门诊医生站ToolStripMenuItem_Click);
            // 
            // 患者病历查询ToolStripMenuItem
            // 
            this.患者病历查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.就诊预约ToolStripMenuItem,
            this.病历查看ToolStripMenuItem});
            this.患者病历查询ToolStripMenuItem.Name = "患者病历查询ToolStripMenuItem";
            this.患者病历查询ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.患者病历查询ToolStripMenuItem.Text = "患者工作台";
            this.患者病历查询ToolStripMenuItem.Visible = false;
            // 
            // 就诊预约ToolStripMenuItem
            // 
            this.就诊预约ToolStripMenuItem.Name = "就诊预约ToolStripMenuItem";
            this.就诊预约ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.就诊预约ToolStripMenuItem.Text = "就诊预约";
            this.就诊预约ToolStripMenuItem.Click += new System.EventHandler(this.就诊预约ToolStripMenuItem_Click);
            // 
            // 病历查看ToolStripMenuItem
            // 
            this.病历查看ToolStripMenuItem.Name = "病历查看ToolStripMenuItem";
            this.病历查看ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.病历查看ToolStripMenuItem.Text = "病历查看";
            this.病历查看ToolStripMenuItem.Click += new System.EventHandler(this.病历查看ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1227, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1081, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // 用户登记ToolStripMenuItem
            // 
            this.用户登记ToolStripMenuItem.Name = "用户登记ToolStripMenuItem";
            this.用户登记ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.用户登记ToolStripMenuItem.Text = "用户登记";
            this.用户登记ToolStripMenuItem.Click += new System.EventHandler(this.用户登记ToolStripMenuItem_Click);
            // 
            // FrmWorkBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 656);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmWorkBench";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工作台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmWorkBench_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem 门诊医生站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者病历查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预约管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者登记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医生排班ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 就诊预约ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 病历查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户登记ToolStripMenuItem;
    }
}