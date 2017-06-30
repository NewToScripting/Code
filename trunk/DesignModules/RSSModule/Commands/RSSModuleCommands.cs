using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Ribbon;
using ActiproSoftware.Windows.Controls.Ribbon.Input;

namespace RSSModule.Commands
{
    public static class RSSModuleCommands
    {

        public static RoutedCommand AddRSSFeedCommand = new RoutedCommand();

        private static RibbonCommand applyTitleForeground; 
        public static RoutedCommand UpScrollItemCommand = new RoutedCommand();
        public static RoutedCommand DownScrollItemCommand = new RoutedCommand();

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a foreground.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a foreground.</value>
        public static RibbonCommand ApplyTitleForeground
        {
            get
            {
                if (applyTitleForeground == null)
                    applyTitleForeground = new RibbonCommand("ApplyTitleForeground", typeof(Ribbon), "Text Color");
                return applyTitleForeground;
            }
        }

        private static RibbonCommand applyDescriptionForeground;

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a foreground.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a foreground.</value>
        public static RibbonCommand ApplyDescriptionForeground
        {
            get
            {
                if (applyDescriptionForeground == null)
                    applyDescriptionForeground = new RibbonCommand("ApplyDescriptionForeground", typeof(Ribbon), "Text Color");
                return applyDescriptionForeground;
            }
        }
    }
}
