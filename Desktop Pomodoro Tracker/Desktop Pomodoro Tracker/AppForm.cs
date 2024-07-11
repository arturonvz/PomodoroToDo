using Microsoft.Web.WebView2.Core;

namespace Desktop_Pomodoro_Tracker
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            await webViewPomodoroTracker.EnsureCoreWebView2Async(null);
            webViewPomodoroTracker.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;
            webViewPomodoroTracker.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webViewPomodoroTracker.Source = new Uri("https://pomodoro-tracker.com/");
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
                await webViewPomodoroTracker.ExecuteScriptAsync(hideScrollbarsScript);

                // Change background color of the specific element in the CSS
                string changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-nav--bar { background: #181818 !important; border-color: rgba(255, 255, 255, .3); }';
                    document.head.appendChild(style);
                ";
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                // Change background color of the specific element in the CSS
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-nav_toggler { color: #e3e3e3; background: #181818 !important; border-color: #e3e3e3; }';
                    document.head.appendChild(style);
                ";
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                // Change background color of the specific element in the CSS
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-nav_item { background: #181818 !important; }';
                    document.head.appendChild(style);
                ";
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);
            }
        }

    }
}
