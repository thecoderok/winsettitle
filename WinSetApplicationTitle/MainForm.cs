using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    using Properties;

    public partial class MainForm : Form
    {
        private static bool canCloseForm = false;
        private readonly Settings AppSettings = Settings.Default;

        public MainForm()
        {
            InitializeComponent();
            this.InitSettings();
            var helper = new HotKeysHelper();
            helper.RegisterHotKey(WinSetApplicationTitle.ModifierKeys.Control | WinSetApplicationTitle.ModifierKeys.Shift, Keys.Z);
            helper.KeyPressed += Helper_KeyPressed;
        }

        public static void AllowFormClosing()
        {
            canCloseForm = true;
        }

        private void Helper_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            var titleSetter = new WindowTitleSetter();
            var winApiHelper = new WinApiHelper();
            GuiWindowInfo window = winApiHelper.GetWindowUnderMouse();
            if (window == null)
            {
                return;
            }

            var arr = window.Title.ToCharArray();
            Array.Reverse(arr);

            titleSetter.SetTitleByMainWindowHandle(window.MainWindowHandle, new string(arr));
        }

        #region Event handlers
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing || canCloseForm)
            {
                return;
            }

            e.Cancel = true;
            this.Hide();
            this.trayIcon.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.CloseApplication();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMainWindow();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowMainWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CloseApplication();
        }

        private void chkStartAppAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.RunApplicationWhenWindowsStarts = this.chkStartAppAutomatically.Checked;
            AppSettings.Save();
            AutostartupHelper.WriteAutostartupOptions(AppSettings.RunApplicationWhenWindowsStarts);
        }

        private void chkHideWindowOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.HideWindowOnStartup = this.chkHideWindowOnStartup.Checked;
            AppSettings.Save();
        }
        #endregion

        #region Helper methods
        private void ShowMainWindow()
        {
            this.Show();
        }

        private void CloseApplication()
        {
            AllowFormClosing();
            this.Close();
        }

        private void InitSettings()
        {
            this.chkStartAppAutomatically.Checked = AppSettings.RunApplicationWhenWindowsStarts;
            this.chkHideWindowOnStartup.Checked = AppSettings.HideWindowOnStartup;
        }
        #endregion
    }
}
