using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FlightInfoModule.Commands;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    /// <summary>
    /// Interaction logic for AirlinePanel.xaml
    /// </summary>
    public partial class AirlinePanel : UserControl, IDisposable
    {
        public AirlinePanel()
        {
            InitializeComponent();
        }

        public AirlinePanel(IEnumerable<Airline> airlines)
            : this()
        {
            lvAirlines.ItemsSource = airlines.OrderBy(airline => airline.Name);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var airline = ((FrameworkElement)e.Source).DataContext as Airline;

            if (airline != null)
                FlightModuleCommands.ShowFlightsCommand.Execute(airline, (ContentControl)Parent);


        }

        public void Dispose()
        {
            try
            {
                ClearValue(ContentProperty);

            }
            catch
            {
            }

        }
    }
}
