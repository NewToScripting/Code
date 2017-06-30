using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.FeedsServiceReference;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Feed Manager
    /// </summary>
    public class FeedManager
    {
        /// <summary>
        /// Get Feeds
        /// </summary>
        /// <returns></returns>
        static public List<Feed> GetFeeds()
        {
            var feeds = new List<Inspire.Events.Proxy.Feed>();
            try
            {
                FeedServiceContractClient client = new FeedServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetFeedsEndpoint();
                
                Inspire.Events.Proxy.FeedsServiceReference.Feeds proxyFeeds = client.GetFeeds();
                

                foreach (Inspire.Events.Proxy.FeedsServiceReference.Feed item in proxyFeeds)
                    {
                        Inspire.Events.Proxy.Feed feed = ProxyFeedToFeed(item);
                        feeds.Add(feed);

                    }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting feeds");
            }
            
            return feeds;
                      
        }//end function

        /// <summary>
        /// Add Feed
        /// </summary>
        /// <param name="feed"></param>
        static public void AddFeed(Inspire.Events.Proxy.Feed feed)
        {
            try
            {
                var proxyFeed = new Inspire.Events.Proxy.FeedsServiceReference.Feed();
                proxyFeed = FeedToProxyFeed(feed);
                
                FeedServiceContractClient client = new FeedServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetFeedsEndpoint();

                client.AddFeed(proxyFeed);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding feed");
            }
           
            
        }//end function

        /// <summary>
        /// Update Feed
        /// </summary>
        /// <param name="feed"></param>
        static public void UpdateFeed(Feed feed)
        {
            try
            {
                var proxyFeed = new Inspire.Events.Proxy.FeedsServiceReference.Feed();
                proxyFeed = FeedToProxyFeed(feed);

                FeedServiceContractClient client = new FeedServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetFeedsEndpoint();

                client.UpdateFeed(proxyFeed);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating feed");
            }
            
        }//end function

        /// <summary>
        /// Delete Feed
        /// </summary>
        /// <param name="feedID"></param>
        static public void DeleteFeed(string feedID)
        {
            try
            {
                FeedServiceContractClient client = new FeedServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetFeedsEndpoint();

                client.DeleteFeed(feedID);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting feed");
            }
           
        }//end function


        /// <summary>
        /// Proxy Feed To Feed
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public Inspire.Events.Proxy.Feed ProxyFeedToFeed(Inspire.Events.Proxy.FeedsServiceReference.Feed from)
        {

            Inspire.Events.Proxy.Feed to = new Inspire.Events.Proxy.Feed();

            to.Name = from.Name;
            to.DateField1Def = from.DateField1Def;
            to.DateField2Def = from.DateField2Def;
            to.DateField3Def = from.DateField3Def;
            to.DateField4Def = from.DateField4Def;
            to.DecimalField1Def = from.DecimalField1Def;
            to.DecimalField2Def = from.DecimalField2Def;
            to.DescField1Def = from.DescField1Def;
            to.DescField2Def = from.DescField2Def;
            to.DescField3Def = from.DescField3Def;
            to.DescField4Def = from.DescField4Def;
            to.Description = from.Description;
            to.GUID = from.GUID;
            to.IntField1Def = from.IntField1Def;
            to.IntField2Def = from.IntField2Def;
            to.NameField1Def = from.NameField1Def;
            to.NameField2Def = from.NameField2Def;
            to.NameField3Def = from.NameField3Def;
            to.NameField4Def = from.NameField4Def;
            to.TextField1Def = from.TextField1Def;
            to.TextField2Def = from.TextField2Def;

            return to;
        }

        /// <summary>
        /// Feed To Proxy Feed
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        static public Inspire.Events.Proxy.FeedsServiceReference.Feed FeedToProxyFeed(Inspire.Events.Proxy.Feed from)
        {

            Inspire.Events.Proxy.FeedsServiceReference.Feed to = new Inspire.Events.Proxy.FeedsServiceReference.Feed();

            to.Name = from.Name;
            to.DateField1Def = from.DateField1Def;
            to.DateField2Def = from.DateField2Def;
            to.DateField3Def = from.DateField3Def;
            to.DateField4Def = from.DateField4Def;
            to.DecimalField1Def = from.DecimalField1Def;
            to.DecimalField2Def = from.DecimalField2Def;
            to.DescField1Def = from.DescField1Def;
            to.DescField2Def = from.DescField2Def;
            to.DescField3Def = from.DescField3Def;
            to.DescField4Def = from.DescField4Def;
            to.Description = from.Description;
            to.GUID = from.GUID;
            to.IntField1Def = from.IntField1Def;
            to.IntField2Def = from.IntField2Def;
            to.NameField1Def = from.NameField1Def;
            to.NameField2Def = from.NameField2Def;
            to.NameField3Def = from.NameField3Def;
            to.NameField4Def = from.NameField4Def;
            to.TextField1Def = from.TextField1Def;
            to.TextField2Def = from.TextField2Def;

            return to;

        }//function
     }//class
}//namespace
