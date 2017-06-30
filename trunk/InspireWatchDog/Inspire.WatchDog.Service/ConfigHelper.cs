using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Inspire.WatchDog.Service
{
    public class ConfigHelper
    {
        public int GetPingInterval()
        { 
            int pingInterval = 15;

                try 
                {	        
            		pingInterval = int.Parse(ConfigurationManager.AppSettings["PingInterval"]);
                }
                catch  
                { }            
            
            return pingInterval;
        }

        public string GetAppPath()
        {
           string appPath = "";

                try 
                { appPath = ConfigurationManager.AppSettings["AppPath"]; }
                
                catch  
                { }            
            
           return appPath;
        }

        public string GetAppName()
        {
            string appName = "";

            try
            { appName = ConfigurationManager.AppSettings["AppName"]; }

            catch
            { }

            return appName;
        }

    }
}
