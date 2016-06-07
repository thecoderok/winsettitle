using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    public partial class MainForm : Form
    {
        private static bool canCloseForm = false;

        public MainForm()
        {
            InitializeComponent();
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
            AllowFormClosing();
            this.Close();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMainWindow();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            this.Show();
        }
    }
}
