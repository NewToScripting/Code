using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    public class TemplatedFlight : DependencyObject
    {
        public Flight Flight { get; set; }

        public Brush BackgroundColor1
        {
            get { return (Brush)GetValue(BackgroundColor1Property); }
            set { SetValue(BackgroundColor1Property, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColor1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColor1Property =
            DependencyProperty.Register("BackgroundColor1", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.Transparent));


        public Brush BackgroundColor2
        {
            get { return (Brush)GetValue(BackgroundColor2Property); }
            set { SetValue(BackgroundColor2Property, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColor2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColor2Property =
            DependencyProperty.Register("BackgroundColor2", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(new SolidColorBrush(Color.FromArgb(33, 51, 250, 250))));



        public double HeaderHeight
        {
            get { return (double)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(77.0));


        public bool ShowHeader
        {
            get { return (bool)GetValue(ShowHeaderProperty); }
            set { SetValue(ShowHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHeaderProperty =
            DependencyProperty.Register("ShowHeader", typeof(bool), typeof(TemplatedFlight), new UIPropertyMetadata(true));


        public double HeaderFontSize
        {
            get { return (double)GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(22.0));


        public FontFamily HeaderFontFamily
        {
            get { return (FontFamily)GetValue(HeaderFontFamilyProperty); }
            set { SetValue(HeaderFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontFamilyProperty =
            DependencyProperty.Register("HeaderFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));


        public Brush HeaderForeground
        {
            get { return (Brush)GetValue(HeaderForegroundProperty); }
            set { SetValue(HeaderForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(new SolidColorBrush(Color.FromArgb(33, 51, 250, 250))));


        public bool ShowNameInsteadOfImage
        {
            get { return (bool)GetValue(ShowNameInsteadOfImageProperty); }
            set { SetValue(ShowNameInsteadOfImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowNameInsteadOfImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowNameInsteadOfImageProperty =
            DependencyProperty.Register("ShowNameInsteadOfImage", typeof(bool), typeof(TemplatedFlight), new UIPropertyMetadata(false));

        public double FlightImageWidth
        {
            get { return (double)GetValue(FlightImageWidthProperty); }
            set { SetValue(FlightImageWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightImageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightImageWidthProperty =
            DependencyProperty.Register("FlightImageWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(130.0));


        public double FlightHeight
        {
            get { return (double)GetValue(FlightHeightProperty); }
            set { SetValue(FlightHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightHeightProperty =
            DependencyProperty.Register("FlightHeight", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(77.0));

        public Brush AirlineNameForeground
        {
            get { return (Brush)GetValue(AirlineNameForegroundProperty); }
            set { SetValue(AirlineNameForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AirlineNameForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AirlineNameForegroundProperty =
            DependencyProperty.Register("AirlineNameForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));

        public FontFamily AirlineNameFontFamily
        {
            get { return (FontFamily)GetValue(AirlineNameFontFamilyProperty); }
            set { SetValue(AirlineNameFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AirlineNameFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AirlineNameFontFamilyProperty =
            DependencyProperty.Register("AirlineNameFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));

        public Brush DestinationCityForeground
        {
            get { return (Brush)GetValue(DestinationCityForegroundProperty); }
            set { SetValue(DestinationCityForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesinationCityForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestinationCityForegroundProperty =
            DependencyProperty.Register("DestinationCityForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public double DestinationCityFontSize
        {
            get { return (double)GetValue(DestinationCityFontSizeProperty); }
            set { SetValue(DestinationCityFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DestinationCityFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestinationCityFontSizeProperty =
            DependencyProperty.Register("DestinationCityFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(22.0));

        public double DestinationCityWidth
        {
            get { return (double)GetValue(DestinationCityWidthProperty); }
            set { SetValue(DestinationCityWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DestinationCityWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestinationCityWidthProperty =
            DependencyProperty.Register("DestinationCityWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(220.00));


        public FontFamily DestinationCityFontFamily
        {
            get { return (FontFamily)GetValue(DestinationCityFontFamilyProperty); }
            set { SetValue(DestinationCityFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DestinationCityFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestinationCityFontFamilyProperty =
            DependencyProperty.Register("DestinationCityFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));

        public Brush ScheduleArrivalDepartureForeground
        {
            get { return (Brush)GetValue(ScheduleArrivalDepartureForegroundProperty); }
            set { SetValue(ScheduleArrivalDepartureForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScheduleArrivalDepartureForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScheduleArrivalDepartureForegroundProperty =
            DependencyProperty.Register("ScheduleArrivalDepartureForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public double ScheduleArrivalDepartureFontSize
        {
            get { return (double)GetValue(ScheduleArrivalDepartureFontSizeProperty); }
            set { SetValue(ScheduleArrivalDepartureFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScheduleArrivalDepartureFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScheduleArrivalDepartureFontSizeProperty =
            DependencyProperty.Register("ScheduleArrivalDepartureFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(22.0));

        public double ScheduleArrivalDepartureWidth
        {
            get { return (double)GetValue(ScheduleArrivalDepartureWidthProperty); }
            set { SetValue(ScheduleArrivalDepartureWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScheduleArrivalDepartureWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScheduleArrivalDepartureWidthProperty =
            DependencyProperty.Register("ScheduleArrivalDepartureWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(150.00));

        public FontFamily ScheduleArrivalDepartureFontFamily
        {
            get { return (FontFamily)GetValue(ScheduleArrivalDepartureFontFamilyProperty); }
            set { SetValue(ScheduleArrivalDepartureFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScheduleArrivalDepartureFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScheduleArrivalDepartureFontFamilyProperty =
            DependencyProperty.Register("ScheduleArrivalDepartureFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));

        public Brush StatusForeground
        {
            get { return (Brush)GetValue(StatusForegroundProperty); }
            set { SetValue(StatusForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesinationCityForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusForegroundProperty =
            DependencyProperty.Register("StatusForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public double StatusFontSize
        {
            get { return (double)GetValue(StatusFontSizeProperty); }
            set { SetValue(StatusFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusFontSizeProperty =
            DependencyProperty.Register("StatusFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(20.0));

        public double StatusWidth
        {
            get { return (double)GetValue(StatusWidthProperty); }
            set { SetValue(StatusWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusWidthProperty =
            DependencyProperty.Register("StatusWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(170.00));

        public FontFamily StatusFontFamily
        {
            get { return (FontFamily)GetValue(StatusFontFamilyProperty); }
            set { SetValue(StatusFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusFontFamilyProperty =
            DependencyProperty.Register("StatusFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));

        public Brush FlightNumberForeground
        {
            get { return (Brush)GetValue(FlightNumberForegroundProperty); }
            set { SetValue(FlightNumberForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesinationCityForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightNumberForegroundProperty =
            DependencyProperty.Register("FlightNumberForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public double FlightNumberFontSize
        {
            get { return (double)GetValue(FlightNumberFontSizeProperty); }
            set { SetValue(FlightNumberFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightNumberFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightNumberFontSizeProperty =
            DependencyProperty.Register("FlightNumberFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(22.0));

        public double FlightNumberWidth
        {
            get { return (double)GetValue(FlightNumberWidthProperty); }
            set { SetValue(FlightNumberWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightNumberWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightNumberWidthProperty =
            DependencyProperty.Register("FlightNumberWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(90.00));


        public FontFamily FlightNumberFontFamily
        {
            get { return (FontFamily)GetValue(FlightNumberFontFamilyProperty); }
            set { SetValue(FlightNumberFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightGateFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightNumberFontFamilyProperty =
            DependencyProperty.Register("FlightNumberFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));

        public Brush FlightGateForeground
        {
            get { return (Brush)GetValue(FlightGateForegroundProperty); }
            set { SetValue(FlightGateForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesinationCityForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightGateForegroundProperty =
            DependencyProperty.Register("FlightGateForeground", typeof(Brush), typeof(TemplatedFlight), new UIPropertyMetadata(Brushes.White));


        public double FlightGateFontSize
        {
            get { return (double)GetValue(FlightGateFontSizeProperty); }
            set { SetValue(FlightGateFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightGateFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightGateFontSizeProperty =
            DependencyProperty.Register("FlightGateFontSize", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(22.0));

        public double FlightGateWidth
        {
            get { return (double)GetValue(FlightGateWidthProperty); }
            set { SetValue(FlightGateWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightGateWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightGateWidthProperty =
            DependencyProperty.Register("FlightGateWidth", typeof(double), typeof(TemplatedFlight), new UIPropertyMetadata(0.00));



        public FontFamily FlightGateFontFamily
        {
            get { return (FontFamily)GetValue(FlightGateFontFamilyProperty); }
            set { SetValue(FlightGateFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlightGateFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlightGateFontFamilyProperty =
            DependencyProperty.Register("FlightGateFontFamily", typeof(FontFamily), typeof(TemplatedFlight), new UIPropertyMetadata(new FontFamily("Arial")));


        public TemplatedFlight() { }

        public TemplatedFlight(Flight flight)
        {
            Flight = new Flight
                         {
                             ActualArrivalDeparture = flight.ActualArrivalDeparture,
                             Airline = flight.Airline,
                             EstimatedArrivalDeparture = flight.EstimatedArrivalDeparture,
                             DelayMinutes = flight.DelayMinutes,
                             Destination = flight.Destination,
                             FlightNumber = flight.FlightNumber,
                             FlyteType = flight.FlyteType,
                             Gate = flight.Gate,
                             Origin = flight.Origin,
                             ScheduleArrivalDeparture = flight.ScheduleArrivalDeparture,
                             Status = flight.Status,
                             StatusCode = flight.StatusCode
                         };
        }

        internal static IEnumerable<TemplatedFlight> ConverToTemplatedFlights(IEnumerable<Flight> flights, TemplatedFlight templatedFlight)
        {
            Collection<TemplatedFlight> templatedFlights = null;

            if (flights != null)
            {
                templatedFlights = new Collection<TemplatedFlight>();
                foreach (var flight in flights)
                {
                    var tFlight = new TemplatedFlight(flight)
                    {
                        FlightHeight = templatedFlight.FlightHeight,
                        BackgroundColor1 = templatedFlight.BackgroundColor1,
                        BackgroundColor2 = templatedFlight.BackgroundColor2,
                        DestinationCityFontFamily = templatedFlight.DestinationCityFontFamily,
                        DestinationCityFontSize = templatedFlight.DestinationCityFontSize,
                        DestinationCityForeground = templatedFlight.DestinationCityForeground,
                        DestinationCityWidth = templatedFlight.DestinationCityWidth,
                        ScheduleArrivalDepartureFontFamily =
                            templatedFlight.ScheduleArrivalDepartureFontFamily,
                        ScheduleArrivalDepartureFontSize =
                            templatedFlight.ScheduleArrivalDepartureFontSize,
                        ScheduleArrivalDepartureForeground =
                            templatedFlight.ScheduleArrivalDepartureForeground,
                        ScheduleArrivalDepartureWidth = templatedFlight.ScheduleArrivalDepartureWidth,
                        ShowNameInsteadOfImage = templatedFlight.ShowNameInsteadOfImage,
                        StatusFontFamily = templatedFlight.StatusFontFamily,
                        StatusFontSize = templatedFlight.StatusFontSize,
                        StatusForeground = templatedFlight.StatusForeground,
                        StatusWidth = templatedFlight.StatusWidth,
                        FlightImageWidth = templatedFlight.FlightImageWidth,
                        FlightNumberFontFamily = templatedFlight.FlightNumberFontFamily,
                        FlightNumberFontSize = templatedFlight.FlightNumberFontSize,
                        FlightNumberForeground = templatedFlight.FlightNumberForeground,
                        FlightNumberWidth = templatedFlight.FlightNumberWidth
                    };
                    templatedFlights.Add(tFlight);
                }
            }
            return templatedFlights;
        }
    }
}
