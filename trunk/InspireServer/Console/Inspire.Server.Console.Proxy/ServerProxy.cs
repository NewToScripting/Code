using System;
using System.Diagnostics;
using Inspire.Server.Console.Proxy.DisplayAdminServiceReference;


namespace Inspire.Server.Console.Proxy
{
    /// <summary>
    /// Server Proxy
    /// </summary>
    public class ServerProxy
    {
        /// <summary>
        /// Send Ping
        /// </summary>
        public static void SendPing()
        {
            EventLogger.Log("Starting ping sequence", EventLogEntryType.Information);
            try
            {
                DisplayAdminServiceContractClient client = new DisplayAdminServiceContractClient();
                client.PingDisplays();
            }
            catch (Exception e)
            {
                EventLogger.Log("Error occoured while sending ping" + Environment.NewLine + e.Message, EventLogEntryType.Error);
            }

            EventLogger.Log("Ping sequence ended", EventLogEntryType.Information);
        }



        /// <summary>
        /// Send Update
        /// </summary>
        public static void SendUpdate()
        {
            EventLogger.Log("Sending daily update", EventLogEntryType.Information);

            try
            {
                DisplayAdminServiceContractClient client = new DisplayAdminServiceContractClient();
                client.UpdateDisplays();
            }
            catch (Exception e)
            {
                EventLogger.Log("Error sending daily update" + Environment.NewLine + e.Message, EventLogEntryType.Error);
            }

            EventLogger.Log("Daily update completed", EventLogEntryType.Information);
        }

         /// <summary>
        /// Send Update
        /// </summary>
        public static void CheckAndSendUpdate()
        {
            EventLogger.Log("Sending check and update", EventLogEntryType.Information);

            try
            {
                DisplayAdminServiceContractClient client = new DisplayAdminServiceContractClient();
                client.CheckAndUpdateDisplays();
            }
            catch (Exception e)
            {
                EventLogger.Log("Error sending check and update" + Environment.NewLine + e.Message, EventLogEntryType.Error);
            }

            EventLogger.Log("Check and update completed", EventLogEntryType.Information);
        }

    }

    
}
