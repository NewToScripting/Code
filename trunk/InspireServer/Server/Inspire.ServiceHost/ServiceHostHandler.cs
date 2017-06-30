using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Inspire.ServiceHost
{
    using System.ComponentModel;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Configuration;
    using System.Configuration.Install;
 
      public partial class ServiceHostHandler : ServiceBase
    {

        public ServiceHost ScheduleManagerService = null;
        public ServiceHost ClientDisplayService = null;
        public ServiceHost ClientDisplayPropertiesService = null;
        public ServiceHost ClientDisplayGroupsService = null;
        public ServiceHost SlideManagerService = null;
        public ServiceHost SlideFileManagerService = null;
        public ServiceHost ScheduledSlideManagerService = null;
        public ServiceHost UserService = null;
        public ServiceHost DisplayAdminService = null;
        public ServiceHost SettingService = null;

        private DisplayStatusTimer displayStatusTimer;
        private Thread workerThread;

        public ServiceHostHandler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            if (ScheduleManagerService != null) { ScheduleManagerService.Close(); }
            if (ClientDisplayService != null) { ClientDisplayService.Close(); }
            if (ClientDisplayPropertiesService != null) { ClientDisplayPropertiesService.Close(); }
            if (ClientDisplayGroupsService != null) { ClientDisplayGroupsService.Close(); }
            if (SlideManagerService != null) { SlideManagerService.Close(); }
            if (SlideFileManagerService != null) { SlideFileManagerService.Close(); }
            if (ScheduledSlideManagerService != null) { ScheduledSlideManagerService.Close(); }
            if (UserService != null) { UserService.Close(); }
            if (DisplayAdminService != null) { DisplayAdminService.Close(); }
            if (SettingService != null) { SettingService.Close(); }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            ScheduleManagerService = new ServiceHost(typeof(Inspire.Server.ScheduleManager.ServiceImplementation.ScheduleManagerService));
            ClientDisplayService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayService));
            ClientDisplayPropertiesService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayPropertiesService));
            ClientDisplayGroupsService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayGroupsService));

            //Had to reference the Slide Manager DLL in the bin forlder for some reason, not the project...was giving error...
            SlideManagerService = new ServiceHost(typeof(Inspire.Server.SlideManager.ServiceImplementation.SlideManagerService));
            SlideFileManagerService = new ServiceHost(typeof(Inspire.Server.SlideManager.ServiceImplementation.SlideFileManagerService));

            ScheduledSlideManagerService = new ServiceHost(typeof(Inspire.Server.ScheduledSlideManager.ServiceImplementation.ScheduledSlideManagerService));
            UserService = new ServiceHost(typeof(Inspire.Users.ServiceImplementation.UserService));
            DisplayAdminService = new ServiceHost(typeof(Inspire.Server.DisplayAdmin.ServiceImplementation.DisplayAdminService));
            SettingService = new ServiceHost(typeof(Inspire.Settings.ServiceImplementation.SettingService));


            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            ScheduleManagerService.Open();
            ClientDisplayService.Open();
            ClientDisplayPropertiesService.Open();
            ClientDisplayGroupsService.Open(); 
            SlideManagerService.Open(); 
            SlideFileManagerService.Open();
            ScheduledSlideManagerService.Open();
            UserService.Open();
            DisplayAdminService.Open();
            SettingService.Open();

            //Windows Service Timer for updates);
            this.displayStatusTimer = new DisplayStatusTimer();
            this.displayStatusTimer.Name = "DisplayStatusTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.displayStatusTimer.StartTimer));
            this.workerThread.Start();

            
        }

        protected override void OnStop()
        {
            ScheduleManagerService.Close();
            ClientDisplayService.Close();
            ClientDisplayPropertiesService.Close();
            ClientDisplayGroupsService.Close();
            SlideManagerService.Close();
            SlideFileManagerService.Close();
            ScheduledSlideManagerService.Close();
            UserService.Close();
            DisplayAdminService.Close();
            SettingService.Close();

            this.displayStatusTimer.StopTimer();
        }
    }
}
