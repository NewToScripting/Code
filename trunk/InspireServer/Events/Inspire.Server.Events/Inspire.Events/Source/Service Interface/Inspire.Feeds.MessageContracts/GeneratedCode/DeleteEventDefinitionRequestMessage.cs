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

namespace Inspire.Server.Events.MessageContracts
{
    /// <summary>
    /// Service Contract Class - DeleteEventDefinitionRequestMessage
    /// </summary>
    [WCF::MessageContract(IsWrapped = false)]
    public partial class DeleteEventDefinitionRequestMessage
    {
        [WCF::MessageBodyMember(Name = "EventDefinitionID")]
        public string EventDefinitionID { get; set; }
    }
}

