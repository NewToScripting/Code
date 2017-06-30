using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace Inspire.ServiceHost
{

    using System.ComponentModel;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Configuration;
    using System.Configuration.Install;

    public partial class ServiceHostHandler : ServiceBase
    {
        public ServiceHost DirectionService = null;
        public ServiceHost GroupsService = null;
        public ServiceHost ImageService = null;
        public ServiceHost ImageWebGetService = null;
        public ServiceHost RoomsService = null;
        public ServiceHost EventService = null;
       
        public ServiceHostHandler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (DirectionService != null) { DirectionService.Close(); }
            if (GroupsService != null) { GroupsService.Close(); }
            if (ImageService != null) { ImageService.Close(); }
            if (ImageWebGetService != null) { ImageWebGetService.Close(); }
            if (RoomsService != null) { RoomsService.Close(); }
            if (EventService != null) { EventService.Close(); }
         
            DirectionService = new ServiceHost(typeof(Inspire.Server.Direction.ServiceImplementation.DirectionService));
            GroupsService = new ServiceHost(typeof(Inspire.Server.Groups.ServiceImplementation.GroupsService));
            ImageService = new ServiceHost(typeof(Inspire.Server.Images.ServiceImplementation.ImageService));
            ImageWebGetService = new ServiceHost(typeof(Inspire.Server.Images.ServiceImplementation.ImageWebGetService));
            RoomsService = new ServiceHost(typeof(Inspire.Server.Rooms.ServiceImplementation.RoomsService));
            EventService = new ServiceHost(typeof(Inspire.Server.Events.ServiceImplementation.EventService));

            DirectionService.Open();
            GroupsService.Open();
            ImageWebGetService.Open();
            ImageService.Open();
            RoomsService.Open();
            EventService.Open();


         }

        protected override void OnStop()
        {

            DirectionService.Close();
            GroupsService.Close();
            ImageService.Close();
            ImageWebGetService.Close();
            RoomsService.Close();
            EventService.Close();

        }
    }
}
