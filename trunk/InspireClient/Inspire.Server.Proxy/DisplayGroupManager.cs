using System;
using System.Collections.Generic;
using Inspire.Server.Proxy.DisplayGroupsServiceReference;


namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Display Group Manager
    /// </summary>
   public class DisplayGroupManager
    {
       /// <summary>
        /// Get Display Groups
       /// </summary>
       /// <param name="groupID"></param>
       /// <returns></returns>
        static public List<DisplayGroup> GetDisplayGroups(string groupID)
        {
            List<DisplayGroup> groups = new List<DisplayGroup>();

            try
            {
                var client = new ClientDisplayGroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();

                DisplayGroups displayGroups = client.GetDisplayGroups(groupID);

                foreach (Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup item in displayGroups)
                {
                    DisplayGroup group = DisplayGroupTranslators.CommonDisplayGroupOut(item);
                    groups.Add(group);
                }

            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting display groups");
            }

            return groups;

        }

       /// <summary>
        /// Get All Display Groups
       /// </summary>
       /// <returns></returns>
        static public List<DisplayGroup> GetAllDisplayGroups()
        {
            List<DisplayGroup> groups = new List<DisplayGroup>();

            try
            {
                var client = new ClientDisplayGroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                
                DisplayGroups displayGroups = client.GetAllDisplayGroups();

                foreach (Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup item in displayGroups)
                {
                    DisplayGroup group = DisplayGroupTranslators.CommonDisplayGroupOut(item);
                    groups.Add(group);
                }

            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting all display groups");
            }
            

            return groups;

        }

       /// <summary>
        /// Add Display Group
       /// </summary>
       /// <param name="displayGroup"></param>
        static public void AddDisplayGroup(DisplayGroup displayGroup)
        {
            try
            {   
                var client = new ClientDisplayGroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup groupOut = DisplayGroupTranslators.ServiceDisplayGroupOut(displayGroup);
                client.AddDisplayGroup(groupOut);

            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding a display group");
            }
            
        }//end function

       /// <summary>
        /// Update Display Group
       /// </summary>
       /// <param name="displayGroup"></param>
        static public void UpdateDisplayGroup(DisplayGroup displayGroup)
        {
            try
            {
                var client = new ClientDisplayGroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup groupOut = DisplayGroupTranslators.ServiceDisplayGroupOut(displayGroup);
                client.UpdateDisplayGroup(groupOut);
            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating a display group");
            }
           

        }//end function

       /// <summary>
        /// Delete Display Group
       /// </summary>
       /// <param name="GroupGuid"></param>
        static public void DeleteDisplayGroup(string GroupGuid)
        {
            try
            {
                var client = new ClientDisplayGroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                client.DeleteDisplayGroup(GroupGuid);

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while removing a display group");
            }
        }//end function
    }
}
