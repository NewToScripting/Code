using System;
using System.Collections.Generic;

namespace Inspire
{
    public class DisplayProperty : IGUIDItem
    {
        public DisplayProperty()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public DisplayProperty(string displayPropertyName)
        {
            GUID = Guid.NewGuid().ToString();
            PropertyName = displayPropertyName;
        }

        public string PropertyDescription { get; set; }

        public string PropertyName { get; set; }

        public string GUID { get; set; }

        readonly List<DisplayGroup> _displaygroups = new List<DisplayGroup>();
        public List<DisplayGroup> DisplayGroups
        {
            get { return _displaygroups; }
        }
    }

    public interface IGUIDItem
    {
        string GUID { get; }
    }
}
