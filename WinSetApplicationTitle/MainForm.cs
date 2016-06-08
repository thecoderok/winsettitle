using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    using Properties;
    using System.Diagnostics;
    public partial class MainForm : Form
    {
        private static bool canCloseForm = false;
        private readonly Settings AppSettings = Settings.Default;
        private Lazy<WinApiHelper> winApiHelper = new Lazy<WinApiHelper>(()=>new WinApiHelper());

        public MainForm()
        {
            InitializeComponent();
            this.InitSettings();
            var helper = new HotKeysHelper();
            helper.RegisterHotKey(WinSetApplicationTitle.ModifierKeys.Control | WinSetApplicationTitle.ModifierKeys.Shift, Keys.Z);
            helper.KeyPressed += Helper_KeyPressed;
            
            AppSettings.Save();
        }

        public static void AllowFormClosing()
        {
            canCloseForm = true;
        }

        private void Helper_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            GuiWindowInfo window = this.winApiHelper.Value.GetWindowUnderMouse();
            if (window == null)
            {
                return;
            }

            var setTitleForm = new EditWindowTitleForm();
            setTitleForm.StartWindowTitleEditing(window);
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
            if (AppSettings.HotKey == null)
            {
                AppSettings.HotKey = new HotKeyCombination(WinSetApplicationTitle.ModifierKeys.Control | WinSetApplicationTitle.ModifierKeys.Shift, Keys.Z);
            }

            this.txtHotkey.Text = AppSettings.HotKey.ToString();
        }
        #endregion

        private void btnEditHotkey_Click(object sender, EventArgs e)
        {
            var form = new EditHotKeyForm();
            form.ShowDialog();
        }
    }
}
