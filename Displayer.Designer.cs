namespace OSTIA
{
    partial class Displayer
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            logEditor = new RichTextBox();
            tabPage2 = new TabPage();
            lblTooltip = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            tabControl1.ItemSize = new Size(60, 30);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(797, 545);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(logEditor);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(789, 507);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Log";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // logEditor
            // 
            logEditor.BackColor = Color.Purple;
            logEditor.BorderStyle = BorderStyle.FixedSingle;
            logEditor.DetectUrls = false;
            logEditor.Dock = DockStyle.Fill;
            logEditor.Font = new Font("Segoe UI Emoji", 12F);
            logEditor.ForeColor = Color.Khaki;
            logEditor.Location = new Point(3, 3);
            logEditor.Margin = new Padding(5, 3, 3, 3);
            logEditor.Name = "logEditor";
            logEditor.ReadOnly = true;
            logEditor.Size = new Size(783, 501);
            logEditor.TabIndex = 0;
            logEditor.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DarkGray;
            tabPage2.Controls.Add(lblTooltip);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(789, 507);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Graphics";
            // 
            // lblTooltip
            // 
            lblTooltip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTooltip.AutoSize = true;
            lblTooltip.BackColor = Color.DimGray;
            lblTooltip.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTooltip.ForeColor = Color.White;
            lblTooltip.Location = new Point(178, 225);
            lblTooltip.Name = "lblTooltip";
            lblTooltip.Size = new Size(446, 38);
            lblTooltip.TabIndex = 0;
            lblTooltip.Text = "Please wait while loading done...";
            // 
            // Displayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 545);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Displayer";
            Text = "Displayer";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox logEditor;
        private TabPage tabPage2;
        private Label lblTooltip;
    }
}