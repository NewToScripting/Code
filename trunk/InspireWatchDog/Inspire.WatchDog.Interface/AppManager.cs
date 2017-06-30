using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;

namespace Inspire.WatchDog.Interface
{
    public class AppManager
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;
        const int MONITOR_ON = -1;
        const int MONITOR_OFF = 2;
        const int MONITOR_STANBY = 1;
        int onFlag = 0;

        private ConfigHelper config = new ConfigHelper();

        /// <summary>
        /// Wake Monitor
        /// </summary>
        private void WakeMonitor()
        {
            if (onFlag == 1)
            {
                SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_ON);
                onFlag = 0;
            }
        }

        /// <summary>
        /// Monitor Off
        /// </summary>
        private void MonitorOff()
        {
            SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
            onFlag = 1;
        }           
        
        /// <summary>
        /// Kill Application
        /// </summary>
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

        /// <summary>
        ///  Is Application Responding
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Is Application Running(
        /// </summary>
        /// <returns></returns>
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
            Process.Start(appPath);  
        }

        /// <summary>
        /// Sleep And Restart Application
        /// </summary>
        public void SleepAndRestartApplication()
        {
            string appName;
            appName = config.GetAppName();

            if (config.GetSleepDuringReboot())
            {
                MonitorOff();
                System.Threading.Thread.Sleep(1000);
            }            

            Process[] processes = Process.GetProcessesByName(appName);
            if (processes.Length > 0)
            {
                foreach (Process item in processes)
                {
                    item.Kill();
                    item.Dispose();
                }
            }                     

            StartApplication();

            if (config.GetSleepDuringReboot())
            {
                WakeMonitor();
            }

        }


          /// <summary>
        /// Check and Kill Error Screen
        /// </summary>
        public bool CheckAndKillErrorScreen()
        {
            if (config.KillErrorScreen())
            { 
                string errorScreenName;
                errorScreenName = config.GetErrorScreenName();

                    Process[] processes = Process.GetProcessesByName(errorScreenName);
                    if (processes.Length > 0)
                    {
                        foreach (Process item in processes)
                        {  
                            item.Kill();
                            item.Dispose();
                        }

                        return true;
                    }

                return false;  
            }     
            
            return false;   
            
        }

    }//class
}//namespace
