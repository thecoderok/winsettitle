namespace WinSetApplicationTitle
{
    using System.Windows.Forms;
    // http://stackoverflow.com/questions/3274406/wrapping-msctls-hotkey32-in-net-windows-forms
    public class HotKeyControl : Control
    {
        public HotKeyControl()
        {
            SetStyle(ControlStyles.UserPaint, false);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassName = "msctls_hotkey32";

                return cp;
            }
        }
    }
}
