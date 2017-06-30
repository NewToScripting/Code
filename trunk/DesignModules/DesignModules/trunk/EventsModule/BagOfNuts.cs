using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsModule
{
    public class BagOfNuts
    {
        public string GroupName { get; set; }
        public string MeetingName { get; set; }
        public string MeetingType { get; set; }
        public string MeetingRoomID { get; set; }
        public string MeetingRoomName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string MeetingPostAs { get; set; }
        public string MeetingID { get; set; }
        public bool IsVisible { get; set; }
    }
}
