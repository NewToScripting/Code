//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using WCF = global::System.ServiceModel;
using Inspire.Server.Images.DataContracts;

namespace Inspire.Server.Images.MessageContracts
{
	/// <summary>
	/// Service Contract Class - GetImagesResponseMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class GetImagesResponseMessage
	{
	    [WCF::MessageBodyMember(Name = "EventImages")]
	    public EventImages EventImages { get; set; }
	}
}
