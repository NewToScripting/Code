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
using Inspire.Server.Common.DataContracts;

namespace Inspire.Server.SlideManager.MessageContracts
{
    /// <summary>
    /// Service Contract Class - AddButton
    /// </summary>
    [WCF::MessageContract(IsWrapped = false)]
    public partial class AddButtonRequestMessage
    {
        [WCF::MessageHeader(Name = "Button")]
        public Button Button { get; set; }

    }
}

