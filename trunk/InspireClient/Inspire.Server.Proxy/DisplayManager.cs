using System;
using System.Collections.Generic;
using Inspire.Server.Proxy.DisplaysServiceReference;

namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Display Manager
    /// </summary>
    public class DisplayManager
    {
        /// <summary>
        /// Get Displays
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        static public List<Display> GetDisplays(string groupID)
        {
            List<Display> displays = new List<Display>();

            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                GetDisplaysRequestMessage request = new GetDisplaysRequestMessage();

                request.GroupID = groupID;
                Displays proxyDisplays = client.GetDisplays(request.GroupID);

                foreach (Inspire.Server.Proxy.DisplaysServiceReference.Display item in proxyDisplays)
                {
                    Display display = DisplayTranslators.CommonDisplayOut(item);
                    displays.Add(display);
                }

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting displays");
            }
            return displays;

        }

        /// <summary>
        /// Get All Displays
        /// </summary>
        /// <returns></returns>
        static public List<Display> GetAllDisplays()
        {
            List<Display> displays = new List<Display>();
            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                
                Displays proxyDisplays = client.GetAllDisplays();
                foreach (Inspire.Server.Proxy.DisplaysServiceReference.Display item in proxyDisplays)
                {
                    Display display = DisplayTranslators.CommonDisplayOut(item);
                    displays.Add(display);
                }

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting all displays");
            }
            
            return displays;

        }

        /// <summary>
        /// Get Single Display
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public Display GetSingleDisplay(string displayID)
        { 
            Display display = new Display();

            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                GetSingleDisplaysRequestMessage request = new GetSingleDisplaysRequestMessage();

                request.DisplayID = displayID;

                GetSingleDisplaysResponseMessage response = new GetSingleDisplaysResponseMessage();
                response.Display = client.GetSingleDisplay(request.DisplayID);

                display = DisplayTranslators.CommonDisplayOut(response.Display);

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting single display");
            }
          
            return display;

        }

        /// <summary>
        /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public List<Display> GetDisplaysInSchedule(string scheduleID)
        {
            List<Display> displays = new List<Display>();

            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                GetDisplaysInScheduleRequestMessage request = new GetDisplaysInScheduleRequestMessage();
                
                request.ScheduleID = scheduleID;

                GetDisplaysInScheduleResponseMessage response = new GetDisplaysInScheduleResponseMessage();
                response.Displays = client.GetDisplaysInSchedule(request.ScheduleID);

                foreach (Inspire.Server.Proxy.DisplaysServiceReference.Display item in response.Displays)
                {
                    Display display = DisplayTranslators.CommonDisplayOut(item);
                    displays.Add(display);
                }

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting displays in schedule");
            }
            
            return displays;

        }

        /// <summary>
        /// Add Display
        /// </summary>
        /// <param name="display"></param>
        static public void AddDisplay(Display display)
        {
            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                AddDisplayRequestMessage request = new AddDisplayRequestMessage();

                Inspire.Server.Proxy.DisplaysServiceReference.Display displayOut = DisplayTranslators.ServiceDisplayOut(display);
                request.Display = displayOut;

                client.AddDisplay(request.Display);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding display");
            }

        }//end function

        /// <summary>
        /// Update Display
        /// </summary>
        /// <param name="display"></param>
        static public void UpdateDisplay(Display display)
        {
            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                UpdateDisplaysRequestMessage request = new UpdateDisplaysRequestMessage();

                Inspire.Server.Proxy.DisplaysServiceReference.Display displayOut = DisplayTranslators.ServiceDisplayOut(display);

                request.Display = displayOut;

                client.UpdateDisplay(request.Display);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating display");
            }

           

        }//end function

        /// <summary>
        /// Delete Display
        /// </summary>
        /// <param name="guid"></param>
        static public void DeleteDisplay(string guid)
        {
            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayEndpoint();
                DeleteDisplaysRequestMessage request = new DeleteDisplaysRequestMessage();

                request.GUID = guid;

                client.DeleteDisplay(request.GUID);
            }

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting display");
            }
           
        }//end function
    }//end class
}//end namespace
