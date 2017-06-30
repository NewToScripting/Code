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
using System.ServiceModel;
using Inspire.Display.Service.BusinessLogic;
using System.Diagnostics;


namespace Inspire.Display.WCF
{	
	/// <summary>
	/// Service Class - DisplayAdminService
	/// </summary>
    
	[ServiceBehavior(Name = "DisplayService", 
		Namespace = "http://schemas.inspiredisplays.com/ServiceContract/", 
		InstanceContextMode = InstanceContextMode.PerSession, 
		ConcurrencyMode = ConcurrencyMode.Single )]
	public abstract class DisplayServiceBase : Inspire.Display.WCF.IDisplayServiceContract
	{
		#region DisplayAdminServiceContract Members

        public virtual void UpdateDisplay(Inspire.Display.WCF.UpdateDisplayRequestMessage request)
		{
            ResourceAccessFasade.GetHardUpdate(System.Environment.MachineName, false);
		}
        
		#endregion		
		
	}
	
	public partial class DisplayService : DisplayServiceBase
	{
	}
	
}
