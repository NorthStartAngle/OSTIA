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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnuOpenFile = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            operatorToolStripMenuItem = new ToolStripMenuItem();
            mnuAssessment = new ToolStripMenuItem();
            mnuGather = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            mnuScale = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, operatorToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuOpenFile, printToolStripMenuItem, toolStripSeparator1, mnuExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // mnuOpenFile
            // 
            mnuOpenFile.Name = "mnuOpenFile";
            mnuOpenFile.Size = new Size(103, 22);
            mnuOpenFile.Text = "Open";
            mnuOpenFile.Click += mnuOpenFile_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(103, 22);
            printToolStripMenuItem.Text = "Print";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(100, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(103, 22);
            mnuExit.Text = "Exit";
            // 
            // operatorToolStripMenuItem
            // 
            operatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAssessment, mnuGather });
            operatorToolStripMenuItem.Name = "operatorToolStripMenuItem";
            operatorToolStripMenuItem.Size = new Size(66, 20);
            operatorToolStripMenuItem.Text = "Operator";
            // 
            // mnuAssessment
            // 
            mnuAssessment.Name = "mnuAssessment";
            mnuAssessment.Size = new Size(137, 22);
            mnuAssessment.Text = "Assesement";
            // 
            // mnuGather
            // 
            mnuGather.Name = "mnuGather";
            mnuGather.Size = new Size(137, 22);
            mnuGather.Text = "Gather";
            mnuGather.Click += mnuGather_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuScale, stopToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // mnuScale
            // 
            mnuScale.Name = "mnuScale";
            mnuScale.Size = new Size(180, 22);
            mnuScale.Text = "Scale";
            mnuScale.Click += mnuScale_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(107, 22);
            mnuAbout.Text = "About";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(180, 22);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 661);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 700);
            Name = "Manager";
            Text = "OSTIA v1.01";
            WindowState = FormWindowState.Maximized;
            FormClosing += Manager_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewExam;
        private Button btnGetData;
        private Button btnLoadFile;
        private Button btnTextualSum;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem operatorToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem mnuOpenFile;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem assesementToolStripMenuItem;
        private ToolStripMenuItem mnuGather;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuAssessment;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuAbout;
        private ToolStripMenuItem mnuScale;
        private ToolStripMenuItem stopToolStripMenuItem;
    }
}