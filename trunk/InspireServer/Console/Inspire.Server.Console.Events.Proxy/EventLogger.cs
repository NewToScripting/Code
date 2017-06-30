using System.Configuration;
using System.Diagnostics;

namespace Inspire.Server.Console.Events.Proxy
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
            string logErrors = ConfigurationManager.AppSettings["LogEvents"];
            if (logErrors == "True" || logErrors == "true")
            {
                const string sSource = "Inspire Server Service";
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, "Application");

                EventLog.WriteEntry(sSource, errorDesc, eventType, 345);
            }
            
        }//function
    }
}