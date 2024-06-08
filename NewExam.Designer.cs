namespace OSTIA
{
    partial class NewExam
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
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label label6;
            Label label7;
            Label label8;
            Label label9;
            Label label10;
            Label label11;
            Label label12;
            Label label13;
            Label label14;
            txtWCB = new TextBox();
            txtCASENUMBER = new TextBox();
            txtASSESSER = new TextBox();
            txtPersonS = new TextBox();
            txtPersonF = new TextBox();
            dtPersionB = new DateTimePicker();
            txtBodyPart = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            dtCurrentTime = new DateTimePicker();
            btnApply = new Button();
            dtSession = new DateTimePicker();
            txtInjComplaint = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Symbol", 12F);
            label1.Location = new Point(13, 20);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 10, 0, 10);
            label1.Size = new Size(156, 52);
            label1.TabIndex = 2;
            label1.Text = "WSIB / WCB #:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Symbol", 12F);
            label2.Location = new Point(358, 20);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 10, 0, 10);
            label2.Size = new Size(156, 52);
            label2.TabIndex = 9;
            label2.Text = "Case Number:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Symbol", 12F);
            label3.Location = new Point(703, 20);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 10, 0, 10);
            label3.Size = new Size(156, 52);
            label3.TabIndex = 11;
            label3.Text = "Assessor:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Symbol", 12F);
            label4.Location = new Point(358, 72);
            label4.Name = "label4";
            label4.Size = new Size(156, 52);
            label4.TabIndex = 15;
            label4.Text = "Patient's Surname:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Symbol", 12F);
            label5.Location = new Point(13, 72);
            label5.Name = "label5";
            label5.Size = new Size(156, 52);
            label5.TabIndex = 13;
            label5.Text = "Patient's First Name:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI Symbol", 12F);
            label6.Location = new Point(703, 72);
            label6.Name = "label6";
            label6.Size = new Size(156, 52);
            label6.TabIndex = 17;
            label6.Text = "Patient's Date of Birth:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI Symbol", 12F);
            label7.Location = new Point(13, 124);
            label7.Name = "label7";
            label7.Size = new Size(156, 52);
            label7.TabIndex = 19;
            label7.Text = "Date of This Exam:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI Symbol", 12F);
            label8.Location = new Point(520, 124);
            label8.Name = "label8";
            label8.Size = new Size(177, 52);
            label8.TabIndex = 21;
            label8.Text = "Current Time:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI Symbol", 12F);
            label9.Location = new Point(13, 228);
            label9.Name = "label9";
            label9.Size = new Size(156, 52);
            label9.TabIndex = 23;
            label9.Text = "Injury Complaint:";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI Symbol", 12F);
            label10.Location = new Point(520, 228);
            label10.Name = "label10";
            label10.Size = new Size(177, 52);
            label10.TabIndex = 25;
            label10.Text = "Soft Tissue Assessed:";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI Symbol", 12F);
            label11.Location = new Point(13, 436);
            label11.Name = "label11";
            label11.Size = new Size(156, 52);
            label11.TabIndex = 31;
            label11.Text = "SampleRate:";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI Symbol", 12F);
            label12.Location = new Point(358, 436);
            label12.Name = "label12";
            label12.Size = new Size(156, 52);
            label12.TabIndex = 33;
            label12.Text = "SampFreq:";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI Symbol", 12F);
            label13.Location = new Point(13, 488);
            label13.Name = "label13";
            label13.Size = new Size(156, 53);
            label13.TabIndex = 35;
            label13.Text = "SampDuty:";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI Symbol", 12F);
            label14.Location = new Point(358, 488);
            label14.Name = "label14";
            label14.Size = new Size(156, 53);
            label14.TabIndex = 36;
            label14.Text = "SampBand:";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtWCB
            // 
            txtWCB.Dock = DockStyle.Fill;
            txtWCB.Font = new Font("Segoe UI", 12F);
            txtWCB.Location = new Point(175, 30);
            txtWCB.Margin = new Padding(3, 10, 3, 3);
            txtWCB.MaxLength = 20;
            txtWCB.Name = "txtWCB";
            txtWCB.Size = new Size(177, 29);
            txtWCB.TabIndex = 8;
            // 
            // txtCASENUMBER
            // 
            txtCASENUMBER.Dock = DockStyle.Fill;
            txtCASENUMBER.Font = new Font("Segoe UI", 12F);
            txtCASENUMBER.Location = new Point(520, 30);
            txtCASENUMBER.Margin = new Padding(3, 10, 3, 3);
            txtCASENUMBER.MaxLength = 20;
            txtCASENUMBER.Name = "txtCASENUMBER";
            txtCASENUMBER.Size = new Size(177, 29);
            txtCASENUMBER.TabIndex = 10;
            // 
            // txtASSESSER
            // 
            txtASSESSER.Dock = DockStyle.Fill;
            txtASSESSER.Font = new Font("Segoe UI", 12F);
            txtASSESSER.Location = new Point(865, 30);
            txtASSESSER.Margin = new Padding(3, 10, 3, 3);
            txtASSESSER.MaxLength = 20;
            txtASSESSER.Name = "txtASSESSER";
            txtASSESSER.Size = new Size(180, 29);
            txtASSESSER.TabIndex = 12;
            // 
            // txtPersonS
            // 
            txtPersonS.Dock = DockStyle.Fill;
            txtPersonS.Font = new Font("Segoe UI", 12F);
            txtPersonS.Location = new Point(520, 82);
            txtPersonS.Margin = new Padding(3, 10, 3, 3);
            txtPersonS.MaxLength = 20;
            txtPersonS.Name = "txtPersonS";
            txtPersonS.Size = new Size(177, 29);
            txtPersonS.TabIndex = 16;
            // 
            // txtPersonF
            // 
            txtPersonF.Dock = DockStyle.Fill;
            txtPersonF.Font = new Font("Segoe UI", 12F);
            txtPersonF.Location = new Point(175, 82);
            txtPersonF.Margin = new Padding(3, 10, 3, 3);
            txtPersonF.MaxLength = 20;
            txtPersonF.Name = "txtPersonF";
            txtPersonF.Size = new Size(177, 29);
            txtPersonF.TabIndex = 14;
            // 
            // dtPersionB
            // 
            dtPersionB.CustomFormat = "yyyy-MM-dd";
            dtPersionB.Font = new Font("Segoe UI", 12F);
            dtPersionB.Format = DateTimePickerFormat.Custom;
            dtPersionB.Location = new Point(865, 82);
            dtPersionB.Margin = new Padding(3, 10, 3, 3);
            dtPersionB.Name = "dtPersionB";
            dtPersionB.Size = new Size(180, 29);
            dtPersionB.TabIndex = 18;
            // 
            // txtBodyPart
            // 
            tableLayoutPanel1.SetColumnSpan(txtBodyPart, 2);
            txtBodyPart.Dock = DockStyle.Fill;
            txtBodyPart.Font = new Font("Segoe UI", 12F);
            txtBodyPart.Location = new Point(703, 231);
            txtBodyPart.MaxLength = 20;
            txtBodyPart.Multiline = true;
            txtBodyPart.Name = "txtBodyPart";
            tableLayoutPanel1.SetRowSpan(txtBodyPart, 3);
            txtBodyPart.Size = new Size(342, 150);
            txtBodyPart.TabIndex = 26;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.6668692F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.6664639F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.6668653F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.6664639F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.6668653F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.6664639F));
            tableLayoutPanel1.Controls.Add(comboBox4, 3, 9);
            tableLayoutPanel1.Controls.Add(comboBox3, 1, 9);
            tableLayoutPanel1.Controls.Add(label14, 2, 9);
            tableLayoutPanel1.Controls.Add(label13, 0, 9);
            tableLayoutPanel1.Controls.Add(comboBox2, 3, 8);
            tableLayoutPanel1.Controls.Add(label12, 2, 8);
            tableLayoutPanel1.Controls.Add(label11, 0, 8);
            tableLayoutPanel1.Controls.Add(dtCurrentTime, 4, 2);
            tableLayoutPanel1.Controls.Add(txtWCB, 1, 0);
            tableLayoutPanel1.Controls.Add(label10, 3, 4);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Controls.Add(txtCASENUMBER, 3, 0);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 4, 0);
            tableLayoutPanel1.Controls.Add(txtASSESSER, 5, 0);
            tableLayoutPanel1.Controls.Add(label8, 3, 2);
            tableLayoutPanel1.Controls.Add(dtPersionB, 5, 1);
            tableLayoutPanel1.Controls.Add(label6, 4, 1);
            tableLayoutPanel1.Controls.Add(label7, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPersonS, 3, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(txtPersonF, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 1);
            tableLayoutPanel1.Controls.Add(txtBodyPart, 4, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnApply, 5, 9);
            tableLayoutPanel1.Controls.Add(dtSession, 1, 2);
            tableLayoutPanel1.Controls.Add(txtInjComplaint, 1, 4);
            tableLayoutPanel1.Controls.Add(comboBox1, 1, 8);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 20, 10, 20);
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1058, 561);
            tableLayoutPanel1.TabIndex = 27;
            // 
            // comboBox4
            // 
            comboBox4.Dock = DockStyle.Fill;
            comboBox4.Font = new Font("Segoe UI", 12F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "1", "3" });
            comboBox4.Location = new Point(520, 498);
            comboBox4.Margin = new Padding(3, 10, 3, 3);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(177, 29);
            comboBox4.TabIndex = 38;
            // 
            // comboBox3
            // 
            comboBox3.Dock = DockStyle.Fill;
            comboBox3.Font = new Font("Segoe UI", 12F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" });
            comboBox3.Location = new Point(175, 498);
            comboBox3.Margin = new Padding(3, 10, 3, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(177, 29);
            comboBox3.TabIndex = 37;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.Font = new Font("Segoe UI", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Contin.", "10 PPS", "100 PPS" });
            comboBox2.Location = new Point(520, 446);
            comboBox2.Margin = new Padding(3, 10, 3, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(177, 29);
            comboBox2.TabIndex = 34;
            // 
            // dtCurrentTime
            // 
            dtCurrentTime.CalendarFont = new Font("Segoe UI", 12F);
            dtCurrentTime.CustomFormat = "yyyy-MM-dd";
            dtCurrentTime.Dock = DockStyle.Fill;
            dtCurrentTime.Font = new Font("Segoe UI", 12F);
            dtCurrentTime.Format = DateTimePickerFormat.Time;
            dtCurrentTime.Location = new Point(703, 134);
            dtCurrentTime.Margin = new Padding(3, 10, 3, 3);
            dtCurrentTime.Name = "dtCurrentTime";
            dtCurrentTime.Size = new Size(156, 29);
            dtCurrentTime.TabIndex = 29;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApply.FlatAppearance.BorderSize = 2;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnApply.Location = new Point(908, 496);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(137, 42);
            btnApply.TabIndex = 27;
            btnApply.Text = "Appy";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // dtSession
            // 
            dtSession.CalendarFont = new Font("Segoe UI", 12F);
            dtSession.CustomFormat = "yyyy-MM-dd";
            dtSession.Dock = DockStyle.Fill;
            dtSession.Font = new Font("Segoe UI", 12F);
            dtSession.Format = DateTimePickerFormat.Custom;
            dtSession.Location = new Point(175, 134);
            dtSession.Margin = new Padding(3, 10, 3, 3);
            dtSession.Name = "dtSession";
            dtSession.Size = new Size(177, 29);
            dtSession.TabIndex = 28;
            // 
            // txtInjComplaint
            // 
            tableLayoutPanel1.SetColumnSpan(txtInjComplaint, 2);
            txtInjComplaint.Dock = DockStyle.Fill;
            txtInjComplaint.Font = new Font("Segoe UI", 12F);
            txtInjComplaint.Location = new Point(175, 231);
            txtInjComplaint.Multiline = true;
            txtInjComplaint.Name = "txtInjComplaint";
            tableLayoutPanel1.SetRowSpan(txtInjComplaint, 3);
            txtInjComplaint.Size = new Size(339, 150);
            txtInjComplaint.TabIndex = 30;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0.25", "0.5", "1.0", "2.0", "Other" });
            comboBox1.Location = new Point(175, 446);
            comboBox1.Margin = new Padding(3, 10, 3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(177, 29);
            comboBox1.TabIndex = 32;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // NewExam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 561);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(1074, 600);
            MinimizeBox = false;
            MinimumSize = new Size(1074, 600);
            Name = "NewExam";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewExam";
            TopMost = true;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtWCB;
        private TextBox txtCASENUMBER;
        private TextBox txtASSESSER;
        private TextBox txtPersonS;
        private TextBox txtPersonF;
        private DateTimePicker dtPersionB;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox7;
        private TextBox txtBodyPart;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnApply;
        private DateTimePicker dtSession;
        private DateTimePicker dtCurrentTime;
        private TextBox txtInjComplaint;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
    }
}