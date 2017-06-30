using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;

namespace Inspire.WatchDog.Interface
{

    public class ConfigHelper
    {
        /// <summary>
        /// Get app path
        /// </summary>
        /// <returns></returns>
        public string GetAppPath()
        {
           string appPath = "";

                try 
                { appPath = ConfigurationManager.AppSettings["AppPath"]; }
                
                catch
                { EventLogger.Log("Error getting AppPath", EventLogEntryType.Error); }            
            
           return appPath;
        }

        /// <summary>
        /// Get app name
        /// </summary>
        /// <returns></returns>
        public string GetAppName()
        {
            string appName = "InspireDisplay";

            try
            { appName = ConfigurationManager.AppSettings["AppName"]; }

            catch
            { EventLogger.Log("Error getting AppPath", EventLogEntryType.Error); }

            return appName;
        }

        /// <summary>
        /// Sleep during reboot
        /// </summary>
        /// <returns></returns>
        public bool GetSleepDuringReboot()
        {
            string item = "";
            bool value = false;

            try
            { item = ConfigurationManager.AppSettings["SleepDuringReboot"]; }

            catch
            { EventLogger.Log("Error getting SleepDuringReboot", EventLogEntryType.Error); }

              if (item == "true" || item == "True")
              {
                  value = true;
              }

            return value;
        }

        /// <summary>
        /// Get reboot time
        /// </summary>
        /// <returns></returns>
        public DateTime GetSleepRebootTime()
          {
              string item = "";
              DateTime itemTime;
              DateTime.TryParse(DateTime.Now.ToShortDateString() + " 02:00:00 AM", out itemTime);
                                         
              try
              { 
                  item = ConfigurationManager.AppSettings["DailyRebootTime"];

                  if (!String.IsNullOrEmpty(item))
                  {
                      DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + item, out itemTime);
                  }        
              }

              catch
              { 
                  EventLogger.Log("Error getting RebootTime", EventLogEntryType.Error);
              }

              return itemTime;
          }


        /// <summary>
        /// Bihourly reboot
        /// </summary>
        /// <returns></returns>
        public bool BiHourlyReboot()
        {
            string item = "";
            bool value = false;

            try
            { item = ConfigurationManager.AppSettings["BiHourlyReboot"]; }

            catch
            { EventLogger.Log("Error getting BiHourlyReboot", EventLogEntryType.Error); }

            if (item == "True" || item == "true")
            {
                value = true;
            }

            return value;
        }


        /// <summary>
        /// Daily reboot
        /// </summary>
        /// <returns></returns>
        public bool DailyReboot()
        {
            string item = "";
            bool value = false;

            try
            { item = ConfigurationManager.AppSettings["DailyReboot"]; }

            catch
            { EventLogger.Log("Error getting DailyReboot", EventLogEntryType.Error); }

            if (item == "True" || item == "true")
            {
                value = true;
            }

            return value;
        }


        /// <summary>
        /// Error Screen Name
        /// </summary>
        /// <returns></returns>
        public string GetErrorScreenName()
        {
            string item = "";
            
            try
            { item = ConfigurationManager.AppSettings["ErrorScreenName"];}

            catch
            { EventLogger.Log("Error getting ErrorScreenName", EventLogEntryType.Error); }
            
            return item;
            
        }


        /// <summary>
        /// Kill Error Screen
        /// </summary>
        /// <returns></returns>
        public bool KillErrorScreen()
        {
            string item = "";
            bool value = false;

            try
            { item = ConfigurationManager.AppSettings["KillErrorScreen"]; }

            catch
            { EventLogger.Log("Error getting KillErrorScreen", EventLogEntryType.Error); }

            if (item == "True" || item == "true")
            {
                value = true;
            }

            return value;
        }
    }//class
}//namespace
