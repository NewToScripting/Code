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

namespace Inspire.Server.ScheduledSlideManager.MessageContracts
{
	/// <summary>
	/// Service Contract Class - AddScheduledSlideRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class AddScheduledSlideRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "ScheduledSlide")]
	    public Inspire.Server.ScheduledSlideManager.DataContracts.ScheduledSlide ScheduledSlide { get; set; }
	}
}

