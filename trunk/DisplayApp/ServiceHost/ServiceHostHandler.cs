using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;



namespace ServiceHost
{
    using System.ComponentModel;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Configuration;
    using System.Configuration.Install;
    

    public partial class ServiceHostHandler : ServiceBase
    {

        public ServiceHost DisplayService = null;

        public ServiceHostHandler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (DisplayService != null) { DisplayService.Close(); }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            DisplayService = new ServiceHost(typeof(Inspire.DisplayService.ServiceImplementation.DisplayService));

            DisplayService.Open();

        }

        protected override void OnStop()
        {
            DisplayService.Close();
        }
    }
}
