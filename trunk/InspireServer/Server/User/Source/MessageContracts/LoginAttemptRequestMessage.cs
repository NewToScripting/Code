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
    /// Service Contract Class - LoginAttemptRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)]
    public partial class LoginAttemptRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "Login")]
	    public string Login { get; set; }

	    [WCF::MessageBodyMember(Name = "Password")]
	    public string Password { get; set; }
	}
}
