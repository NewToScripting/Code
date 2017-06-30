using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Inspire.WatchDog.Service
{
    public partial class WatchDogService : ServiceBase
    {
        private Thread workerThread;
        private PingTimer pingTimer;

        public WatchDogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.pingTimer = new PingTimer();
            this.pingTimer.Name = "PingTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.pingTimer.StartTimer));
            this.workerThread.Start();
        }

        protected override void OnStop()
        {
            this.pingTimer.StopTimer();
        }
          
    }
}
