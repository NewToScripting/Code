using System.Configuration;
using System.Diagnostics;
using System;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Proxy Error Handler
    /// </summary>
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

                    EventLog.WriteEntry(sSource, errorDesc + " " + e.Message, EventLogEntryType.Error, 234);

                }
            }
            catch (Exception ex)
            {
                throw ex;
                //do nothing at this point...
            }

            //throw e; //throw error again

        }//function
    }//class
}//namespace
