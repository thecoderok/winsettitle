using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinSetApplicationTitle.Properties;

namespace WinSetApplicationTitle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
            try
            {
                using (new SingleGlobalInstance(1000))
                {
                    // TODO: logging
                    LaunchApplication();
                }
            }
            catch (TimeoutException)
            {
                if (!TryToActivateAnotherInstance())
                {
                    MessageBox.Show("Another instance of application is already running.",
                        "WinSetTitle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // TODO: error handling
                return -1;
            }

            return 0;
        }

        private static void LaunchApplication()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                WinApiDllImports.SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static bool TryToActivateAnotherInstance()
        {
            try
            {
                var currentProcess = Process.GetCurrentProcess();
                var prc = Process.GetProcessesByName(currentProcess.ProcessName);
                if (prc.Length > 0)
                {
                    foreach (var process in prc)
                    {
                        if (process.Id != currentProcess.Id && process.MainWindowHandle != IntPtr.Zero)
                        {
                            WinApiDllImports.ShowWindow(process.MainWindowHandle, 1);
                            WinApiDllImports.SetForegroundWindow(process.MainWindowHandle);
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: error handling
                return false;
            }
        }

        private static void UpgradeSettingsIfNeeded()
        {
            try
            {
                if (Settings.Default.CallUpgrade)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.CallUpgrade = false;
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                // TODO: proper error handling
                throw ex;
            }
        }
    }
}
