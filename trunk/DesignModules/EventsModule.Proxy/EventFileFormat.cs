
using System;
using System.Collections.Generic;

namespace Inspire.Events.Proxy
{
    public class EventFileFormat
    {
        public string EventFileFormatGuid { get; set; }
        public string EventFormatName { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? SkipFirstFile { get; set; }
        public string FieldDelimeter { get; set; }
        public TextFormats? TextFormat { get; set; }
        public List<FieldContract> FieldContracts { get; set; }

        public EventFileFormat()
        {
            EventFileFormatGuid = Guid.NewGuid().ToString();
            TextFormat = TextFormats.Separated;
            IsReadOnly = false;
        }
              
    }

    public enum TextFormats { Fixed = 1, Separated = 2  }


   

}



