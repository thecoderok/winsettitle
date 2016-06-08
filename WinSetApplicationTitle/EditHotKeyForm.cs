using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    public partial class EditHotKeyForm : Form
    {
        public EditHotKeyForm()
        {
            InitializeComponent();
            var hotKey = Properties.Settings.Default.HotKey;
            this.chkAlt.Checked = hotKey.ModifierKeys.HasFlag(WinSetApplicationTitle.ModifierKeys.Alt);
            this.chkControl.Checked = hotKey.ModifierKeys.HasFlag(WinSetApplicationTitle.ModifierKeys.Control);
            this.chkShift.Checked = hotKey.ModifierKeys.HasFlag(WinSetApplicationTitle.ModifierKeys.Shift);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
