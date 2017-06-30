using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using Inspire.Server.SlideManager.FaultContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    class EventLogger
    {
        /// <summary>
        /// Log error and throw fault.
        /// </summary>
        /// <param name="errorDesc">System Message</param>
        /// <param name="faultReason">UI Message</param>
        static public void LogAndThrowFault(string errorDesc, string faultReason)
        {

            string logErrors = ConfigurationManager.AppSettings["LogErrors"];
            if (logErrors == "True")
            {
                const string sSource = "Inspire Server";
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, "Application");

                EventLog.WriteEntry(sSource, faultReason + Environment.NewLine + errorDesc, EventLogEntryType.Error, 345);
            }

            var faultContract = new DefaultFaultContract();
            faultContract.ErrorDesc = errorDesc;

            var reason = new FaultReason(faultReason);
            FaultException fault = new FaultException<DefaultFaultContract>(faultContract, reason);
            throw (fault);

        }//function



    }
}
