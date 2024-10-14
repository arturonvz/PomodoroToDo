using Microsoft.Web.WebView2.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Drawing;

namespace Desktop_Pomodoro_Tracker
{
    public partial class AppForm : Form
    {
        string CurrentMode = "";
        Color colorPomodoro;
        Color colorShort;
        Color colorLong;
        Color darkenedRed = Color.DarkRed;
        Color darkenedGreen = Color.DarkGreen;
        Color darkenedBlue = Color.DarkBlue;

        public AppForm()
        {
            InitializeComponent();

            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            await webViewPomodoroTracker.EnsureCoreWebView2Async(null);
            webViewPomodoroTracker.CoreWebView2.PermissionRequested += WebViewPomodoroTracker_PermissionRequested;
        }

        private void WebViewPomodoroTracker_PermissionRequested(object sender, CoreWebView2PermissionRequestedEventArgs e)
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
            // Buscar la pantalla más a la izquierda
            Screen leftScreen = Screen.AllScreens.OrderBy(screen => screen.Bounds.X).First();

            // Ubicar el formulario en la esquina superior izquierda de la pantalla (0,0)
            // y ajustar la altura al alto de la pantalla izquierda menos la barra de tareas.
            this.Location = new Point(leftScreen.Bounds.X, leftScreen.Bounds.Y);
            this.Height = leftScreen.WorkingArea.Height; // WorkingArea excluye la barra de tareas
            this.Width = 538; // Ajusta el ancho del formulario a 538 píxeles

            // Crear el ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Focus Time Color", null, FocusTime_Click);
            contextMenu.Items.Add("Short Break Color", null, ShortBreak_Click);
            contextMenu.Items.Add("Long Break Color", null, LongBreak_Click);

            // DarkenedColors
            colorPomodoro = DarkenColor(ColorTranslator.FromHtml("#a94442"), 0.7);
            colorShort = DarkenColor(ColorTranslator.FromHtml("#388f38"), 0.7);
            colorLong = DarkenColor(ColorTranslator.FromHtml("#337ab7"), 0.7);
            darkenedRed = DarkenColor(ColorTranslator.FromHtml("#a94442"), 0.7);
            darkenedGreen = DarkenColor(ColorTranslator.FromHtml("#388f38"), 0.7);
            darkenedBlue = DarkenColor(ColorTranslator.FromHtml("#337ab7"), 0.7);

            // Asignar el ContextMenuStrip al label
            lblCurrentMode.ContextMenuStrip = contextMenu;
        }

        private void FocusTime_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            //lblCurrentMode.Text = "FOCUS TIME";
            this.BackColor = darkenedRed; // Rojo
        }

        private void ShortBreak_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            //lblCurrentMode.Text = "DESCANSO CORTO";
            this.BackColor = darkenedGreen; // Verde
        }

        private void LongBreak_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            //lblCurrentMode.Text = "DESCANSO LARGO";
            this.BackColor = darkenedBlue; // Azul
        }


        private async void WebViewPomodoroTracker_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
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

                // Change background color of the specific element in the CSS
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.long { background: #38478f !important; }'; 
                    document.head.appendChild(style);
                ";//#388f38
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                // Change background color of the specific element in the CSS - POMODORO
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.pomodoro button { background-color: #a94442 !important; }'; 
                    document.head.appendChild(style);
                ";//#56bd56

                // Change background color of the specific element in the CSS
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.pomodoro { background: #a94442 !important; }'; 
                    document.head.appendChild(style);
                ";//#388f38
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                // Change background color of the specific element in the CSS - SHORT
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.short button { background-color: #388f38 !important; }'; 
                    document.head.appendChild(style);
                ";//#56bd56

                // Change background color of the specific element in the CSS
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.short { background: #388f38 !important; }'; 
                    document.head.appendChild(style);
                ";//#388f38
                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                // Change background color of the specific element in the CSS - LONG
                changeBackgroundColorScript = @"
                    var style = document.createElement('style');
                    style.innerHTML = 'body[data-theme=dark] .c-timer.long button { background-color: #38478f !important; }'; 
                    document.head.appendChild(style);
                ";//#56bd56

                await webViewPomodoroTracker.ExecuteScriptAsync(changeBackgroundColorScript);

                timer1_Tick(sender, e);
            }
        }

        private Color DarkenColor(Color color, double factor)
        {
            // El factor debe estar entre 0 y 1. Un valor de 0 significa completamente negro, 1 significa sin cambios.
            int r = (int)(color.R * factor);
            int g = (int)(color.G * factor);
            int b = (int)(color.B * factor);
            return Color.FromArgb(color.A, r, g, b);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string script = @"
        (function() {
            var timerElement = document.querySelector('.c-timer');
            if (timerElement) {
                return timerElement.getAttribute('data-test');
            } else {
                return null;
            }
        })();
    ";

                string dataTestValue = await webViewPomodoroTracker.ExecuteScriptAsync(script);
                dataTestValue = dataTestValue.ToLower().Replace("\"", "");

                script = @"
        (function() {
            var timerElement = document.querySelector('.c-timer');
            if (timerElement) {
                return timerElement.getAttribute('data-test-state');
            } else {
                return null;
            }
        })();
    ";
                string dataTestStatus = await webViewPomodoroTracker.ExecuteScriptAsync(script);
                dataTestStatus = dataTestStatus.ToLower().Replace("\"", "");

                // Ahora puedes usar el valor de dataTestValue
                if (!string.IsNullOrEmpty(dataTestValue) && dataTestValue != "null")
                {
                    if (!string.IsNullOrEmpty(dataTestStatus) && dataTestStatus != "null")
                    {
                        if (dataTestValue.ToLower() != CurrentMode)
                        {
                            CurrentMode = dataTestValue.ToLower();
                            switch (dataTestValue.ToLower())
                            {
                                case "pomodoro":
                                    lblCurrentMode.Text = "FOCUS TIME";
                                    this.BackColor = darkenedRed; // Fondo oscuro para el panel
                                    lblCurrentMode.BackColor = darkenedRed;
                                    break;
                                case "short":
                                    lblCurrentMode.Text = "DESCANSO CORTO";
                                    this.BackColor = darkenedGreen; // Fondo oscuro para el panel
                                    lblCurrentMode.BackColor = darkenedGreen;
                                    break;
                                case "long":
                                    lblCurrentMode.Text = "DESCANSO LARGO";
                                    this.BackColor = darkenedBlue; // Fondo oscuro para el panel
                                    lblCurrentMode.BackColor = darkenedBlue;
                                    break;
                                default:
                                    lblCurrentMode.Text = "";
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Manejo de excepciones si es necesario
            }
        }

        private void lblCurrentMode_DoubleClick(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Establece el color inicial como el color de fondo actual del Label.
                colorDialog.Color = lblCurrentMode.BackColor;

                // Habilitar la opción para que el usuario seleccione colores personalizados.
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;

                // Mostrar el diálogo y verificar si el usuario seleccionó un color.
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cambiar el color de fondo del Label al color seleccionado.
                    lblCurrentMode.BackColor = colorDialog.Color;
                }
            }
        }

        private void webViewToDo_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // CSS que deseas inyectar
            string css = @"
                const style = document.createElement('style');
                style.textContent = `
                    .taskItem.selected .taskItem-body {
                        background: #896643 !important;
                    }
                `;
                document.head.append(style);
            ";

            // Ejecutar el script para inyectar el CSS
            webViewToDo.CoreWebView2.ExecuteScriptAsync(css);
        }
    }
}
