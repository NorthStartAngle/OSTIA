namespace OSTIA
{
    partial class Summery
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
            txtThresh = new NumericUpDown();
            txtSecs = new NumericUpDown();
            txtPosReq = new NumericUpDown();
            panel1 = new Panel();
            btnAppy = new Button();
            txtDoc = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtThresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSecs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPosReq).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 12F);
            label1.Location = new Point(7, 15);
            label1.Name = "label1";
            label1.Size = new Size(129, 21);
            label1.TabIndex = 2;
            label1.Text = "Threshold (mW) :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 12F);
            label2.Location = new Point(227, 15);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 4;
            label2.Text = "Time window (sec) :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 12F);
            label3.Location = new Point(464, 15);
            label3.Name = "label3";
            label3.Size = new Size(112, 21);
            label3.TabIndex = 6;
            label3.Text = "% Correlation :";
            // 
            // txtThresh
            // 
            txtThresh.Font = new Font("Segoe UI", 11F);
            txtThresh.Location = new Point(142, 13);
            txtThresh.Name = "txtThresh";
            txtThresh.Size = new Size(79, 27);
            txtThresh.TabIndex = 1;
            txtThresh.TextAlign = HorizontalAlignment.Center;
            // 
            // txtSecs
            // 
            txtSecs.Font = new Font("Segoe UI", 11F);
            txtSecs.Location = new Point(379, 13);
            txtSecs.Name = "txtSecs";
            txtSecs.Size = new Size(79, 27);
            txtSecs.TabIndex = 3;
            txtSecs.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPosReq
            // 
            txtPosReq.Font = new Font("Segoe UI", 11F);
            txtPosReq.Location = new Point(582, 13);
            txtPosReq.Name = "txtPosReq";
            txtPosReq.Size = new Size(79, 27);
            txtPosReq.TabIndex = 5;
            txtPosReq.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(btnAppy);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSecs);
            panel1.Controls.Add(txtThresh);
            panel1.Controls.Add(txtPosReq);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(3000, 50);
            panel1.MinimumSize = new Size(500, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(1042, 50);
            panel1.TabIndex = 1;
            // 
            // btnAppy
            // 
            btnAppy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAppy.Font = new Font("Segoe UI", 12F);
            btnAppy.Location = new Point(933, 8);
            btnAppy.Name = "btnAppy";
            btnAppy.Size = new Size(99, 35);
            btnAppy.TabIndex = 7;
            btnAppy.Text = "Appy";
            btnAppy.UseVisualStyleBackColor = true;
            btnAppy.Click += btnAppy_Click;
            // 
            // txtDoc
            // 
            txtDoc.BorderStyle = BorderStyle.FixedSingle;
            txtDoc.Dock = DockStyle.Fill;
            txtDoc.Location = new Point(0, 50);
            txtDoc.Margin = new Padding(5, 10, 5, 5);
            txtDoc.Name = "txtDoc";
            txtDoc.Size = new Size(1042, 541);
            txtDoc.TabIndex = 2;
            txtDoc.Text = "";
            // 
            // Summery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 591);
            Controls.Add(txtDoc);
            Controls.Add(panel1);
            Name = "Summery";
            Text = "Summery";
            ((System.ComponentModel.ISupportInitialize)txtThresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSecs).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPosReq).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown txtThresh;
        private Label label1;
        private Label label2;
        private NumericUpDown txtSecs;
        private Label label3;
        private NumericUpDown txtPosReq;
        private Panel panel1;
        private Button btnAppy;
        private RichTextBox txtDoc;
    }
}