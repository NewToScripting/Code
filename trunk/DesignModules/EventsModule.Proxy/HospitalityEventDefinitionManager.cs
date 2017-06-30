using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.EventReference;

namespace Inspire.Events.Proxy
{
    public class HospitalityEventDefinitionManager
    {
        /// <summary>
        /// Get Events
        /// </summary>
        /// <returns></returns>
        static public List<HospitalityEventDefinition> GetEventDefinitions()
        {
            var events = new List<HospitalityEventDefinition>();
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                HospitalityEventDefinitions proxyEvents = client.GetEventDefinitions();

                foreach (EventReference.HospitalityEventDefinition item in proxyEvents)
                {
                    if(item != null)
                    { 
                        HospitalityEventDefinition eventItem = ProxyFeedToFeed(item);
                        events.Add(eventItem);
                    }
                   

                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting events");
            }

            return events;

        }//end function

        /// <summary>
        /// Get Default
        /// </summary>
        /// <returns></returns>
        static public HospitalityEventDefinition GetDefaultEventDefinition()
        {
            var eventDefinition = new HospitalityEventDefinition();
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                EventReference.HospitalityEventDefinition proxyEvent = client.GetDefaultEventDefinition();
                eventDefinition = ProxyFeedToFeed(proxyEvent);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting event definitions.");
            }

            return eventDefinition;

        }//end function





        /// <summary>
        /// Add Feed
        /// </summary>
        /// <param name="feed"></param>
        static public void AddEventDefinition(HospitalityEventDefinition feed)
        {
            try
            {
                var proxyFeed = new EventReference.HospitalityEventDefinition();
                proxyFeed = FeedToProxyFeed(feed);

                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                client.AddEventDefinition(proxyFeed);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while adding event definition");
            }


        }//end function


        /// <summary>
        /// Delete Feed
        /// </summary>
        /// <param name="feedID"></param>
        static public void DeleteEventDefinition(string feedID)
        {
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                client.DeleteEventDefinition(feedID);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while deleting event definition");
            }

        }//end function


        static public List<EventFileFormat> GetEventFileFormats()
        {
            var items = new List<EventFileFormat>();
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                EventFileFormats proxyItems = client.GetEventFileFormats();

                foreach (EventReference.EventFileFormat item in proxyItems)
                {
                    EventFileFormat eventItem = ProxyEventFileFormatToEventFileFormat(item);
                    items.Add(eventItem);

                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error getting event file format");
            }

            return items;

        }//end function


        static public EventFileFormat GetEventFileFormat(string guid)
        {
            EventFileFormat item = new EventFileFormat();

            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                EventReference.EventFileFormat proxyItem = client.GetEventFileFormat(guid);
                item = ProxyEventFileFormatToEventFileFormat(proxyItem);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error getting event file format");
            }

            return item;

        }//end function

        static public void AddEventFileFormat(EventFileFormat item)
        {
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                EventReference.EventFileFormat proxyItem = EventFileFormatToProxyEventFileFormat(item);
                client.AddEventFileFormat(proxyItem);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error adding event file format");
            }

        }//end function


        static public void UpdateEventFileFormat(EventFileFormat item)
        {
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                EventReference.EventFileFormat proxyItem = EventFileFormatToProxyEventFileFormat(item);
                client.UpdateEventFileFormat(proxyItem);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error updateing event file format");
            }

        }//end function

        static public void DeleteEventFileFormat(string item)
        {
            try
            {
                EventServiceContractClient client = new EventServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventsEndpoint();

                client.DeleteEventFileFormat(item);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error removing event file format");
            }

        }//end function



        /// <summary>
        /// Proxy HospitalityEventDefinition To HospitalityEventDefinition
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public HospitalityEventDefinition ProxyFeedToFeed(EventReference.HospitalityEventDefinition from)
        {

            HospitalityEventDefinition to = new HospitalityEventDefinition();

            to.EventDefinitionGUID = from.EventDefinitionGuid;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Uri = from.Uri;
            to.EventFileFormat = ProxyEventFileFormatToEventFileFormat(from.EventFileFormat);
            // to.SourceType = (SourceTypes)from.SourceType;
            to.Default = from.Default;
            to.UpdateIntervalInMinutes = from.UpdateIntervalMinutes;
            to.Active = from.Active;

            return to;
        }

        /// <summary>
        /// HospitalityEventDefinition To Proxy HospitalityEventDefinition
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public EventReference.HospitalityEventDefinition FeedToProxyFeed(HospitalityEventDefinition from)
        {
            EventReference.HospitalityEventDefinition to = new EventReference.HospitalityEventDefinition();

            to.EventDefinitionGuid = from.EventDefinitionGUID;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Uri = from.Uri;
            to.EventFileFormat = EventFileFormatToProxyEventFileFormat(from.EventFileFormat);
            //to.SourceType = (int)from.SourceType;
            to.Default = from.Default;
            to.UpdateIntervalMinutes = from.UpdateIntervalInMinutes;
            to.Active = from.Active;

            return to;

        }//function   


        /// <summary>
        /// EventFileFormat To Proxy EventFileFormat
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public EventReference.EventFileFormat EventFileFormatToProxyEventFileFormat(EventFileFormat from)
        {
            EventReference.EventFileFormat to = new EventReference.EventFileFormat();

            if (from != null)
            {
                to.EventFileFormatGuid = from.EventFileFormatGuid;
                to.EventFormatName = from.EventFormatName;
                to.FieldDelimeter = from.FieldDelimeter;
                to.IsReadOnly = from.IsReadOnly;
                to.SkipFirstFile = from.SkipFirstFile;
                to.TextFormat = (int)from.TextFormat;
                to.FieldContracts = FieldContractToProxyFieldContract(from.FieldContracts, from.EventFileFormatGuid);

            }
            return to;

        }//function     


        /// <summary>
        /// Proxy EventFileFormat To EventFileFormat
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public EventFileFormat ProxyEventFileFormatToEventFileFormat(EventReference.EventFileFormat from)
        {
            EventFileFormat to = new EventFileFormat();

            if (from != null)
            {
                to.EventFileFormatGuid = from.EventFileFormatGuid;
                to.EventFormatName = from.EventFormatName;
                to.IsReadOnly = from.IsReadOnly;
                to.FieldDelimeter = from.FieldDelimeter;
                to.SkipFirstFile = from.SkipFirstFile;

                switch (from.TextFormat)
                {
                    case 1:
                        {
                            to.TextFormat = TextFormats.Fixed;
                            break;
                        }
                    case 2:
                        {
                            to.TextFormat = TextFormats.Separated;
                            break;
                        };

                }

                to.FieldContracts = ProxyFieldContractToFieldContract(from.FieldContracts, from.EventFileFormatGuid);

            }
            return to;
        }


        /// <summary>
        /// ProxyFieldContractToFieldContract
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public List<FieldContract> ProxyFieldContractToFieldContract(EventReference.FieldContracts from, string guid)
        {
            List<FieldContract> to = new List<FieldContract>();

                if(from != null)
                {
                    foreach (EventReference.FieldContract i in from)
                    {
                        FieldContract t = new FieldContract();

                            if (i != null)
                            {
                                t.GUID = i.GUID;
                                t.EventFileFormatGuid = guid;
                                t.FieldType = i.FieldType;
                                t.Length = (int)i.Length;
                                t.Start = (int)i.Start;
                                t.Value = i.Value;
                                t.Name = i.Name;
                                to.Add(t);
                            }
                        
                }
            }
            
            return to;
        }

        /// <summary>
        /// ProxyFieldContractToFieldContract
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public EventReference.FieldContracts FieldContractToProxyFieldContract(List<FieldContract> from, string guid)
        {
            EventReference.FieldContracts to = new EventReference.FieldContracts();

            foreach (FieldContract i in from)
            {
                EventReference.FieldContract t = new EventReference.FieldContract();
                    if (i != null)
                    {   
                        t.GUID = i.GUID;
                        t.EventFileFormatGuid = guid;
                        t.FieldType = i.FieldType;
                        t.Length = (int)i.Length;
                        t.Start = (int)i.Start;
                        t.Value = i.Value;
                        t.Name = i.Name;
                        to.Add(t);
                    }
            
            }
            return to;
        }



    }//class
}//namespace
