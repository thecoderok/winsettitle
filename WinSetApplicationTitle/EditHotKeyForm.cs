using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinSetApplicationTitle.Properties;

namespace WinSetApplicationTitle
{
    public partial class EditHotKeyForm : Form
    {
        private Settings AppSettings = Properties.Settings.Default;
        private List<Keys> allowedKeys = new List<Keys>()
        {
            Keys.A,
            Keys.B,
            Keys.C,
            Keys.D,
            Keys.E,
            Keys.F,
            Keys.G,
            Keys.H,
            Keys.I,
            Keys.J,
            Keys.K,
            Keys.L,
            Keys.M,
            Keys.N,
            Keys.O,
            Keys.P,
            Keys.Q,
            Keys.R,
            Keys.S,
            Keys.T,
            Keys.U,
            Keys.V,
            Keys.W,
            Keys.X,
            Keys.Y,
            Keys.Z,
            Keys.Delete,
            Keys.Divide,
            Keys.Down,
            Keys.Up,
            Keys.Left,
            Keys.Right,
            Keys.Scroll,
            Keys.Space,
            Keys.Tab,
        };

        public EditHotKeyForm()
        {
            InitializeComponent();
            this.chkAlt.Checked = AppSettings.HotKeyAlt;
            this.chkControl.Checked = AppSettings.HotKeyControl;
            this.chkShift.Checked = AppSettings.HotKeyShift;
            this.comboKey.Items.Clear();
            int indexToSelect = -1;
            for(int i=0; i < this.allowedKeys.Count; i++)
            {
                this.comboKey.Items.Add(this.allowedKeys[i]);
                if (this.allowedKeys[i].ToString() == AppSettings.HotKeyKey)
                {
                    indexToSelect = i;
                }
            }

            if (indexToSelect == -1)
            {
                throw new ApplicationException("Not supported hot key");
            }

            this.comboKey.SelectedIndex = indexToSelect;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppSettings.HotKeyKey = this.comboKey.SelectedItem.ToString();
            AppSettings.HotKeyAlt = this.chkAlt.Checked;
            AppSettings.HotKeyControl = this.chkControl.Checked;
            AppSettings.HotKeyShift = this.chkShift.Checked;
            AppSettings.Save();
            this.Close();
        }
    }
}
