


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Net.Security;
using WCF = global::System.ServiceModel;
using Inspire.Server.Common.FaultContracts;
using Inspire.Server.SlideManager.MessageContracts;

namespace Inspire.Server.SlideManager.ServiceContracts
{
	/// <summary>
	/// Service Contract Class - SlideManagerServiceContract
	/// </summary>
	
[WCF::ServiceContract(Namespace = "http://schemas.inspiredisplays.com", Name = "SlideManagerServiceContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None )]
	public partial interface ISlideManagerServiceContract 
	{
[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlides", ProtectionLevel = ProtectionLevel.None)]
		GetAllSlidesResponseMessage GetAllSlides(GetAllSlidesRequestMessage request);

[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetSlide", ProtectionLevel = ProtectionLevel.None)]
        GetSlideResponseMessage GetSlide(GetSlideRequestMessage request);

[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlide", ProtectionLevel = ProtectionLevel.None)]
		AddSlideResponseMessage AddSlide(AddSlideRequestMessage request);

[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlide", ProtectionLevel = ProtectionLevel.None)]
		UpdateSlideResponseMessage UpdateSlide(UpdateSlideRequestMessage request);

[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlide", ProtectionLevel = ProtectionLevel.None)]
		DeleteSlideResponseMessage DeleteSlide(DeleteSlideRequestMessage request);

//[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
//        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteTouchScreenButton", ProtectionLevel = ProtectionLevel.None)]
//        DeleteButtonResponseMessage DeleteButton(DeleteButtonRequestMessage request);

//[WCF::FaultContract(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract))]
//        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddTouchScreenButton", ProtectionLevel = ProtectionLevel.None)]
//        AddButtonResponseMessage AddButton(AddButtonRequestMessage request);

	}
}

