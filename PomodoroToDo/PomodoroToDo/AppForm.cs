using Microsoft.Web.WebView2.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Drawing;
using Microsoft.VisualBasic;
using Cyotek.Windows.Forms;

namespace Desktop_Pomodoro_Tracker
{
    public partial class AppForm : Form
    {
        public string CurrentMode = "";
        public string CurrentColorHex = "#181818";
        public string[] AppStrings;

        public string colorPomodoro;
        public string colorShort;
        public string colorLong;
        public string colorNavBarDark;
        public string colorToDoSelected;

        public Color darkenedRed = Color.DarkRed;
        public Color darkenedGreen = Color.DarkGreen;
        public Color darkenedBlue = Color.DarkBlue;

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
            contextMenu.Items.Add("Force red", null, ForceRed_Click);
            contextMenu.Items.Add("Force green", null, ForceGreen_Click);
            contextMenu.Items.Add("Force blue", null, ForceBlue_Click);
            contextMenu.Items.Add("Force other color", null, ForceOtherColor_Click);

            // DarkenedColors
            colorNavBarDark = "#181818";
            colorPomodoro = "#a94442";
            colorShort = "#388f38";
            colorLong = "#337ab7";
            darkenedRed = DarkenColor(ColorTranslator.FromHtml("#a94442"), 0.7);
            darkenedGreen = DarkenColor(ColorTranslator.FromHtml("#388f38"), 0.7);
            darkenedBlue = DarkenColor(ColorTranslator.FromHtml("#337ab7"), 0.7);
            this.BackColor = ColorTranslator.FromHtml(CurrentColorHex);

            // Asignar el ContextMenuStrip al label
            lblCurrentMode.ContextMenuStrip = contextMenu;

            LoadLanguage("en");
        }

        private void LoadLanguage(string language)
        {
            
        }

        private void ForceRed_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            this.BackColor = darkenedRed; // Rojo
            CurrentColorHex = ColorTranslator.ToHtml(this.BackColor);
        }

        private void ForceGreen_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            this.BackColor = darkenedGreen; // Verde
            CurrentColorHex = ColorTranslator.ToHtml(this.BackColor);
        }

        private void ForceBlue_Click(object sender, EventArgs e)
        {
            lblCurrentMode.BackColor = Color.Transparent;
            this.BackColor = darkenedBlue; // Azul
            CurrentColorHex = ColorTranslator.ToHtml(this.BackColor);
        }

        private void ForceOtherColor_Click(object sender, EventArgs e)
        {
            using (ColorPickerDialog colorPickerDialog = new ColorPickerDialog())
            {
                // Establecer el color inicial como el color de fondo actual del Label.
                colorPickerDialog.Color = this.BackColor;

                // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó un color.
                if (colorPickerDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cambiar el color de fondo del Label al color seleccionado.
                    this.BackColor = colorPickerDialog.Color;
                }
            }
            CurrentColorHex = ColorTranslator.ToHtml(this.BackColor);
        }

        private async void WebViewPomodoroTracker_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // Inject CSS to hide scrollbars
                string hideScrollbarsCss = "body::-webkit-scrollbar { display: none; }";
                string hideScrollbarsScript = $"var style = document.createElement('style'); style.innerHTML = '{hideScrollbarsCss}'; document.head.appendChild(style);";
                await webViewPomodoroTracker.ExecuteScriptAsync(hideScrollbarsScript);

                // CSS for dark theme and system with prefers-color-scheme: dark
                string darkThemeCss = @"
@media (prefers-color-scheme: dark) {
    body[data-theme=system] .c-nav--bar {
        background: " + colorNavBarDark + @" !important;
        border-color: rgba(255, 255, 255, .3) !important;
    }
    body[data-theme=system] .c-nav_toggler {
        color: #e3e3e3 !important;
        background: " + colorNavBarDark + @" !important;
        border-color: #e3e3e3 !important;
    }
    body[data-theme=system] .c-nav_item {
        background: " + colorNavBarDark + @" !important;
    }
    body[data-theme=system] .c-timer.long {
        background: " + colorLong + @" !important;
    }
    body[data-theme=system] .c-timer.pomodoro {
        background: " + colorPomodoro + @" !important;
    }
    body[data-theme=system] .c-timer.pomodoro button {
        background-color: " + colorPomodoro + @" !important;
    }
    body[data-theme=system] .c-timer.short {
        background: " + colorShort + @" !important;
    }
    body[data-theme=system] .c-timer.short button {
        background-color: " + colorShort + @" !important;
    }
    body[data-theme=system] .c-timer.long button {
        background-color: " + colorLong + @" !important;
    }
}

body[data-theme=dark] .c-nav--bar {
    background: " + colorNavBarDark + @" !important;
    border-color: rgba(255, 255, 255, .3);
}
body[data-theme=dark] .c-nav_toggler {
    color: #e3e3e3 !important;
    background: " + colorNavBarDark + @" !important;
    border-color: #e3e3e3;
}
body[data-theme=dark] .c-nav_item {
    background: " + colorNavBarDark + @" !important;
}
body[data-theme=dark] .c-timer.long {
    background: " + colorLong + @" !important;
}
body[data-theme=dark] .c-timer.pomodoro {
    background: " + colorPomodoro + @" !important;
}
body[data-theme=dark] .c-timer.pomodoro button {
    background-color: " + colorPomodoro + @" !important;
}
body[data-theme=dark] .c-timer.short {
    background: " + colorShort + @" !important;
}
body[data-theme=dark] .c-timer.short button {
    background-color: " + colorShort + @" !important;
}
body[data-theme=dark] .c-timer.long button {
    background-color: " + colorLong + @" !important;
}";

                // Escapar las comillas en el CSS para la inyección
                darkThemeCss = darkThemeCss.Replace("'", "\\'");
                darkThemeCss = darkThemeCss.Replace("\"", "\\\"");

                string injectCssScript = $"var style = document.createElement('style'); style.innerHTML = `{darkThemeCss}`; document.head.appendChild(style);";
                await webViewPomodoroTracker.ExecuteScriptAsync(injectCssScript);

                // Llama al timer1_Tick por si necesitas iniciar algún proceso después de la inyección.
                tmrGetCurrentMode_Tick(sender, e);
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

        private async void tmrGetCurrentMode_Tick(object sender, EventArgs e)
        {
            tmrGetCurrentMode.Enabled = false;
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
                                    lblCurrentMode.Text = "SHORT BREAK";
                                    this.BackColor = darkenedGreen; // Fondo oscuro para el panel
                                    lblCurrentMode.BackColor = darkenedGreen;
                                    break;
                                case "long":
                                    lblCurrentMode.Text = "LONG BREAK";
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
            tmrGetCurrentMode.Enabled = true;
        }

        private void lblCurrentMode_DoubleClick(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Write the name of the current activity:", "Current activity text", lblCurrentMode.Text);
            if (!string.IsNullOrEmpty(input))
            {
                lblCurrentMode.Text = input;
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

            // Script para seleccionar la lista "My Day"
            string script = @"
        (function() {
            // Busca el elemento que corresponde a 'My Day' y simula un clic.
            const myDayElement = document.querySelector('button[data-test-id=""my-day-sidebar-button""]');
            if (myDayElement) {
                myDayElement.click();
            }
        })();
    ";

        }
    }
}
