using System.Configuration;
using System;

namespace Inspire.Server.Console.Events.Proxy
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class EventTimer
    {
        private System.Timers.Timer _Timer;
        private double eventInterval;
       
        public int Interval { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventTimer()
        {
            eventInterval = 60000 * Convert.ToDouble(ConfigurationManager.AppSettings["EventInterval"]);
                
            Name = "";
            this._Timer = new System.Timers.Timer();
            this._Timer.Elapsed += new
                System.Timers.ElapsedEventHandler(_Timer_Elapsed);
            this._Timer.Enabled = false;
            this._Timer.Interval = eventInterval;
            
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
            EventsProxy.LoadEvents();
        }
    }
}