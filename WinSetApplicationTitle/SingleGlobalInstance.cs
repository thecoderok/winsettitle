using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace WinSetApplicationTitle
{
    /// <summary>
    /// Class to prevent more than one app instance running
    /// http://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c/229567
    /// </summary>
    public class SingleGlobalInstance : IDisposable
    {
        public bool HasHandle = false;
        Mutex mutex;

        private void InitMutex()
        {
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            // use this to have only one appp per machine: string.Format("Global\\{{{0}}}", appGuid);
            string mutexId = string.Format("{{{0}}}", appGuid);
            mutex = new Mutex(false, mutexId);

            var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            mutex.SetAccessControl(securitySettings);
        }

        public SingleGlobalInstance(int timeOut)
        {
            InitMutex();
            try
            {
                HasHandle = mutex.WaitOne(timeOut <= 0 ? Timeout.Infinite : timeOut, false);

                if (HasHandle == false)
                    throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
            }
            catch (AbandonedMutexException)
            {
                HasHandle = true;
            }
        }


        public void Dispose()
        {
            if (mutex != null)
            {
                if (HasHandle)
                    mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
    }
}