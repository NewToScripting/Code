using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Common.MediaObjects;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IWeakEventListener
    {
       // public UndoService undoService;

       // private DragCanvas dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.MainWindow = this;

            Application.Current.Resources.MergedDictionaries.Add(new DevComponents.WpfRibbon.themes.Office2010BlackColorScheme());

            LoadedEventManager.AddListener(this, this);
        }

        public MainWindow(bool isDesignerMode) : this()
        {
            Designer.DesignWindow.IsDesignerMode = isDesignerMode;

            User.UserPermision.Add(PermissionTypes.ContentCreator);

            
            SchedulePane.IsEnabled = false;
            SchedulePane.Visibility = System.Windows.Visibility.Collapsed;
            ConfigurePane.IsEnabled = false;
            ConfigurePane.Visibility = System.Windows.Visibility.Collapsed;
            SchedulerWindow.Visibility = System.Windows.Visibility.Collapsed;
            DesignerWindow.Visibility = System.Windows.Visibility.Visible;
            scheduleTab.Visibility = System.Windows.Visibility.Collapsed;
            configurationTab.Visibility = System.Windows.Visibility.Collapsed;
        }

        public MainWindow(string userName, string userGuid, IEnumerable<Role> roles) : this()
        {
            foreach (var role in roles)
            {
                switch (role.Name)
                {
                    case "Administrator":
                        User.UserPermision.Add(PermissionTypes.Administrator);
                        break;
                    case "Content Designer":
                        User.UserPermision.Add(PermissionTypes.ContentCreator);
                        break;
                    case "Content Manager":
                        User.UserPermision.Add(PermissionTypes.ContentManager);
                        break;
                    case "Guest":
                        User.UserPermision.Add(PermissionTypes.Guest);
                        break;
                }
            }

            User.UserName = userName;
            User.UserGuid = userGuid;
        }

        void MainWindow_Loaded(object sender, EventArgs e)
        {
            
            InspireApp.IsPlayer = false; // This flag determines if the modules should load up and play after being initialized.

            if (!Designer.DesignWindow.IsDesignerMode)
            {
                SlideItemCollection.SetOnlineSlides(SlideManager.GetSlides());
            }

            // Loads up offline slides
            SlideItemCollection.LoadOffLineSlides();

            SlideItemCollection.SortSlidesByName();

            Cursor = Cursors.Arrow;
        }

        private void Show_Scheduler(object sender, RoutedEventArgs e)
        {
            if (!Designer.DesignWindow.IsDesignerMode)
            {
                ICommand command = InspireCommands.ShowSchedulerCommand;
                command.Execute("ShowScheduler");
            }
        }

        private void Show_Designer(object sender, RoutedEventArgs e)
        {
            if (!Designer.DesignWindow.IsDesignerMode)
            {
                ICommand command = InspireCommands.ShowDesignerCommand;
                command.Execute("ShowDesigner");
            }
        }

        private void Show_Configuration(object sender, RoutedEventArgs e)
        {
            if (!Designer.DesignWindow.IsDesignerMode)
            {
                ICommand command = InspireCommands.ShowConfigurationCommand;
                command.Execute("ShowConfiguration");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (SlideItemCollection.CheckIfSaving())
            {
                CommonDialog commonDialog = new CommonDialog("File(s) Saving",
                                                             "There are file(s) currently being saved to the server. Closing now will terminate the file save. Would you still like to exit?",
                                                             "Yes", "No");
                commonDialog.ShowDialog();
                if(commonDialog.DialogResult == true)
                {
                    base.OnClosing(e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                MainWindow_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void MoreColors_Click(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            var ch = ((FrameworkElement)sender).DataContext as ContentControl;

            DesignTextBox tb = null;
            if (ch != null)
            {
                var cc = ch.Content as ContentControl;

                if (cc != null)
                {
                    tb = cc.Content as DesignTextBox;

                    if (tb != null)
                        if (tb.SelectionForeground != null)
                            cPicker.StartingColor = ((SolidColorBrush)tb.SelectionForeground).Color;
                }
            }

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);

                var param = new BrushValueCommandParameter();

                param.Value = selectedColor;

                param.Action = ValueCommandParameterAction.Commit;

                if (tb != null) InspireCommands.ApplyForeground.Execute(param, tb);
            }
        }

    }
}
