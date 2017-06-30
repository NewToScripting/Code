using System;
using System.Collections.Generic;

namespace Inspire
{
    public class DisplayGroup : IGUIDItem
    {
        public DisplayGroup()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public DisplayGroup(string displayGroupName, string displayGroupDescription)
        {
            GUID = Guid.NewGuid().ToString();
            GroupName = displayGroupName;
            GroupDescription = displayGroupDescription;
        }

        public string PropertyID { get; set; }

        public string GroupDescription { get; set; }

        public string GroupName { get; set; }

        public string GUID { get; set; }

        readonly List<Display> _displays = new List<Display>();
        public List<Display> Displays
        {
            get { return _displays; }
        } 
    }
}
