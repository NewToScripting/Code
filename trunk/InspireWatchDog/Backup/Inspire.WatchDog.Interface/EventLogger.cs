using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;

namespace Inspire.WatchDog.Interface
{
    /// <summary>
    /// Event Logger
    /// </summary>
    class EventLogger
    {
        /// <summary>
        /// Log Events
        /// </summary>
        /// <param name="errorDesc"></param>
        /// <param name="eventType"></param>
        static public void Log(string errorDesc, EventLogEntryType eventType)
        {
            try
            {
                string logErrors = ConfigurationManager.AppSettings["LogEvents"];
                if (logErrors == "True" || logErrors == "true")
                {
                    const string sSource = "Inspire WatchDog";
                    if (!EventLog.SourceExists(sSource))
                        EventLog.CreateEventSource(sSource, "Application");

                    EventLog.WriteEntry(sSource, errorDesc, eventType, 345);
                }
            }
            catch 
            {              
               // Do nothing
            }            
            
        }//function
    }//class
}//namespace
  