using System;

namespace Inspire
{

    [Serializable]
    public class SlideButton
    {
        public string GUID { get; set; }
        public string ButtonName { get; set; }
        public string SlideID { get; set; }
        public string ScheduledSlideID { get; set; }
        public string SlideGuidToNavigateTo { get; set; }       
    }
}
