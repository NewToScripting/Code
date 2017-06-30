//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using Inspire.Server.Groups.BusinessLogic;
using Inspire.Server.Groups.MessageContracts;
using Inspire.Server.Groups.ServiceContracts;
using WCF = global::System.ServiceModel;

namespace Inspire.Server.Groups.ServiceImplementation
{
    /// <summary>
    /// Service Class - GroupsService
    /// </summary>
    [ServiceBehavior(Name = "GroupsService", 
        Namespace = "http://schemas.inspiredisplays.com", 
        InstanceContextMode = InstanceContextMode.PerSession, 
        ConcurrencyMode = ConcurrencyMode.Single )]
    public abstract class GroupsServiceBase : IGroupsServiceContract
    {
        #region GroupServiceContract Members

        public virtual GetGroupsResponseMessage GetGroups(GetGroupsRequestMessage request)
        {
            GetGroupsResponseMessage response = new GetGroupsResponseMessage();
            response.Groups = ResouceAccessFasade.GetGroups();
            return response;
        }

        public virtual AddGroupResponseMessage AddGroup(AddGroupRequestMessage request)
        {
            ResouceAccessFasade.AddGroup(request.Group);
            return new AddGroupResponseMessage();
        }


        public virtual UpdateGroupResponseMessage UpdateGroup(UpdateGroupRequestMessage request)
        {
            ResouceAccessFasade.UpdateGroup(request.Group);
            return new UpdateGroupResponseMessage();
        }


        public virtual DeleteGroupResponseMessage DeleteGroup(DeleteGroupRequestMessage request)
        {
            ResouceAccessFasade.DeleteGroup(request.GUID);
            return new DeleteGroupResponseMessage();
        }

        public virtual GetAliasesResponseMessage GetAliases(GetAliasesRequestMessage request)
        {
            GetAliasesResponseMessage response = new GetAliasesResponseMessage();
            response.Aliases = ResouceAccessFasade.GetAliases(request.GroupID);
            return response;
        }

        public virtual AddAliasResponseMessage AddAlias(AddAliasRequestMessage request)
        {
            ResouceAccessFasade.AddAlias(request.Alias);
            return new AddAliasResponseMessage();
        }

        public virtual DeleteAliasResponseMessage DeleteAlias(DeleteAliasRequestMessage request)
        {
            ResouceAccessFasade.DeleteAlias(request.AliasID);
            return new DeleteAliasResponseMessage();
        }

        #endregion		
		
    }

    public partial class GroupsService : GroupsServiceBase
    {
    }
}