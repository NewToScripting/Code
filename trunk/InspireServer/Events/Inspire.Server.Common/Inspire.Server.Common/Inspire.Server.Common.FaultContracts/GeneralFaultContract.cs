//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using WcfSerialization = global::System.Runtime.Serialization;

namespace Inspire.Server.Common.FaultContracts
{
	/// <summary>
	/// Data Contract Class - GeneralFaultContract
	/// </summary>
	[WcfSerialization::DataContract(Namespace = "http://schemas.inspiredisplays.com", Name = "GeneralFaultContract")]
	public partial class GeneralFaultContract 
	{
	    [WcfSerialization::DataMember(Name = "ErrorCode", IsRequired = false, Order = 0)]
	    public string ErrorCode { get; set; }

	    [WcfSerialization::DataMember(Name = "ErrorDesc", IsRequired = false, Order = 1)]
	    public string ErrorDesc { get; set; }
	}
}

