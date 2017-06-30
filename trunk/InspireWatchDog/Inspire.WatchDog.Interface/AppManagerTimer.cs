using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace Inspire.WatchDog.Interface
{
    /// <summary>
    /// Demonstrate the use of a timer.
    /// </summary>
    public class AppManagerTimer
    {
        private System.Timers.Timer _Timer;
        private double pingInterval;
        private ConfigHelper configHelper;
        private DateTime updateTime;
        private bool failedLastCheck;
        public int Interval { get; set; }
        public string Name { get; set; }

        AppManager app;

        /// <summary>
        /// Constructor
        /// </summary>
        public AppManagerTimer()
        {
            configHelper = new ConfigHelper();
            updateTime = configHelper.GetSleepRebootTime();
            //Gets time and current day...
            updateTime = updateTime.AddDays(1);
            //Add a day...do not restart until a day after
            //the application has begun, on the given time.

            pingInterval = 60000;
            failedLastCheck = false;
            //pings every minutes

            Name = "";
            this._Timer = new System.Timers.Timer();
            this._Timer.Elapsed += new
                System.Timers.ElapsedEventHandler(_Timer_Elapsed);
            this._Timer.Enabled = false;
            this._Timer.Interval = pingInterval;

            app = new AppManager();
           
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

       /// <summary>
       /// Timer Elapsed
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!BiHourlyReset())//CHeck for hourly reboot first
                {
                    if (!DailyReboot()) //Do not check the app status because we just restarted
                        {
                            CheckAppStatus();
                        }
                }
                       
        }//_Timer_Elapsed

        /// <summary>
        /// Moves restart time to the next day if time has passed
        /// </summary>
        private void RolloverTime()
        {    // If the user selects a time already passed, it must be for tomorrow
            if (DateTime.Now.TimeOfDay.CompareTo(updateTime.TimeOfDay) > 0) 
            { 
                updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, updateTime.Hour, updateTime.Minute, updateTime.Second); 
            }   
                // Otherwise, set it for today
            else
            { 
                updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, updateTime.Hour, updateTime.Minute, updateTime.Second); 
            }
        }

        /// <summary>
        /// This checks the application status and restarts if needed
        /// </summary>
        private void CheckAppStatus()
        {  
           try
            {
                if (app.CheckAndKillErrorScreen())
                {
                    EventLogger.Log("Inspire display had error on screen...restarting app to remove error screen", EventLogEntryType.Error);
                    System.Threading.Thread.Sleep(1000);
                    app.KillApplication();
                    app.StartApplication();
                }
                else
                {
             
                    if (app.IsApplicationRunning())
                    {
                        if (!app.IsApplicationResponding())
                        {
                            if (failedLastCheck)
                            {
                                EventLogger.Log("Inspire display is not responding...restarting", EventLogEntryType.Error);
                                app.KillApplication();
                                app.StartApplication();
                                EventLogger.Log("Inspire display restarted", EventLogEntryType.Information);
                                failedLastCheck = false;
                            }
                            else
                            {
                                EventLogger.Log("Inspire display is not responding...waiting 30 seconds", EventLogEntryType.Warning);
                                failedLastCheck = true;
                            }
                        }
                        else
                        {
                            failedLastCheck = false;
                        }                                        
                }
                else
                {
                    EventLogger.Log("Inspire display is not running...starting ", EventLogEntryType.Error);
                    app.StartApplication();
                    EventLogger.Log("Inspire display started", EventLogEntryType.Information);
                    failedLastCheck = false;
                   
                }
              }
            }
            catch (Exception ex)
            {
                EventLogger.Log("Error occoured while checking/starting client " + ex.Message, EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Daily Reboot
        /// </summary>
        /// <returns></returns>
        private bool DailyReboot()
        {
           try
            {
                if (configHelper.DailyReboot())
                {
                    if (DateTime.Now.CompareTo(updateTime) >= 0)
                    {    // Add a day to the alarm to reset it for the next day
                        RolloverTime();
                        EventLogger.Log("Starting daily reboot", EventLogEntryType.Information);
                        app.SleepAndRestartApplication();
                        EventLogger.Log("Ending daily reboot", EventLogEntryType.Information);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }             
                
            }
            catch (Exception ex)
            {
                EventLogger.Log("Error occoured during daily restart " + ex.Message, EventLogEntryType.Error);
                return false;                
            }
        }

        /// <summary>
        /// Bi-Hourly reboot on odd hours
        /// </summary>
        /// <returns></returns>
        private bool BiHourlyReset()
        {
            if (configHelper.BiHourlyReboot())
            {
                if (DateTime.Now.TimeOfDay.Minutes == 00 && (DateTime.Now.TimeOfDay.Hours % 2) != 0) //odd hour, no minutes
                {
                    app.SleepAndRestartApplication();
                    EventLogger.Log("Ending bi-hourly re-start", EventLogEntryType.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }



    }//class
}//namespace
