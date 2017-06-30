using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using FlightInfoModule.Commands;
using Inspire;
using Inspire.Commands;
using Inspire.Services.WeakEventHandlers;
using FlightInfoModule.Proxy;
using Transitionals.Controls;
using Transitionals.Transitions;

namespace FlightInfoModule
{
    public class FlightContentControl : TransitionElement, IWeakEventListener, IDisposable, IFilterable
    {

        public FlightRequest FlightRequest { get; set; }

        public TemplatedFlight FlightTemplate { get; set; }

        public bool IsTouchscreen { get; set; }

        public double SecondsPerPage { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool AdvanceOnEnd { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int AdvanceAfterLoops { get; set; }

        private List<Airline> _airlines;
        private List<Flight> _flights;
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly BackgroundWorker _getFlightsBackgroundWorker = new BackgroundWorker();

        public string PanelAnimation
        {
            get { return (string)GetValue(PanelAnimationProperty); }
            set { SetValue(PanelAnimationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PanelAnimation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PanelAnimationProperty =
            DependencyProperty.Register("PanelAnimation", typeof(string), typeof(FlightContentControl), new UIPropertyMetadata("EnterTopExitTop-Quad"));

        public string FlightStyle
        {
            get { return (string)GetValue(FlightStyleProperty); }
            set
            {
                SetValue(FlightStyleProperty, value);
                SetResourceTemplate();
            }
        }

        // Using a DependencyProperty as the backing store for FlightStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightStyleProperty =
            DependencyProperty.Register("FlightStyle", typeof(string), typeof(FlightContentControl), new UIPropertyMetadata("Standard"));



        public string PanelStyle { get; set; }

        private bool _isLoaded = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Placeholder
        {
            set { Content = value; }
        }

        private static void ShowAirlinesCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = InspireApp.IsPreviewMode || InspireApp.IsPlayer;
        }

        private void ShowAirlinesExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // The Work to perform on another thread
            ThreadStart start = delegate()
            {
                // ...

                // This will work as its using the dispatcher
                DispatcherOperation op = Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action<double>(ShowAirlines), ActualWidth);

                DispatcherOperationStatus status = op.Status;
                while (status != DispatcherOperationStatus.Completed)
                {
                    status = op.Wait(TimeSpan.FromMilliseconds(1000));
                    if (status == DispatcherOperationStatus.Aborted)
                    {
                        // Alert Someone
                    }
                }
            };

            // Create the thread and kick it started!
            new Thread(start).Start();
        }

        private void ShowAirlines(double actualWidth)
        {
            var translateTransition = new SlideInTransitionFX();
            translateTransition.Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
            Transition = translateTransition;
            Placeholder = new AirlinePanel(_airlines);
        }

        public FlightContentControl()
        {
            CommandBindings.Add(new CommandBinding(FlightModuleCommands.ShowAirlinesCommand, ShowAirlinesExecuted, ShowAirlinesCanExecute));
            CommandBindings.Add(new CommandBinding(FlightModuleCommands.ShowFlightsCommand, ShowFlightsExecuted, ShowFlightsCanExecute));
            CommandBindings.Add(new CommandBinding(FlightModuleCommands.RefreshFlightsCommand, RefreshFlightsExecuted, RefreshFlightsCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.FilterListCommand, OnFilterExecuted, OnFilterCanExecute));

            _dispatcherTimer.Interval = TimeSpan.FromMinutes(10);
            _getFlightsBackgroundWorker.DoWork += new DoWorkEventHandler(_getFlightsBackgroundWorker_DoWork);
            DispatcherTimerTickEventManager.AddListener(_dispatcherTimer, this);
            LoadedEventManager.AddListener(this, this);
        }

        private void OnFilterCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnFilterExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var filterList = (KeyValuePair<string, IEnumerable<object>>)e.Parameter;
            FilterList(filterList.Key, filterList.Value, _flights);
        }

        private void FilterList(object filterVar, IEnumerable<object> filterCollection, List<Flight> collectionToFilter)
        {
            var results = GetRemainingCollection(filterVar, (IEnumerable<string>)filterCollection, collectionToFilter);

            if(Content is IFlightPanel)
                ((IFlightPanel)Content).ReloadFlightsNow((List<Flight>)results);
        }

        public static IEnumerable GetRemainingCollection(object filterVar, IEnumerable<string> filterCollection, List<Flight> collectionToFilter)
        {
            var startIndex = 0;

            if (collectionToFilter != null)
            {
                if (filterVar != null)
                    startIndex =
                        collectionToFilter.ToList().Select(s => s.Destination.City[0].ToString().ToLower()).ToList().
                            IndexOf(filterVar.ToString().ToLower());

                if (startIndex == -1)
                    return GetRemainingCollection(CollectionHelpers.GetNext(filterVar, filterCollection),
                                                  filterCollection, collectionToFilter);

                var endIndex = collectionToFilter.Count() - startIndex;

                return collectionToFilter.ToList().GetRange(startIndex, endIndex).ToList();
            }
            return null;
        }

        void _getFlightsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var flightRequest = e.Argument as FlightRequest;
            _flights = PullFlightInformation(flightRequest).ToList();
        }

        private static void RefreshFlightsCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RefreshFlightsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _flights = PullFlightInformation(FlightRequest).ToList();
        }

        private static void ShowFlightsCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ShowFlightsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // The Work to perform on another thread
            ThreadStart start = delegate()
            {
                // ...

                // This will work as its using the dispatcher
                DispatcherOperation op = Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action<double>(ShowFlights), ActualWidth);

                DispatcherOperationStatus status = op.Status;
                while (status != DispatcherOperationStatus.Completed)
                {
                    status = op.Wait(TimeSpan.FromMilliseconds(1000));
                    if (status == DispatcherOperationStatus.Aborted)
                    {
                        // Alert Someone
                    }
                }
            };

            // Create the thread and kick it started!
            new Thread(start).Start();
        }

        private void ShowFlights(double actualWidth)
        {
            var translateTransition = new SlideInTransitionFX();
            translateTransition.Direction = SlideInTransitionFX.SlideDirection.RightToLeft;
            Transition = translateTransition;
            var flighPanel = new FlightPanel(SecondsPerPage, true, FlightTemplate, PanelAnimation, _flights, AdvanceOnEnd, AdvanceAfterLoops);
            Placeholder = flighPanel;
        }

        public List<Flight> GetFlights()
        {
            return _flights;
        }

        private static IEnumerable<Flight> PullFlightInformation(FlightRequest flightRequest)
        {
            try
            {
                if (InspireApp.IsDemoMode)
                    return SampleFlights.GetFlights(flightRequest);// GetSerializedFlights();

                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                    return FlightInfoProxy.GetFlights(flightRequest);

                return SampleFlights.GetFlights(flightRequest);
            }
            catch (Exception)
            {
                return new List<Flight>();
            }
        }

        private static IEnumerable<Flight> GetSerializedFlights()
        {
            FlightCollection flights;

            Uri XmlUri = new Uri("SampleFlights.xaml", UriKind.Relative);

            using (var XmlStreamSourceInfo = Application.GetResourceStream(XmlUri).Stream)
            {
                flights = (FlightCollection)XamlReader.Load(XmlStreamSourceInfo);
            }

            //using (FileStream xamlFile = new FileStream(Application.GetResourceStream(XmlUri).Stream, FileMode.Open, FileAccess.Read))
            //{
            //    flights = (FlightCollection) XamlReader.Load(xamlFile);
            //}
            return flights;
        }

        ~FlightContentControl()
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
        }

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                if (_dispatcherTimer != null)
                    _dispatcherTimer.Stop();

                if (Content is IDisposable)
                    ((IDisposable)Content).Dispose();
                ClearValue(ContentProperty);

                Placeholder = null;
            }));
        }

        void FlightContentControl_Loaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                Placeholder = new LoadingControl();

                var backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += _backgroundWorker_DoWork;
                backgroundWorker.RunWorkerAsync();
                _isLoaded = true;

                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                    _dispatcherTimer.Start();
            }
        }

        private void FlightContentControl_DispatcherTick(object sender, EventArgs eventArgs)
        {
            _getFlightsBackgroundWorker.RunWorkerAsync(FlightRequest);
        }

        public FlightContentControl(string panelStyle, FlightRequest flightRequest, double secondsPerPage, TemplatedFlight flightTemplate, bool isTouchscreen, string flightStyle, string panelAnimation)
            : this()
        {
            FlightStyle = flightStyle;

            if (!string.IsNullOrEmpty(panelAnimation))
                PanelAnimation = panelAnimation;

            FlightRequest = flightRequest;

            IsTouchscreen = isTouchscreen;

            if (!string.IsNullOrEmpty(panelStyle))
                PanelStyle = panelStyle;

            SecondsPerPage = secondsPerPage;

            FlightTemplate = flightTemplate;

        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (SecondsPerPage < 3.0)
                SecondsPerPage = 8.0;

            if (FlightRequest == null)
                FlightRequest = new FlightRequest(); // { FID = "49e3481552e7c4c9:-f32609:127db71a141:-3d7f" };

            try
            {
                _flights = PullFlightInformation(FlightRequest).ToList();

                //var flightCollection = new FlightCollection();
                //flightCollection.AddRange(PullFlightInformation(FlightRequest));

                //using (TextWriter textWriter = new StreamWriter(Paths.ClientLocalSlidesDirectory + "SampleFlights.xaml"))
                //{
                //    XamlWriter.Save(flightCollection, textWriter);
                //    textWriter.Dispose();
                //}
            }
            catch (Exception)
            {
                _flights = null;
            }


            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(OnAction));
        }

        private void OnAction()
        {
            if (FlightTemplate == null)
                FlightTemplate = new TemplatedFlight();

            UserControl flightControl;

            if (!IsTouchscreen)
                switch (PanelStyle)
                {
                    case ("FlightPanel"):
                        flightControl = new FlightPanel(SecondsPerPage, IsTouchscreen, FlightTemplate, PanelAnimation, _flights, AdvanceOnEnd, AdvanceAfterLoops);
                        break;
                    case ("DoubleFlightPanel"):
                        flightControl = new DoublePaneFlightPanel(SecondsPerPage, FlightTemplate, PanelAnimation, _flights, AdvanceOnEnd, AdvanceAfterLoops);
                        break;
                    default:
                        flightControl = new FlightPanel(SecondsPerPage, IsTouchscreen, FlightTemplate, PanelAnimation, _flights, AdvanceOnEnd, AdvanceAfterLoops);
                        break;
                }
            else
            {
                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                {
                    _airlines = FlightInfoProxy.GetAirlines(FlightRequest);
                    flightControl = new AirlinePanel(_airlines);
                }
                else
                    flightControl = new FlightPanel(SecondsPerPage, IsTouchscreen, FlightTemplate, PanelAnimation, _flights, AdvanceOnEnd, AdvanceAfterLoops);
                //_airlines = SampleAirlines.GetAirlines();

            }

            SetResourceTemplate();

            Placeholder = flightControl;

            if (flightControl is IFlightPanel)
                ((IFlightPanel)flightControl).RefreshCollection(false, true);
        }

        public void SetResourceTemplate()
        {
            try
            {
                Resources =
                    new ResourceDictionary
                    {

                        Source =
                            new Uri(
                            "pack://application:,,,/FlightInfoModule;component/themes/" +
                            FlightStyle + ".xaml")
                    };
            }
            catch (Exception)
            {
                Resources =
                    new ResourceDictionary
                    {

                        Source =
                            new Uri(
                            "pack://application:,,,/FlightInfoModule;component/themes/" +
                            "Standard" + ".xaml")
                    };
            }
        }


        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                FlightContentControl_Loaded(sender, e);
                return true;
            }
            else if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                FlightContentControl_DispatcherTick(sender, e);
                return true;
            }
            return false;
        }
    }
}
