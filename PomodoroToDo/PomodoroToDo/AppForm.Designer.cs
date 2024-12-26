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
            tmrGetCurrentMode = new System.Windows.Forms.Timer(components);
            lblCurrentMode = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            webViewToDo = new Microsoft.Web.WebView2.WinForms.WebView2();
            contextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewToDo).BeginInit();
            SuspendLayout();
            // 
            // webViewPomodoroTracker
            // 
            webViewPomodoroTracker.AllowExternalDrop = true;
            webViewPomodoroTracker.CreationProperties = null;
            webViewPomodoroTracker.DefaultBackgroundColor = Color.White;
            webViewPomodoroTracker.Dock = DockStyle.Fill;
            webViewPomodoroTracker.Location = new Point(3, 3);
            webViewPomodoroTracker.Margin = new Padding(0);
            webViewPomodoroTracker.Name = "webViewPomodoroTracker";
            webViewPomodoroTracker.Size = new Size(660, 200);
            webViewPomodoroTracker.Source = new Uri("https://pomodoro-tracker.com/", UriKind.Absolute);
            webViewPomodoroTracker.TabIndex = 0;
            webViewPomodoroTracker.ZoomFactor = 0.7D;
            webViewPomodoroTracker.NavigationCompleted += WebViewPomodoroTracker_NavigationCompleted;
            // 
            // tmrGetCurrentMode
            // 
            tmrGetCurrentMode.Enabled = true;
            tmrGetCurrentMode.Interval = 1000;
            tmrGetCurrentMode.Tick += tmrGetCurrentMode_Tick;
            // 
            // lblCurrentMode
            // 
            lblCurrentMode.Dock = DockStyle.Fill;
            lblCurrentMode.Font = new Font("Segoe UI Black", 28F, FontStyle.Bold);
            lblCurrentMode.Location = new Point(0, 0);
            lblCurrentMode.Margin = new Padding(5);
            lblCurrentMode.Name = "lblCurrentMode";
            lblCurrentMode.Size = new Size(666, 64);
            lblCurrentMode.TabIndex = 1;
            lblCurrentMode.Text = "PomodoroToDo";
            lblCurrentMode.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentMode.DoubleClick += lblCurrentMode_DoubleClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 197F));
            tableLayoutPanel1.Size = new Size(672, 561);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCurrentMode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(666, 64);
            panel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(3, 73);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(webViewPomodoroTracker);
            splitContainer1.Panel1.Padding = new Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(webViewToDo);
            splitContainer1.Panel2.Padding = new Padding(3);
            splitContainer1.Size = new Size(666, 485);
            splitContainer1.SplitterDistance = 206;
            splitContainer1.TabIndex = 5;
            // 
            // webViewToDo
            // 
            webViewToDo.AllowExternalDrop = true;
            webViewToDo.CreationProperties = null;
            webViewToDo.DefaultBackgroundColor = Color.White;
            webViewToDo.Dock = DockStyle.Fill;
            webViewToDo.Location = new Point(3, 3);
            webViewToDo.Margin = new Padding(0);
            webViewToDo.Name = "webViewToDo";
            webViewToDo.Size = new Size(660, 269);
            webViewToDo.Source = new Uri("https://to-do.live.com/tasks/lists/myday\r\n", UriKind.Absolute);
            webViewToDo.TabIndex = 4;
            webViewToDo.ZoomFactor = 0.9D;
            webViewToDo.NavigationCompleted += webViewToDo_NavigationCompleted;
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
            ClientSize = new Size(672, 561);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(0, 600);
            Name = "AppForm";
            Text = "PomodoroToDo -by ZizuDEV";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewToDo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewPomodoroTracker;
        private System.Windows.Forms.Timer tmrGetCurrentMode;
        private Label lblCurrentMode;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip contextMenu;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewToDo;
        private SplitContainer splitContainer1;
    }
}
