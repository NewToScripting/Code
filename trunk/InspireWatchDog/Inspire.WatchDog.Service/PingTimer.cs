using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace Inspire.WatchDog.Service
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
            pingInterval = 60000 * 2;

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
            AppChecker checker = new AppChecker();

            try
            {
                if (checker.IsApplicationRunning())
                {
                    if (!checker.IsApplicationResponding())
                    {
                        checker.KillApplication();
                        checker.StartApplication();
                    }
                }
                else
                {
                    checker.StartApplication();
                }                
                
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
