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
    /// Service Contract Class - IsSlideScheduledRequestMessage
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)]
    public partial class UpdateOriginalSlideIdsRequestMessage
	{
	    [WCF::MessageBodyMember(Name = "NewSlideID")]
        public string NewSlideID { get; set; }

        [WCF::MessageBodyMember(Name = "OriginalSlideID")]
        public string OriginalSlideID { get; set; }

        [WCF::MessageBodyMember(Name = "DeleteExistingSlide")]
        public bool DeleteExistingSlide { get; set; }
	}
}

