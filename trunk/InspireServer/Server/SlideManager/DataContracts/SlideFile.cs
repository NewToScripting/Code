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

namespace Inspire.Server.SlideManager.DataContracts
{
	/// <summary>
	/// Data Contract Class - SlideFile
	/// </summary>
	[WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "SlideFile")]
	public partial class SlideFile 
	{
	    [WcfSerialization::DataMember(Name = "GUID", IsRequired = false, Order = 0)]
	    public string GUID { get; set; }

	    [WcfSerialization::DataMember(Name = "File", IsRequired = false, Order = 1)]
	    public byte[] File { get; set; }
	}
}

