//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.IO;
using WCF = global::System.ServiceModel;

namespace Inspire.Server.SlideManager.MessageContracts
{
	/// <summary>
	/// Service Contract Class - AddSlideFileRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class AddSlideFileRequestMessage
	{
        [WCF::MessageHeader(Name = "SlideFileID")]
        public string SlideFileID { get; set; }

        [WCF::MessageHeader(Name = "SlideFileSize")]
        public int SlideFileSize { get; set; }

        [WCF::MessageBodyMember(Name = "SlideFileStream")]
        public Stream SlideFileStream { get; set; }


	}
}
