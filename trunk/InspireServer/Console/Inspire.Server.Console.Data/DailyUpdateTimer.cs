using Inspire.Server.Console.Proxy;
using System.Configuration;
using System;
using Inspire.Server.Console;
using System.Diagnostics;


namespace Inspire.Server.Console.Objects
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class DailyUpdateTimer
    {
        private System.Timers.Timer _Timer;
        private double updateInterval;
        private DateTime updateTime;
        public int Interval { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DailyUpdateTimer()
        {
            updateInterval = 60000;
            DateTime.TryParse(DateTime.Now.ToShortDateString() + " 01:30:00 AM", out updateTime);

            string strUpdateTime = ConfigurationManager.AppSettings["DailyUpdateTime"];

            if (!String.IsNullOrEmpty(strUpdateTime))
            {
                DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + strUpdateTime, out updateTime);
            }

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
            if (DateTime.Now.CompareTo(updateTime) >= 0)
            {    // Add a day to the alarm to reset it for the next day
                RolloverTime();
                ServerProxy.SendUpdate();              
            }
                      
        }

        private void RolloverTime()
        {    // If the user selects a time already passed, it must be for tomorrow
            if (DateTime.Now.TimeOfDay.CompareTo(updateTime.TimeOfDay) > 0) 
            { updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, updateTime.Hour, updateTime.Minute, updateTime.Second); }   
                // Otherwise, set it for today
            else
            { updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, updateTime.Hour, updateTime.Minute, updateTime.Second); }
        }

    }


}