//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ServiceModel;
using Inspire.Server.Groups.DataContracts;
using WCF = global::System.ServiceModel;

namespace Inspire.Server.Groups.MessageContracts
{
    /// <summary>
    /// Service Contract Class - GetAliasesResponseMessage
    /// </summary>
    [MessageContract(IsWrapped = false)] 
    public partial class GetAliasesResponseMessage
    {
        [MessageBodyMember(Name = "Aliases")]
        public GroupAliases Aliases { get; set; }
    }
}