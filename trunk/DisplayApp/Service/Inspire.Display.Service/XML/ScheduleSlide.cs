//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using WcfSerialization = global::System.Runtime.Serialization;


namespace Inspire.Display.Service.XML
{/// <summary>
    /// Data Contract Class - ScheduledSlide
    /// </summary>
   
    public partial class ScheduleSlide
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Transition { get; set; }
        public int TransitionSpeed { get; set; }
        public string Version { get; set; }
        public DateTime Duration { get; set; }
        public string ScheduleID { get; set; }
        public string OriginalSlideID { get; set; }
        public double? HResolution { get; set; }
        public double? VResolution { get; set; }
        public Buttons Buttons { get; set; }
    }


}

