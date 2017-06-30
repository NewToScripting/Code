using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FlightInfoModule.Commands;
using FlightInfoModule.Proxy;
using System.Collections.ObjectModel;
using IdentityMine.Windows.Panels;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using System.Windows.Threading;
using Inspire;


namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for FlightPanel.xaml
    /// </summary>
    public partial class FlightPanel : IWeakEventListener, IPlayable, IFlightPanel, IDisposable
    {
        private List<Flight> _templatedFlights = new List<Flight>();
        private double _loadedHeight;
        private bool _isPlaying;
        private bool _isLoaded;
        private bool _startAtBeginning;
        private int _flightsShown;
        private readonly ItemsControl _lv1;
        private readonly System.Windows.Controls.DockPanel _dockPanel;
        private double _flightHeight;
        private List<Flight> _flights;
        private bool _firstLoad;

        private bool _advanceOnEnd;
        private int _advanceAfterLoops;
        private int _loopCount;


        public string PanelAnimation { get; set; }

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private readonly double _secondsPerPage = 8.0;

        public bool IsTouchscreen { get; set; }

        public TemplatedFlight FlightTemplate { get; set; }

        private ObservableCollection<Flight> _flightCollection;

        readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private double _headerHeight;
        private bool _reloadFlightsNextCycle;

        public void ReloadFlightsNextCycle(List<Flight> flights)
        {
            _flights = flights;
            if (!_reloadFlightsNextCycle)
                _reloadFlightsNextCycle = true;
        }

        public void ReloadFlightsNow(List<Flight> flights)
        {
            _firstLoad = true;
            _templatedFlights = flights;
            _timer.Interval = TimeSpan.FromSeconds(_secondsPerPage);
            _timer.Start();
            _reloadFlightsNextCycle = false;
            RefreshCollection(true, false);
            _startAtBeginning = true;
            //_reloadFlightsNextCycle = true;
        }

        public FlightPanel()
        {
            InitializeComponent();

            backgroundWorker.DoWork += backgroundWorker_DoWork;

            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(_timer, this);

            _firstLoad = true;

            _dockPanel = Content as System.Windows.Controls.DockPanel;

            var scrollPanel = _dockPanel.Children[2] as ScrollPanelWrapper;
            _lv1 = new ItemsControl { AlternationCount = 2 };
            //_lv1.ItemsPanel = FindResource("panelTemplate") as ItemsPanelTemplate;
            _lv1.DataContext = FlightTemplate;
            scrollPanel.Content = _lv1;
            var touchscreenButton = _dockPanel.Children[1] as FrameworkElement;
            touchscreenButton.DataContext = this;
        }

        public FlightPanel(double secondsPerPage, bool isTouchscreen, TemplatedFlight flightTemplate, string panelAnimation, List<Flight> flights, bool advanceOnEnd, int advanceAfterLoops)
            : this()
        {
            IsTouchscreen = isTouchscreen;
            _secondsPerPage = secondsPerPage;
            FlightTemplate = flightTemplate;
            PanelAnimation = panelAnimation;
            _flights = flights;
            // _flightHeight = FlightTemplate.FlightHeight;

            _advanceOnEnd = advanceOnEnd;
            _advanceAfterLoops = advanceAfterLoops;
        }

        public FlightPanel(TemplatedFlight templatedFlight, string panelAnimation, List<Flight> flights, bool advanceOnEnd, int advanceAfterLoops)
            : this()
        {
            IsTouchscreen = true;

            FlightTemplate = templatedFlight;
            PanelAnimation = panelAnimation;
            _flights = flights;
            _advanceOnEnd = advanceOnEnd;
            _advanceAfterLoops = advanceAfterLoops;
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                FlightControlLoaded(sender, e);
                return true;
            }
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                TimerTick(sender, e);
                return true;
            }
            return false;
        }

        private void FlightControlLoaded(object sender, EventArgs eventArgs)
        {
            if (!_isLoaded)
            {
                if (FlightTemplate == null)
                    FlightTemplate = new TemplatedFlight();

                SetDataContext();

                if ((InspireApp.IsPlayer || InspireApp.IsPreviewMode) && !IsTouchscreen)
                {
                    Play();
                    if (!backgroundWorker.IsBusy)
                        backgroundWorker.RunWorkerAsync();
                }

                _isLoaded = true;

                Resized();
            }
        }

        public void RefreshItemsTemplate()
        {
            //_templatedFlights = new List<TemplatedFlight>(TemplatedFlight.ConverToTemplatedFlights(flights, FlightTemplate));
            _lv1.Items.Refresh();
        }

        public void SetDataContext()
        {
            var border = _dockPanel.Children[0] as Border;
            border.DataContext = FlightTemplate;
            var stackPanel = border.Child as System.Windows.Controls.StackPanel;

            foreach (FrameworkElement f in stackPanel.Children)
            {
                f.DataContext = FlightTemplate;
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                                             LoadNextFlights));
        }

        private void TimerTick(object sender, EventArgs e)
        {
            try
            {
                if (!IsVisible)
                {
                    Dispose();
                }
                else
                {
                    if (!backgroundWorker.IsBusy)
                        backgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception)
            {
                // Block Exception
            }

        }

        public void RefreshCollection(bool itemChange, bool updateCollection)
        {
            _flightHeight = FlightTemplate.FlightHeight;
            _headerHeight = FlightTemplate.HeaderHeight;

            if (updateCollection)
            {
                if (_flights != null)
                    _templatedFlights = _flights;
            }

            if (itemChange)
            {
                _flightsShown = 0;
                LoadNextFlights();
                _firstLoad = true;
            }

            //_reloadFlightsNextCycle = false;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            Resized();
            base.OnRenderSizeChanged(sizeInfo);
        }

        private void Resized()
        {
            if (_isLoaded)
            {
                var hHeight = _headerHeight;

                if (!FlightTemplate.ShowHeader)
                    hHeight = 0;

                _loadedHeight = ActualHeight - hHeight - PART_BackButton.ActualHeight;

                if (!_isPlaying)//&& !_hasLoadedOnce
                {
                    _flightsShown = 0;

                    if (!backgroundWorker.IsBusy)
                        backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void LoadNextFlights()
        {
            if (_reloadFlightsNextCycle && _startAtBeginning)
                RefreshCollection(false, true);

            if (_templatedFlights == null) return;
            int totalFlights = _templatedFlights.Count;
            double totalItemsHight = totalFlights * _flightHeight;
            _startAtBeginning = false;

            //if ((_loadedHeight > totalItemsHight || IsTouchscreen) && !_firstLoad) return;

            if (_loadedHeight > totalItemsHight || IsTouchscreen)
            {
                _flightCollection = new ObservableCollection<Flight>(_templatedFlights.OrderBy(f => f.Destination.City));
                _startAtBeginning = true;
                _reloadFlightsNextCycle = true;
      
            }
            else
            {
                int itemsToFit = (int)(_loadedHeight / _flightHeight);

                if (_flightsShown + itemsToFit > totalFlights)
                {
                    itemsToFit = totalFlights - _flightsShown;

                    if (itemsToFit < 1)
                    {
                        _flightsShown = 0;
                        itemsToFit = (int)(_loadedHeight / _flightHeight);
                        _reloadFlightsNextCycle = true;
                        RefreshCollection(false, true);
                    }
                    _startAtBeginning = true;
                    
                }

                _flightCollection = new ObservableCollection<Flight>(_templatedFlights.OrderBy(f => f.Destination.City).ToList().GetRange(
                    _flightsShown,
                    itemsToFit));

                _flightsShown = _flightsShown + itemsToFit;
            }

            _firstLoad = false;


            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                                             () => _lv1.ItemsSource = _flightCollection));
            }
            catch (Exception)
            {
                // Block Exception
            }

        }


        public void RePopulateBasedOnSize(SizeChangedInfo sizeChangedInfo)
        {
            Resized();
        }

        public void Play()
        {
            try
            {
                _lv1.ItemsPanel = FindResource(PanelAnimation) as ItemsPanelTemplate;
            }
            catch (Exception)
            {
                _lv1.ItemsPanel = FindResource("EnterTopExitTop-BackEaseInOut") as ItemsPanelTemplate;
            }

            _timer.Interval = TimeSpan.FromSeconds(_secondsPerPage);
            _timer.Start();
            _isPlaying = true;

        }

        public void Stop()
        {
            _lv1.ItemsPanel = FindResource("designerTemplate") as ItemsPanelTemplate;
            _timer.Stop();
            _isPlaying = false;
        }

        public bool IsPlaying()
        {
            return _isPlaying;
        }

        private void PART_BackButton_Click(object sender, RoutedEventArgs e)
        {
            FlightModuleCommands.ShowAirlinesCommand.Execute(null, (ContentControl)Parent);
        }

        public void Dispose()
        {
            try
            {
                if (_timer != null)
                    _timer.Stop();
                ClearValue(ContentProperty);

            }
            catch
            {

            }

        }
    }
}
