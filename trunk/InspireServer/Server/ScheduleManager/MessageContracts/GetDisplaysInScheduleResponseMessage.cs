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

namespace Inspire.Server.ScheduleManager.MessageContracts
{
	/// <summary>
    /// Service Contract Class - GetDisplaysInScheduleResponseMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class GetDisplaysInScheduleResponseMessage
	{
	    [WCF::MessageBodyMember(Name = "Displays")]
	    public string[] Displays { get; set; }
	}
}

