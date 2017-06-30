using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Threading;
using System.ServiceModel;

namespace Inspire.Display.Service
{
    public partial class InspireDisplayService : ServiceBase
    {
        private Thread workerThread;
        private UpdateTimer updateTimer;
        private DailyUpdateTimer dailyUpdateTimer;

        public ServiceHost UpdateDisplayService = null;


        public InspireDisplayService()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            //WCF Host stuff
            if (UpdateDisplayService != null) { UpdateDisplayService.Close(); }
            UpdateDisplayService = new ServiceHost(typeof(Inspire.Display.WCF.DisplayService));
            UpdateDisplayService.Open();

            //Windows Service Timer for updates
            this.updateTimer = new UpdateTimer();
            this.updateTimer.Name = "UpdateTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.updateTimer.StartTimer));
            this.workerThread.Start();

            //Windows Service Timer for updates
            this.dailyUpdateTimer = new DailyUpdateTimer();
            this.dailyUpdateTimer.Name = "DailyUpdateTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.dailyUpdateTimer.StartTimer));
            this.workerThread.Start();


        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            UpdateDisplayService.Close();
            this.dailyUpdateTimer.StopTimer();
            this.updateTimer.StopTimer();

        }
    }
}
