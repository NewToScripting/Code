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

namespace Inspire.Server.Rooms.DataContracts
{
    /// <summary>
    /// Data Contract Class - Room
    /// </summary>
    [WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "Room")]
    public partial class Room 
    {
        [WcfSerialization::DataMember(Name = "GUID", IsRequired = false, Order = 0)]
        public string GUID { get; set; }

        [WcfSerialization::DataMember(Name = "Name", IsRequired = false, Order = 1)]
        public string Name { get; set; }

        [WcfSerialization::DataMember(Name = "RoomAliases", IsRequired = false, Order = 2)]
        public RoomAliases RoomAliases { get; set; }
    }
}