using System.Collections.ObjectModel;
using Inspire.Events.Proxy;

namespace EventsModule
{
    public class DisplayRoom
    {
        public string Guid { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
    }
}
