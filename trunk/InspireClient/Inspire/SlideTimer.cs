using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Threading;

namespace Inspire
{
    //public class NotifySlideTimer : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private DateTime _timer;

    //    public NotifySlideTimer()
    //    {
    //        _timer = DateTime.Today.Date;

    //        DispatcherTimer timer = new DispatcherTimer();
    //        timer.Interval = TimeSpan.FromMilliseconds(100);
    //        timer.Tick += timer_Tick;
    //        timer.Start();
    //    }

    //    void timer_Tick(object sender, EventArgs e)
    //    {
    //        SlideTimer = _timer;
    //    }

    //    public DateTime SlideTimer
    //    {
    //        get{ return _timer; }
    //        set
    //        { 
    //            _timer = value;
    //            if(PropertyChanged!= null)
    //                PropertyChanged(this,new PropertyChangedEventArgs("SlideTimer"));
            
    //        }
    //    }

    //}
}
