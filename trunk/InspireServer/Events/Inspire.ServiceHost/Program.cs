﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Inspire.ServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ConfigEncrypt.Encrypt();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new ServiceHostHandler() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
