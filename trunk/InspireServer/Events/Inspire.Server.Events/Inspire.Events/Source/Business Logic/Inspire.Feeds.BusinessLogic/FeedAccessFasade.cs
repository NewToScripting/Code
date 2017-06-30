//using Inspire.Server.Feeds.DataAccess;


//namespace Inspire.Server.Feeds.BusinessLogic
//{
//    /// <summary>
//    /// Feed Access Fasade
//    /// </summary>
//    public class FeedAccessFasade
//    {
//        /// <summary>
//        /// Get Feeds
//        /// </summary>
//        /// <returns></returns>
//       static public DataContracts.Feeds GetFeeds()
//        {
//            DataContracts.Feeds feeds = new DataContracts.Feeds();
//            feeds = HospitalityEventDescriptionsDatabaseAccess.GetFeeds();
//            return feeds;
//        }

//        /// <summary>
//        /// Add Feed
//        /// </summary>
//        /// <param name="feed"></param>
//       static public void AddFeed(DataContracts.Feed feed)
//        {
//            HospitalityEventDescriptionsDatabaseAccess.AddFeed(feed);
//        }

//        /// <summary>
//        /// Update Feed
//        /// </summary>
//        /// <param name="feed"></param>
//       static public void UpdateFeed(DataContracts.Feed feed)
//        {
//            HospitalityEventDescriptionsDatabaseAccess.UpdateFeed(feed);
//        }

//        /// <summary>
//        /// Delete Feed
//        /// </summary>
//        /// <param name="feedID"></param>
//       static public void DeleteFeed(string feedID)
//        {
//            HospitalityEventDescriptionsDatabaseAccess.DeleteFeed(feedID);
//        }

//    }
//}
