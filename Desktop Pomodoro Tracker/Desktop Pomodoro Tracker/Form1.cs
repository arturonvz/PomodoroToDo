using Microsoft.Web.WebView2.Core;

namespace Desktop_Pomodoro_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;
            webView21.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView21.Source = new Uri("https://pomodoro-tracker.com/");
        }

        private void CoreWebView2_PermissionRequested(object sender, CoreWebView2PermissionRequestedEventArgs e)
        {
            Console.WriteLine($"Permission Requested: {e.PermissionKind}");

            if (e.PermissionKind == CoreWebView2PermissionKind.Notifications)
            {
                e.State = CoreWebView2PermissionState.Allow;
                Console.WriteLine("Notification permission allowed.");
            }
            else
            {
                e.State = CoreWebView2PermissionState.Default;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // Inject CSS to hide scrollbars
                string hideScrollbarsCss = "body::-webkit-scrollbar { display: none; }";
                string hideScrollbarsScript = $"var style = document.createElement('style'); style.innerHTML = '{hideScrollbarsCss}'; document.head.appendChild(style);";
                await webView21.ExecuteScriptAsync(hideScrollbarsScript);

                // Inject CSS to change --button-bg to green
                string changeButtonBgCss = ":root { --button-bg: green !important; }";
                string changeButtonBgScript = $"var style = document.createElement('style'); style.innerHTML = '{changeButtonBgCss}'; document.head.appendChild(style);";
                await webView21.ExecuteScriptAsync(changeButtonBgScript);
            }
        }
    }
}
