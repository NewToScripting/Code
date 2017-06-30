using System;
using System.Collections.Generic;
using Inspire.Server.Proxy.DisplayPropertyServiceReference;


namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Display Property Manager
    /// </summary>
    public class DisplayPropertyManager
    {
        /// <summary>
        /// Get All Display Properties
        /// </summary>
        /// <returns></returns>
        static public List<DisplayProperty> GetAllDisplayProperties()
        {
            List<DisplayProperty> displays = new List<DisplayProperty>();

            try
            {
                ClientDisplayPropertiesServiceContractClient client = new ClientDisplayPropertiesServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetPropertyEndpoint();
                
                DisplayProperties displayProperties= client.GetDisplayProperties();

                foreach (Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty item in displayProperties)
                {
                    DisplayProperty displayProperty = DisplayPropertyTranslators.CommonDisplayPropertyOut(item);
                    displays.Add(displayProperty);
                }
            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting all properties");
            }

            return displays;

        }

        /// <summary>
        /// Add Display Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void AddDisplayProperty(DisplayProperty displayProperty)
        {
            try
            {
                ClientDisplayPropertiesServiceContractClient client = new ClientDisplayPropertiesServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetPropertyEndpoint();
                Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty propertyOut = DisplayPropertyTranslators.ServiceDisplayPropertyOut(displayProperty);

                client.AddDisplayProperty(propertyOut);

            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding property");
            }
           

        }//end function

        /// <summary>
        /// Update Display Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void UpdateDisplayProperty(DisplayProperty displayProperty)
        {
            try
            {
                ClientDisplayPropertiesServiceContractClient client = new ClientDisplayPropertiesServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetPropertyEndpoint();
               
                Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty propertyOut = DisplayPropertyTranslators.ServiceDisplayPropertyOut(displayProperty);

                client.UpdateDisplayProperty(propertyOut);
            }//try

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating property");
            }

        }//end function

        /// <summary>
        /// Delete Display Property
        /// </summary>
        /// <param name="propertyGuid"></param>
        static public void DeleteDisplayProperty(string propertyGuid)
        {
            try
            {
                ClientDisplayPropertiesServiceContractClient client = new ClientDisplayPropertiesServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetPropertyEndpoint();
                client.DeleteDisplayProperty(propertyGuid);
            }

            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting property");
            }
            
        }//end function
    }
}
