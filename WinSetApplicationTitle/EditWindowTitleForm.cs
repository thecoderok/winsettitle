using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    public partial class EditWindowTitleForm : Form
    {
        private GuiWindowInfo m_window = null;

        public EditWindowTitleForm()
        {
            InitializeComponent();
        }

        public void StartWindowTitleEditing(GuiWindowInfo window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("process");
            }
            this.m_window = window;
            this.Text = string.Format("Edit title ({0}: {1})", window.ProcessId, window.ProcessName);
            this.txtTitle.Text = window.Title;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WindowTitleSetter.SetTitleByMainWindowHandle(this.m_window.MainWindowHandle, this.txtTitle.Text);
            this.Close();
        }
    }
}
