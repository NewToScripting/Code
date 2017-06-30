using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using ExceptionHelper;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Messaging;


namespace Newmarket.WebServices.MeetingSpace
{
    using Newmarket.WebServices.MeetingSpaceFaults;

    [SoapActor("*")] //Which allows all Actors.
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebService(Namespace = "http://htng.org/PWSWG/2007/01/DigitalSignage")]
    public partial class MeetingSpaceProviderService : IMeetingSpaceServiceSoap
    {
        
        /// <summary>
        /// Constructor 
        /// </summary>
        public MeetingSpaceProviderService()
            : base()
        {
                     
        }

        public MeetingSpaceResponse MeetingSpaceRequest( MeetingSpaceRequest MeetingSpaceRequestData)
        {
            String TransactionId = "";
            MeetingSpaceResponse Response = null; ;

            try
            {

                // Obtain the TransactionId if required.
                TransactionId = RequestSoapContext.Current.Addressing.MessageID.Value.ToString();

                if( MeetingSpaceRequestData.propertyKey.ToLower() == "fault" )
                {
                    MeetingSpaceFaults.InvalidPropertyKeyFault fault = new Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault();
                    fault.Details = "Invalid Property Key - The property key (PID) in the message is not configured in I-Server.";
                    throw new MeetingSpaceFaults.InvalidPropertyKeyFaultException( SoapException.ClientFaultCode, fault );
                }

                DateTime startDate = new DateTime();
                if( MeetingSpaceRequestData.DateRange != null )
                {
                    startDate = MeetingSpaceRequestData.DateRange.startDateTime;
                }
                
                Response = BuildResponseMessage( startDate,MeetingSpaceRequestData.propertyKey, "Newmarket Hotel & Spa");

               
                // Update the Addressing Relates To value so the client can obtain the transaction Id from the response.
                ResponseSoapContext.Current.Addressing.RelatesTo = new Microsoft.Web.Services3.Addressing.RelatesTo( new Uri( TransactionId ) );
            }
            catch( MeetingSpaceFaults.DigitalSignageGenericFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.NoMeetingSpaceFoundFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.InvalidDateTimeFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.DateRangeTooLargeFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.InvalidPropertyKeyFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.InvalidRoomGroupingFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.InvalidEventKeyFaultException ex )
            {
                throw ex;
            }
            catch( Exception ex )
            {
                throw ex;
            }

            return Response;
        }

        private MeetingSpaceResponse BuildResponseMessage(DateTime startDate, String PropertyKey, String HotelName )
        {
            MeetingSpaceResponse Response = new MeetingSpaceResponse();

            Response.isResponseComplete = true;
            Response.Property = new PropertyType[1];
            Response.Property[0] = new PropertyType();
            // Build the property specific data
            Response.Property[0].propertyKey = PropertyKey;
            Response.Property[0].propertyName = HotelName;
            // Create the Event ( Business )
            Response.Property[0].Event = new EventType[2];
            Response.Property[0].Event[0] = new EventType();
            Response.Property[0].Event[0].eventKey = "44.42";
            Response.Property[0].Event[0].eventName = "Quarterly Meeting";
            Response.Property[0].Event[0].eventPostAs = "Quarterly Meeting";
            Response.Property[0].Event[0].eventLogo = "";

            // Create the Group ( Account )
            Response.Property[0].Event[0].Group = new GroupType();
            Response.Property[0].Event[0].Group.key = "4567.42";
            Response.Property[0].Event[0].Group.name = "Newmarket Travel Agency";
            // Create the MeetingSpace ( Event )
            Response.Property[0].Event[0].MeetingSpace = new MeetingSpaceType[2];
            Response.Property[0].Event[0].MeetingSpace[0] = new MeetingSpaceType();
            Response.Property[0].Event[0].MeetingSpace[0].startDateTime = new DateTime( startDate.Year, startDate.Month, startDate.Day, 11, 21, 20 );
            Response.Property[0].Event[0].MeetingSpace[0].endDateTime = new DateTime( startDate.Year, startDate.Month, startDate.Day, 23, 0, 0 );
            Response.Property[0].Event[0].MeetingSpace[0].roomKey = "123.42";
            Response.Property[0].Event[0].MeetingSpace[0].roomName = "BallRoom 2";
            Response.Property[0].Event[0].MeetingSpace[0].meetingKey = "123.42.222.42";
            Response.Property[0].Event[0].MeetingSpace[0].meetingName = "Dinner";
            Response.Property[0].Event[0].MeetingSpace[0].meetingPostAs = "Dinner Reception";
            Response.Property[0].Event[0].MeetingSpace[0].isExhibit = false;
            Response.Property[0].Event[0].MeetingSpace[0].isPostable = true;
            Response.Property[0].Event[0].MeetingSpace[0].isPostableSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[0].isExhibitSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[0].agr_attend = 50;
            Response.Property[0].Event[0].MeetingSpace[0].agr_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[0].exp_attend = 50;
            Response.Property[0].Event[0].MeetingSpace[0].exp_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[0].gtd_attend = 0;
            Response.Property[0].Event[0].MeetingSpace[0].gtd_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[0].set_attend = 0;
            Response.Property[0].Event[0].MeetingSpace[0].set_attendSpecified = true;
            
            // Add Backup MeetingRoom
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom = new OtherRoomType[1];
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0] = new OtherRoomType();
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0].roomKey = "1111.42";
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0].roomName = "Backup Meeting Room Name";
            // Add the Overflow MeetingRoom
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom = new OtherRoomType[1];
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0] = new OtherRoomType();
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0].roomKey = "1112";
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0].roomName = "West Wing Corridor";
            // Create the second MeetingSpace ( Event ).
            Response.Property[0].Event[0].MeetingSpace[1] = new MeetingSpaceType();
            Response.Property[0].Event[0].MeetingSpace[1].endDateTime = new DateTime( startDate.Year, startDate.Month, startDate.Day, 17, 0, 0 );
            Response.Property[0].Event[0].MeetingSpace[1].roomKey = "124.42";
            Response.Property[0].Event[0].MeetingSpace[1].roomName = "BallRoom 1";
            Response.Property[0].Event[0].MeetingSpace[1].meetingKey = "124.42.222.42";
            Response.Property[0].Event[0].MeetingSpace[1].meetingName = "Quarterly Meeting";
            Response.Property[0].Event[0].MeetingSpace[1].meetingPostAs = "Quarterly Meeting";
            Response.Property[0].Event[0].MeetingSpace[1].isExhibit = false;
            Response.Property[0].Event[0].MeetingSpace[1].isPostable = true;
            Response.Property[0].Event[0].MeetingSpace[1].isPostableSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[1].isExhibitSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[1].agr_attend = 50;
            Response.Property[0].Event[0].MeetingSpace[1].agr_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[1].exp_attend = 50;
            Response.Property[0].Event[0].MeetingSpace[1].exp_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[1].gtd_attend = 0;
            Response.Property[0].Event[0].MeetingSpace[1].gtd_attendSpecified = true;
            Response.Property[0].Event[0].MeetingSpace[1].set_attend = 0;
            Response.Property[0].Event[0].MeetingSpace[1].set_attendSpecified = true;
            
            // Create the second event
            // Create the Event ( Business )
            Response.Property[0].Event[1] = new EventType();
            Response.Property[0].Event[1].eventKey = "4224.42";
            Response.Property[0].Event[1].eventName = "Kickoff Meeting";
            Response.Property[0].Event[1].eventPostAs = "Kickoff Meeting";
            Response.Property[0].Event[1].eventLogo = "";

            // Create the Group ( Account )
            Response.Property[0].Event[1].Group = new GroupType();
            Response.Property[0].Event[1].Group.key = "6789.42";
            Response.Property[0].Event[1].Group.name = "Portsmouth Travel Agency";
            // Create the MeetingSpace ( Event )
            Response.Property[0].Event[1].MeetingSpace = new MeetingSpaceType[2];
            Response.Property[0].Event[1].MeetingSpace[0] = new MeetingSpaceType();
            Response.Property[0].Event[1].MeetingSpace[0].startDateTime = new DateTime( startDate.Year, startDate.Month + 1 , startDate.Day, 11, 21, 20 );
            Response.Property[0].Event[1].MeetingSpace[0].endDateTime = new DateTime( startDate.Year, startDate.Month + 1, startDate.Day, 23, 0, 0 );
            Response.Property[0].Event[1].MeetingSpace[0].roomKey = "123.42";
            Response.Property[0].Event[1].MeetingSpace[0].roomName = "BallRoom 2";
            Response.Property[0].Event[1].MeetingSpace[0].meetingKey = "123.42.222.42";
            Response.Property[0].Event[1].MeetingSpace[0].meetingName = "Dinner";
            Response.Property[0].Event[1].MeetingSpace[0].meetingPostAs = "Dinner Reception";
            Response.Property[0].Event[1].MeetingSpace[0].isExhibit = false;
            Response.Property[0].Event[1].MeetingSpace[0].isPostable = true;
            Response.Property[0].Event[1].MeetingSpace[0].isPostableSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[0].isExhibitSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[0].agr_attend = 60;
            Response.Property[0].Event[1].MeetingSpace[0].agr_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[0].exp_attend = 60;
            Response.Property[0].Event[1].MeetingSpace[0].exp_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[0].gtd_attend = 0;
            Response.Property[0].Event[1].MeetingSpace[0].gtd_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[0].set_attend = 0;
            Response.Property[0].Event[1].MeetingSpace[0].set_attendSpecified = true;
            
            // Add Backup MeetingRoom
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom = new OtherRoomType[1];
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0] = new OtherRoomType();
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0].roomKey = "1111.42";
            Response.Property[0].Event[0].MeetingSpace[0].BackupMeetingRoom[0].roomName = "Backup Meeting Room Name";
            // Add the Overflow MeetingRoom
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom = new OtherRoomType[1];
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0] = new OtherRoomType();
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0].roomKey = "1112";
            Response.Property[0].Event[0].MeetingSpace[0].OverflowMeetingRoom[0].roomName = "West Wing Corridor";
            // Create the second MeetingSpace ( Event ).
            Response.Property[0].Event[1].MeetingSpace[1] = new MeetingSpaceType();
            Response.Property[0].Event[1].MeetingSpace[1].endDateTime = new DateTime( startDate.Year, startDate.Month, startDate.Day, 17, 0, 0 );
            Response.Property[0].Event[1].MeetingSpace[1].roomKey = "124.42";
            Response.Property[0].Event[1].MeetingSpace[1].roomName = "BallRoom 1";
            Response.Property[0].Event[1].MeetingSpace[1].meetingKey = "124.42.222.42";
            Response.Property[0].Event[1].MeetingSpace[1].meetingName = "Quarterly Meeting";
            Response.Property[0].Event[1].MeetingSpace[1].meetingPostAs = "Quarterly Meeting";
            Response.Property[0].Event[1].MeetingSpace[1].isExhibit = false;
            Response.Property[0].Event[1].MeetingSpace[1].isPostable = true;
            Response.Property[0].Event[1].MeetingSpace[1].isPostableSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[1].isExhibitSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[1].agr_attend = 40;
            Response.Property[0].Event[1].MeetingSpace[1].agr_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[1].exp_attend = 40;
            Response.Property[0].Event[1].MeetingSpace[1].exp_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[1].gtd_attend = 40;
            Response.Property[0].Event[1].MeetingSpace[1].gtd_attendSpecified = true;
            Response.Property[0].Event[1].MeetingSpace[1].set_attend = 40;
            Response.Property[0].Event[1].MeetingSpace[1].set_attendSpecified = true;
                  
            return Response;
        }

        public MeetingSpaceCharacteristicsResponse MeetingSpaceCharacteristicsRequest(MeetingSpaceCharacteristicsRequest MeetingSpaceCharacteristicsRequestData)
        {
            String TransactionId = "";

            MeetingSpaceCharacteristicsResponse Response = null;  

            try
            {
                // Obtain the TransactionId if required.
                TransactionId = RequestSoapContext.Current.Addressing.MessageID.Value.ToString();

                if( MeetingSpaceCharacteristicsRequestData.propertyKey.ToLower() == "fault" )
                {
                    MeetingSpaceFaults.InvalidPropertyKeyFault fault = new Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault();
                    fault.Details = "Invalid Property Key - The property key (PID) in the message is not configured in I-Server.";
                    throw new MeetingSpaceFaults.InvalidPropertyKeyFaultException( SoapException.ClientFaultCode, fault );
                }
                
                Response = BuildCharacteristicsResponseMessage( MeetingSpaceCharacteristicsRequestData.propertyKey );

                // Update the Addressing Relates To value so the client can obtain the transaction Id from the response.
                ResponseSoapContext.Current.Addressing.RelatesTo = new Microsoft.Web.Services3.Addressing.RelatesTo( new Uri( TransactionId ) );
            }
            catch( MeetingSpaceFaults.DigitalSignageGenericFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.InvalidPropertyKeyFaultException ex )
            {
                throw ex;
            }
            catch( MeetingSpaceFaults.NoMeetingRoomsFoundFaultException ex )
            {
                throw ex;
            }
            catch( Exception ex )
            {
                throw ex;
            }

            return Response;
        }

        private MeetingSpaceCharacteristicsResponse BuildCharacteristicsResponseMessage(String PropertyKey )
        {
            MeetingSpaceCharacteristicsResponse Response = new MeetingSpaceCharacteristicsResponse();
            Response.isResponseComplete = true;
            Response.isResponseCompleteSpecified = true;

            Response.Property = new MeetingSpaceCharacteristicsResponseProperty[1];
            Response.Property[0] = new MeetingSpaceCharacteristicsResponseProperty();
            Response.Property[0].propertyKey = PropertyKey;
            Response.Property[0].propertyName = "Newmarket Hotel & Conference Center";
            Response.Property[0].MeetingSpaceCharacteristics = new MeetingSpaceCharacteristicsResponsePropertyMeetingSpaceCharacteristics[4];
            // Build Room one
            Response.Property[0].MeetingSpaceCharacteristics[0] = new MeetingSpaceCharacteristicsResponsePropertyMeetingSpaceCharacteristics();
            Response.Property[0].MeetingSpaceCharacteristics[0].roomKey = "123.42";
            Response.Property[0].MeetingSpaceCharacteristics[0].roomName = "BallRoom 2";
            Response.Property[0].MeetingSpaceCharacteristics[0].floorNumber = "2";
            Response.Property[0].MeetingSpaceCharacteristics[0].floorDescription = "2nd Floor";
            Response.Property[0].MeetingSpaceCharacteristics[0].roomGrouping = "North Hall";
            Response.Property[0].MeetingSpaceCharacteristics[0].directions = "Proceed down the north hall and take a right.";
            Response.Property[0].MeetingSpaceCharacteristics[0].isDivisible = true;
            Response.Property[0].MeetingSpaceCharacteristics[0].mapReferenceNum = "225";
            Response.Property[0].MeetingSpaceCharacteristics[0].parentRoomKey = "";

            // Build Room two
            Response.Property[0].MeetingSpaceCharacteristics[1] = new MeetingSpaceCharacteristicsResponsePropertyMeetingSpaceCharacteristics();
            Response.Property[0].MeetingSpaceCharacteristics[1].roomKey = "223.42";
            Response.Property[0].MeetingSpaceCharacteristics[1].roomName = "BallRoom 1";
            Response.Property[0].MeetingSpaceCharacteristics[1].floorNumber = "1";
            Response.Property[0].MeetingSpaceCharacteristics[1].floorDescription = "Main Floor";
            Response.Property[0].MeetingSpaceCharacteristics[1].roomGrouping = "North Hall";
            Response.Property[0].MeetingSpaceCharacteristics[1].directions = "Proceed down the north hall and take a right.";
            Response.Property[0].MeetingSpaceCharacteristics[1].isDivisible = true;
            Response.Property[0].MeetingSpaceCharacteristics[1].mapReferenceNum = "125";
            Response.Property[0].MeetingSpaceCharacteristics[1].parentRoomKey = "";

            // Build Room three
            Response.Property[0].MeetingSpaceCharacteristics[2] = new MeetingSpaceCharacteristicsResponsePropertyMeetingSpaceCharacteristics();
            Response.Property[0].MeetingSpaceCharacteristics[2].roomKey = "100.42";
            Response.Property[0].MeetingSpaceCharacteristics[2].roomName = "Winchester Meeting Room";
            Response.Property[0].MeetingSpaceCharacteristics[2].floorNumber = "1";
            Response.Property[0].MeetingSpaceCharacteristics[2].floorDescription = "Main Floor";
            Response.Property[0].MeetingSpaceCharacteristics[2].roomGrouping = "West Wing";
            Response.Property[0].MeetingSpaceCharacteristics[2].directions = "Proceed down the main hall and take a left to west wing.";
            Response.Property[0].MeetingSpaceCharacteristics[2].isDivisible = false;
            Response.Property[0].MeetingSpaceCharacteristics[2].mapReferenceNum = "110";
            Response.Property[0].MeetingSpaceCharacteristics[2].parentRoomKey = "";

            // Build Room four
            Response.Property[0].MeetingSpaceCharacteristics[3] = new MeetingSpaceCharacteristicsResponsePropertyMeetingSpaceCharacteristics();
            Response.Property[0].MeetingSpaceCharacteristics[3].roomKey = "100.42";
            Response.Property[0].MeetingSpaceCharacteristics[3].roomName = "Meeting Room A";
            Response.Property[0].MeetingSpaceCharacteristics[3].floorNumber = "3";
            Response.Property[0].MeetingSpaceCharacteristics[3].floorDescription = "3rd Floor";
            Response.Property[0].MeetingSpaceCharacteristics[3].roomGrouping = "Meeting Rooms";
            Response.Property[0].MeetingSpaceCharacteristics[3].directions = "Off the 3rd Floor elevator to the left.";
            Response.Property[0].MeetingSpaceCharacteristics[3].isDivisible = true;
            Response.Property[0].MeetingSpaceCharacteristics[3].mapReferenceNum = "310";
            Response.Property[0].MeetingSpaceCharacteristics[3].parentRoomKey = "";

            return Response;
        }
    }

}