//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.ServiceModel.Activation;
using Inspire.Users.BusinessLogic;
using Inspire.Users.MessageContracts;
using WCF = global::System.ServiceModel;

namespace Inspire.Users.ServiceImplementation
{	
	/// <summary>
	/// Service Class - UserService
	/// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[WCF::ServiceBehavior(Name = "UserService", Namespace = "http://schemas.inspiredisplays.com", InstanceContextMode = WCF::InstanceContextMode.PerSession, ConcurrencyMode = WCF::ConcurrencyMode.Single )]
	public abstract class UserServiceBase : ServiceContracts.IUserServiceContract
	{
		#region UserServiceContract Members

		public virtual GetUsersResponseMessage GetUsers(GetUsersRequestMessage request)
		{
            GetUsersResponseMessage response = new GetUsersResponseMessage();
            response.Users = ResourceAccessFasade.GetUsers();
            return response;
		}

		public virtual GetRolesFromUserIDResponseMessage GetRolesFromUserID(GetRolesFromUserIDRequestMessage request)
		{
            GetRolesFromUserIDResponseMessage response = new GetRolesFromUserIDResponseMessage();
            response.Roles = ResourceAccessFasade.GetRolesFromUserID(request.UserID);
			return null;
		}

		public virtual GetAllRolesResponseMessage GetAllRoles(GetAllRolesRequestMessage request)
		{
            GetAllRolesResponseMessage response = new GetAllRolesResponseMessage();
            response.Roles = ResourceAccessFasade.GetAllRoles();
            return response;
		}

		public virtual AddUserResponseMessage AddUser(AddUserRequestMessage request)
		{
            ResourceAccessFasade.AddUser(request.User);
			return new AddUserResponseMessage();
		}

		public virtual AddRolesToUserResponseMessage AddRolesToUser(AddRolesToUserRequestMessage request)
		{
            ResourceAccessFasade.AddRolesToUser(request.UserID,request.RoleID);
            return new AddRolesToUserResponseMessage(); 
		}

		public virtual DeleteUserResponseMessage DeleteUser(DeleteUserRequestMessage request)
		{
            ResourceAccessFasade.DeleteUser(request.UserID);
            return new DeleteUserResponseMessage();
		}

		public virtual DeleteRoleResponseMessage DeleteRole(DeleteRoleRequestMessage request)
		{
            ResourceAccessFasade.DeleteRole(request.UserID, request.RoleID);
			return new DeleteRoleResponseMessage();
		}

        public virtual LoginAttemptResponseMessage LoginAttempt(LoginAttemptRequestMessage request)
        {
            LoginAttemptResponseMessage response = new LoginAttemptResponseMessage();
                        
            response.Result = ResourceAccessFasade.LoginAttempt(request.Login, request.Password);

            return response;
        }
        
		#endregion		
		
	}
	
	public partial class UserService : UserServiceBase
	{
	}
	
}

