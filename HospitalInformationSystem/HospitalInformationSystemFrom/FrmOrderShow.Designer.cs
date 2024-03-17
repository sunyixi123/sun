namespace HospitalInformationSystemFrom
{
    partial class FrmOrderShow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMedications = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PrescriptionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DosagePerUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.comboBoxFrequency = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxTreatmentPlan = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDiagnosis = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDosagePerUse = new System.Windows.Forms.ComboBox();
            this.numericUpDownPerUnit = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDosage = new System.Windows.Forms.NumericUpDown();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDosage)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxName.Location = new System.Drawing.Point(91, 39);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(200, 28);
            this.textBoxName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "姓名：";
            // 
            // textBoxMedications
            // 
            this.textBoxMedications.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMedications.Location = new System.Drawing.Point(92, 288);
            this.textBoxMedications.MaxLength = 11;
            this.textBoxMedications.Name = "textBoxMedications";
            this.textBoxMedications.Size = new System.Drawing.Size(207, 28);
            this.textBoxMedications.TabIndex = 16;
            this.textBoxMedications.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(7, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "药品信息：";
            this.label5.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(806, 345);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 29);
            this.button3.TabIndex = 13;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(686, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "添加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrescriptionDate,
            this.Medications,
            this.Frequency,
            this.Route,
            this.DoctorID,
            this.Unit,
            this.PerUnit,
            this.DosagePerUse,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 271);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 100;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(898, 397);
            this.dataGridView2.TabIndex = 0;
            // 
            // PrescriptionDate
            // 
            this.PrescriptionDate.DataPropertyName = "PrescriptionDate";
            this.PrescriptionDate.HeaderText = "日期";
            this.PrescriptionDate.Name = "PrescriptionDate";
            this.PrescriptionDate.ReadOnly = true;
            this.PrescriptionDate.Width = 120;
            // 
            // Medications
            // 
            this.Medications.DataPropertyName = "Medications";
            this.Medications.HeaderText = "药品信息";
            this.Medications.Name = "Medications";
            this.Medications.ReadOnly = true;
            this.Medications.Width = 200;
            // 
            // Frequency
            // 
            this.Frequency.DataPropertyName = "Frequency";
            this.Frequency.HeaderText = "频次";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Width = 120;
            // 
            // Route
            // 
            this.Route.DataPropertyName = "Route";
            this.Route.HeaderText = "用法途径";
            this.Route.Name = "Route";
            this.Route.ReadOnly = true;
            this.Route.Width = 150;
            // 
            // DoctorID
            // 
            this.DoctorID.DataPropertyName = "Dosage";
            this.DoctorID.HeaderText = "用药剂量";
            this.DoctorID.Name = "DoctorID";
            this.DoctorID.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "总量单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // PerUnit
            // 
            this.PerUnit.DataPropertyName = "PerUnit";
            this.PerUnit.HeaderText = "每次用药剂量";
            this.PerUnit.Name = "PerUnit";
            this.PerUnit.ReadOnly = true;
            this.PerUnit.Width = 120;
            // 
            // DosagePerUse
            // 
            this.DosagePerUse.DataPropertyName = "DosagePerUse";
            this.DosagePerUse.HeaderText = "每次用药单位";
            this.DosagePerUse.Name = "DosagePerUse";
            this.DosagePerUse.ReadOnly = true;
            this.DosagePerUse.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "PrescriptionID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 668);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(273, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(898, 668);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxRoute);
            this.panel5.Controls.Add(this.comboBoxFrequency);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.richTextBoxTreatmentPlan);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.textBoxDiagnosis);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.comboBoxDosagePerUse);
            this.panel5.Controls.Add(this.numericUpDownPerUnit);
            this.panel5.Controls.Add(this.numericUpDownDosage);
            this.panel5.Controls.Add(this.comboBoxUnit);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.textBoxName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.textBoxMedications);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(898, 271);
            this.panel5.TabIndex = 20;
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.AccessibleName = "Route";
            this.comboBoxRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoute.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Items.AddRange(new object[] {
            "口服",
            "肌注",
            "静滴"});
            this.comboBoxRoute.Location = new System.Drawing.Point(686, 288);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(123, 28);
            this.comboBoxRoute.TabIndex = 39;
            this.comboBoxRoute.Visible = false;
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.AccessibleName = "Route";
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Items.AddRange(new object[] {
            "每日一次",
            "每日二次",
            "每日三次"});
            this.comboBoxFrequency.Location = new System.Drawing.Point(372, 288);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(223, 28);
            this.comboBoxFrequency.TabIndex = 38;
            this.comboBoxFrequency.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(691, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 80);
            this.button1.TabIndex = 37;
            this.button1.Text = "添加病历";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxTreatmentPlan
            // 
            this.richTextBoxTreatmentPlan.Location = new System.Drawing.Point(91, 100);
            this.richTextBoxTreatmentPlan.Name = "richTextBoxTreatmentPlan";
            this.richTextBoxTreatmentPlan.Size = new System.Drawing.Size(587, 161);
            this.richTextBoxTreatmentPlan.TabIndex = 36;
            this.richTextBoxTreatmentPlan.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(8, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "病历：";
            // 
            // textBoxDiagnosis
            // 
            this.textBoxDiagnosis.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxDiagnosis.Location = new System.Drawing.Point(494, 39);
            this.textBoxDiagnosis.Name = "textBoxDiagnosis";
            this.textBoxDiagnosis.Size = new System.Drawing.Size(184, 28);
            this.textBoxDiagnosis.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(419, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "诊断：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(492, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "每次用药单位：";
            this.label9.Visible = false;
            // 
            // comboBoxDosagePerUse
            // 
            this.comboBoxDosagePerUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDosagePerUse.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDosagePerUse.FormattingEnabled = true;
            this.comboBoxDosagePerUse.Items.AddRange(new object[] {
            "片",
            "毫升"});
            this.comboBoxDosagePerUse.Location = new System.Drawing.Point(605, 344);
            this.comboBoxDosagePerUse.Name = "comboBoxDosagePerUse";
            this.comboBoxDosagePerUse.Size = new System.Drawing.Size(58, 28);
            this.comboBoxDosagePerUse.TabIndex = 31;
            this.comboBoxDosagePerUse.Visible = false;
            // 
            // numericUpDownPerUnit
            // 
            this.numericUpDownPerUnit.Font = new System.Drawing.Font("思源宋体 CN SemiBold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownPerUnit.Location = new System.Drawing.Point(425, 344);
            this.numericUpDownPerUnit.Name = "numericUpDownPerUnit";
            this.numericUpDownPerUnit.Size = new System.Drawing.Size(54, 28);
            this.numericUpDownPerUnit.TabIndex = 30;
            this.numericUpDownPerUnit.Visible = false;
            // 
            // numericUpDownDosage
            // 
            this.numericUpDownDosage.Font = new System.Drawing.Font("思源宋体 CN SemiBold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownDosage.Location = new System.Drawing.Point(96, 345);
            this.numericUpDownDosage.Name = "numericUpDownDosage";
            this.numericUpDownDosage.Size = new System.Drawing.Size(54, 28);
            this.numericUpDownDosage.TabIndex = 29;
            this.numericUpDownDosage.Visible = false;
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnit.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "瓶",
            "盒",
            "片"});
            this.comboBoxUnit.Location = new System.Drawing.Point(241, 345);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(58, 28);
            this.comboBoxUnit.TabIndex = 28;
            this.comboBoxUnit.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(315, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "每次用药剂量：";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(156, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "总量单位：";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(10, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "用药剂量：";
            this.label8.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(601, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "用法途径：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(315, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "频次：";
            this.label2.Visible = false;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.CalendarFont = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePickerDOB.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePickerDOB.Location = new System.Drawing.Point(60, 36);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new System.Drawing.Size(185, 28);
            this.dateTimePickerDOB.TabIndex = 21;
            this.dateTimePickerDOB.ValueChanged += new System.EventHandler(this.dateTimePickerDOB_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "日期：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 668);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.dateTimePickerDOB);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 668);
            this.panel3.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("思源宋体 CN", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(60, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 80);
            this.button4.TabIndex = 40;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FrmOrderShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 668);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOrderShow";
            this.Text = "医嘱开立";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDosage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMedications;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDOB;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDosagePerUse;
        private System.Windows.Forms.NumericUpDown numericUpDownPerUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownDosage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxTreatmentPlan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDiagnosis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrescriptionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medications;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DosagePerUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
    }
}