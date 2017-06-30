using System;
using System.ComponentModel;
//using System.Threading;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;
using Timer = System.Timers.Timer;

namespace WeatherModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public class WeatherContentControl : ContentControl, IWeakEventListener, IDisposable
    {

        public Location Location { get; set; }

        public string WeatherStyle { get; set; }

        public string DegreeType { get; set; }

        private bool isLoaded = false;

        private Timer _timer;

        BackgroundWorker _backgroundWorker;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Placeholder
        {
            set { Content = value; }
        }

        public WeatherContentControl()
        {
            LoadedEventManager.AddListener(this, this);
        }

        ~WeatherContentControl()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                try
                {
                    if (Content is LoadingControl)
                        ((LoadingControl)Content).Dispose();

                    if (InspireApp.IsPlayer ||
                        InspireApp.IsPreviewMode)
                    {
                        Dispose();
                    }
                }
                catch
                {

                }
            }));
            //MessageBox.Show("RSS Gone");
        }

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                if (_timer != null)
                {
                    _timer.Stop();
                    _timer.Elapsed -= _timer_Elapsed;
                    _timer = null;
                }

                if(_backgroundWorker != null)
                {
                    _backgroundWorker.DoWork -= _backgroundWorker_DoWork;
                    _backgroundWorker = null;
                }

                Placeholder = null;

                ClearValue(ContentProperty);
            }));
        }

        void WeatherContentControl_Loaded(object sender, EventArgs e)
        {
            
            if (!isLoaded)
            {
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += _backgroundWorker_DoWork;

                _timer = new Timer(60000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();

                Placeholder = new LoadingControl();
                PopulateControl();
                isLoaded = true;
            }
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {

                if (Content is WeatherControl &&
                    !((WeatherControl) Content).
                        IsWeatherPopulated)
                    PopulateControl();
            }));
        }

        private void PopulateControl()
        {
            try
            {
                if (!_backgroundWorker.IsBusy)
                    _backgroundWorker.RunWorkerAsync();
            }
            catch
            {
            }
            
        }

        public WeatherContentControl(Location location, string weatherstyle, string type)
            : this()
        {
            DegreeType = "f";

            if (!string.IsNullOrEmpty(weatherstyle))
                WeatherStyle = weatherstyle;

            if (!string.IsNullOrEmpty(type))
                DegreeType = type;

            Location = location;

        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var weatherControl = new WeatherControl(Location, DegreeType);

            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(delegate
            {

                Resources =
                    new ResourceDictionary
                    {
                        Source =
                            new Uri(
                            "pack://application:,,,/WeatherModule;component/Resources/" +
                            WeatherStyle + ".xaml")
                        //"pack://application:,,,/WeatherModule;component/Resources/3Day.xaml")
                    };
                Placeholder = weatherControl;
            }));
        }


        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                WeatherContentControl_Loaded(sender, e);
                return true;
            }
            return false;
        }
    }
}
