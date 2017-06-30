using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Ribbon;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Inspire.Properties;

namespace Inspire.Commands
{
    public class InspireCommands
    {
        public static RoutedCommand AdminLoginCommand = new RoutedCommand(); // TODO: Take this out after Demos!
        public static RoutedCommand RegisterCommand = new RoutedCommand();


        public static RoutedCommand OkCommand = new RoutedUICommand(InspireApp.ResourceManager.GetString("OkCommand"), "OkCommand", typeof(InspireCommands));
        public static RoutedCommand CancelCommand = new RoutedUICommand(InspireApp.ResourceManager.GetString("CancelCommand"), "CancelCommand", typeof(InspireCommands));

        public static RoutedCommand SaveCommand = new RoutedUICommand(InspireApp.ResourceManager.GetString("SaveCommand"), "SaveCommand", typeof(InspireCommands));


        public static RoutedCommand RefreshTreeCommand = new RoutedCommand();
        public static RoutedCommand RefreshSlidesCommand = new RoutedCommand();

        public static RoutedCommand LoadOfflineFileDialogCommand = new RoutedCommand();
        public static RoutedCommand UploadSlideToServer = new RoutedCommand();

        public static RoutedCommand NewPropertyCommand = new RoutedCommand();
        public static RoutedCommand EditPropertyCommand = new RoutedCommand();
        public static RoutedCommand DeletePropertyCommand = new RoutedCommand();

        public static RoutedCommand NewDisplayGroupCommand = new RoutedCommand();
        public static RoutedCommand EditDisplayGroupCommand = new RoutedCommand();
        public static RoutedCommand DeleteDisplayGroupCommand = new RoutedCommand();

        public static RoutedCommand NewDisplayCommand = new RoutedCommand();
        public static RoutedCommand EditDisplayCommand = new RoutedCommand();
        public static RoutedCommand DeleteDisplayCommand = new RoutedCommand();
        public static RoutedCommand SaveDisplayCommand = new RoutedCommand();

        public static RoutedCommand SaveDisplayFormCommand = new RoutedCommand();
        public static RoutedCommand SaveGroupFormCommand = new RoutedCommand();
        public static RoutedCommand SavePropertyFormCommand = new RoutedCommand();

        public static RoutedCommand NewScheduleCommand = new RoutedCommand();
        public static RoutedCommand NewBlankScheduleCommand = new RoutedCommand();
        public static RoutedCommand EditScheduleCommand = new RoutedCommand();
        public static RoutedCommand DeleteScheduleCommand = new RoutedCommand();
        public static RoutedCommand SaveScheduleCommand = new RoutedCommand();
        public static RoutedCommand UpdateScheduleCommand = new RoutedCommand();
        public static RoutedCommand CancelScheduleCommand = new RoutedCommand();
        public static RoutedCommand RemoveDisplayFromScheduleCommand = new RoutedCommand();

        public static RoutedCommand FillCalendarCommand = new RoutedCommand();
        public static RoutedCommand FillScheduledSlidesCommand = new RoutedCommand();
        public static RoutedCommand ClearScheduledSlidesCommand = new RoutedCommand();

        public static RoutedCommand NewSlideCommand = new RoutedCommand();
        public static RoutedCommand SchedulerNewSlideCommand = new RoutedCommand();
        public static RoutedCommand EditSlideCommand = new RoutedCommand();
        public static RoutedCommand DeleteSlideCommand = new RoutedCommand();
        public static RoutedCommand SaveSlideCommand = new RoutedCommand();
        public static RoutedCommand LoadSlideCommand = new RoutedCommand();

        public static RoutedCommand SaveSlideToServerCommand = new RoutedCommand();

        public static RoutedCommand SaveSlideLocalCommand = new RoutedCommand();

        public static RoutedCommand ExportSlideCommand = new RoutedCommand();

        public static RoutedCommand DeleteScheduledSlideCommand = new RoutedCommand();

        public static RoutedCommand UpdateDisplaysCommand = new RoutedCommand();

        public static RoutedCommand PlayCanvasCommand = new RoutedCommand();
        public static RoutedCommand StopCanvasCommand = new RoutedCommand();

        public static RoutedCommand PlayScheduleCommand = new RoutedCommand();

        public static RoutedCommand PreviewScheduleForDisplayCommand = new RoutedCommand();
        public static RoutedCommand PreviewCurrentContentsCommand = new RoutedCommand();

        public static RoutedCommand ClearSlideCommand = new RoutedCommand();

        public static RoutedCommand ShowDesignerCommand = new RoutedCommand();
        public static RoutedCommand ShowSchedulerCommand = new RoutedCommand();
        public static RoutedCommand ShowConfigurationCommand = new RoutedCommand();
        public static RoutedCommand ShowLayersPanel = new RoutedCommand();

        public static RoutedCommand CopyCommand = new RoutedCommand();
        public static RoutedCommand DuplicateCommand = new RoutedCommand();
        public static RoutedCommand CutCommand = new RoutedCommand();
        public static RoutedCommand PasteCommand = new RoutedCommand();
        public static RoutedCommand DeleteCommand = new RoutedCommand();

        public static RoutedCommand UndoCommand = new RoutedCommand();
        public static RoutedCommand RedoCommand = new RoutedCommand();

        public static RoutedCommand SendBackwardCommand = new RoutedCommand();
        public static RoutedCommand SendToBackCommand = new RoutedCommand();
        public static RoutedCommand BringForwardCommand = new RoutedCommand();
        public static RoutedCommand BringToFrontCommand = new RoutedCommand();

        public static RoutedCommand Rotate90RightCommand = new RoutedCommand();
        public static RoutedCommand Rotate90LeftCommand = new RoutedCommand();
        public static RoutedCommand FlipVerticalCommand = new RoutedCommand();
        public static RoutedCommand FlipHorizontalCommand = new RoutedCommand();

        public static RoutedCommand FitToSlideCommand = new RoutedCommand();
        public static RoutedCommand AddReflectionCommand = new RoutedCommand();

        public static RoutedCommand AlignTopCommand = new RoutedCommand();
        public static RoutedCommand AlignVerticalCentersCommand = new RoutedCommand();
        public static RoutedCommand AlignBottomCommand = new RoutedCommand();
        public static RoutedCommand AlignLeftCommand = new RoutedCommand();
        public static RoutedCommand AlignHorizontalCentersCommand = new RoutedCommand();
        public static RoutedCommand AlignRightCommand = new RoutedCommand();
        public static RoutedCommand DistributeHorizontalCommand = new RoutedCommand();
        public static RoutedCommand DistributeVerticalCommand = new RoutedCommand();
        public static RoutedCommand SelectAllCommand = new RoutedCommand();

        public static RoutedCommand MoveItemUpCommand = new RoutedCommand();
        public static RoutedCommand MoveItemDownCommand = new RoutedCommand();
        public static RoutedCommand MoveItemLeftCommand = new RoutedCommand();
        public static RoutedCommand MoveItemRightCommand = new RoutedCommand();

        public static RoutedCommand MoveItemUpShiftCommand = new RoutedCommand();
        public static RoutedCommand MoveItemDownShiftCommand = new RoutedCommand();
        public static RoutedCommand MoveItemLeftShiftCommand = new RoutedCommand();
        public static RoutedCommand MoveItemRightShiftCommand = new RoutedCommand();

        public static RoutedCommand NextCommand = new RoutedCommand();
        public static RoutedCommand PreviousCommand = new RoutedCommand();

        public static RoutedCommand AddUserFormCommand = new RoutedUICommand(Resources.ResourceManager.GetString("AddUserFormCommand"), "AddUserFormCommand", typeof(InspireCommands));
        public static RoutedCommand AddUserCommand = new RoutedCommand();
        public static RoutedCommand EditUserCommand = new RoutedUICommand(Resources.ResourceManager.GetString("EditUserCommand"), "EditUserCommand", typeof(InspireCommands));
        public static RoutedCommand DeleteUserCommand = new RoutedUICommand(Resources.ResourceManager.GetString("DeleteUserCommand"), "DeleteUserCommand", typeof(InspireCommands));

        public static RoutedCommand AddRoleFormCommand = new RoutedUICommand(Resources.ResourceManager.GetString("AddRoleFormCommand"), "AddRoleFormCommand", typeof(InspireCommands));
        
        public static RoutedCommand AddRoleCommand = new RoutedCommand();
        public static RoutedCommand RemoveRoleCommand = new RoutedUICommand(Resources.ResourceManager.GetString("RemoveRoleCommand"), "RemoveRoleCommand", typeof(InspireCommands));

        public static RoutedCommand PlayNextSlideCommand = new RoutedCommand();
        public static RoutedCommand PlayPreviousSlideCommand = new RoutedCommand();
        public static RoutedCommand GoToSlideCommand = new RoutedCommand();
        public static RoutedCommand TouchNavigateCommand = new RoutedCommand();
        public static RoutedCommand ConfigureTouchscreenButtons = new RoutedCommand();
        public static RoutedCommand SaveTouchscreenButtonsCommand = new RoutedCommand();
        public static RoutedCommand CancelTouchscreenButtonsCommand = new RoutedCommand();
        public static RoutedCommand ConfigureTransitionCommand = new RoutedCommand();
        public static RoutedCommand RestartTimerCommand = new RoutedCommand();

        public static RoutedCommand FilterListCommand = new RoutedCommand();

        private static RibbonCommand fontFamily;
        private static RibbonCommand fontSize;
        private static RibbonCommand applyBackground;
        private static RibbonCommand applyDefaultBackground;
        private static RibbonCommand applyDefaultForeground;
        private static RibbonCommand applyForeground;
        private static RibbonCommand clearFormatting;
        private static RibbonCommand toggleStrikethrough;


        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to change the font family.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to change the font family.</value>
        public static RibbonCommand FontFamily
        {
            get
            {
                if (fontFamily == null)
                    fontFamily = new RibbonCommand("FontFamily", typeof(Ribbon), "Font Family");
                return fontFamily;
            }
        }

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to change the font size.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to change the font size.</value>
        public static RibbonCommand FontSize
        {
            get
            {
                if (fontSize == null)
                    fontSize = new RibbonCommand("FontSize", typeof(Ribbon), "Font Size");
                return fontSize;
            }
        }

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a background.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a background.</value>
        public static RibbonCommand ApplyBackground
        {
            get
            {
                if (applyBackground == null)
                    applyBackground = new RibbonCommand("ApplyBackground", typeof(Ribbon), "Text Highlight Color");
                return applyBackground;
            }
        }

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a default background.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a default background.</value>
        public static RibbonCommand ApplyDefaultBackground
        {
            get
            {
                if (applyDefaultBackground == null)
                    applyDefaultBackground = new RibbonCommand("ApplyDefaultBackground", typeof(Ribbon), "Text Highlight Color");
                return applyDefaultBackground;
            }
        }

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to apply a default foreground.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to apply a default foreground.</value>
        public static RibbonCommand ApplyDefaultForeground
        {
            get
            {
                if (applyDefaultForeground == null)
                    applyDefaultForeground = new RibbonCommand("ApplyDefaultForeground", typeof(Ribbon), "Font Color", null, "pack://application:,,,/Inspire.Client;component/Resources/Images/FontColor.png");
                return applyDefaultForeground;
            }
        }

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

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to clear the formatting.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to clear the formatting.</value>
        public static RibbonCommand ClearFormatting
        {
            get
            {
                if (clearFormatting == null)
                    clearFormatting = new RibbonCommand("ClearFormatting", typeof(Ribbon), "Clear Formatting");
                return clearFormatting;
            }
        }

        /// <summary>
        /// Gets the <see cref="RibbonCommand"/> that is used to toggle strikethrough.
        /// </summary>
        /// <value>The <see cref="RibbonCommand"/> that is used to toggle strikethrough.</value>
        public static RibbonCommand ToggleStrikethrough
        {
            get
            {
                if (toggleStrikethrough == null)
                    toggleStrikethrough = new RibbonCommand("ToggleStrikethrough", typeof(Ribbon), "Strikethrough");
                return toggleStrikethrough;
            }
        }
    }
}
