using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;

namespace Inspire
{
    //public class Clock : Control, IWeakEventListener
    //{
    //    private DispatcherTimer timer;

    //    static Clock()
    //    {
    //        //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
    //        //This style is defined in themes\generic.xaml
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
    //    }

    //    protected override void OnInitialized(EventArgs e)
    //    {
    //        base.OnInitialized(e);

    //        UpdateDateTime();

    //        timer = new DispatcherTimer();
    //        timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
    //        DispatcherTimerTickEventManager.AddListener(timer, this);
    //        timer.Start();
    //    }

    //    private void Timer_Tick(object sender, EventArgs e)
    //    {
    //        UpdateDateTime();

    //        timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
    //        timer.Start();
    //    }

    //    private void UpdateDateTime()
    //    {
    //        DateTime = DateTime.Now;
    //    }

    //    #region DateTime property
    //    public DateTime DateTime
    //    {
    //        get
    //        {
    //            return (DateTime)GetValue(DateTimeProperty);
    //        }
    //        private set
    //        {
    //            SetValue(DateTimeProperty, value);
    //        }
    //    }

    //    public static DependencyProperty DateTimeProperty = DependencyProperty.Register(
    //            "DateTime",
    //            typeof(DateTime),
    //            typeof(Clock),
    //            new PropertyMetadata(DateTime.Now, OnDateTimeInvalidated));

    //    public static readonly RoutedEvent DateTimeChangedEvent =
    //        EventManager.RegisterRoutedEvent("DateTimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(Clock));

    //    protected virtual void OnDateTimeChanged(DateTime oldValue, DateTime newValue)
    //    {
    //        RoutedPropertyChangedEventArgs<DateTime> args = new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue);
    //        args.RoutedEvent = DateTimeChangedEvent;
    //        RaiseEvent(args);
    //    }

    //    private static void OnDateTimeInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        Clock clock = (Clock)d;

    //        DateTime oldValue = (DateTime)e.OldValue;
    //        DateTime newValue = (DateTime)e.NewValue;

    //        clock.OnDateTimeChanged(oldValue, newValue);
    //    }
    //    #endregion

    //    #region IWeakEventListener Members

    //    public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
    //    {
    //        if (managerType == typeof(DispatcherTimerTickEventManager))
    //        {
    //            Timer_Tick(sender, e);
    //            return true;
    //        }
    //        return false;
    //    }

    //    #endregion
    //}
}
