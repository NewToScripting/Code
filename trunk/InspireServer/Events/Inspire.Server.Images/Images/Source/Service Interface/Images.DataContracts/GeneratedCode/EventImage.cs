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

namespace Inspire.Server.Images.DataContracts
{
	/// <summary>
	/// Data Contract Class - EventImage
	/// </summary>
	[WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "EventImage")]
	public partial class EventImage 
	{
	    [WcfSerialization::DataMember(Name = "GUID", IsRequired = false, Order = 0)]
	    public string GUID { get; set; }

	    //[WcfSerialization::DataMember(Name = "Name", IsRequired = false, Order = 1)]
	    //public string Name { get; set; }

        [WcfSerialization::DataMember(Name = "Description", IsRequired = false, Order = 2)]
        public string Description { get; set; }

	    [WcfSerialization::DataMember(Name = "WebPath", IsRequired = false, Order = 3)]
	    public string WebPath { get; set; }

	    [WcfSerialization::DataMember(Name = "FileExtension", IsRequired = false, Order = 4)]
	    public string FileExtension { get; set; }

        [WcfSerialization::DataMember(Name = "Type", IsRequired = false, Order = 5)]
        public int? Type { get; set; }
	}
}

