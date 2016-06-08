namespace WinSetApplicationTitle
{
    using System;
    using System.Diagnostics;
    public class GuiWindowInfo
    {
        public readonly IntPtr MainWindowHandle;

        public readonly string Title;

        private readonly Process m_process;

        public int ProcessId
        {
            get
            {
                return m_process.Id;
            }
        }

        public string ProcessName
        {
            get
            {
                return m_process.ProcessName;
            }
        }

        public GuiWindowInfo(IntPtr mainWindowHandle, string title, Process process)
        {
            if (mainWindowHandle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid main window handle");
            }

            if (process == null)
            {
                throw new ArgumentNullException("process");
            }

            this.MainWindowHandle = mainWindowHandle;
            this.Title = title;
            this.m_process = process;
        }
    }
}
