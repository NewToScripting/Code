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

namespace Inspire.Server.Display.MessageContracts
{
	/// <summary>
	/// Service Contract Class - GetAllDisplaysRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class GetDisplaysRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "GroupID")]
	    public string GroupID { get; set; }
	}
}

