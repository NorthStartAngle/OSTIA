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
            panGraph = new Panel();
            lblDrawPanel = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panGraph.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            tabControl1.ItemSize = new Size(60, 30);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1083, 748);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(logEditor);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1075, 710);
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
            logEditor.Font = new Font("Segoe UI Emoji", 18F);
            logEditor.ForeColor = Color.Khaki;
            logEditor.Location = new Point(3, 3);
            logEditor.Margin = new Padding(5, 3, 3, 3);
            logEditor.Name = "logEditor";
            logEditor.ReadOnly = true;
            logEditor.Size = new Size(1069, 704);
            logEditor.TabIndex = 0;
            logEditor.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DarkGray;
            tabPage2.Controls.Add(panGraph);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1075, 710);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Graphics";
            // 
            // panGraph
            // 
            panGraph.AutoScroll = true;
            panGraph.Controls.Add(lblDrawPanel);
            panGraph.Dock = DockStyle.Fill;
            panGraph.Location = new Point(3, 3);
            panGraph.Name = "panGraph";
            panGraph.Size = new Size(1069, 704);
            panGraph.TabIndex = 1;
            // 
            // lblDrawPanel
            // 
            lblDrawPanel.Location = new Point(10, 10);
            lblDrawPanel.Name = "lblDrawPanel";
            lblDrawPanel.Size = new Size(1053, 691);
            lblDrawPanel.TabIndex = 1;
            lblDrawPanel.Text = "lblDrawPanel";
            lblDrawPanel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Displayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 748);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Displayer";
            Text = "Displayer";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panGraph.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox logEditor;
        private TabPage tabPage2;
        private Panel panGraph;
        private Label lblDrawPanel;
    }
}