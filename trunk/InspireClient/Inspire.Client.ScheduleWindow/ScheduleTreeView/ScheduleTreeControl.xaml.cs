using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Client.Designer;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Client.ScheduleWindow.Dialogs;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Common.TreeViewModel;
using Inspire.Server.Proxy;
using System.Windows.Threading;
using Transitionals.Transitions;

namespace Inspire.Client.ScheduleWindow.ScheduleTreeView
{
    /// <summary>
    /// Interaction logic for ScheduleTreeControl.xaml
    /// </summary>
    public partial class ScheduleTreeControl
    {
        private ScheduleWindow schedulerWindow;
        private string _selectedGuid;

        private bool onceLoaded;
        public ScheduleTreeControl()
        {
            InitializeComponent();
            Loaded += ScheduleTreeControl_Loaded;
        }

        void ScheduleTreeControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!onceLoaded)
            {
                Window mainApp = Application.Current.Windows[0];

                if (mainApp != null) schedulerWindow = mainApp.FindName("SchedulerWindow") as ScheduleWindow;
                if (mainApp != null)
                {

                    RefreshScheduleDisplaysExecuted(null, null);

                    onceLoaded = true;
                }
            }
        }

        internal List<string> AddSchedulesToTree(Schedule schedule, TreeView treeView, IEnumerable items)
        {
            List<string> displayGuids = new List<string>();

            foreach (DisplayViewModel listViewDisplayViewModel in items)
            {
                displayGuids.Add(listViewDisplayViewModel.GUID);

                IEnumerable<PropertyViewModel> propertyViewModels = treeView.Items.OfType<PropertyViewModel>();
                foreach (PropertyViewModel propertyItem in propertyViewModels)
                {
                    if (!propertyItem.HasDummyChild)
                    {
                        IEnumerable<TreeViewItemViewModel> displayGroupViewModels = propertyItem.Children;
                        foreach (DisplayGroupViewModel displayGroupViewModel in displayGroupViewModels)
                        {
                            if (!displayGroupViewModel.HasDummyChild)
                            {
                                IEnumerable<TreeViewItemViewModel> displayViewModels = displayGroupViewModel.Children;
                                foreach (DisplayViewModel treeDisplayViewModel in displayViewModels)
                                {
                                    if (treeDisplayViewModel.GUID
                                        == listViewDisplayViewModel.GUID && !treeDisplayViewModel.HasDummyChild)
                                        listViewDisplayViewModel.Children.Add(new ScheduleViewModel(schedule,
                                                                                                    treeDisplayViewModel));
                                }
                            }
                        }
                    }
                }
            }
            return displayGuids;
        }

        internal void UpdateSchedulesOnTree(Schedule schedule, TreeView treeView, IEnumerable<string> displays)
        {

            var propertyViewModels = treeView.Items.OfType<PropertyViewModel>();
                foreach (PropertyViewModel propertyItem in propertyViewModels)
                {
                    if (propertyItem.HasDummyChild) continue;
                    IEnumerable<TreeViewItemViewModel> displayGroupViewModels = propertyItem.Children;
                    foreach (DisplayGroupViewModel displayGroupViewModel in displayGroupViewModels)
                    {
                        if (displayGroupViewModel.HasDummyChild) continue;
                        IEnumerable<TreeViewItemViewModel> displayViewModels = displayGroupViewModel.Children;
                        foreach (DisplayViewModel treeDisplayViewModel in displayViewModels)
                        {
                            if (treeDisplayViewModel.HasDummyChild) continue;
                            ScheduleViewModel scheduleViewModel = null;

                            IEnumerable<TreeViewItemViewModel> scheduleViewModels = treeDisplayViewModel.Children;

                            var schedList = new List<string>();

                            foreach (ScheduleViewModel treeScheduleViewModel in scheduleViewModels)
                            {
                                if (treeScheduleViewModel.GUID
                                    == schedule.GUID && !treeDisplayViewModel.HasDummyChild)
                                {
                                    scheduleViewModel = treeScheduleViewModel;
                                }
                                schedList.Add((treeScheduleViewModel).GUID);
                            }
                            if (!displays.Contains(treeDisplayViewModel.GUID) &&
                                scheduleViewModel != null)
                                treeDisplayViewModel.Children.Remove(scheduleViewModel);

                            if (!displays.Contains(treeDisplayViewModel.GUID)) continue;
                            if (scheduleViewModel != null)
                                treeDisplayViewModel.Children.Remove(scheduleViewModel);
                            treeDisplayViewModel.Children.Add(new ScheduleViewModel(schedule,
                                                                                    treeDisplayViewModel));
                        }
                    }
                }
        }

        private void NewSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
             Window mainApp = Application.Current.Windows[0];

             if (mainApp != null)
             {
                 UserControl designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                 if (designWindow != null)
                 {
                     Display tempDisplay;

                     TabControl tabControl = designWindow.FindName("DesignerDragCanvasHolder") as TabControl;
                    if (tabControl != null)
                    {
                        var tabItem = new CloseableTabItem();
                        
                        var dragCanvas = new DragCanvas();

                        InspireApp.CurrentDragCanvas = dragCanvas;

                         if (ScheduleTree.SelectedItem != null)
                         {
                             tempDisplay = DisplayManager.GetSingleDisplay(((DisplayViewModel) ScheduleTree.SelectedItem).GUID);
                             if (tempDisplay.VResolution > 0 && tempDisplay.HResolution > 0)
                             {
                                 dragCanvas.Width = tempDisplay.HResolution;
                                 dragCanvas.Height = tempDisplay.VResolution;

                                 tabItem.Header = "untitled-" + (tabControl.Items.Count + 1);
                                 tabItem.Content = dragCanvas;

                                 tabControl.Items.Add(tabItem);

                                 tabControl.SelectedItem = tabItem;

                                 InspireCommands.ShowDesignerCommand.Execute(null, designWindow);

                                 InspireApp.CanvasExists = true;

                                 Label label = designWindow.FindName("lblNewSlide") as Label;
                                 if (label != null) label.Visibility = Visibility.Collapsed;

                                 if (schedulerWindow != null)
                                     schedulerWindow.Visibility = Visibility.Collapsed;
                                 designWindow.Visibility = Visibility.Visible;
                             }
                         }
                     }
                 }
             }
            e.Handled = true;
        }

        private void NewSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ScheduleTree != null)
            {
                if (ScheduleTree.SelectedItem != null)
                    if (ScheduleTree.SelectedItem.GetType().Name == "DisplayViewModel")
                        e.CanExecute = true;
            }
        }

        private void DeleteScheduledSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void DeleteScheduledSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnRightMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var treeViewItemText = e.Source as FrameworkElement;

            if (treeViewItemText != null)
            {
                StackPanel treeViewStackPanel = treeViewItemText.Parent as StackPanel;

                if (treeViewStackPanel == null)
                {
                    Grid grid = treeViewItemText.Parent as Grid;
                    if (grid != null) treeViewStackPanel = grid.Parent as StackPanel;
                }
                if (treeViewStackPanel != null)
                {
                    ContentPresenter treeViewContentPres = treeViewStackPanel.TemplatedParent as ContentPresenter;
                    if (treeViewContentPres != null)
                    {
                        Grid treeViewContentGrid = treeViewContentPres.Parent as Grid;
                        if (treeViewContentGrid != null)
                        {
                            Border treeViewItemBorder = treeViewContentGrid.Parent as Border;
                            if (treeViewItemBorder != null)
                            {
                                Grid treeViewItemGrid2 = treeViewItemBorder.Parent as Grid;


                                if (treeViewItemGrid2 != null)
                                {
                                    TreeViewItem treeViewItem = treeViewItemGrid2.TemplatedParent as TreeViewItem;
                                    if (treeViewItem == null) return;

                                    treeViewItem.IsSelected = true;
                                }
                            }
                        }
                    }
                }
            }

            
        }

        private void ScheduleDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ScheduleTree != null)
            {
                if(schedulerWindow != null)
                if (schedulerWindow.SchedulerHolder.Content.GetType() == typeof(ScheduleCalendar))
                {
                    InspireCommands.FillCalendarCommand.Execute(ScheduleTree.SelectedItem, null);
                    InspireCommands.ClearScheduledSlidesCommand.Execute(null, null);
                }
                else
                {

                    DisplayViewModel displaySelected = (DisplayViewModel) ScheduleTree.SelectedItem;

                    DragDrop.DoDragDrop(ScheduleTree, displaySelected, DragDropEffects.Copy);
                }
            }

           // e.Handled = true;
        }

        private void ScheduleDisplayGroup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ScheduleTree != null)
            {
                if(schedulerWindow.SchedulerHolder.Content.GetType() == typeof(ScheduleCalendar))
                {
                    InspireCommands.FillCalendarCommand.Execute(ScheduleTree.SelectedItem, null);
                    InspireCommands.ClearScheduledSlidesCommand.Execute(null,null);
                    _selectedGuid = string.Empty;
                }
                else
                {
                    DisplayGroupViewModel displayGroupSelected = (DisplayGroupViewModel)ScheduleTree.SelectedItem;

                    DragDrop.DoDragDrop(ScheduleTree, displayGroupSelected, DragDropEffects.Copy);
                }
            }

            e.Handled = true;
        }

        private void TreeItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItemText = e.Source as FrameworkElement;

            if (treeViewItemText != null)
            {
                StackPanel treeViewStackPanel = treeViewItemText.Parent as StackPanel;

                if (treeViewStackPanel == null)
                {
                    Grid grid = treeViewItemText.Parent as Grid;
                    if (grid != null) treeViewStackPanel = grid.Parent as StackPanel;
                }

                if (treeViewStackPanel != null)
                {
                    ContentPresenter treeViewContentPres = treeViewStackPanel.TemplatedParent as ContentPresenter;
                    if (treeViewContentPres != null)
                    {
                        Grid treeViewContentGrid = treeViewContentPres.Parent as Grid;
                        if (treeViewContentGrid != null)
                        {
                            Border treeViewItemBorder = treeViewContentGrid.Parent as Border;
                            if (treeViewItemBorder != null)
                            {
                                Grid treeViewItemGrid2 = treeViewItemBorder.Parent as Grid;


                                if (treeViewItemGrid2 != null)
                                {
                                    TreeViewItem treeViewItem = treeViewItemGrid2.TemplatedParent as TreeViewItem;
                                    if (treeViewItem == null) return;

                                    treeViewItem.IsSelected = true;
                                    CommandManager.InvalidateRequerySuggested();
                                }
                            }
                        }
                    }
                }
            }
        }

        //private void TreeItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    InspireCommands.FillCalendarCommand.Execute(ScheduleTree.SelectedItem, null);
        //    if(((FrameworkElement)sender).DataContext.GetType() == typeof(ScheduleViewModel))
        //        InspireCommands.FillScheduledSlidesCommand.Execute(((ScheduleViewModel)ScheduleTree.SelectedItem).ScheduleGUID,null);
        //    else
        //    {
        //        InspireCommands.ClearScheduledSlidesCommand.Execute(null, null);
        //    }
        //    e.Handled = true;
        //}

        private void RefreshScheduleDisplaysExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                DisplayProperty[] displayProperties = DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                CorporationViewModel viewModel = new CorporationViewModel(displayProperties);
                DataContext = viewModel;
            }
            catch
            {
                // Check for database to be off line, also handle adding properties because an exception is thrown there
                //MessageBox.Show("Loading the AdminTree Failed." + ex);
            }
        }

        private void RefreshScheduleDisplaysCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ScheduleTree != null)
            {
                e.CanExecute = true;
            }
        }

        private void Schedule_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (((FrameworkElement)sender).DataContext.GetType() == typeof(ScheduleViewModel))
                {
                    InspireCommands.EditScheduleCommand.Execute(((ScheduleViewModel) ScheduleTree.SelectedItem).GUID,
                                                                null);
                    _selectedGuid = string.Empty;
                }

            }
            else
            {
                if (ScheduleTree.SelectedItem is IGUIDItem && ((IGUIDItem)ScheduleTree.SelectedItem).GUID.Equals(_selectedGuid)) return;
                InspireCommands.FillCalendarCommand.Execute(ScheduleTree.SelectedItem, null);
                if (((FrameworkElement)sender).DataContext is ScheduleViewModel)
                    InspireCommands.FillScheduledSlidesCommand.Execute(((ScheduleViewModel)ScheduleTree.SelectedItem).GUID, null);
                else
                {
                    InspireCommands.ClearScheduledSlidesCommand.Execute(null, null);
                    _selectedGuid = string.Empty;
                }
            }
            e.Handled = true;
        }

        //private void PreviewScheduleForDisplayExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    if (((ScheduleTreeControl)e.Source).ScheduleTree.SelectedItem.GetType() == typeof(ScheduleViewModel))
        //    {
        //        InspireApp.PlaybackHostName = ((DisplayViewModel) ((ScheduleViewModel) ScheduleTree.SelectedItem).Parent).DisplayHostName;
        //        InspireCommands.PreviewScheduleForDisplayCommand.Execute(
        //            ((ScheduleViewModel) ScheduleTree.SelectedItem).ScheduleGUID, schedulerWindow);
        //    }
        //}

        //private void PreviewScheduleForDisplayCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void PreviewCurrentContentsExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    if (((ScheduleTreeControl)e.Source).ScheduleTree.SelectedItem.GetType() == typeof(DisplayViewModel))
        //    {
        //        InspireApp.PlaybackHostName = ((DisplayViewModel) ScheduleTree.SelectedItem).DisplayHostName;
        //        InspireCommands.PreviewCurrentContentsCommand.Execute(
        //            ((DisplayViewModel) ScheduleTree.SelectedItem).DisplayGUID, schedulerWindow);
        //    }
        //}

        //private void PreviewCurrentContentsCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        private void FillCalendarCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter != null)
            {
                Type treeType = e.Parameter.GetType();

                List<Schedule> schedules = null;

                if (treeType == typeof(DisplayGroupViewModel))
                {
                    //SchedulerCalendar.Calendar.CalendarModel.Appointments.Clear(); // TODO: Replace when the Server calls to Get Schedules for Display Groups are implemented.
                }
                else if (treeType == typeof(DisplayViewModel))
                {
                    var displayViewModel = e.Parameter as DisplayViewModel;
                    if (displayViewModel != null)
                    {
                        schedules = ScheduleManager.GetSchedules(displayViewModel.GUID);
                        _selectedGuid = displayViewModel.GUID;
                    }
                }
                else if (treeType == typeof(PropertyViewModel))
                {
                    //SchedulerCalendar.Calendar.CalendarModel.Appointments.Clear(); // TODO: Replace when the Server calls to Get Schedules for Property are implemented.
                }
                else if (treeType == typeof(ScheduleViewModel))
                {
                    ScheduleViewModel scheduleViewModel = e.Parameter as ScheduleViewModel;
                    if (scheduleViewModel != null)
                    {
                        schedules = new List<Schedule>();
                        Schedule schedule = ScheduleManager.GetSingleSchedule(scheduleViewModel.GUID);
                        schedules.Add(schedule);
                        _selectedGuid = scheduleViewModel.GUID;
                    }
                }

                schedulerWindow.SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    schedulerWindow.SchedulerCalendar.
                        FillCalendar(
                        schedules);
                    schedulerWindow.SchedulerCalendar.
                        Calendar.
                        CalendarModel.
                        InvalidateAppointmentCache
                        ();
                }));


                schedulerWindow.SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                                                                        () =>

                                                                                            {
                                                                                                ((SlideInTransitionFX)schedulerWindow.SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
                                                                                                schedulerWindow.
                                                                                                    SchedulerHolder.
                                                                                                    Content =
                                                                                                    schedulerWindow.
                                                                                                        SchedulerCalendar;
                                                                                            }));

            }
            e.Handled = true;
        }

        private void FillCalendarCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ScheduleTree != null)
            {
                DisplayViewModel treeViewItemModel = ScheduleTree.SelectedItem as DisplayViewModel;
                if (treeViewItemModel != null)
                {
                    ((SlideInTransitionFX)schedulerWindow.SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.RightToLeft;
                    schedulerWindow.SchedulerHolder.Content = schedulerWindow.SchedulerInfo;
                    schedulerWindow.SchedulerInfo.Clear();
                    schedulerWindow.SchedulerInfo.lvDisplays.Items.Add(treeViewItemModel);
                    schedulerWindow.SchedulerCalendar.SchedulerSlideControl.SlideControlItems.Clear();
                    schedulerWindow.SetEditMode(true);
                    schedulerWindow.SchedulerInfo.NewSchedule();
                }
            }
        }

        private void NewBlankScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((SlideInTransitionFX)schedulerWindow.SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.RightToLeft;
            schedulerWindow.SchedulerHolder.Content = schedulerWindow.SchedulerInfo;
            schedulerWindow.SchedulerInfo.Clear();

            if (schedulerWindow != null)
            {
                if (schedulerWindow.SchedulerCalendar.Calendar.DateSelectionStart != null && schedulerWindow.SchedulerCalendar.Calendar.DateSelectionEnd != null)
                {
                    Schedule schedule = new Schedule();
                    schedule.Type = Schedule.ScheduleTypeEnum.Continuous;
                    schedule.StartDate = schedulerWindow.SchedulerCalendar.Calendar.DateSelectionStart.Value.Date;
                    schedule.StartTime = schedulerWindow.SchedulerCalendar.Calendar.DateSelectionStart;
                    schedule.EndDate = schedulerWindow.SchedulerCalendar.Calendar.DateSelectionEnd.Value.Date;

                    schedule.EndTime = schedulerWindow.SchedulerCalendar.Calendar.DateSelectionEnd;

                    schedulerWindow.SchedulerInfo.NewDefinedSchedule(schedule);
                }
            }

            schedulerWindow.SetEditMode(true);

            e.Handled = true;
        }

        private void NewBlankScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        }

        private void NewScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((User.UserPermision.Contains(PermissionTypes.Administrator) ||
                             User.UserPermision.Contains(PermissionTypes.ContentManager)) &&
                            (ScheduleTree.SelectedItem != null) &&
                            ScheduleTree.SelectedItem.GetType().Name == "DisplayViewModel");
        }

        

        private void EditScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

                // TODO: place loading control

                string scheduleGuid = string.Empty;

                if (ScheduleTree.SelectedItem is ScheduleViewModel)
                {
                    ScheduleViewModel scheduleViewModel = ScheduleTree.SelectedItem as ScheduleViewModel;
                    if (scheduleViewModel != null) scheduleGuid = scheduleViewModel.GUID;
                }

                if (!string.IsNullOrEmpty(scheduleGuid))
                {
                    Schedule schedule = ScheduleManager.GetSingleSchedule(scheduleGuid);

                    if (schedule != null)
                    {
                        schedulerWindow.SchedulerInfo.SetUpdateSchedule(schedule);
                        schedulerWindow.ClearCheckBoxes();

                        var scheduledSlides =
                            ScheduledSlideManager.GetScheduledSlides(scheduleGuid) as IEnumerable<ScheduledSlide>;

                        schedulerWindow.SchedulerInfo.FillSchedulerInfo(schedule);

                        schedulerWindow.SchedulerInfo.FillScheduledSlides(scheduledSlides);

                        schedulerWindow.GetTypeSettings(schedule);

                        schedulerWindow.GetPlayBackSettings(schedule);

                        List<Display> displays = DisplayManager.GetDisplaysInSchedule(scheduleGuid);

                        foreach (var display in displays)
                        {
                            DisplayViewModel displayViewModel = new DisplayViewModel(display);
                            schedulerWindow.SchedulerInfo.lvDisplays.Items.Add(displayViewModel);
                        }

                        schedulerWindow.SchedulerCalendar.SchedulerSlideControl.LoadSlides(scheduledSlides);

                        schedulerWindow.SetEditMode(true);


                        // TODO: Update UI with new window.


                        Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                                                                                             {
                                                                                                 ((
                                                                                                  SlideInTransitionFX
                                                                                                  )
                                                                                                  schedulerWindow.
                                                                                                      SchedulerHolder
                                                                                                      .Transition).
                                                                                                     Direction =
                                                                                                     SlideInTransitionFX
                                                                                                         .
                                                                                                         SlideDirection
                                                                                                         .
                                                                                                         RightToLeft;
                                                                                                 schedulerWindow.
                                                                                                     SchedulerHolder
                                                                                                     .
                                                                                                     Content =
                                                                                                     schedulerWindow
                                                                                                         .
                                                                                                         SchedulerInfo;

                                                                                                 schedulerWindow.
                                                                                                     SchedulerInfo.
                                                                                                     Focus();
                                                                                             }));
                    }
                }
            }
            catch (Exception ex)
            {
                CommonDialog commonDialog = new CommonDialog("Error", "This schedule no longer exists, or communication to the server has been lost. Please try refreshing the displays.");
                commonDialog.ShowDialog();
            }

            e.Handled = true;
        }

        private void EditScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        }

        private void DeleteScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ScheduleTree != null)
            {
                ScheduleViewModel treeViewItemModel = ScheduleTree.SelectedItem as ScheduleViewModel;
                if (treeViewItemModel != null)
                {
                    CommonDialog commonDialog = new CommonDialog("Delete Schedule?", "Are you sure you like to delete the schedule?");
                    commonDialog.ShowDialog();
                    if (commonDialog.DialogResult == true)
                    {
                        ScheduleManager.DeleteSchedule(treeViewItemModel.GUID);
                        DisplayViewModel displayViewModel = treeViewItemModel.Parent as DisplayViewModel;
                        if (displayViewModel != null) displayViewModel.Children.Remove(treeViewItemModel);
                    }
                }
            }
        }

        private void DeleteScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((User.UserPermision.Contains(PermissionTypes.Administrator) ||
                             User.UserPermision.Contains(PermissionTypes.ContentManager)) &&
                            (ScheduleTree.SelectedItem != null) &&
                            ScheduleTree.SelectedItem.GetType().Name == "ScheduleViewModel");
        }

        private void FillScheduledSlidesCommandExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Parameter == null) return;
            schedulerWindow.SchedulerCalendar.SchedulerSlideControl.LoadSlides(ScheduledSlideManager.GetScheduledSlides(e.Parameter.ToString()));
            schedulerWindow.SetEditMode(false);
        }

        private void FillScheduledSlidesCommandCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ClearScheduledSlidesCommandExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            schedulerWindow.SchedulerCalendar.SchedulerSlideControl.Clear();
            if (e.OriginalSource.GetType() == typeof (TreeViewItem)) return;
            schedulerWindow.SchedulerCalendar.Calendar.CalendarModel.Appointments.Clear();
            schedulerWindow.SchedulerCalendar.Calendar.CalendarModel.InvalidateAppointmentCache();
        }

        private void ClearScheduledSlidesCommandCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PreviewScheduleForDisplayExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (((ScheduleTreeControl) e.Source).ScheduleTree.SelectedItem.GetType() != typeof (ScheduleViewModel))
                return;
            var scheduledSlide = ((ScheduleViewModel) ScheduleTree.SelectedItem);

            InspireApp.PlaybackHostName =
                ((DisplayViewModel) scheduledSlide.Parent).DisplayHostName;

            var scheduledSlides =
                ScheduledSlideManager.GetScheduledSlides(
                    scheduledSlide.GUID);
            var previewCanvas = new PreviewCanvas(scheduledSlides, InspireApp.PlaybackHostName, scheduledSlide.ScheduleType);
            previewCanvas.ShowDialog();
        }

        private void PreviewScheduleForDisplayCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PreviewCurrentContentsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            InspireApp.PlaybackHostName = ((DisplayViewModel)ScheduleTree.SelectedItem).DisplayHostName;

            var displaySchedules = ScheduleManager.GetSchedules(((DisplayViewModel)ScheduleTree.SelectedItem).GUID);

            var slides = ScheduleWindow.GetSlides(displaySchedules);

            Schedule.ScheduleTypeEnum scheduleTypeEnum = displaySchedules.Where(sch => sch.Type == Schedule.ScheduleTypeEnum.Touchscreen).Count() > 0 ? Schedule.ScheduleTypeEnum.Touchscreen : Schedule.ScheduleTypeEnum.Continuous;

            var previewCanvas = new PreviewCanvas(slides, InspireApp.PlaybackHostName, scheduleTypeEnum);
            previewCanvas.ShowDialog();

        }

        private void PreviewCurrentContentsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RemoveDisplayFromScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ScheduleTree != null)
            {
                ScheduleViewModel treeViewItemModel = ScheduleTree.SelectedItem as ScheduleViewModel;
                if (treeViewItemModel != null)
                {
                    CommonDialog commonDialog = new CommonDialog("Remove schedule from display?", "Are you sure you like to remove this schedule from the display?");
                    commonDialog.ShowDialog();
                    if (commonDialog.DialogResult == true)
                    {
                        Schedule schedule = ScheduleManager.GetSingleSchedule(treeViewItemModel.GUID);
                        DisplayViewModel displayViewModel = treeViewItemModel.Parent as DisplayViewModel;
                        if (displayViewModel == null) return;
                        var displayList = DisplayManager.GetDisplaysInSchedule(schedule.GUID).Where(s => s.GUID != displayViewModel.GUID);

                        bool wasDeleted = true;

                        if(displayList.Count() > 0)
                            ScheduleManager.UpdateSchedule(schedule, displayList.Select(w => w.GUID).ToList()); 
                        else
                        {
                             CommonDialog commonDialog2 = new CommonDialog("Delete Schedule?", "This schedule is not associated with any other displays, would you like to delete the schedule?");
                                commonDialog2.ShowDialog();
                                if (commonDialog2.DialogResult == true)
                                {
                                    ScheduleManager.DeleteSchedule(treeViewItemModel.GUID);
                                }
                                else
                                    wasDeleted = false;

                        }

                        if(wasDeleted)
                            displayViewModel.Children.Remove(treeViewItemModel);
                    }
                }
            }
        }

        private void RemoveDisplayFromScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((User.UserPermision.Contains(PermissionTypes.Administrator) ||
                             User.UserPermision.Contains(PermissionTypes.ContentManager)) &&
                            (ScheduleTree.SelectedItem != null) &&
                            ScheduleTree.SelectedItem.GetType().Name == "ScheduleViewModel");
        }
    }
}
