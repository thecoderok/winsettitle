namespace WinSetApplicationTitle
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class WinApiHelper
    {
        // https://code.msdn.microsoft.com/windowsapps/C-Getting-the-Windows-da1bd524

        public GuiWindowInfo GetWindowUnderMouse()
        {
            IntPtr windowHandle = this.GetTopmostWindowHandleUnderTheMouse();
            if (windowHandle == IntPtr.Zero)
            {
                return null;
            }

            uint processId = 0;
            WinApiDllImports.GetWindowThreadProcessId(windowHandle, out processId);
            Process process = Process.GetProcessById((int)processId);
            string windowTitle = this.GetCaptionOfWindow(windowHandle);
            return new GuiWindowInfo(windowHandle, windowTitle, process);
        }

        private IntPtr GetTopmostWindowHandleUnderTheMouse()
        {
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
                    
                    Debug.Assert(hwnd != IntPtr.Zero && hwnd.ToInt64() > 0, "Invalid window handle");
                    return hwnd;
                }
            }
            return IntPtr.Zero;
        }

        private string GetCaptionOfWindow(IntPtr hwnd)
        {
            try
            {
                int max_length = WinApiDllImports.GetWindowTextLength(hwnd);
                var windowText = new StringBuilder("", max_length + 5);
                WinApiDllImports.GetWindowText(hwnd, windowText, max_length + 2);
                return windowText.ToString();
            }
            catch (Exception ex)
            {
                 // TODO: what can throw here
                throw ex;
            }
        } 
    }
}
