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

namespace Inspire.Users.MessageContracts
{
	/// <summary>
    /// Service Contract Class - LoginAttemptResponseMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)]
    public partial class LoginAttemptResponseMessage
	{
	    [WCF::MessageBodyMember(Name = "Result")]
	    public bool Result { get; set; }
	}
}
