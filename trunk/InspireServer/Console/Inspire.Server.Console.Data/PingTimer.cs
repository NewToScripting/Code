using System.Configuration;
using Inspire.Server.Console.Proxy;
using System;

namespace Inspire.Server.Console.Objects
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class PingTimer
    {
        private System.Timers.Timer _Timer;
        private double pingInterval;
       
        public int Interval { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PingTimer()
        {
            pingInterval = 60000 * Convert.ToDouble(ConfigurationManager.AppSettings["PingInterval"]);
                
            Name = "";
            this._Timer = new System.Timers.Timer();
            this._Timer.Elapsed += new
                System.Timers.ElapsedEventHandler(_Timer_Elapsed);
            this._Timer.Enabled = false;
            this._Timer.Interval = pingInterval;
            
        }

        /// <summary>
        /// Start the timer.
        /// </summary>
        public void StartTimer()
        {
            this._Timer.Enabled = true;
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        public void StopTimer()
        {
            this._Timer.Enabled = false;
        }


        /*
         * Respond to the _Timer elapsed event.
         */
        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ServerProxy.SendPing();
        }
    }
}