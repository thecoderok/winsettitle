namespace WinSetApplicationTitle
{
    using System;

    public class GuiWindowInfo
    {
        public readonly IntPtr MainWindowHandle;

        public readonly string Title;

        public GuiWindowInfo(IntPtr mainWindowHandle, string title)
        {
            if (mainWindowHandle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid main window handle");
            }

            this.MainWindowHandle = mainWindowHandle;
            this.Title = title;
        }
    }
}
