using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class Direction
    {
        public string Guid { get; set; }
        public string DisplayID { get; set; }
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string DirectionImageWebPath { get; set; }
        public string DirectionImageID { get; set; }
    }
    public class DirectionalImage
    {
        public string Guid { get; set; }
        public string FileExtention { get; set; }
        public string Description { get; set; }
        public string WebPath { get; set; }
       
    }


}


