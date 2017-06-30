using System.ComponentModel;

namespace Inspire.Events.Proxy
{
      public class EventImage
    {
        public string Guid { get; set; }
        public string FileExtention { get; set; }
        public string Description { get; set; }
        public string WebPath { get; set; }
        public EventImageType Type { get; set; }
    }

    public enum EventImageType
    {
        Directional=1, Group=2
    };
}


