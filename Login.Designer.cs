namespace OSTIA
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Mark = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblStatus = new Label();
            panel1 = new Panel();
            btnConfirm = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label7 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Mark
            // 
            lbl_Mark.AutoEllipsis = true;
            lbl_Mark.BackColor = Color.Transparent;
            lbl_Mark.Font = new Font("Verdana", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Mark.ForeColor = Color.Cornsilk;
            lbl_Mark.Location = new Point(202, 20);
            lbl_Mark.Name = "lbl_Mark";
            lbl_Mark.Size = new Size(222, 87);
            lbl_Mark.TabIndex = 0;
            lbl_Mark.Text = "OSTIA";
            lbl_Mark.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gill Sans MT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FloralWhite;
            label1.Location = new Point(51, 144);
            label1.Name = "label1";
            label1.Size = new Size(514, 40);
            label1.TabIndex = 1;
            label1.Text = "Objective Injury Assessment System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gill Sans MT", 19.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.GradientActiveCaption;
            label2.Location = new Point(136, 237);
            label2.Name = "label2";
            label2.Size = new Size(327, 38);
            label2.TabIndex = 2;
            label2.Text = "Revision 1.0a1  Feb 2024";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans MT", 17.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.GradientActiveCaption;
            label3.Location = new Point(173, 321);
            label3.Name = "label3";
            label3.Size = new Size(262, 34);
            label3.TabIndex = 3;
            label3.Text = "Copyright 1994 - 2024";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Gill Sans MT", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkTurquoise;
            label4.Location = new Point(224, 395);
            label4.Name = "label4";
            label4.Size = new Size(173, 29);
            label4.TabIndex = 4;
            label4.Text = "All Rights Reserved";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.DarkOrange;
            lblStatus.Location = new Point(12, 439);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(630, 32);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Loading ...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(btnConfirm);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(648, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(445, 507);
            panel1.TabIndex = 6;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(270, 383);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(111, 45);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Conform";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtPassword
            // 
            txtPassword.AcceptsReturn = true;
            txtPassword.BackColor = SystemColors.Info;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(213, 217);
            txtPassword.MaxLength = 20;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(168, 30);
            txtPassword.TabIndex = 3;
            txtPassword.Text = "123";
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.AcceptsReturn = true;
            txtUsername.BackColor = SystemColors.Info;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(213, 137);
            txtUsername.MaxLength = 20;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(168, 30);
            txtUsername.TabIndex = 2;
            txtUsername.Text = "admin";
            txtUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Leelawadee", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Image = Resource1._lock;
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(67, 217);
            label7.Name = "label7";
            label7.Size = new Size(125, 23);
            label7.TabIndex = 1;
            label7.Text = "Password  ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Leelawadee", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Image = Resource1.user;
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(67, 141);
            label6.Name = "label6";
            label6.Size = new Size(125, 23);
            label6.TabIndex = 0;
            label6.Text = "User Name";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(1091, 491);
            Controls.Add(panel1);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbl_Mark);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome to you in OSTIA!";
            FormClosing += Login_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Mark;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblStatus;
        private Panel panel1;
        private Label label6;
        private Label label7;
        private Button btnConfirm;
        private TextBox txtPassword;
        private TextBox txtUsername;
    }
}
