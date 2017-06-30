using System.Windows;
using System.Windows.Input;

namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for FlightChooser.xaml
    /// </summary>
    public partial class FlightChooser
    {
        public string PanelType { get; set; }

        public FlightChooser()
        {
            InitializeComponent();
        }

        private void Single_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PanelType = "FlightPanel";
            
            DialogResult = true;
        }

        private void Double_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PanelType = "DoubleFlightPanel";
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
