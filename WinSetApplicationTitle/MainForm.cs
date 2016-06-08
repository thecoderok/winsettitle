using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    using NLog;
    using Properties;
    using System.Diagnostics;
    using System.Reflection;
    public partial class MainForm : Form
    {
        private static bool canCloseForm = false;
        private readonly Settings AppSettings = Settings.Default;
        private readonly HotKeysHelper hotKeysHelper = new HotKeysHelper();
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        private Lazy<WinApiHelper> winApiHelper = new Lazy<WinApiHelper>(()=>new WinApiHelper());

        public MainForm()
        {
            InitializeComponent();
            this.InitSettings();
            this.InitHotKeys();

            hotKeysHelper.KeyPressed += Helper_KeyPressed;
            this.txtVersion.Text = GetAppVersion();
        }

        private void InitHotKeys()
        {
            var hkc = HotKeyCombination.GetFromConfig(AppSettings);
            this.txtHotkey.Text = hkc.ToString();
            hotKeysHelper.UnregisterHotKeys();
            try
            {
                hotKeysHelper.RegisterHotKey(hkc.ModifierKeys, hkc.Key);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when tried to register hot key: {0}.", ex.Message);
                MessageBox.Show("Application was unable to register hot key\r\nperhaps it is already in use by other app.\r\nPlease pick different hot key.", "WinSetApplicationTitle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
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

        private void btnEditHotkey_Click(object sender, EventArgs e)
        {
            var form = new EditHotKeyForm();
            var currentHkc = HotKeyCombination.GetFromConfig(AppSettings);
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var newHkc = HotKeyCombination.GetFromConfig(AppSettings);
                if (newHkc.ToString() != currentHkc.ToString())
                {
                    InitHotKeys();
                }
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.CloseApplication();
        }

        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/thecoderok/winsettitle");
        }

        public string GetAppVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (AppSettings.HideWindowOnStartup)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }
    }
}
