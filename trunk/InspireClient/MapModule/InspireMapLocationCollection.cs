using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MapModule
{
    [Serializable]
    public class InspireMapLocationCollection : ObservableCollection<InspireMapLocation>
    {
        public InspireMapLocationCollection(){}

        public string Capacity { get; set; }

        public InspireMapLocationCollection(IEnumerable<InspireMapLocation> inspireMapLocations)
        {
            foreach (var inspireMapLocation in inspireMapLocations)
                Add(inspireMapLocation);
        }
    }
}