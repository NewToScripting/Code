using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Ribbon;
using ActiproSoftware.Windows.Controls.Ribbon.Input;

namespace ScrollModule.Commands
{
    public static class ScrollModuleCommands
    {
        private static RibbonCommand applyForeground;

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a foreground.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a foreground.</value>
        public static RibbonCommand ApplyForeground
        {
            get
            {
                if (applyForeground == null)
                    applyForeground = new RibbonCommand("ApplyForeground", typeof(Ribbon), "Text Color");
                return applyForeground;
            }
        }

        public static RoutedCommand PlayScrollCommand = new RoutedCommand();
        public static RoutedCommand StopScrollCommand = new RoutedCommand();
        public static RoutedCommand UpScrollItemCommand = new RoutedCommand();
        public static RoutedCommand DownScrollItemCommand = new RoutedCommand();
    }
}
