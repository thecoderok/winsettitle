using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    using System.Linq;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var helper = new HotKeysHelper();
            helper.RegisterHotKey(WinSetApplicationTitle.ModifierKeys.Control | WinSetApplicationTitle.ModifierKeys.Shift, Keys.Z);
            helper.KeyPressed += Helper_KeyPressed;
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
    }
}
