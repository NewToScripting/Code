using System.Windows.Input;

namespace EventEntry.Commands
{
    public static class EventEntryCommands
    {
        public static RoutedCommand AddEventCommand = new RoutedCommand();
        public static RoutedCommand UpdateEventCommand = new RoutedCommand();
        public static RoutedCommand DeleteEventCommand = new RoutedCommand();
        public static RoutedCommand ClearEventsCommand = new RoutedCommand();
        public static RoutedCommand RefreshEventsCommand = new RoutedCommand();
    }
}
