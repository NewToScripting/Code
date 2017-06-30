using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security.Tokens;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Addressing;

namespace MeetingSpaceService_TestHarness
{
    using Newmarket.WebServices.MeetingSpace.client;
    using Newmarket.WebServices.MeetingSpaceFaults;
    using MeetingSpaceService_TestHarness.Inspire.Server.Events;
    using MeetingSpaceService_TestHarness;

    public class NewmarketEventProxy
    {
        public static MeetingSpaceResponse GetProperty()
        {
            // Create the Service Proxy that will be used to call the Web Service.  Use the fully qualified name.            
            Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService ServiceProxy = new Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService();

            ServiceProxy.Timeout = 90000;

            //SecurityToken token = new ServiceProxy.SetClientCredential(sec);

            //-- Create the solution type of proxy (VS dev web service) or the regular iis web service type
            ServiceProxy.Url = ConfigFileManager.GetServiceURL();

            // Now add the User name and password to the SOAP Header.
            ConfigureSoapHeader(ServiceProxy);

            MeetingSpaceRequest RequestXml = BuildMeetingSpaceRequestMessage();

            MeetingSpaceRequestDateRange dateRange = new MeetingSpaceRequestDateRange();

            int daysAhead = ConfigFileManager.GetAheadDays();
            int daysBehind = ConfigFileManager.GetBehindDays();
            DateTime startDate = DateTime.Now.AddDays(-daysBehind);
            DateTime endDate = DateTime.Now.AddDays(daysAhead);

            dateRange.startDateTime = startDate;
            dateRange.endDateTime = endDate;

            RequestXml.DateRange = dateRange;

            EventServiceContractClient client = new EventServiceContractClient();

            //client.ClientCredentials.HttpDigest.ClientCredential.Domain = "infotech";
            //client.ClientCredentials.HttpDigest.ClientCredential.UserName = "readerboardhost";
            //client.ClientCredentials.HttpDigest.ClientCredential.Password = "Password01";
            
            MeetingSpaceResponse output = new MeetingSpaceResponse();

            try
            {
                output = ServiceProxy.MeetingSpaceRequest(RequestXml);
            }

            catch (DigitalSignageGenericFaultException exDG)
            {
                string strDetails = String.Format("Generic DG exception returned -  return code [{0}]: {1}", exDG.TypedDetail.errorCode, exDG.TypedDetail.errorMsg);
                MessageBox.Show(strDetails);
            }
            catch (InvalidDateTimeFaultException exDT)
            {
                string strDetails = String.Format("DateTime exception returned - {0}", exDT.TypedDetail.Details);
                MessageBox.Show(strDetails);
            }
            catch (InvalidPropertyKeyFaultException exPK)
            {
                string strDetails = String.Format("Property Key exception returned - {0}", exPK.TypedDetail.Details);
                MessageBox.Show(strDetails);
            }
            catch (NoMeetingSpaceFoundFaultException exMR)
            {
                string strDetails = String.Format("No Meeting space found exception - {0}", exMR.TypedDetail.Details);
                MessageBox.Show(strDetails);
            }
            catch (InvalidEventKeyFaultException exEK)
            {
                string strDetails = String.Format("Invalid event key (Delphi booking key) exception - {0}", exEK.TypedDetail.Details);
                MessageBox.Show(strDetails);
            }
            catch (InvalidRoomGroupingFaultException exRG)
            {
                string strDetails = String.Format("Invalid room grouping key exception - {0}", exRG.TypedDetail.Details);
                MessageBox.Show(strDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return output;
        }



        /// <summary>
        /// Configure the soap header information
        /// </summary>
        /// <param name="proxy"></param>
        private static void ConfigureSoapHeader(Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService proxy)
        {
            //-- Add the username token
            string login = ConfigFileManager.GetPropertyLogin();
            string password = ConfigFileManager.GetPropertyPassword();

            UsernameToken token = new UsernameToken(login, password, PasswordOption.SendPlainText);

            // define policy 
            Policy clientPolicy = new Policy();
            // add an assertion that will force the client to include 
            // the UsernameToken into the SOAP request
            clientPolicy.Assertions.Add(new UsernameOverTransportAssertion());

            // apply the policy on the web service client
            proxy.SetPolicy(clientPolicy);
            // set the value of UsernameToken
            proxy.SetClientCredential<UsernameToken>(token);

            return;
        }

        private static MeetingSpaceRequest BuildMeetingSpaceRequestMessage()
        {
            MeetingSpaceRequest RequestMsg = new MeetingSpaceRequest();

            // Required
            if(!string.IsNullOrEmpty(ConfigFileManager.GetPropertyKey()))
            {
                RequestMsg.propertyKey = ConfigFileManager.GetPropertyKey();
            }
          
         
            // Required
            RequestMsg.isBatchInitiated = true;

            // Optional           
            RequestMsg.isExhibitSpecified = false;

            // Optional         
            RequestMsg.isPostableSpecified = false;
            
            // Optional
            //-- Only send the Date range element if the start and end dates are enabled

            MeetingSpaceRequestDateRange range = new MeetingSpaceRequestDateRange();
            range.startDateTime = DateTime.Now.AddDays(-365);
            range.endDateTime = DateTime.Now.AddDays(365);
            RequestMsg.DateRange = range;


            return RequestMsg;
        }
    }
}