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

namespace Inspire.Settings.MessageContracts
{
	/// <summary>
    /// Service Contract Class - DeleteSettingRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)]
    public partial class DeleteSettingRequestMessage
	{
        [WCF::MessageBodyMember(Name = "Key")]
        public string Key { get; set; }

	   
	}
}

