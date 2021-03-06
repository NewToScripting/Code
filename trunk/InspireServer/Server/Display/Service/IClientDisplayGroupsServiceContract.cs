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
using Inspire.Server.Common.FaultContracts;
using Inspire.Server.Display.MessageContracts;

namespace Inspire.Server.Display.ServiceContracts
{
	/// <summary>
	/// Service Contract Class - ClientDisplayGroupsServiceContract
	/// </summary>
	[WCF::ServiceContract(Namespace = "http://schemas.inspiredisplays.com/ServiceContract.Model/", Name = "ClientDisplayGroupsServiceContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None )]
	public partial interface IClientDisplayGroupsServiceContract 
	{
        [WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract.Model/ClientDisplayGroupsServiceContract/GetAllDisplayGroups", ProtectionLevel = ProtectionLevel.None)]
        GetAllDisplayGroupsResponseMessage GetAllDisplayGroups(GetAllDisplayGroupsRequestMessage request);

		[WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract.Model/ClientDisplayGroupsServiceContract/GetDisplayGroups", ProtectionLevel = ProtectionLevel.None)]
		GetDisplayGroupsResponseMessage GetDisplayGroups(GetDisplayGroupsRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract.Model/ClientDisplayGroupsServiceContract/AddDisplayGroup", ProtectionLevel = ProtectionLevel.None)]
		AddDisplayGroupResponseMessage AddDisplayGroup(AddDisplayGroupRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract.Model/ClientDisplayGroupsServiceContract/UpdateDisplayGroup", ProtectionLevel = ProtectionLevel.None)]
		UpdateDisplayGroupResponseMessage UpdateDisplayGroup(UpdateDisplayGroupRequestMessage request);

        [WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract.Model/ClientDisplayGroupsServiceContract/DeleteDisplayGroup", ProtectionLevel = ProtectionLevel.None)]
		DeleteDisplayGroupResponseMessage DeleteDisplayGroup(DeleteDisplayGroupRequestMessage request);

	}
}

