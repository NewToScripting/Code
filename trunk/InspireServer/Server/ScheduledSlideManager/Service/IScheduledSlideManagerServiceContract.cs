//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Net.Security;
using WCF = global::System.ServiceModel;
using Inspire.Server.ScheduledSlideManager.MessageContracts;
using Inspire.Server.Common.FaultContracts;

namespace Inspire.Server.ScheduledSlideManager.ServiceContracts
{
	/// <summary>
	/// Service Contract Class - ScheduledSlideManagerServiceContract
	/// </summary>
	[WCF::ServiceContract(Namespace = "http://schemas.inspiredisplays.com/ServiceContract/", Name = "ScheduledSlideManagerServiceContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None )]
	public partial interface IScheduledSlideManagerServiceContract 
	{
		[WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/GetScheduledSlides", ProtectionLevel = ProtectionLevel.None)]
		GetScheduledSlidesResponseMessage GetScheduledSlides(GetScheduledSlidesRequestMessage request);
        
        [WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/GetScheduledSlidesNoThumb", ProtectionLevel = ProtectionLevel.None)]
        GetScheduledSlidesNoThumbResponseMessage GetScheduledSlidesNoThumb(GetScheduledSlidesNoThumbRequestMessage request);
        
        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/AddScheduledSlide", ProtectionLevel = ProtectionLevel.None)]
		AddScheduledSlideResponseMessage AddScheduledSlide(AddScheduledSlideRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/UpdateScheduleSlide", ProtectionLevel = ProtectionLevel.None)]
		UpdateScheduleSlidesResponseMessage UpdateScheduleSlides(UpdateScheduleSlidesRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/DeleteScheduledSlide", ProtectionLevel = ProtectionLevel.None)]
		DeleteScheduledSlideResponseMessage DeleteScheduledSlide(DeleteScheduledSlideRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/IsSlideScheduled", ProtectionLevel = ProtectionLevel.None)]
        IsSlideScheduledResponseMessage IsSlideScheduled(IsSlideScheduledRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ScheduledSlideManagerServiceContract/UpdateOriginalSlideIds", ProtectionLevel = ProtectionLevel.None)]
        UpdateOriginalSlideIdsResponseMessage UpdateOriginalSlideIds(UpdateOriginalSlideIdsRequestMessage request);

        [WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlideNavagation", ProtectionLevel = ProtectionLevel.None)]
        DeleteSlideNavagationResponseMessage DeleteSlideNavagation(DeleteSlideNavagationRequestMessage request);

        [WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlideNavagation", ProtectionLevel = ProtectionLevel.None)]
        AddSlideNavagationResponseMessage AddSlideNavagation(AddSlideNavagationRequestMessage request);



	}
}

