using System;
using WcfSerialization = global::System.Runtime.Serialization;

namespace Inspire.Server.Events.DataContracts
{
    /// <summary>
    /// Data Contract Class - FieldContract
    /// </summary>
    [WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "FieldContract")]
    public class FieldContract
    {
        [WcfSerialization::DataMember(Name = "GUID", IsRequired = false, Order = 0)]
        public string GUID { get; set; }

        [WcfSerialization::DataMember(Name = "Start", IsRequired = false, Order = 1)]
        public int? Start { get; set; }

        [WcfSerialization::DataMember(Name = "Length", IsRequired = false, Order = 2)]
        public int? Length { get; set; }

        [WcfSerialization::DataMember(Name = "Name", IsRequired = false, Order = 3)]
        public string Name { get; set; }

        [WcfSerialization::DataMember(Name = "FieldType", IsRequired = false, Order = 4)]
        public string FieldType { get; set; }

        [WcfSerialization::DataMember(Name = "Value", IsRequired = false, Order = 5)]
        public string Value { get; set; }

        [WcfSerialization::DataMember(Name = "EventFileFormatGuid", IsRequired = false, Order = 6)]
        public string EventFileFormatGuid { get; set; }


    }
}
