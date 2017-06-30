using System;
using System.Diagnostics;
using System.Configuration;

namespace InspireDisplay
{
    public class ProxyErrorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="errorDesc"></param>
        public static void LogError(Exception e, string errorDesc)
        {
            try
            {
                string logErrors = ConfigurationManager.AppSettings["LogErrors"];
                if (logErrors == "True")
                {
                    const string sSource = "Inspire Display";
                    if (!EventLog.SourceExists(sSource))
                        EventLog.CreateEventSource(sSource, "Application");

                    EventLog.WriteEntry(sSource, errorDesc + " " + e.Message, EventLogEntryType.Error, 235);

                }
            }
            catch (Exception ex)
            {
                //throw ex;
                //do nothing at this point...
            }

        }//function

        public static void LogAndRestart(Exception e, string error)
        {
            LogError(e, error);

            System.Windows.Forms.Application.Restart();

            System.Windows.Application.Current.Shutdown();
        }
    }//class
}
