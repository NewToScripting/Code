using System;
using System.Windows;

namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for FlightControlDetails.xaml
    /// </summary>
    public partial class FlightControlDetails
    {
        public string AirportCode { get; set; }

        public bool IsTouchscreen { get; set; }

        public double SecondsPerPage { get; set; }

        public string FlightStyle { get; set; }

        public string PanelAnimation { get; set; }

        public bool ShowNameInsteadOfImage { get; set; }

        public TimeSpan? ShowAhead { get; set; }

        public TimeSpan? ShowBehind { get; set; }

        public FlightControlDetails()
        {
            InitializeComponent();

            // THIS IS HARD CODED FOR TAMPA TAKE THIS OUT WHEN WE HAVE MORE THAN TAMPA IN OUR CLIENT LIST
            //tbapCode.Text = "49e3481552e7c4c9:-f32609:127db71a141:-3d7f";

            // TODO get airport guid from config here.

            //cbAirports.ItemsSource = FlightInfoProxy.GetAirports(new FlightRequest());
            //if (cbAirports.Items.Count > 0)
            //    cbAirports.SelectedIndex = 0;
        }

        public FlightControlDetails(bool touchscreenHidden)
            : this()
        {
            if (!touchscreenHidden) return;
            cbTouchScreen.Visibility = Visibility.Collapsed;
            lblTS.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var ap = cbAirports.SelectedItem as Airport;

            //if (ap != null)
            //    AirportCode = ap.AirportCode;

            //if (tbapCode.Text.Replace(" ","").Length == 3 || tbapCode.Text.Replace(" ","").Length == 4)
            //{
            //    var airportList = cbAirports.ItemsSource as List<Airport>;
            //    if(airportList != null && airportList.Count > 0)
            //    {
            //        var airPort = airportList.FirstOrDefault(a => a.AirportCode.ToLower() == tbapCode.Text.ToLower());
            //        if (airPort != null)
            //            AirportCode = airPort.AirportCode;
            //        else
            //            AirportCode = tbapCode.Text;
            //    }
            //}

            if (cbNameInsteadOfIcon.IsChecked != null)
                if ((bool)cbNameInsteadOfIcon.IsChecked)
                    ShowNameInsteadOfImage = true;

            if (tbapCode.Text.Replace(" ", "").Length > 4)
            {
                AirportCode = tbapCode.Text;
            }

            if (cbTouchScreen.IsChecked != null) IsTouchscreen = (bool)cbTouchScreen.IsChecked;

            double secondsPerPage;
            double.TryParse(cbSecPP.SelectionBoxItem.ToString(), out secondsPerPage);

            SecondsPerPage = secondsPerPage > 0 ? secondsPerPage : 8.0;

            FlightStyle = CbStyle.Text;

            PanelAnimation = cbAnimation.Text;

            if (dtShowAhead.Value != null)
            {
                ShowAhead = new TimeSpan(dtShowAhead.Value.Value.Hour, dtShowAhead.Value.Value.Minute, 0);
                if (dtShowBehind.Value != null)
                    ShowBehind = new TimeSpan(dtShowBehind.Value.Value.Hour, dtShowBehind.Value.Value.Minute, 0);
            }

            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
