namespace WinSetApplicationTitle
{
    using System.Reflection;
    using Microsoft.Win32;

    public class AutostartupHelper
    {
        private static readonly string ApplicationName = Assembly.GetExecutingAssembly().GetName().Name;
        private static readonly string ApplicationStartupKey = ApplicationName;
        private const string AutorunRegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AutorunRelativePath = @"Software\Microsoft\Windows\CurrentVersion\Run\";
        private static readonly string PathToApplication = Assembly.GetExecutingAssembly().Location;

        public static void WriteAutostartupOptions(bool shouldStartAutomatically)
        {
            if (shouldStartAutomatically)
            {
                Registry.SetValue(AutorunRegistryKey, ApplicationStartupKey, PathToApplication);
            }
            else
            {
                var key = Registry.CurrentUser.OpenSubKey(AutorunRelativePath, true);
                if (key != null)
                {
                    key.DeleteValue(ApplicationStartupKey, false);
                    key.Close();
                }
                else
                {
                    // TODO: error logging
                    /*Log.Error(String.Format("Unable to delete auto-startup option, key '{0}' is null", AutorunRelativePath));*/
                }
            }
        }

    }
}
