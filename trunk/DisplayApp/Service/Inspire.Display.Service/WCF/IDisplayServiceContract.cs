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

namespace Inspire.Display.WCF
{
	/// <summary>
	/// Service Contract Class - DisplayServiceContract
	/// </summary>
    

	[WCF::ServiceContract(Namespace = "http://schemas.inspiredisplays.com/ServiceContract/", Name = "DisplayServiceContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None )]
	public partial interface IDisplayServiceContract 
	{
        [WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = true, AsyncPattern = false, Action = "http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/UpdateDisplay", ProtectionLevel = ProtectionLevel.None)]
        void UpdateDisplay(Inspire.Display.WCF.UpdateDisplayRequestMessage request);

	}
}
