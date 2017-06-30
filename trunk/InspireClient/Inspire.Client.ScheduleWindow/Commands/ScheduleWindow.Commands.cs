using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;
using Inspire.Common.Dialogs;
using Inspire.Common.TreeViewModel;
using Inspire.Server.Proxy;
using Inspire.Helpers;
using Inspire.Client.ScheduleWindow.ScheduleTreeView;
using Transitionals.Transitions;

namespace Inspire.Client.ScheduleWindow 
{
    public partial class ScheduleWindow
    {
        private static ScheduleInfo _scheduleInfo;


        static ScheduleWindow()
        {
            Window mainApp = Application.Current.Windows[1];

            if (mainApp != null)
            {
                _schedulerTreeControl = mainApp.FindName("SchedulerTreeControl") as ScheduleTreeControl;
            }
        }

        private ScheduleInfo FindSchedInfo()
        {
            if (SchedulerHolder.Content is ScheduleInfo)
                return SchedulerHolder.Content as ScheduleInfo;
            return null;
        }
        private TouchScreenScheduler FindTouchScreenScheduler()
        {
            if (SchedulerHolder.Content is TouchScreenScheduler)
                return SchedulerHolder.Content as TouchScreenScheduler;
            return null;
        }

        private TouchScreenScheduler GetTouchScreenScheduler
        {
            get { return _touchScreenScheduler ?? (_touchScreenScheduler = FindTouchScreenScheduler()); }
        }

        private ScheduleInfo GetScheduleInfo
        {
            get { return _scheduleInfo ?? (_scheduleInfo = FindSchedInfo()); }
        }

        public static ScheduleTreeControl SchedulerTreeControl
        {
            get { return _schedulerTreeControl; }
        }

        private void CancelScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((SlideInTransitionFX)SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
            
            //SchedulerInfo.Clear();
            //SchedulerCalendar.SchedulerSlideControl.SlideControlItems.Clear();
            SetEditMode(false);

            SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                                                                               {
                                                                                                   SchedulerHolder.Content = SchedulerCalendar;
                                                                                               }));
            e.Handled = true;
        }

        private void CancelScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.Name = SchedulerInfo.txtSchedName.Text;

            SetTypeInfo(schedule);

            SetModeInfo(schedule);

            SetDateTime(schedule);

            List<string> displayGuids = _schedulerTreeControl.AddSchedulesToTree(schedule, _schedulerTreeControl.ScheduleTree,
                                                                          SchedulerInfo.lvDisplays.Items);

            ScheduleManager.AddSchedule(schedule, displayGuids);

            var newScheduledSlides = GetScheduleInfo.GetScheduledSlides(schedule);

            foreach (ScheduledSlide scheduledSlide in newScheduledSlides)
                ScheduledSlideManager.AddScheduledSlide(scheduledSlide);

            //SchedulerInfo.Clear();
            SchedulerCalendar.SchedulerSlideControl.Clear();

            SetEditMode(false);

            var schedules = new List<Schedule> { schedule };

            SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                SchedulerCalendar.
                    FillCalendar(
                    schedules);
                SchedulerCalendar.
                    Calendar.
                    CalendarModel.
                    InvalidateAppointmentCache
                    ();
                SchedulerCalendar.SchedulerSlideControl.LoadSlides(newScheduledSlides);
            }));


            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                var slideTransition = SchedulerHolder.Transition as SlideInTransitionFX;
                slideTransition.Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
                SchedulerHolder.
                    Content =
                    SchedulerCalendar;
            }));

            e.Handled = true;
        }

        private void SaveScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (!String.IsNullOrEmpty(SchedulerInfo.txtSchedName.Text) && SchedulerInfo.lvDisplays.Items.Count > 0 && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)));
        }

        private void UpdateScheduleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            bool skipUpdate = false;
            bool scheduleDeleted = false;

            if (SchedulerInfo.lvDisplays.Items.Count < 1)
            {
                var deleteDialog = new CommonDialog("Delete Schedule?",
                                                    "The schedule is not assigned to any displays, would you like to delete the schedule? (A schedule must be assigned to a display.)", "Yes", "No");
                deleteDialog.ShowDialog();
                if (deleteDialog.DialogResult == true)
                {
                    ScheduleManager.DeleteSchedule(SchedulerInfo.UpdateSchedule.GUID);
                    scheduleDeleted = true;
                    SchedulerCalendar.SchedulerSlideControl.Clear();
                }
                else
                    skipUpdate = true;
            }

            if (!skipUpdate)
                UpdateSchedule(scheduleDeleted);

            e.Handled = true;
        }

        private void UpdateScheduleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        }

        internal void UpdateSchedule(bool scheduleDeleted)
        {
            Schedule schedule = new Schedule();
            schedule.GUID = SchedulerInfo.UpdateSchedule.GUID;
            schedule.Name = SchedulerInfo.txtSchedName.Text;

            SetTypeInfo(schedule);

            SetModeInfo(schedule);

            SetDateTime(schedule);

            var displays = (from DisplayViewModel displayViewModel in SchedulerInfo.lvDisplays.Items select displayViewModel.GUID).ToList();

            SchedulerTreeControl.UpdateSchedulesOnTree(schedule, SchedulerTreeControl.ScheduleTree, displays);

            ScheduleManager.UpdateSchedule(schedule, displays);

            var newScheduledSlides = GetScheduleInfo.GetScheduledSlides(schedule);

            ScheduledSlideManager.UpdateScheduledSlides(newScheduledSlides,
                                                        schedule.GUID);

            //SchedulerInfo.Clear();
            //SchedulerCalendar.SchedulerSlideControl.Clear();

            SetEditMode(false);

            var schedules = new List<Schedule>();

            schedules.Add(schedule);

            SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                            {
                                                SchedulerCalendar.
                                                    FillCalendar(
                                                    schedules);
                                                SchedulerCalendar.
                                                    Calendar.
                                                    CalendarModel.
                                                    InvalidateAppointmentCache
                                                    ();
                                                SchedulerCalendar.SchedulerSlideControl.LoadSlides(newScheduledSlides);
                                            }));


            SchedulerCalendar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                            {
                                                var slideTransition = SchedulerHolder.Transition as SlideInTransitionFX;
                                                slideTransition.Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
                                                SchedulerHolder.
                                                    Content =
                                                    SchedulerCalendar;
                                            }));
            
        }

        internal void SetDateTime(Schedule schedule)
        {
            if (SchedulerInfo.cbAllDay.IsChecked == true)
            {
                schedule.StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0, 1);
                schedule.EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59, 1);
            }
            else
            {
                if (SchedulerInfo.tpStart.Value != null)
                    schedule.StartTime = SchedulerInfo.tpStart.Value;
                schedule.EndTime = SchedulerInfo.tpEnd.Value;
            }

            if (SchedulerInfo.dpStart.Value != null)
                schedule.StartDate = SchedulerInfo.dpStart.Value;
            schedule.EndDate = SchedulerInfo.dpEnd.Value;
        }

        internal void ClearCheckBoxes()
        {
            SchedulerInfo.ckbMonday.IsChecked = false;
            SchedulerInfo.ckbTuesday.IsChecked = false;
            SchedulerInfo.ckbWednesday.IsChecked = false;
            SchedulerInfo.ckbThursday.IsChecked = false;
            SchedulerInfo.ckbFriday.IsChecked = false;
            SchedulerInfo.ckbSaturday.IsChecked = false;
            SchedulerInfo.ckbSunday.IsChecked = false;
        }

        //private void NewScheduleExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        //{
        //    if (SchedulerTreeControl.ScheduleTree != null)
        //    {
        //        DisplayViewModel treeViewItemModel = SchedulerTreeControl.ScheduleTree.SelectedItem as DisplayViewModel;
        //        if (treeViewItemModel != null)
        //        {
        //            SchedulerHolder.Content = SchedulerInfo;
        //            SchedulerInfo.Clear();
        //            SchedulerInfo.lvDisplays.Items.Add(treeViewItemModel);
        //            SchedulerSlideControl.SlideControlItems.Clear();
        //            SetEditMode(true);
        //        }
        //    }
        //}

        //private void NewBlankScheduleExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        //{
        //    SchedulerHolder.Content = SchedulerInfo;
        //    SchedulerInfo.Clear();
        //    ScheduleWindow scheduleWindow = sender as ScheduleWindow;
        //    if(scheduleWindow != null)
        //    {
        //        if (scheduleWindow.SchedulerCalendar.Calendar.DateSelectionStart != null && scheduleWindow.SchedulerCalendar.Calendar.DateSelectionEnd != null)
        //        {
        //            Schedule schedule = new Schedule();
        //            schedule.Type = Schedule.ScheduleTypeEnum.Continuous;
        //            schedule.StartDate = scheduleWindow.SchedulerCalendar.Calendar.DateSelectionStart.Value.Date;
        //            schedule.StartTime = scheduleWindow.SchedulerCalendar.Calendar.DateSelectionStart;
        //            schedule.EndDate = scheduleWindow.SchedulerCalendar.Calendar.DateSelectionEnd.Value.Date;
        //            schedule.EndTime = scheduleWindow.SchedulerCalendar.Calendar.DateSelectionEnd;

        //            SchedulerInfo.NewDefinedSchedule(schedule);
        //        }
        //    }

        //    SetEditMode(true);

        //    e.Handled = true;
        //}

        //private void NewBlankScheduleCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        //}

        //private void NewScheduleCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = ((User.UserPermision.Contains(PermissionTypes.Administrator) ||
        //                     User.UserPermision.Contains(PermissionTypes.ContentManager)) &&
        //                    (SchedulerTreeControl.ScheduleTree.SelectedItem != null) &&
        //                    SchedulerTreeControl.ScheduleTree.SelectedItem.GetType().Name == "DisplayViewModel");
        //}

        internal static List<ScheduledSlide> GetSlides(List<Schedule> displaySchedules)
        {
            var slides = new List<ScheduledSlide>();

            displaySchedules = Schedule.GetCurrentValidSchedules(displaySchedules); // TODO: Add error handling and Random, Shuffle

            var interspersedSlides = new List<ScheduledSlide>();
            var noMixSlides = new List<ScheduledSlide>();
            var randomSlides = new List<ScheduledSlide>();
            var normalSlides = new List<ScheduledSlide>();

            foreach (Schedule schedule in displaySchedules)
            {
                if (schedule.Mode == Schedule.ModeEnum.Default)
                    normalSlides.AddRange(ScheduledSlideManager.GetScheduledSlides(schedule.GUID));
                else if(schedule.Mode == Schedule.ModeEnum.Intersperse)
                    interspersedSlides.AddRange(ScheduledSlideManager.GetScheduledSlides(schedule.GUID)); 
                else if(schedule.Mode == Schedule.ModeEnum.Shuffle)
                    randomSlides.AddRange(ScheduledSlideManager.GetScheduledSlides(schedule.GUID));
                else if(schedule.Mode == Schedule.ModeEnum.DoNotMix)
                    noMixSlides.AddRange(ScheduledSlideManager.GetScheduledSlides(schedule.GUID));
            }

            slides.AddRange(randomSlides.Count > 0 ? Shuffler.ShuffleSlides(randomSlides, normalSlides) : normalSlides);

            slides = Intersperser.IntersperseSlides(interspersedSlides, slides);

            slides.AddRange(noMixSlides);
            return slides;
        }

        private void ConfigureTouchscreenButtonsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var schedSlide = ((Button)e.OriginalSource).DataContext as ScheduledSlide;
            if (schedSlide != null)
            {
                if(_touchScreenScheduler == null)
                    _touchScreenScheduler = new TouchScreenScheduler();

                _touchScreenScheduler.SetTouchScreenButtons(schedSlide, GetScheduleInfo.GetScheduledSlides(schedSlide.ScheduleId));

                //SchedulerCalendar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                //{
                    var slideTransition = SchedulerHolder.Transition as SlideInTransitionFX;
                    slideTransition.Direction = SlideInTransitionFX.SlideDirection.RightToLeft;
                    SchedulerHolder.
                        Content = _touchScreenScheduler;
               // }));
            }
        }

        private void ConfigureTouchscreenButtonsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveTouchscreenButtonsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                var schedSlide = ((FrameworkElement)e.OriginalSource).DataContext as ScheduledSlide;

                schedSlide.Buttons = GetTouchScreenScheduler.GetButtons();

                ((SlideInTransitionFX)SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
                
                SchedulerInfo.lbSlideInfoSlides.Items.Refresh();
                
                SchedulerHolder.Content = SchedulerInfo;

            }));
        }

        private void SaveTouchscreenButtonsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CancelTouchscreenButtonsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                ((SlideInTransitionFX)SchedulerHolder.Transition).Direction = SlideInTransitionFX.SlideDirection.LeftToRight;
                SchedulerHolder.Content = SchedulerInfo;
            }));
        }

        private void CancelTouchscreenButtonsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ConfigureTransitionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var schedSlide = ((Button)e.OriginalSource).DataContext as ScheduledSlide;
            if (schedSlide != null)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    SlideTransition stForm = new SlideTransition(schedSlide.Transition);
                    stForm.ShowDialog();
                    if (stForm.SelectedTransition != null)
                        schedSlide.Transition = stForm.SelectedTransition;
                }));
            }
        }

        private void ConfigureTransitionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
