using System;
using Inspire.Server.Proxy.RegistrationServiceReference;
using Inspire.Server.Proxy.SettingsServiceReference;

namespace Inspire.Server.Proxy
{
    public class RegistrationManager
    {
        /// <summary>
        /// Register Software
        /// </summary>
       static public bool RegisterSoftware(string firstname, string lastname, string companyname, string address1, string address2, string city,  string state, string zip, string email, string phone, string regKey)
        {
            try
            {
                var client = new RegistrationServiceClient();
                //client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                RegistrationRequestMessage request = new RegistrationRequestMessage();
                RegistrationResponseMessage response = new RegistrationResponseMessage();
                request.FirstName = firstname;
                request.LastName = lastname;
                request.CompanyName = companyname;
                request.Address1 = address1;
                request.Address2 = address2;
                request.City = city;
                request.State = state;
                request.Zip = zip;
                request.Email = email;
                request.Phone = phone;
                var guid = Guid.NewGuid();
                Guid.TryParse(regKey, out guid);
                request.RegKey = guid;

                response = client.Register(request);

                if (response.RegKey != Guid.Empty)
                {
                    AddRegistrationKeyToServer(response.RegKey.ToString(), response.RegDate);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured calling register server");
                return false;
            }

        }


        /// <summary>
        /// Add registration key to server
        /// </summary>
        /// <param name="slides"></param>
        /// <param name="scheduleID"></param>
        static public bool AddRegistrationKeyToServer(string regKey, DateTime regDate)
        {
            try
            {
                var client = new SettingServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSettingsEndpoint();

                Setting regKeySetting = new Setting();

                regKeySetting.Key = "RegKey";
                regKeySetting.Value = regKey;

                client.AddSetting(regKeySetting);

                Setting regDateSetting = new Setting();

                regDateSetting.Key = "RegDate";
                regDateSetting.Value = regDate.ToString();
                
                client.AddSetting(regDateSetting);

                return true;

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error adding reg key to server");
                return false;
            }

        }
    }
    
}
