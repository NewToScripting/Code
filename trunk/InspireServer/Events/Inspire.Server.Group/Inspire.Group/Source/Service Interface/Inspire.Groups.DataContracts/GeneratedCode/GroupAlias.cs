//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using WcfSerialization = global::System.Runtime.Serialization;

namespace Inspire.Server.Groups.DataContracts
{
    /// <summary>
    /// Data Contract Class - RoomAlias
    /// </summary>
    [WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "GroupAlias")]
    public partial class GroupAlias 
    {
        [WcfSerialization::DataMember(Name = "GUID", IsRequired = false, Order = 0)]
        public string GUID { get; set; }

        [WcfSerialization::DataMember(Name = "Value", IsRequired = false, Order = 1)]
        public string Value { get; set; }

        [WcfSerialization::DataMember(Name = "GroupID", IsRequired = false, Order = 2)]
        public string GroupID { get; set; }
    }
}