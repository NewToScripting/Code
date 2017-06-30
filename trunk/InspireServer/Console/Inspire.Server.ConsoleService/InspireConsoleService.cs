using System.Threading;
using Inspire.Server.Console.Objects;
using Inspire.Server.Console.Events.Proxy;
using System.Configuration;

namespace Inspire.Server.Console.Service
{ 
    public partial class InspireConsoleService : System.ServiceProcess.ServiceBase
   {
      private string useEvents = ConfigurationManager.AppSettings["UseEvents"];
      private Thread workerThread;
      private PingTimer pingTimer;
      private UpdateTimer updateTimer;
      private DailyUpdateTimer dailyUpdateTimer;
      private EventTimer eventTimer;

      public InspireConsoleService()
      {
         // This call is required by the Windows.Forms Component
         // Designer.
         InitializeComponent();

         // TODO: Add any initialization after the InitComponent
         // call
      }
        
      /// <summary>
      /// Set things in motion so your service can do its work.
      /// </summary>
      protected override void OnStart(string[] args)
      {
            this.pingTimer = new PingTimer();
            this.pingTimer.Name = "PingTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.pingTimer.StartTimer));
            this.workerThread.Start();
          
            this.updateTimer = new UpdateTimer();
            this.updateTimer.Name = "UpdateTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.updateTimer.StartTimer));
            this.workerThread.Start();

            this.dailyUpdateTimer = new DailyUpdateTimer();
            this.dailyUpdateTimer.Name = "DailyUpdateTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.dailyUpdateTimer.StartTimer));
            this.workerThread.Start();
          
          if (useEvents == "True")
          { 
            this.eventTimer = new EventTimer();
            this.eventTimer.Name = "EventTimer";
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.eventTimer.StartTimer));
            this.workerThread.Start();
          }

           
      }

      /// <summary>
      /// Stop this service.
      /// </summary>
      protected override void OnStop()
      {
         this.pingTimer.StopTimer();
         this.updateTimer.StopTimer();
         this.dailyUpdateTimer.StopTimer();
         this.eventTimer.StopTimer();
      }
   }
}
