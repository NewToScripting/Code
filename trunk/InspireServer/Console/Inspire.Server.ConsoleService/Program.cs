using System.ServiceProcess;

namespace Inspire.Server.Console.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new InspireConsoleService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
