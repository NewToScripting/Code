using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace RSSModule
{
    public static class RSSHelpers
    {
        /// <summary>      
        /// Gets an RSS feed from a given URL and returns the resulting XML as a string.    
        /// </summary> 
        /// <param name="url">URL of the feed to load.</param>
        /// <param name="convertSummaryToString">Convert html into text?</param>
        /// <returns>The feed XML as a string.</returns> 
        public static IEnumerable<SyndicationItem> GetFeed(string url, bool convertSummaryToString)
        {

            XmlReaderSettings settings = new XmlReaderSettings();

            settings.IgnoreWhitespace = true;

            settings.CheckCharacters = true;

            settings.CloseInput = true;

            settings.IgnoreComments = true;

            settings.IgnoreProcessingInstructions = true;

            settings.DtdProcessing = DtdProcessing.Ignore;

            try
            {
                using (XmlReader reader = XmlReader.Create(url, settings))
                {
                    SyndicationFeedFormatter formatter = null;

                    Atom10FeedFormatter atom = new Atom10FeedFormatter();

                    Rss20FeedFormatter rss = new Rss20FeedFormatter();

                    SyndicationFeed feed;

                    // Determine the format of the feed 

                    if (reader.ReadState == ReadState.Initial)
                    {
                        reader.MoveToContent();
                    }

                    if (atom.CanRead(reader))
                    {
                        formatter = atom;
                    }

                    if (rss.CanRead(reader))
                    {

                        formatter = rss;

                    }

                    if (formatter == null)
                    {

                        throw new Exception("The feeed is not supported.");

                    }

                    formatter.ReadFrom(reader);
                    feed = formatter.Feed;


                    //// Remove unwanted items 
                    //List<SyndicationItem> items = new List<SyndicationItem>();
                    //int added = 0;

                    //foreach (SyndicationItem i in feed.Items)
                    //{

                    //    items.Add(i);

                    //    if (added++ == count - 1) break;
                    //}

                    //feed.Items = items;
                    //StringWriter sw = new StringWriter();
                    //XmlTextWriter tw = new XmlTextWriter(sw);



                    //feed.SaveAsRss20(tw);
                    //string rfeed = sw.ToString();

                    //using (var reader2 = XmlReader.Create(new StringReader(rfeed)))
                    //{
                    //    var feed2 = SyndicationFeed.Load(reader2);
                    //    items.Clear();

                    //    foreach (SyndicationItem i in feed2.Items)
                    //    {
                    //        items.Add(i);
                    //    }
                    //}

                    if (convertSummaryToString)
                    {
                        var newItems = new List<SyndicationItem>();

                        foreach (var item in feed.Items)
                        {
                            string rssDesc = string.Empty;

                            //var flowDocument = new FlowDocument();
                            if (item.Summary != null)
                            {
                                try
                                {
                                    // Remove HTML tags and empty newlines and spaces
                                    string returnString = Regex.Replace(item.Summary.Text, "<.*?>", "");
                                    returnString = Regex.Replace(returnString, @"\n+\s+", "\n\n");

                                    // Decode HTML entities
                                    rssDesc = HttpUtility.HtmlDecode(returnString);

                                    rssDesc = rssDesc.Replace("&nbsp;", " ");

                                    rssDesc = rssDesc.Replace("&#39;", "'");

                                    rssDesc = rssDesc.Replace("&apos;", "'");

                                    //string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(item.Summary.Text, false,
                                    //                                                    Convert.ToInt32(14),
                                    //                                                   "Arial");

                                    //using (MemoryStream stream = new MemoryStream((new ASCIIEncoding()).GetBytes(xaml)))
                                    //{
                                    //    try
                                    //    {
                                    //        var flowDocument = new FlowDocument();
                                    //        TextRange text = new TextRange(flowDocument.ContentStart,
                                    //                                       flowDocument.ContentEnd);
                                    //        text.Load(stream, DataFormats.Xaml);
                                    //        rssDesc = Inspire.Utilities.ConvertWhitespaceToSpaces(text.Text);
                                    //    }
                                    //    catch (Exception)
                                    //    {
                                    //        //flowDocument = null;
                                    //        stream.Close();
                                    //    }
                                    //}

                                }
                                catch (Exception)
                                {
                                    throw new Exception("Failed to convert HTML to text");
                                }

                            }
                            var syndicationItem = new SyndicationItem();
                            syndicationItem.Title = new TextSyndicationContent(item.Title.Text.Trim());
                            syndicationItem.Summary = new TextSyndicationContent(rssDesc);
                            newItems.Add(syndicationItem);
                        }
                        return newItems;
                    }
                    return feed.Items;
                }
            }
            catch
            {
                return new List<SyndicationItem>();
                //throw new Exception("The feed could not be read. Please check the URL.");
            }
        }
    }
}
