using System;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
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
            WinApiDllImports.POINT p = new WinApiDllImports.POINT();
            bool retVal = WinApiDllImports.GetCursorPos(ref p);
            if (retVal)
            {
                IntPtr hwnd = WinApiDllImports.WindowFromPoint(p);
                if (hwnd.ToInt64() > 0)
                {
                    var result = hwnd;
                    while (WinApiDllImports.GetParent(hwnd).ToInt64() > 0)
                    {
                        hwnd = WinApiDllImports.GetParent(hwnd);
                    }
                    titleSetter.SetTitleByMainWindowHandle(hwnd, "root");
                    //For Parent 
                    /*IntPtr hWndParent = WinApiDllImports.GetParent(hwnd);
                    if (hWndParent.ToInt64() > 0)
                    {
                        titleSetter.SetTitleByMainWindowHandle(hWndParent, "Parent");
                    }*/
                }
            }
        }
    }
}
