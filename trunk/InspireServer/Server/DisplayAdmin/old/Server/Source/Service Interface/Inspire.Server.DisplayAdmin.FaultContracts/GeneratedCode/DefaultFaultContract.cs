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

namespace Inspire.Server.DisplayAdmin.FaultContracts
{
	/// <summary>
	/// Data Contract Class - DefaultFaultContract
	/// </summary>
	[WcfSerialization::DataContract(Namespace = "http://DataContract.InspireDisplays.com", Name = "DefaultFaultContract")]
	public partial class DefaultFaultContract 
	{
	    [WcfSerialization::DataMember(Name = "FaultOccurred", IsRequired = false, Order = 0)]
	    public string FaultOccurred { get; set; }
	}
}

