using System;
using System.ServiceProcess;

namespace Inspire.Server.Console.Interface
{
    /// <summary>
    /// Service Admin
    /// </summary>
    public class ServiceAdmin
    {
        /// <summary>
        /// Starts Service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        static public string StartService(ServiceController service)
        {
            try
            {
                if (!(service.Status == ServiceControllerStatus.Running || service.Status == ServiceControllerStatus.StartPending))
                {
                    service.Start();
                    service.Refresh();
                    return "Service started";
                }
                return "Could not start service...";
            }
            catch (Exception)
            {
                return "Error starting service...";
            }
        }

        /// <summary>
        /// Stops Service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        static public string StopService(ServiceController service)
        {
            try
            {
                if (!(service.Status == ServiceControllerStatus.StopPending || service.Status == ServiceControllerStatus.Stopped))
                {
                    service.Stop();
                    service.Refresh();
                    return "Service stopped";
                }
                return "Could not stop service...";
            }
            catch (Exception)
            {
                return "Error stopping service...";
            }
        }

    }
}
