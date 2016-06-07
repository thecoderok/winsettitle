using System;
using System.Runtime.InteropServices;

namespace WinSetApplicationTitle
{
    public static class WinApiDllImports
    {
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);
    }
}
