using System;
using System.ComponentModel;

namespace MapModule
{
    [Serializable]
    public class MapCategory
    {
        public MapCategory(){ MapLocations = new InspireMapLocationCollection();}

        public MapCategory(string categoryName, string catStyle): this()
        {
            Name = categoryName;
            CategoryStyle = catStyle;
            AutoPopulate = true;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private InspireMapLocationCollection _mapLocations;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public InspireMapLocationCollection MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public string CategoryStyle { get; set; }

        public string Name { get; set; }

        public bool AutoPopulate { get; set; }
    }
}