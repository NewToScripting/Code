using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Ribbon;
using ActiproSoftware.Windows.Controls.Ribbon.Input;


namespace EventsModule.Commands
{
    public static class EventsModuleCommands
    {
        public static RoutedCommand AddDisplayRoomCommand = new RoutedCommand();
        public static RoutedCommand RemoveDisplayRoomCommand = new RoutedCommand();

        public static RoutedCommand AddRoomCommand = new RoutedCommand();
        public static RoutedCommand RemoveRoomCommand = new RoutedCommand();

        public static RoutedCommand AddDataSourceCommand = new RoutedCommand();
        public static RoutedCommand EditDataSourceCommand = new RoutedCommand();
        public static RoutedCommand RemoveDataSourceCommand = new RoutedCommand();
        public static RoutedCommand SaveDataSourceCommand = new RoutedCommand();
        public static RoutedCommand ClearDataSourceCommand = new RoutedCommand();

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

    }
}
