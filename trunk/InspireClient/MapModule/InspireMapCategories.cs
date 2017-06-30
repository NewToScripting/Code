using System;
using System.Collections.Generic;

namespace MapModule
{
    [Serializable]
    public class InspireMapCategories : List<MapCategory>
    {
        public InspireMapCategories(){}

        public InspireMapCategories(IEnumerable<MapCategory> mapCategories)
        {
            foreach (var mapCategory in mapCategories)
                Add(mapCategory);
        }
    }

    //[Serializable]
    //public class InspireMapLocations : List<InspireMapLocation>
    //{
    //    public InspireMapLocations() { }

    //    public InspireMapLocations(IEnumerable<InspireMapLocation> mapLocations)
    //    {
    //        foreach (var mapCategory in mapLocations)
    //            Add(mapCategory);
    //    }
    //}
}