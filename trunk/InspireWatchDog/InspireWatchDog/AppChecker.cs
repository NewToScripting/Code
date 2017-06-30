using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security;

namespace Inspire.WatchDog.Service
{
    public class AppChecker
    {        
        private ConfigHelper config = new ConfigHelper();

        public void KillApplication()
        {
            string appName;
            appName = config.GetAppName();

            Process[] processes = Process.GetProcessesByName(appName);
            if (processes.Length > 0)
            {
                foreach (Process item in processes)
                {
                    item.Kill();
                    item.Dispose();
                }
            }
        }

        public bool IsApplicationResponding()
        {
            bool isRunning = false;
            string appName;
            appName = config.GetAppName();

            Process[] processes = Process.GetProcessesByName(appName);
            if (processes.Length > 0)
            {
                foreach (Process item in processes)
                {
                    if (item.Responding)
                    {
                        isRunning = true;
                    }                  
                }
            }

            return isRunning;
        }

        public bool IsApplicationRunning()
        {
            bool isRunning = false;
            string appName;
            appName = config.GetAppName();

            Process[] processes = Process.GetProcessesByName(appName);
            if (processes.Length > 0)
            {
                foreach (Process item in processes)
                {      
                        isRunning = true;                 
                }
            }

            return isRunning;
        }

        public void StartApplication()
        {
            string appPath = config.GetAppPath();
            ProcessStartInfo info = new ProcessStartInfo(appPath);

            info.UseShellExecute = false;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UserName = "jhaveard";

            string passFromConfig = "qavfat8";
            SecureString password = new SecureString();                                  
            
            if (!string.IsNullOrEmpty(passFromConfig))
            {
                foreach (char c in passFromConfig)
                { password.AppendChar(c); }
            }

            info.Password = password;            
            Process.Start(info);  
        }

    }//class
}//namespace
