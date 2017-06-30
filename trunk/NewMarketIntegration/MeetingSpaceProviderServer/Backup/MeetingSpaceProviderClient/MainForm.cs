using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security.Tokens;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Addressing;


namespace MeetingSpaceExportService
{
    using Newmarket.WebServices.MeetingSpace.client;
    using Newmarket.WebServices.MeetingSpaceFaults;
    
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the beo summary or detail data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GetEvents_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            // Create the Service Proxy that will be used to call the Web Service.  Use the fully qualified name.            
            Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService ServiceProxy = new Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService();
            
            ServiceProxy.Timeout = 90000;
            if (ValidateData_Get_Meeting_Space())
            {
                //-- Create the solution type of proxy (VS dev web service) or the regular iis web service type
                ServiceProxy.Url = text_ServiceURL.Text;

                // Now add the User name and password to the SOAP Header.
                ConfigureSoapHeader(ServiceProxy);

                MeetingSpaceRequest RequestXml = BuildMeetingSpaceRequestMessage();

                try
                {

                    MeetingSpaceResponse output = ServiceProxy.MeetingSpaceRequest(RequestXml);


                    // Serialize the Response for display 
                    XmlSerializer serializer = new XmlSerializer(typeof(MeetingSpaceResponse), "http://htng.org/PWSWG/2007/01/DigitalSignage/MeetingSpaceResponse/Types");
                    MemoryStream tempStream = new MemoryStream();
                    serializer.Serialize(tempStream, output);
                    //-- Reset the stream to the beginning and read the data from it
                    tempStream.Position = 0;
                    TextReader reader = new StreamReader(tempStream);

                    //-- Save the output response to a file
                    using (StreamWriter sw = new StreamWriter(text_OutputFile.Text))
                    {
                        sw.Write(reader.ReadToEnd());
                    }
                    reader.Close();

                    // View the results in a Browser window.
                    ViewOutPut();

                    //-- Set cursor back to normal
                    this.Cursor = Cursors.Default;
                }


                catch (DigitalSignageGenericFaultException exDG)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Generic DG exception returned -  return code [{0}]: {1}", exDG.TypedDetail.errorCode, exDG.TypedDetail.errorMsg);
                    MessageBox.Show(strDetails);
                }
                catch (InvalidDateTimeFaultException exDT)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("DateTime exception returned - {0}", exDT.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (InvalidPropertyKeyFaultException exPK)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Property Key exception returned - {0}", exPK.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (NoMeetingSpaceFoundFaultException exMR)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("No Meeting space found exception - {0}", exMR.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (InvalidEventKeyFaultException exEK)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Invalid event key (Delphi booking key) exception - {0}", exEK.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (InvalidRoomGroupingFaultException exRG)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Invalid room grouping key exception - {0}", exRG.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private bool ValidateData_Get_Meeting_Space()
        {
            bool bValid = true;
            if (text_ServiceURL.Text.Trim() == "")
            {
                if (MessageBox.Show("Web Svc URL can not be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    text_ServiceURL.Focus();
                    bValid = false;
                }
            }
            if (text_UserName.Text.Trim() == "")
            {
                if (MessageBox.Show("User Name can not be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    text_UserName.Focus();
                    bValid = false;
                }
            }
            if (text_Password.Text.Trim() == "")
            {
                if (MessageBox.Show("Password can not be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    text_Password.Focus();
                    bValid = false;
                }
            }
            if (text_OutputFile.Text.Trim() == "")
            {
                if (MessageBox.Show("Response xml File can not be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    text_OutputFile.Focus();
                    bValid = false;
                }
            }
            return bValid;
        }

        /// <summary>
        /// Get Meeting Room characteristics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GetMtgRooms_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService ServiceProxy = new Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService();

            ServiceProxy.Timeout = 90000;
            if (ValidateData_Get_Meeting_Space())
            {

                ServiceProxy.Url = text_ServiceURL.Text;

                ConfigureSoapHeader(ServiceProxy);

                MeetingSpaceCharacteristicsRequest RequestXml = new MeetingSpaceCharacteristicsRequest();
                RequestXml.propertyKey = this.text_PropertyKey.Text;

                try
                {
                    MeetingSpaceCharacteristicsResponse ResponseXml = ServiceProxy.MeetingSpaceCharacteristicsRequest(RequestXml);

                    // Serialize the results for display
                    XmlSerializer serializer = new XmlSerializer(typeof(MeetingSpaceCharacteristicsResponse), "http://htng.org/PWSWG/2007/01/DigitalSignage/MeetingSpaceCharacteristicsResponse/Types");
                    MemoryStream tempStream = new MemoryStream();
                    serializer.Serialize(tempStream, ResponseXml);
                    //-- Reset the stream to the beginning and read the data from it
                    tempStream.Position = 0;
                    TextReader reader = new StreamReader(tempStream);

                    //-- Save the output response to a file
                    using (StreamWriter sw = new StreamWriter(text_OutputFile.Text))
                    {
                        sw.Write(reader.ReadToEnd());
                    }
                    reader.Close();

                    // View the results in a Browser window.
                    ViewOutPut();

                    this.Cursor = Cursors.Default;

                }

                catch (DigitalSignageGenericFaultException exDG)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Generic DG exception -  return code [{0}]: {1}", exDG.TypedDetail.errorCode, exDG.TypedDetail.errorMsg);
                    MessageBox.Show(strDetails);
                }
                catch (InvalidPropertyKeyFaultException exPK)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("Property Key exception returned - {0}", exPK.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (NoMeetingRoomsFoundFaultException exMR)
                {
                    this.Cursor = Cursors.Default;
                    string strDetails = String.Format("No Meeting rooms found exception - {0}", exMR.TypedDetail.Details);
                    MessageBox.Show(strDetails);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Browse for the Beo output xml file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                text_OutputFile.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            timeStart.Text = "08:00 AM";
            timeEnd.Text = "11:00 PM";

        }

        
        /// <summary>
        /// Configure the soap header information
        /// </summary>
        /// <param name="proxy"></param>
        private void ConfigureSoapHeader( Newmarket.WebServices.MeetingSpace.client.MeetingSpaceService proxy )
        {
            //-- Add the username token
            UsernameToken token = new UsernameToken( text_UserName.Text, text_Password.Text, PasswordOption.SendPlainText);

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
        
        
        /// <summary>
        /// View the Output file in a Browser.
        /// </summary>
        private void ViewOutPut()
        {
            //-- Get the full path to the output file
            Process ieForXml = new Process();

            ieForXml.StartInfo.FileName = "explorer.exe";
            ieForXml.StartInfo.Arguments = text_OutputFile.Text;
            ieForXml.Start();
        }
        /// <summary>
        /// View the output file if it exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ViewOutput_Click(object sender, EventArgs e)
        {
            ViewOutPut();
        }

        private MeetingSpaceRequest BuildMeetingSpaceRequestMessage()
        {
            MeetingSpaceRequest RequestMsg = new MeetingSpaceRequest();

            // Required
            RequestMsg.propertyKey = this.text_PropertyKey.Text;
            
            // Optional
            RequestMsg.eventKey = text_EventKey.Text;
            
            // Required
            RequestMsg.isBatchInitiated = true;

            // Optional
            if (radio_ExhibitSkip.Checked)
                RequestMsg.isExhibitSpecified = false;
            else
            {
                RequestMsg.isExhibitSpecified = true;
                RequestMsg.isExhibit = radio_ExhibitYes.Checked;
            }

            // Optional
            if (radio_PostSkip.Checked)
                RequestMsg.isPostableSpecified = false;
            else
            {
                RequestMsg.isPostableSpecified = true;
                RequestMsg.isPostable = radio_PostYes.Checked;
            }

            // Optional  Do not add the element if there is no data to send.
            if (text_RoomGrouping.Text.Length > 0 ) 
                RequestMsg.roomGrouping = text_RoomGrouping.Text;

            // Optional
            //-- Only send the Date range element if the start and end dates are enabled
            if (dateStart.Checked && dateEnd.Checked)
            {
                MeetingSpaceRequestDateRange range = new MeetingSpaceRequestDateRange();
                                
                range.startDateTime = new DateTime();
                if( timeStart.Checked )
                    range.startDateTime = Convert.ToDateTime( dateStart.Value.ToShortDateString() + " " + timeStart.Value.ToShortTimeString() );
                else
                    range.startDateTime = dateStart.Value;
                
                range.endDateTime = new DateTime();
                if( timeEnd.Checked )
                    range.endDateTime = Convert.ToDateTime( dateEnd.Value.ToShortDateString() + " " + timeEnd.Value.ToShortTimeString() );
                else
                    range.endDateTime = dateEnd.Value;

                RequestMsg.DateRange = range;
            }
            
            return RequestMsg;
        }
    }
   
}