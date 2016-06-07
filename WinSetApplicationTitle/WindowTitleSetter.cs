using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinSetApplicationTitle
{
    public class WindowTitleSetter
    {
        public void SetTitleForProcessMainWindow(Process process, string newTitle)
        {
            if (process == null)
            {
                throw new ArgumentNullException("process");
            }

            if (process.MainWindowHandle == IntPtr.Zero)
            {
                throw new WinSetTitleException("Give process does not have GUI window: " + process.ProcessName);
            }

            SetWindowText(process.MainWindowHandle, newTitle);
        }

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
    }
}
