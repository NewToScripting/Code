//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ServiceModel;
using WCF = global::System.ServiceModel;

namespace Inspire.Server.Rooms.MessageContracts
{
    /// <summary>
    /// Service Contract Class - GetRoomsResponseMessage
    /// </summary>
    [MessageContract(IsWrapped = false)] 
    public partial class GetRoomsResponseMessage
    {
        [MessageBodyMember(Name = "Rooms")]
        public Server.Rooms.DataContracts.Rooms Rooms { get; set; }
    }
}