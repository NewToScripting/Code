using System;
using System.Windows;
using System.Windows.Controls;

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

        public FrameworkElement GetScrollItem()
        {
            FrameworkElement frameworkElement = null;
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
                            textBlock.FontSize = scrollTextBlock.FontSize;
                            textBlock.Foreground = scrollTextBlock.Foreground;
                            textBlock.FontFamily = scrollTextBlock.FontFamily;
                            return textBlock;
                        }
                    }
                    break;
            }
            return frameworkElement;
        }

    }

    
}
