using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using FlightInfoModule.Proxy;
using Inspire;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for DoublePaneFlightPanel.xaml
    /// </summary>
    public partial class DoublePaneFlightPanel : IWeakEventListener, IPlayable, IFlightPanel, IDisposable
    {
        private List<Flight> _templatedFlights = new List<Flight>();
        private double _loadedHeight;
        private bool _isPlaying;
        private bool _isLoaded;
        // private int _totalFlights;
        private int _flightsShown;
        private List<Flight> _flights;
        private bool _startAtBeginning;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly double _secondsPerPage;
        private FlightRequest _flightRequest;
        private double _flightHeight;
        private double _headerHeight;
        private readonly StackPanel _stackPanel2;
        private readonly ItemsControl _lv1;
        private readonly StackPanel _stackPanel1;
        private readonly ItemsControl _lv2;
        private bool _reloadFlightsNextCycle;
        private bool _firstLoad;

        private bool _advanceOnEnd;
        private int _advanceAfterLoops;
        private int _loopCount;

        public void ReloadFlightsNextCycle(List<Flight> flights)
        {
            _flights = flights;
            if (!_reloadFlightsNextCycle)
                _reloadFlightsNextCycle = true;
        }

        public void ReloadFlightsNow(List<Flight> flights)
        {
            _templatedFlights = flights;
            _reloadFlightsNextCycle = true;
            _startAtBeginning = true;
            RefreshCollection(false, false);
        }

        public string PanelAnimation { get; set; }

        public TemplatedFlight FlightTemplate { get; set; }


        public DoublePaneFlightPanel()
        {
            InitializeComponent();

            _secondsPerPage = 3;

            _firstLoad = true;

            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(_timer, this);

            var grid = Content as Grid;

            _stackPanel1 = grid.Children[0] as StackPanel;
            _stackPanel2 = grid.Children[1] as StackPanel;

            var scrollPanel = _stackPanel1.Children[1] as ScrollPanelWrapper;
            _lv1 = new ItemsControl { AlternationCount = 2 };
            //_lv1.ItemsPanel = FindResource("panelTemplate") as ItemsPanelTemplate;
            scrollPanel.Content = _lv1;

            var scrollPanel2 = _stackPanel2.Children[1] as ScrollPanelWrapper;
            _lv2 = new ItemsControl { AlternationCount = 2 };
            //_lv2.ItemsPanel = FindResource("panelTemplate") as ItemsPanelTemplate;
            scrollPanel2.Content = _lv2;
        }

        public DoublePaneFlightPanel(double secondsPerPage, TemplatedFlight flightTemplate, string panelAnimation, List<Flight> flights, bool advanceOnEnd, int advanceAfterLoops)
            : this()
        {
            _secondsPerPage = secondsPerPage;
            FlightTemplate = flightTemplate;
            _flights = flights;
            PanelAnimation = panelAnimation;
            _flightHeight = flightTemplate.FlightHeight;
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
            if (_isLoaded) return;

            if (FlightTemplate == null)
                FlightTemplate = new TemplatedFlight();

            headerBorder1.DataContext = FlightTemplate;
            airlineColumn.DataContext = FlightTemplate;
            schedArDepColumn.DataContext = FlightTemplate;
            destinationColumn.DataContext = FlightTemplate;
            statusColumn.DataContext = FlightTemplate;
            flightNumColumn.DataContext = FlightTemplate;

            headerBorder2.DataContext = FlightTemplate;
            airlineColumn2.DataContext = FlightTemplate;
            schedArDepColumn2.DataContext = FlightTemplate;
            destinationColumn2.DataContext = FlightTemplate;
            statusColumn2.DataContext = FlightTemplate;
            flightNumColumn2.DataContext = FlightTemplate;

            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                _timer.Interval = TimeSpan.FromSeconds(_secondsPerPage);
                _timer.Start();
                _isPlaying = true;
            }

            _isLoaded = true;

            Resized();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(LoadNextFlights));
        }

        public void RefreshCollection(bool itemChange, bool refreshCollection)
        {
            _flightHeight = FlightTemplate.FlightHeight;
            _headerHeight = FlightTemplate.HeaderHeight;

            if(refreshCollection)
                _templatedFlights = _flights;

            if (itemChange)
                LoadNextFlights();
            _firstLoad = true;
            _reloadFlightsNextCycle = false;
        }

        public void RefreshItemsTemplate()
        {
            _lv1.Items.Refresh();
            _lv2.Items.Refresh();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            Resized();
            base.OnRenderSizeChanged(sizeInfo);
        }

        private void Resized()
        {
            if (!_isLoaded) return;

            var hHeight = _headerHeight;

            if (!FlightTemplate.ShowHeader)
                hHeight = 0;

            _loadedHeight = ActualHeight - hHeight;//PARTScrollPanel.ActualHeight;

            if (!_isPlaying) //&& !_hasLoadedOnce
                _flightsShown = 0;

            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(LoadNextFlights));
        }

        private void LoadNextFlights()
        {
            if (_reloadFlightsNextCycle && _startAtBeginning)
                RefreshCollection(false, true);

            if (_templatedFlights == null) return;
            int totalFlights = _templatedFlights.Count;
            double totalItemsHight = totalFlights * _flightHeight;

            if (!_firstLoad && (totalItemsHight / 2) <= _loadedHeight) return;

            _firstLoad = false;

            if (_loadedHeight > totalItemsHight)
            {
                _lv1.ItemsSource = _templatedFlights.OrderBy(f => f.Destination.City);
                _lv2.ItemsSource = null;
                _startAtBeginning = true;
            }
            else
            {
                int itemsToFit = (int)(_loadedHeight / _flightHeight);

                bool secondColumnFlights = true;

                if (_flightsShown + itemsToFit > totalFlights)
                {
                    itemsToFit = totalFlights - _flightsShown;

                    if (itemsToFit.Equals(0))
                    {
                        _flightsShown = 0;
                        itemsToFit = (int)(_loadedHeight / _flightHeight);
                    }
                    else
                        secondColumnFlights = false;

                    _startAtBeginning = true;
                }

                _lv1.ItemsSource = _templatedFlights.OrderBy(f => f.Destination.City).ToList().GetRange(
                    _flightsShown,
                    itemsToFit);

                if (secondColumnFlights)
                {
                    _flightsShown = _flightsShown + itemsToFit;

                    if (_flightsShown + itemsToFit > totalFlights)
                    {
                        itemsToFit = totalFlights - _flightsShown;
                        _flightsShown = 0;
                        _startAtBeginning = true;
                    }

                    _lv2.ItemsSource = _templatedFlights.OrderBy(f => f.Destination.City).ToList().GetRange(
                        _flightsShown,
                        itemsToFit);

                    _flightsShown = _flightsShown + itemsToFit;
                }
                else
                {
                    _lv2.ItemsSource = null;
                    _flightsShown = 0;
                    _startAtBeginning = true;
                }
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
                _lv2.ItemsPanel = FindResource(PanelAnimation) as ItemsPanelTemplate;
            }
            catch (Exception)
            {
                _lv1.ItemsPanel = FindResource("EnterTopExitTop-BackEaseInOut") as ItemsPanelTemplate;
                _lv2.ItemsPanel = FindResource("EnterTopExitTop-BackEaseInOut") as ItemsPanelTemplate;
            }

            _timer.Interval = TimeSpan.FromSeconds(_secondsPerPage);
            _timer.Start();
            _isPlaying = true;

        }

        public void Stop()
        {
            _lv1.ItemsPanel = FindResource("designerTemplate") as ItemsPanelTemplate;
            _lv2.ItemsPanel = FindResource("designerTemplate") as ItemsPanelTemplate;
            _timer.Stop();
            _isPlaying = false;
        }

        public bool IsPlaying()
        {
            return _isPlaying;
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
