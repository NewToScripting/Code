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

namespace Inspire.Server.Direction.MessageContracts
{
	/// <summary>
	/// Service Contract Class - DeleteDirectionRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class DeleteDirectionRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "DirectionID")]
	    public string DirectionID { get; set; }
	}
}

