using System.Windows.Input;

namespace FlightInfoModule.Commands
{
    public static class FlightModuleCommands
    {
        public static RoutedCommand ShowAirlinesCommand = new RoutedCommand();
        public static RoutedCommand RefreshFlightsCommand = new RoutedCommand();
        public static RoutedCommand ShowFlightsCommand = new RoutedCommand();
    }
}
