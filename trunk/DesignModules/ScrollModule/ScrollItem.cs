using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel.Syndication;
using System.Windows.Documents;
using System.IO;
using HTMLConverter;
using System.Text;
using System.Collections.Generic;
using RSSModule;

namespace ScrollModule
{
    [Serializable]
    public class ScrollItem : IScrollItem
    {
        public ScrollItem()
        {
        }

        public ScrollItem(string scrollType, string scrollContent, ListBox scrollItemHelpers)
        {
            ScrollType = scrollType;
            ScrollContent = scrollContent;
            ScrollItemHelpers = scrollItemHelpers;
        }

        /// <summary>
        /// String that represents the content type that is being scrolled
        /// Text = Text that can be scrolled, such as messages or typed information
        /// RSS = Scrolls RSS Information
        /// </summary>
        public string ScrollType { get; set; }

        /// <summary>
        /// String that represents the information for the type - for text this would hold the actual text. For RSS - this would hold the Rss Feed URL
        /// </summary>
        public string ScrollContent { get; set; }

        /// <summary>
        /// Holds Framework Elements that hold data for the Scroll elements. Such as Font Sizes, Font Types, etc. Children must derive from FrameworkElement and be serializable. Also to prevent
        /// changes breaking
        /// </summary>
        public ListBox ScrollItemHelpers { get; set; }

        // Instead of Enums, to make serialization and deserialization safer, the ScrollType is set as a string
        // 

        public List<FrameworkElement> GetScrollItems(string scrollinfo)
        {
            try
            {
                List<FrameworkElement> frameworkElements = new List<FrameworkElement>();
                switch (ScrollType)
                {
                    case ("Text"):
                        if (ScrollItemHelpers.Items != null)
                        {
                            TextBlock scrollTextBlock = ScrollItemHelpers.Items[0] as TextBlock;
                            if (scrollTextBlock != null)
                            {
                                var textBlock = new TextBlock();
                                textBlock.Text = scrollTextBlock.Text;
                                textBlock.VerticalAlignment = VerticalAlignment.Center;
                                textBlock.Foreground = scrollTextBlock.Foreground;
                                textBlock.FontSize = scrollTextBlock.FontSize;
                                textBlock.Tag = scrollTextBlock.Tag;
                                textBlock.FontFamily = scrollTextBlock.FontFamily;
                                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                                textBlock.FontStyle = scrollTextBlock.FontStyle;
                                textBlock.FontWeight = scrollTextBlock.FontWeight;
                                textBlock.TextDecorations = scrollTextBlock.TextDecorations;

                                if (scrollinfo == "Up" || scrollinfo == "Down")
                                    textBlock.TextWrapping = TextWrapping.Wrap;

                                frameworkElements.Add(textBlock);

                                return frameworkElements;
                            }
                        }
                        break;
                    case ("RSS"):
                        if (ScrollItemHelpers.Items != null)
                        {
                            TextBlock titleTB = ScrollItemHelpers.Items[0] as TextBlock;
                            TextBlock descTB = ScrollItemHelpers.Items[1] as TextBlock;

                            if (titleTB != null)
                            {
                                try
                                {
                                    SyndicationFeed BlogFeed = new SyndicationFeed();

                                    List<SyndicationItem> scrollItems = null;

                                    if (titleTB.Text.Length > 0)
                                    {
                                        scrollItems = RSSHelpers.GetFeed(titleTB.Text, true).ToList();
                                    }
                                    //using (XmlReader reader = XmlReader.Create(titleTB.Text))
                                    //{
                                    //    BlogFeed = SyndicationFeed.Load(reader);
                                    //    reader.Close();
                                    //}

                                    if (scrollItems != null)
                                    {
                                        int pullNumber;

                                        if (int.TryParse(titleTB.Tag.ToString(), out pullNumber))
                                        {
                                            if (pullNumber > 100)
                                                pullNumber = 20;
                                        }
                                        else
                                            pullNumber = 5;


                                        int itemCount = scrollItems.Count();

                                        if (pullNumber > itemCount)
                                            pullNumber = itemCount;

                                        if (BlogFeed != null)
                                            foreach (SyndicationItem item in scrollItems.GetRange(0, pullNumber))
                                            //new List<SyndicationItem>(BlogFeed.Items).GetRange(0, pullNumber)
                                            {
                                                StackPanel feedElement = new StackPanel();

                                                feedElement.Orientation = Orientation.Horizontal;
                                                feedElement.VerticalAlignment = VerticalAlignment.Center;
                                                feedElement.HorizontalAlignment = HorizontalAlignment.Center;

                                                string RSSTitle = string.Empty;
                                                if (item.Title != null)
                                                    RSSTitle =
                                                        Inspire.Utilities.ConvertWhitespaceToSpaces(item.Title.Text);

                                                var textBlock = new TextBlock();
                                                textBlock.Text = RSSTitle + "  -  ";
                                                textBlock.VerticalAlignment = VerticalAlignment.Center;
                                                textBlock.Foreground = titleTB.Foreground;
                                                textBlock.FontSize = titleTB.FontSize;
                                                textBlock.Tag = titleTB.Tag;
                                                textBlock.FontFamily = titleTB.FontFamily;
                                                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                                                textBlock.FontStyle = titleTB.FontStyle;
                                                textBlock.FontWeight = titleTB.FontWeight;
                                                textBlock.TextDecorations = titleTB.TextDecorations;
                                                feedElement.Children.Add(textBlock);

                                                //var RSSDescription = new FlowDocument();

                                                string rssDesc = string.Empty;

                                                //var flowDocument = new FlowDocument();
                                                if (item.Summary != null)
                                                {
                                                    try
                                                    {
                                                        string xaml =
                                                            HtmlToXamlConverter.ConvertHtmlToXaml(item.Summary.Text,
                                                                                                  false,
                                                                                                  Convert.ToInt32(
                                                                                                      descTB.FontSize),
                                                                                                  descTB.FontFamily.
                                                                                                      ToString
                                                                                                      ());

                                                        using (
                                                            MemoryStream stream =
                                                                new MemoryStream((new ASCIIEncoding()).GetBytes(xaml)))
                                                        {
                                                            try
                                                            {
                                                                var flowDocument = new FlowDocument();
                                                                TextRange text = new TextRange(
                                                                    flowDocument.ContentStart,
                                                                    flowDocument.ContentEnd);
                                                                text.Load(stream, DataFormats.Xaml);
                                                                rssDesc =
                                                                    Inspire.Utilities.ConvertWhitespaceToSpaces(
                                                                        text.Text);
                                                            }
                                                            catch (Exception)
                                                            {
                                                                //flowDocument = null;
                                                            }
                                                            finally
                                                            {
                                                                stream.Dispose();
                                                            }
                                                        }

                                                    }
                                                    catch (Exception)
                                                    {
                                                        // flowDocument = null;
                                                    }

                                                }
                                                if (rssDesc.Length > 0)
                                                {
                                                    var rssBlock = new TextBlock();
                                                    rssBlock.VerticalAlignment = VerticalAlignment.Center;
                                                    rssBlock.Text = rssDesc + "     ";
                                                    rssBlock.Foreground = descTB.Foreground;
                                                    rssBlock.FontSize = descTB.FontSize;
                                                    rssBlock.FontFamily = descTB.FontFamily;
                                                    rssBlock.HorizontalAlignment = HorizontalAlignment.Center;
                                                    rssBlock.FontStyle = descTB.FontStyle;
                                                    rssBlock.FontWeight = descTB.FontWeight;
                                                    rssBlock.TextDecorations = descTB.TextDecorations;

                                                    feedElement.Children.Add(rssBlock);
                                                }

                                                double mostWidth = 0d;

                                                foreach (UIElement uiElement in feedElement.Children)
                                                {
                                                    uiElement.Measure(new Size(double.PositiveInfinity,
                                                                               double.PositiveInfinity));

                                                    mostWidth += uiElement.DesiredSize.Width;
                                                }

                                                feedElement.Width = mostWidth;

                                                frameworkElements.Add(feedElement);
                                            }
                                    }
                                    return frameworkElements;
                                }
                                catch (Exception)
                                {
                                    // TODO: Log Error
                                    return null;
                                }
                            }
                        }
                        break;
                }
                return frameworkElements;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}

