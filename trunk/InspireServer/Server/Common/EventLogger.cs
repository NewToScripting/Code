using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Inspire.Server.Common.FaultContracts;

namespace Inspire.Server.Common
{
    public class EventLogger
    {
        /// <summary>
        /// Log error and throw fault.
        /// </summary>
        /// <param name="errorDesc">System Message</param>
        /// <param name="faultReason">UI Message</param>
        static public void LogAndThrowFault(string errorDesc, string faultReason)
        {

            //string logErrors = ConfigurationManager.AppSettings["LogErrors"];
            //if (logErrors == "True")
            //{
                const string sSource = "Inspire Server";
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, "Application");

                EventLog.WriteEntry(sSource, faultReason + Environment.NewLine + errorDesc, EventLogEntryType.Error, 345);
            //}

                var faultContract = new GeneralFaultContract();
                faultContract.ErrorDesc = errorDesc;

                var reason = new FaultReason(faultReason);
                FaultException fault = new FaultException<GeneralFaultContract>(faultContract, reason);
                //throw (fault);

        }//function



        /// <summary>
        /// Log error and throw fault.
        /// </summary>
        /// <param name="errorDesc">System Message</param>
        /// <param name="faultReason">UI Message</param>
        static public void Write(string errorDesc, EventLogEntryType faulType)
        {

            //string logErrors = ConfigurationManager.AppSettings["LogErrors"];
            //if (logErrors == "True")
            //{
                const string sSource = "Inspire Server";
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, "Application");

                EventLog.WriteEntry(sSource, errorDesc, faulType, 345);
            //}

            //var faultContract = new GeneralFaultContract();
            //faultContract.ErrorDesc = errorDesc;

            //var reason = new FaultReason(errorDesc);
            //FaultException fault = new FaultException<GeneralFaultContract>(faultContract, reason);
            //throw (fault);

        }//function


    }
}
