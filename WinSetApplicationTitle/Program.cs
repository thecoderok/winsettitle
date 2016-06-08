using NLog;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinSetApplicationTitle.Properties;

namespace WinSetApplicationTitle
{
    static class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

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
                    log.Info("Launching application");
                    LaunchApplication();
                }
            }
            catch (TimeoutException)
            {
                if (!TryToActivateAnotherInstance())
                {
                    log.Warn("Another instance detected");
                    MessageBox.Show("Another instance of application is already running.",
                        "WinSetTitle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error while trying to check for another isntance: {0}.", ex.Message);
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
                log.Error(ex, "Error while trying to activate another isntance: {0}.", ex.Message);
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
                log.Error(ex, "Error while trying to upgrade settings: {0}.", ex.Message);
                throw ex;
            }
        }
    }
}
