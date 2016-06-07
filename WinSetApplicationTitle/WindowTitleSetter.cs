using System;
using System.Diagnostics;

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

            this.SetTitleByMainWindowHandle(process.MainWindowHandle, newTitle);
        }

        public void SetTitleByMainWindowHandle(IntPtr mainWindowHandle, string newTitle)
        {
            WinApiDllImports.SetWindowText(mainWindowHandle, newTitle);
        }
    }
}
