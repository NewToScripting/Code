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
    /// Service Contract Class - GetDisplaysInScheduleRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)]
    public partial class GetDisplaysInScheduleRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "ScheduleID")]
	    public string ScheduleID { get; set; }
	}
}

