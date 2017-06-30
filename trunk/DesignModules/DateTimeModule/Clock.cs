using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;

namespace DateTimeModule
{
    public class Clock : TextBox, IWeakEventListener
    {
        private DispatcherTimer timer;

        public static DependencyProperty DateTimeFormatProperty = DependencyProperty.Register(
                "DateTimeFormat",
                typeof(DTFormat),
                typeof(Clock), null);


        public DTFormat DateTimeFormat
        {
            get
            {
                return (DTFormat)GetValue(DateTimeFormatProperty);
            }
            set
            {
                //if (value == DTFormat.Time)
                //{
                //    Style = FindResource("shortTimeKey") as Style;
                //}
                SetValue(DateTimeFormatProperty, value);  
            }
        }

        static Clock()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            UpdateDateTime();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
            DispatcherTimerTickEventManager.AddListener(timer, this);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();

            timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
            timer.Start();
        }

        private void UpdateDateTime()
        {
            DateTime = DateTime.Now;
        }

        #region DateTime property
        public DateTime DateTime
        {
            get
            {
                return (DateTime)GetValue(DateTimeProperty);
            }
            private set
            {
                SetValue(DateTimeProperty, value);
            }
        }

        public static DependencyProperty DateTimeProperty = DependencyProperty.Register(
                "DateTime",
                typeof(DateTime),
                typeof(Clock),
                new PropertyMetadata(DateTime.Now, OnDateTimeInvalidated));

        public static readonly RoutedEvent DateTimeChangedEvent =
            EventManager.RegisterRoutedEvent("DateTimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(Clock));

        protected virtual void OnDateTimeChanged(DateTime oldValue, DateTime newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime> args = new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue);
            args.RoutedEvent = DateTimeChangedEvent;
            RaiseEvent(args);
        }

        private static void OnDateTimeInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Clock clock = (Clock)d;

            DateTime oldValue = (DateTime)e.OldValue;
            DateTime newValue = (DateTime)e.NewValue;

            clock.OnDateTimeChanged(oldValue, newValue);
        }
        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                Timer_Tick(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        internal void ChangeTimer(int i)
        {
            switch (i)
            {
                case (0):
                    timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
                    timer.Start();
                    break;
                case (1):
                    timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
                    timer.Start();
                    break;
            }
        }
    }

    public enum DTFormat
    {
        Time,
        Date,
        MilitaryTime
    }
}
