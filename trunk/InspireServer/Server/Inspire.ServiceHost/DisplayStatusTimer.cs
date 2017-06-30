using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Inspire.Server.DisplayAdmin.BusinessLogic;


namespace Inspire.ServiceHost
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class DisplayStatusTimer
    {
        private System.Timers.Timer _Timer;
        private double updateInterval;

        public int Interval { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DisplayStatusTimer()
        {
            updateInterval = 60000 * 15;
            //check display status every 15 minutes

            Name = "";
            this._Timer = new System.Timers.Timer();
            this._Timer.Elapsed += new
                System.Timers.ElapsedEventHandler(_Timer_Elapsed);
            this._Timer.Enabled = false;
            this._Timer.Interval = updateInterval;

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
             ResourceAccess.CheckDisplayStatus();  
        }
    }
}
