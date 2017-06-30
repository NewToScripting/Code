using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Events.Proxy.EventReference;

namespace Inspire.Events.Proxy
{
    class EventManager
    {
        /// <summary>
        /// Feed Manager
        /// </summary>
        public class FeedManager
        {
            /// <summary>
            /// Get Events
            /// </summary>
            /// <returns></returns>
            static public List<HospitalityEvent> GetEvents(string eventDescriptionID)
            {
                var events = new List<Inspire.Events.Proxy.HospitalityEvent>();
                try
                {
                    EventServiceContractClient client = new EventServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                    Inspire.Events.Proxy.EventReference.HospitalityEvents proxyEvents = client.GetEvents(eventDescriptionID);


                    foreach (Inspire.Events.Proxy.EventReference.HospitalityEvent item in proxyEvents)
                    {
                        Inspire.Events.Proxy.HospitalityEvent eventItem = ProxyFeedToFeed(item);
                        events.Add(eventItem);

                    }
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while getting events");
                }

                return events;

            }//end function

            /// <summary>
            /// Add Feed
            /// </summary>
            /// <param name="feed"></param>
            static public void AddEvent(Inspire.Events.Proxy.HospitalityEvent feed)
            {
                try
                {
                    var proxyFeed = new Inspire.Events.Proxy.EventReference.HospitalityEvent();
                    proxyFeed = FeedToProxyFeed(feed);

                    EventServiceContractClient client = new EventServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                    client.AddEvent(proxyFeed);
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while adding event");
                }


            }//end function

            ///// <summary>
            ///// Update Feed
            ///// </summary>
            ///// <param name="feed"></param>
            //static public void UpdateFeed(Feed feed)
            //{
            //    try
            //    {
            //        var proxyFeed = new Inspire.Events.Proxy.FeedsServiceReference.Feed();
            //        proxyFeed = FeedToProxyFeed(feed);

            //        FeedServiceContractClient client = new FeedServiceContractClient();
            //        client.Endpoint.Address = SeverSettings.GetFeedsEndpoint();

            //        client.UpdateFeed(proxyFeed);
            //    }
            //    catch (Exception e)
            //    {
            //        ProxyErrorHandler.Throw(e, "Error occured while updating feed");
            //    }

            //}//end function

            /// <summary>
            /// Delete Feed
            /// </summary>
            /// <param name="feedID"></param>
            static public void DeleteEvent(string feedID)
            {
                try
                {
                    EventServiceContractClient client = new EventServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                    client.DeleteEvent(feedID);

                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while deleting event");
                }

            }//end function


            /// <summary>
            /// Proxy Feed To Feed
            /// </summary>
            /// <param name="from"></param>
            /// <returns></returns>
            static public Inspire.Events.Proxy.HospitalityEvent ProxyFeedToFeed(Inspire.Events.Proxy.EventReference.HospitalityEvent from)
            {

                Inspire.Events.Proxy.HospitalityEvent to = new Inspire.Events.Proxy.HospitalityEvent();

                to.BackupMeetingRoomSpace = from.BackupMeetingRoomSpace;
                to.Date = from.Date;
                to.EndDate = from.EndDate;
                to.EndTime = from.EndTime;
                to.Exhibit = from.Exhibit;
                to.GroupLogo = from.GroupLogo;
                to.GroupName = from.GroupName;
                to.HostEventIdentifier = from.HostEventIdentifier;
                to.HotelName = from.HotelName;
                to.IsVisible = from.IsVisible;
                to.MeetingID = from.MeetingId;
                to.MeetingLogo = from.MeetingLogo;
                to.MeetingName = from.MeetingName;
                to.MeetingPostAs = from.MeetingPostAs;
                to.MeetingRoomID = from.MeetingRoomId;
                to.MeetingRoomLogo = from.MeetingRoomLogo;
                to.MeetingRoomName = from.MeetingRoomName;
                to.MeetingType = from.MeetingType;
                to.OverflowMeetingRoomSpace = from.OverFlowMeetingRoomSpace;
                to.Postable = from.Postable;
                to.StartDate = from.StartDate;
                to.StartTime = from.StartTime;
                to.MeetingType = from.MeetingType;

                return to;
            }

            /// <summary>
            /// Feed To Proxy Feed
            /// </summary>
            /// <param name="from"></param>
            /// <returns></returns>
            static public Inspire.Events.Proxy.EventReference.HospitalityEvent FeedToProxyFeed(Inspire.Events.Proxy.HospitalityEvent from)
            {
                Inspire.Events.Proxy.EventReference.HospitalityEvent to = new Inspire.Events.Proxy.EventReference.HospitalityEvent();

                to.BackupMeetingRoomSpace = from.BackupMeetingRoomSpace;
                to.Date = from.Date;
                to.EndDate = from.EndDate;
                to.EndTime = from.EndTime;
                to.Exhibit = from.Exhibit;
                to.GroupLogo = from.GroupLogo;
                to.GroupName = from.GroupName;
                to.HostEventIdentifier = from.HostEventIdentifier;
                to.HotelName = from.HotelName;
                to.IsVisible = from.IsVisible;
                to.MeetingId = from.MeetingID;
                to.MeetingLogo = from.MeetingLogo;
                to.MeetingName = from.MeetingName;
                to.MeetingPostAs = from.MeetingPostAs;
                to.MeetingRoomId = from.MeetingRoomID;
                to.MeetingRoomLogo = from.MeetingRoomLogo;
                to.MeetingRoomName = from.MeetingRoomName;
                to.MeetingType = from.MeetingType;
                to.OverFlowMeetingRoomSpace = from.OverflowMeetingRoomSpace;
                to.Postable = from.Postable;
                to.StartDate = from.StartDate;
                to.StartTime = from.StartTime;
                to.MeetingType = from.MeetingType;

                return to;

            }//function
        }

    }
}