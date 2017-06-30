using System.Collections.Generic;

namespace Inspire.Events.Proxy
{


    public class Room
    {
        public string Guid { get; set; }
        public string MeetingRoomIdentifier { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public string FloorDescription { get; set; }

        /// <summary>
        /// Physical Location Like a Wing, Building, Etc.
        /// </summary>
        public string RoomGrouping { get; set; }
        /// <summary>
        /// Directions to the meeting room.
        /// </summary>
        public string Directions { get; set; }
        public enum RoomTypes
        {
            Divisible,Indivisible
        } 
        public RoomTypes RoomType { get; set; }

        public string ParentMeetingRoomIdentifier { get; set; }

        public int MapReferenceNumber { get; set; }
        
        public List<Alias> Aliases { get; set; }

    }

    public class Alias
    {
        public string Guid { get; set; }
        public string Value { get; set; }
        public string RoomID { get; set; }

    }
}
