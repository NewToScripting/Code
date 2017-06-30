using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
//using Inspire;

namespace WeatherModule.Proxy
{
    //internal static class WeatherLoader
    //{

    //    private static WeatherReport _weatherReport;

    //    private static readonly BackgroundWorker WeatherWorker;

    //    private static readonly Timer GetEventTimer;

    //    private static bool _eventFlag;

    //    private static readonly double UpdateInterval;

    //    static WeatherLoader()
    //    {
    //        if (InspireApp.IsPlayer)
    //        {
    //            _weatherReport = new WeatherReport();

    //            UpdateInterval = SeverSettings.WeatherRefreshInterval * 60000;

    //            _eventFlag = true;

    //            WeatherWorker = new BackgroundWorker();
    //            WeatherWorker.DoWork += EventWorkerDoWork;
    //            WeatherWorker.RunWorkerCompleted += EventWorkerRunWorkerCompleted;
    //            WeatherWorker.RunWorkerAsync();

    //            GetEventTimer = new Timer(UpdateInterval);
    //            GetEventTimer.Elapsed += GetEventTimerElapsed;
    //            GetEventTimer.Start();
    //        }

    //    }

    //    static void GetEventTimerElapsed(object sender, ElapsedEventArgs e)
    //    {
    //        if (_eventFlag)
    //            if (!WeatherWorker.IsBusy)
    //                WeatherWorker.RunWorkerAsync();
    //    }

    //    static void EventWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        _eventFlag = false;
    //        GetEventTimer.Interval = UpdateInterval;
    //    }

    //    static void EventWorkerDoWork(object sender, DoWorkEventArgs e)
    //    {
    //        if(e.Argument is )
    //        var location = e.Argument[0]
    //        var weatherReport = WeatherProxy.GetLatestWeatherReport(_)

    //        if (weatherReport != null)
    //            _weatherReport = weatherReport;
    //    }

    //    internal static WeatherReport GetWeather(Location location, UnitsSystems unitsSystems)
    //    {
            

    //        return _weatherReport;
    //    }
    //}
}
