using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newmarket.WebServices.MeetingSpace.client;
using Newmarket.WebServices.MeetingSpaceFaults;
using MeetingSpaceService_TestHarness.Inspire.Server.Events;

namespace MeetingSpaceService_TestHarness
{
    public class ProxyHelper
    {
        public static HospitalityEvents LoadEvents(MeetingSpaceResponse response)
        {
            HospitalityEvents items = new HospitalityEvents();
            foreach (PropertyType prop in response.Property)
            {
                foreach (EventType ev in prop.Event)
                {
                    foreach (MeetingSpaceType sp in ev.MeetingSpace)
                    {
                        items.Add(LoadEventSingle(prop.propertyName, ev.eventName, ev.eventPostAs, ev.Group.logoURL, sp));                        
                    }
                }
            }

            return items;
        }

        public static HospitalityEvent LoadEventSingle(string hotelName, string eventName, string eventPostAs, string groupLogo, MeetingSpaceType sp)
        {

             HospitalityEvent item = new HospitalityEvent();
                                    item.EventDefinitionId = Guid.Empty.ToString();
                                    item.EventId = Guid.NewGuid().ToString();  
            
                                    //Property
                                    item.HotelName = hotelName;
                                    
                                    //Event
                                    if (!string.IsNullOrEmpty(eventPostAs))
                                        item.GroupName = eventPostAs;
                                    else
                                        item.GroupName = eventName;

                                    //MeetingSpace
                                    item.StartDateTime = sp.startDateTime;
                                    item.EndDateTime = sp.endDateTime;
                                    //item.Exhibit = sp.isExhibit;
                                    item.Postable = sp.isPostable;
                                    
                                    item.MeetingPostAs = sp.meetingPostAs;

                                    if (!String.IsNullOrEmpty(sp.meetingPostAs))
                                    {
                                        item.MeetingName = sp.meetingPostAs;
                                    }
                                    else
                                    {
                                        item.MeetingName = sp.meetingName;
                                    }

                                    item.MeetingId = sp.meetingKey;
                                    item.MeetingRoomName = sp.roomName;
                                    item.MeetingRoomId = sp.roomKey;
            

                                    return item;
             }        
    }
}
