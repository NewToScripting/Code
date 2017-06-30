using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Services.WeakEventHandlers;

namespace DateTimeModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ClockControl : IWeakEventListener, IDisposable
    {

        #region DateTimeFormat dependency property

        /// <summary>
        /// Integer Representing the DateTimeFormat of the Time Control
        /// </summary>
        public static readonly DependencyProperty DateTimeFormatProperty;

        static ClockControl()
        {
            //register dependency property
            FrameworkPropertyMetadata md = new FrameworkPropertyMetadata(0);
            DateTimeFormatProperty = DependencyProperty.Register("DateTimeFormat", typeof (int), typeof (ClockControl), md); 
        }

        /// <summary>
        /// A property wrapper for the <see cref="DateTimeFormatProperty"/>
        /// dependency property:<br/>
        /// Integer Representing the DateTimeFormat of the Time Control
        /// </summary>
        public int DateTimeFormat
        {
            get { return (int) GetValue(DateTimeFormatProperty); }
            set {
                    SetValue(DateTimeFormatProperty, value);
                    SetStyle(value);
                }
        }

        #endregion

        private bool _isLoaded;


        public ClockControl()
        {
            InitializeComponent();

            LoadedEventManager.AddListener(this, this);
        }

        //~ClockControl()
        //{
        //    MessageBox.Show("Clock Control Gone");
        //}

        void ClockControl_Loaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                SetStyle(DateTimeFormat);
                _isLoaded = true;
            }
        }

        public ClockControl(int i, object clockTextBlock)
        {
            InitializeComponent();

            var clock = clockTextBlock as Clock;
            {
                if (clock != null)
                {
                    var newClock = new Clock
                                       {
                                           FontSize = clock.FontSize,
                                           FontFamily = clock.FontFamily,
                                           Foreground = clock.Foreground,
                                           FontStyle = clock.FontStyle,
                                           FontWeight = clock.FontWeight,
                                           TextDecorations = clock.TextDecorations
                                       };
                    Content = newClock;
                }
            }

            
            DateTimeFormat = i;
        }

        private void SetStyle(int i)
        {
            var clock = Content as Clock;
            if (clock != null)
            {
                clock.ChangeTimer(i);
                switch (i)
                {
                    case (0):
                        clock.Style = FindResource("shortTimeKey") as Style;
                        break;
                    case (1):
                        clock.Style = FindResource("longTimeKey") as Style;
                        break;
                    case (2):
                        clock.Style = FindResource("shortDateKey") as Style;
                        break;
                    case (3):
                        clock.Style = FindResource("fullDateKey") as Style;
                        break;
                }
            }
        }

        public IDictionary<int, string> GetFormats()
        {
            IDictionary<int, string> formats = new Dictionary<int, string>();

            formats.Add(0, "12:00 am");
            formats.Add(1, "12:00:00 am");
            formats.Add(2, "01/01/2000");
            formats.Add(3, "Monday, January 1, 2009");

            return formats;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ClockControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        public void Dispose()
        {
            ClearValue(ContentProperty);
        }
    }
}
