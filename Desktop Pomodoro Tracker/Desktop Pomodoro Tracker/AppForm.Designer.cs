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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            webViewPomodoroTracker = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).BeginInit();
            SuspendLayout();
            // 
            // webViewPomodoroTracker
            // 
            webViewPomodoroTracker.AllowExternalDrop = true;
            webViewPomodoroTracker.CreationProperties = null;
            webViewPomodoroTracker.DefaultBackgroundColor = Color.White;
            webViewPomodoroTracker.Dock = DockStyle.Fill;
            webViewPomodoroTracker.Location = new Point(0, 0);
            webViewPomodoroTracker.Name = "webViewPomodoroTracker";
            webViewPomodoroTracker.Size = new Size(382, 191);
            webViewPomodoroTracker.Source = new Uri("https://pomodoro-tracker.com/", UriKind.Absolute);
            webViewPomodoroTracker.TabIndex = 0;
            webViewPomodoroTracker.ZoomFactor = 0.67D;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 49, 49);
            ClientSize = new Size(382, 191);
            Controls.Add(webViewPomodoroTracker);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AppForm";
            Text = "Pomodoro-Tracker-Desktop";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webViewPomodoroTracker).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewPomodoroTracker;
    }
}
