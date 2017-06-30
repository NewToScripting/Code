using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Inspire.Display.Service.BusinessLogic;

namespace Inspire.Display.Service
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class UpdateTimer
    {
        private System.Timers.Timer _Timer;
        private double updateInterval;

        public int Interval { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateTimer()
        {
            updateInterval = 60000 * Convert.ToDouble(ConfigurationManager.AppSettings["updateInterval"]);

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

            if (SlideFolderAccess.CheckForScheduleFile())
                {
                     ResourceAccessFasade.GetSmartUpdate(System.Environment.MachineName);
                }
            else
                {
                    ResourceAccessFasade.GetHardUpdate(System.Environment.MachineName, false);                   
                }

            
        }
    }
}
