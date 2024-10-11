namespace Desktop_Pomodoro_Tracker
{
    partial class AppForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            webViewPomodoroTracker = new Microsoft.Web.WebView2.WinForms.WebView2();
            timer1 = new System.Windows.Forms.Timer(components);
            lblCurrentMode = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            webViewToDo = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            contextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewToDo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // webViewPomodoroTracker
            // 
            webViewPomodoroTracker.AllowExternalDrop = true;
            webViewPomodoroTracker.CreationProperties = null;
            webViewPomodoroTracker.DefaultBackgroundColor = Color.White;
            webViewPomodoroTracker.Dock = DockStyle.Fill;
            webViewPomodoroTracker.Location = new Point(0, 70);
            webViewPomodoroTracker.Margin = new Padding(0);
            webViewPomodoroTracker.Name = "webViewPomodoroTracker";
            webViewPomodoroTracker.Size = new Size(392, 197);
            webViewPomodoroTracker.Source = new Uri("https://pomodoro-tracker.com/", UriKind.Absolute);
            webViewPomodoroTracker.TabIndex = 0;
            webViewPomodoroTracker.ZoomFactor = 0.7D;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblCurrentMode
            // 
            lblCurrentMode.Dock = DockStyle.Fill;
            lblCurrentMode.Font = new Font("Segoe UI Black", 28F, FontStyle.Bold);
            lblCurrentMode.Location = new Point(0, 0);
            lblCurrentMode.Margin = new Padding(5);
            lblCurrentMode.Name = "lblCurrentMode";
            lblCurrentMode.Size = new Size(386, 64);
            lblCurrentMode.TabIndex = 1;
            lblCurrentMode.Text = "POMODORO";
            lblCurrentMode.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentMode.Click += lblCurrentMode_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(webViewToDo, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(webViewPomodoroTracker, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 197F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(392, 561);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // webViewToDo
            // 
            webViewToDo.AllowExternalDrop = true;
            webViewToDo.CreationProperties = null;
            webViewToDo.DefaultBackgroundColor = Color.White;
            webViewToDo.Dock = DockStyle.Fill;
            webViewToDo.Location = new Point(0, 267);
            webViewToDo.Margin = new Padding(0);
            webViewToDo.Name = "webViewToDo";
            webViewToDo.Size = new Size(392, 294);
            webViewToDo.Source = new Uri("https://to-do.live.com/tasks/AQMkADAwATM3ZmYAZS00MjNhLTZmNWItMDACLTAwCgAuAAADHznh97RuwEaTylqDMZTK3wEAiVSD-def2E_3fkwt9tLmgQACye-BYgAAAA==", UriKind.Absolute);
            webViewToDo.TabIndex = 4;
            webViewToDo.ZoomFactor = 1D;
            webViewToDo.NavigationCompleted += webViewToDo_NavigationCompleted;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCurrentMode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 64);
            panel1.TabIndex = 3;
            // 
            // contextMenu
            // 
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(61, 4);
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 49, 49);
            ClientSize = new Size(392, 561);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(408, 1200);
            MinimumSize = new Size(408, 600);
            Name = "AppForm";
            Text = "PomodoroToDo";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewToDo).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewPomodoroTracker;
        private System.Windows.Forms.Timer timer1;
        private Label lblCurrentMode;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip contextMenu;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewToDo;
    }
}
