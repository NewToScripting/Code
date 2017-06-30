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

namespace Inspire.Server.Events.ServiceContracts
{
	/// <summary>
	/// Service Contract Class - EventServiceContract
	/// </summary>
	[WCF::ServiceContract(Namespace = "http://schemas.inspiredisplays.com", Name = "EventServiceContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None )]
	public partial interface IFeedServiceContract 
	{
                
[WCF::FaultContract(typeof(GeneralFaultContract))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/AddEvent", ProtectionLevel = ProtectionLevel.None)]
		Inspire.Server.Events.MessageContracts.AddEventResponseMessage AddEvent(Inspire.Server.Events.MessageContracts.AddEventRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/UpdateEvent", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.UpdateEventResponseMessage UpdateEvent(Inspire.Server.Events.MessageContracts.UpdateEventRequestMessage request);
        
[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEvents", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventsResponseMessage GetEvents(Inspire.Server.Events.MessageContracts.GetEventsRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/DeleteEvents", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.DeleteEventResponseMessage DeleteEvent(Inspire.Server.Events.MessageContracts.DeleteEventRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEventDefinitions", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventDefinitionsResponseMessage GetEventDefinitions(Inspire.Server.Events.MessageContracts.GetEventDefinitionsRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetDefaultEventDefinition", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetDefaultEventDefinitionResponseMessage GetDefaultEventDefinition(Inspire.Server.Events.MessageContracts.GetDefaultEventDefinitionRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/AddEventDefinition", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.AddEventDefinitionResponseMessage AddEventDefinition(Inspire.Server.Events.MessageContracts.AddEventDefinitionRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/DeleteEventDefinition", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.DeleteEventDefinitionResponseMessage DeleteEventDefinition(Inspire.Server.Events.MessageContracts.DeleteEventDefinitionRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEventsFiltered", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventsFilteredResponseMessage GetEventsFiltered(Inspire.Server.Events.MessageContracts.GetEventsFilteredRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEventsNonFiltered", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventsNonFilteredResponseMessage GetEventsNonFiltered(Inspire.Server.Events.MessageContracts.GetEventsNonFilteredRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/LoadEvents", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.LoadEventsResponseMessage LoadEvents(Inspire.Server.Events.MessageContracts.LoadEventsRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/UpdateEventDefinition", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.UpdateEventDefinitionResponseMessage UpdateEventDefinition(Inspire.Server.Events.MessageContracts.UpdateEventDefinitionRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/SetDefaultEventDefinition", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.SetDefaultEventDefinitionResponseMessage SetDefaultEventDefinition(Inspire.Server.Events.MessageContracts.SetDefaultEventDefinitionRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/TruncateEvents", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.TruncateEventsResponseMessage TruncateEvents(Inspire.Server.Events.MessageContracts.TruncateEventsRequestMessage request);

//EventFileFormat

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEventFileFormat", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventFileFormatResponseMessage GetEventFileFormat(Inspire.Server.Events.MessageContracts.GetEventFileFormatRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/GetEventFileFormats", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.GetEventFileFormatsResponseMessage GetEventFileFormats(Inspire.Server.Events.MessageContracts.GetEventFileFormatsRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/AddEventFileFormat", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.AddEventFileFormatResponseMessage AddEventFileFormat(Inspire.Server.Events.MessageContracts.AddEventFileFormatRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/UpdateEventFileFormat", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.UpdateEventFileFormatResponseMessage UpdateEventFileFormat(Inspire.Server.Events.MessageContracts.UpdateEventFileFormatRequestMessage request);

[WCF::FaultContract(typeof(GeneralFaultContract))]
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/FeedServiceContract/DeleteEventFileFormat", ProtectionLevel = ProtectionLevel.None)]
        Inspire.Server.Events.MessageContracts.DeleteEventFileFormatResponseMessage DeleteEventFileFormat(Inspire.Server.Events.MessageContracts.DeleteEventFileFormatRequestMessage request);





    }
}
