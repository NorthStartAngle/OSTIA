namespace OSTIA
{
    partial class Manager
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
            btnNewExam = new Button();
            btnGetData = new Button();
            btnLoadFile = new Button();
            btnTextualSum = new Button();
            button5 = new Button();
            button6 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewExam
            // 
            btnNewExam.Location = new Point(23, 23);
            btnNewExam.Name = "btnNewExam";
            btnNewExam.Size = new Size(115, 41);
            btnNewExam.TabIndex = 0;
            btnNewExam.Text = "New Assessment";
            btnNewExam.UseVisualStyleBackColor = true;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(217, 23);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(115, 41);
            btnGetData.TabIndex = 1;
            btnGetData.Text = "Collect Data";
            btnGetData.UseVisualStyleBackColor = true;
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(411, 23);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(115, 41);
            btnLoadFile.TabIndex = 2;
            btnLoadFile.Text = "Display Data";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += GetData;
            // 
            // btnTextualSum
            // 
            btnTextualSum.Location = new Point(605, 23);
            btnTextualSum.Name = "btnTextualSum";
            btnTextualSum.Size = new Size(115, 41);
            btnTextualSum.TabIndex = 3;
            btnTextualSum.Text = "Print Data";
            btnTextualSum.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(799, 23);
            button5.Name = "button5";
            button5.Size = new Size(115, 41);
            button5.TabIndex = 4;
            button5.Text = "Others";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(993, 23);
            button6.Name = "button6";
            button6.Size = new Size(94, 41);
            button6.TabIndex = 5;
            button6.Text = "Help";
            button6.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(button6, 6, 0);
            tableLayoutPanel1.Controls.Add(button5, 5, 0);
            tableLayoutPanel1.Controls.Add(btnTextualSum, 4, 0);
            tableLayoutPanel1.Controls.Add(btnLoadFile, 3, 0);
            tableLayoutPanel1.Controls.Add(btnGetData, 2, 0);
            tableLayoutPanel1.Controls.Add(btnNewExam, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 20, 0, 20);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1090, 88);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 661);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(800, 700);
            Name = "Manager";
            Text = "OSTIA v1.01";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewExam;
        private Button btnGetData;
        private Button btnLoadFile;
        private Button btnTextualSum;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel1;
    }
}