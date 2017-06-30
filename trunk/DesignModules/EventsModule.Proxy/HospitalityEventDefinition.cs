
using System;

namespace Inspire.Events.Proxy
{
    public class HospitalityEventDefinition
    {
        public string EventDefinitionGUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventFileFormat EventFileFormat { get; set; }
        public string Uri { get; set; }
        //public SourceTypes SourceType { get; set; }
        public bool? Default { get; set; }
        public int? UpdateIntervalInMinutes { get; set; }
        public bool? Active { get; set; }

        public HospitalityEventDefinition()
        {
            EventDefinitionGUID = Guid.NewGuid().ToString();
            Name = string.Empty;
            Description = string.Empty;
            Uri = string.Empty;
            Default = false;
            UpdateIntervalInMinutes = 15;
            Active = true;
        }
      
    }


    //public enum SourceTypes : int
    //{       
    //    Fixed = 1,       
    //    Tab = 2,      
    //    Comma = 3,       
    //    Excel = 4,        
    //    Custom = 5,
    //}


}



