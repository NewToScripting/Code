using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using FlightInfoModule.Proxy;
using System.ComponentModel;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using System.Windows.Threading;
using Inspire;

namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for FlightPanel.xaml
    /// </summary>
    public class FlightPanelX : ContentControl, IWeakEventListener, IPlayable
    {

        private List<Flight> _flights = new List<Flight>();
        private int _viewableRows = 0;
        private double _loadedHeight;
        private bool _isPlaying;
        private bool _hasLoadedOnce;
        private bool _isLoaded;
        private int _totalFlights;
        private int _flightsShown;
        private int _firstPageFlightTotal;
        private bool _forceRefresh;
        //private ItemsControl LV1;
        //private ScrollPanelWrapper _scrollPanel;

        private readonly DispatcherTimer _timer = new DispatcherTimer();


        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public TextBlock HeaderRow { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TemplatedFlight FlightTemplate { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool IsTouchscreen { get; set; }

        private ObservableCollection<TemplatedFlight> _flightCollection;
        public ObservableCollection<TemplatedFlight> FlightCollection
        {
            get { return _flightCollection; }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public double SecondsPerPage { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double SecondsPerPage
        {
            get { return (double)GetValue(SecondsPerPageProperty); }
            set { SetValue(SecondsPerPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondsPerPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondsPerPageProperty =
            DependencyProperty.Register("SecondsPerPage", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(8.0));



        public FlightPanelX()
        {
            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(_timer, this);

            DataContext = this;
        }

        //public override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();
        //    _scrollPanel = GetTemplateChild("PART_ScrollPanel") as ScrollPanelWrapper;
        //}

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
            if (FlightTemplate == null)
                FlightTemplate = new TemplatedFlight();

            //var itemsControl = GetTemplateChild("PART_ItemsControl") as ItemsControl;

            //_scrollPanel = GetTemplateChild("PART_ScrollPanel") as ScrollPanelWrapper;

            //var grid = Content as Grid;

            //Border headerBorder = grid.Children[0] as Border;

            //headerBorder.DataContext = FlightTemplate;

            //var stackPanel = headerBorder.Child as StackPanel;

            //foreach (FrameworkElement c in stackPanel.Children)
            //{
            //    c.DataContext = FlightTemplate;
            //}

            //PARTScrollPanel = grid.Children[1] as ScrollPanelWrapper;


            //LV1 = PARTScrollPanel.Content as ItemsControl;

            //airlineColumn.DataContext = FlightTemplate;
            //schedArDepColumn.DataContext = FlightTemplate;
            //destinationColumn.DataContext = FlightTemplate;
            //statusColumn.DataContext = FlightTemplate;
            //flightNumColumn.DataContext = FlightTemplate;

            GetFlights();

            if (!_isLoaded)
            {
                if ((InspireApp.IsPlayer || InspireApp.IsPreviewMode) && !IsTouchscreen)
                {
                    Play();
                }

                _isLoaded = true;
                Resized();
            }

            DataContext = this;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LoadNextFlights();
        }

        private void GetFlights()
        {
            FlightRequest flightReq = new FlightRequest();

            flightReq.FID = "34b64945a69b9cac:790015b0:1271c50d09a:3a0";

            _flights = FlightInfoProxy.GetFlights(flightReq);

            _flightCollection = new ObservableCollection<TemplatedFlight>(TemplatedFlight.ConverToTemplatedFlights(_flights, FlightTemplate));

            _totalFlights = _flights.Count;
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
                _loadedHeight = ActualHeight - FlightTemplate.FlightHeight;

                if (!_isPlaying)//&& !_hasLoadedOnce
                {
                    _flightsShown = 0;

                    LoadNextFlights();
                }
            }
        }

        private void LoadNextFlights()
        {

            double totalItemsHight = _flights.Count * FlightTemplate.FlightHeight;

            if (_loadedHeight > totalItemsHight || IsTouchscreen)
            {
                _flightCollection.OrderBy(f => f.Flight.Destination.City);
                //_flightCollection = new ObservableCollection<TemplatedFlight>(_flightCollection.OrderBy(f => f.Flight.Destination.City));
            }
            else
            {
                int itemsToFit = (int)(_loadedHeight / FlightTemplate.FlightHeight);

                if (_flightsShown + itemsToFit > _totalFlights)
                {
                    itemsToFit = _totalFlights - _flightsShown;

                    if (itemsToFit.Equals(0))
                    {
                        _flightsShown = 0;
                        itemsToFit = (int)(_loadedHeight / FlightTemplate.FlightHeight);
                    }
                }

                _flightCollection.OrderBy(f => f.Flight.Destination.City).ToList().GetRange(_flightsShown, itemsToFit);

                //_flightCollection = new ObservableCollection<TemplatedFlight>(_flightCollection.OrderBy(f => f.Flight.Destination.City).ToList().GetRange(
                //    _flightsShown,
                //    itemsToFit)); 

                _flightsShown = _flightsShown + itemsToFit;
            }
        }

        public void RePopulateBasedOnSize(SizeChangedInfo sizeChangedInfo)
        {
            Resized();
        }

        public void Play()
        {
            _timer.Interval = TimeSpan.FromSeconds(SecondsPerPage);
            _timer.Start();
            _isPlaying = true;

        }

        public void Stop()
        {
            _timer.Stop();
            _isPlaying = false;
        }

        public bool IsPlaying()
        {
            return _isPlaying;
        }
    }
}

