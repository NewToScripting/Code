//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using WcfSerialization = global::System.Runtime.Serialization;

namespace Inspire.Server.Events.DataContracts
{
	/// <summary>
    /// Data Contract Class - EventFileFormat
	/// </summary>
    [WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "EventFileFormat")]
    public partial class EventFileFormat
	{
        [WcfSerialization::DataMember(Name = "EventFileFormatGuid", IsRequired = false, Order = 0)]
        public string EventFileFormatGuid { get; set; }

        [WcfSerialization::DataMember(Name = "TextFormat", IsRequired = false, Order = 1)]
        public int? TextFormat { get; set; }

        [WcfSerialization::DataMember(Name = "EventFormatName", IsRequired = false, Order = 2)]
        public string EventFormatName { get; set; }

        [WcfSerialization::DataMember(Name = "IsReadOnly", IsRequired = false, Order = 3)]
        public bool? IsReadOnly { get; set; }

        [WcfSerialization::DataMember(Name = "FieldContracts", IsRequired = false, Order = 4)]
        public FieldContracts FieldContracts { get; set; }

        [WcfSerialization::DataMember(Name = "SkipFirstFile", IsRequired = false, Order = 5)]
        public bool? SkipFirstFile { get; set; }

        [WcfSerialization::DataMember(Name = "FieldDelimeter", IsRequired = false, Order = 6)]
        public string FieldDelimeter { get; set; }

	}

   
}
