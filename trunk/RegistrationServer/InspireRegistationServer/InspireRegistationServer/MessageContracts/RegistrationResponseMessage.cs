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

namespace Inspire.Server.Registration
{
	/// <summary>
    /// Service Contract Class - RegistrationResponseMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class RegistrationResponseMessage
	{
        [WCF::MessageBodyMember(Name = "RegDate")]
        public DateTime RegDate { get; set; }

        [WCF::MessageBodyMember(Name = "RegKey")]
        public Guid RegKey { get; set; }

	}
}

