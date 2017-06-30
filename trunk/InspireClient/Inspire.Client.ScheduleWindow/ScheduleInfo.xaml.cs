using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Inspire.Client.ScheduleWindow.Dialogs;
using Inspire.Common.TreeViewModel;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for ScheduleInfo.xaml
    /// </summary>
    public partial class ScheduleInfo
    {

        public Schedule UpdateSchedule { get; set; }

        private bool initialLoadFinished;

        public ScheduleInfo()
        {
            InitializeComponent();
            UpdateSchedule = new Schedule();
            txtSchedName.Focus();
            cbSchedType.SelectionChanged += cbSchedType_SelectionChanged;
            dpEnd.ValueChanged += dpEnd_ValueChanged;
            dpStart.ValueChanged += dpStart_ValueChanged;
            ckbMonday.Click += CheckBoxClicked;
            ckbTuesday.Click += CheckBoxClicked;
            ckbWednesday.Click += CheckBoxClicked;
            ckbThursday.Click += CheckBoxClicked;
            ckbFriday.Click += CheckBoxClicked;
            ckbSaturday.Click += CheckBoxClicked;
            ckbSunday.Click += CheckBoxClicked;

            Clear();
            //Loaded += new RoutedEventHandler(ScheduleInfo_Loaded);
        }

        private void CheckBoxClicked(object sender, RoutedEventArgs e)
        {
            SetTypeInfo(UpdateSchedule);
            ChangeDescription(UpdateSchedule);
        }

        public List<ScheduledSlide> GetScheduledSlides(Schedule sched)
        {
            var schedSlides = (ObservableCollection<ScheduledSlide>) lbSlideInfoSlides.ItemsSource;

            if (schedSlides != null)
            {
                foreach (var scheduledSlide in schedSlides)
                {
                    scheduledSlide.ScheduleId = sched.GUID;
                    scheduledSlide.ResetButtonSchedSlideGuids();
                }

                return schedSlides.ToList();
            }
            return new List<ScheduledSlide>();
        }


        public List<ScheduledSlide> GetScheduledSlides(string schedId)
        {
            return ((ObservableCollection<ScheduledSlide>)lbSlideInfoSlides.ItemsSource).ToList();
        }

        public List<ScheduledSlide> GetSlidesForPreview(string _scheduleGuid)
        {
            return ((ObservableCollection<ScheduledSlide>)lbSlideInfoSlides.ItemsSource).ToList();
        }

        public void NewSchedule()
        {
            SetTypeInfo(UpdateSchedule);
            SetDateTime(UpdateSchedule);
            ChangeDescription(UpdateSchedule);
        }

        void dpEnd_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (initialLoadFinished)
            {
                SetDateTime(UpdateSchedule);

                ChangeDescription(UpdateSchedule);
            }
        }

        void dpStart_ValueChanged(object sender, RoutedEventArgs e)
        {
            if(initialLoadFinished)
            {
                SetDateTime(UpdateSchedule);

                ChangeDescription(UpdateSchedule);
            }
        }

        void cbSchedType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (initialLoadFinished)
            {
                SetTypeInfo(UpdateSchedule);

                ChangeDescription(UpdateSchedule);
            }
        }

        internal void SetDateTime(Schedule schedule)
        {
            if (cbAllDay.IsChecked == true)
            {
                schedule.StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0, 1);
                schedule.EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59, 1);
            }
            else
            {
                if (tpStart.Value != null)
                    schedule.StartTime = tpStart.Value;
                schedule.EndTime = tpEnd.Value;
            }

            if (dpStart.Value != null)
                schedule.StartDate = dpStart.Value;
            schedule.EndDate = dpEnd.Value;
        }

        private void SetTypeInfo(Schedule sched)
        {
            switch (((ContentControl)cbSchedType.SelectedItem).Content.ToString())
            {
                case "Does not repeat":
                    sched.Type = Schedule.ScheduleTypeEnum.Continuous;
                    break;
                case "Default":
                    sched.Type = Schedule.ScheduleTypeEnum.Default;
                    break;
                case "Daily":
                    sched.Type = Schedule.ScheduleTypeEnum.Daily;
                    break;
                case "Every weekday (Mon-Fri)":
                    sched.Type = Schedule.ScheduleTypeEnum.Weekly;
                    sched.Days = Schedule.DaysEnum.Monday | Schedule.DaysEnum.Tuesday | Schedule.DaysEnum.Wednesday |
                                 Schedule.DaysEnum.Thursday | Schedule.DaysEnum.Friday;
                    break;
                case "Every Mon., Wed., and Fri.":
                    sched.Type = Schedule.ScheduleTypeEnum.Weekly;
                    sched.Days = Schedule.DaysEnum.Monday | Schedule.DaysEnum.Wednesday | Schedule.DaysEnum.Friday;
                    break;
                case "Every Tues., and Thurs.":
                    sched.Type = Schedule.ScheduleTypeEnum.Weekly;
                    sched.Days = Schedule.DaysEnum.Tuesday | Schedule.DaysEnum.Thursday;
                    break;
                case "Weekly":
                    sched.Type = Schedule.ScheduleTypeEnum.Weekly;
                    int days = 0;
                    if (ckbSunday.IsChecked == true)
                        days = days + 64;
                    if (ckbMonday.IsChecked == true)
                        days = days + 1;
                    if (ckbTuesday.IsChecked == true)
                        days = days + 2;
                    if (ckbWednesday.IsChecked == true)
                        days = days + 4;
                    if (ckbThursday.IsChecked == true)
                        days = days + 8;
                    if (ckbFriday.IsChecked == true)
                        days = days + 16;
                    if (ckbSaturday.IsChecked == true)
                        days = days + 32;
                    sched.Days = (Schedule.DaysEnum)days;
                    break;
                case "Monthly":
                    sched.Type = Schedule.ScheduleTypeEnum.Monthly;
                    break;
                case "Touchscreen":
                    sched.Type = Schedule.ScheduleTypeEnum.Touchscreen;
                    break;
                case "Yearly":
                    sched.Type = Schedule.ScheduleTypeEnum.Yearly;
                    break;
                case "Sleep Mode":
                    sched.Type = Schedule.ScheduleTypeEnum.Sleep;
                    break;
                //case "Triggered":
                //    sched.Type = Schedule.ScheduleTypeEnum.Triggerable;
                //    break;
                default:
                    sched.Type = Schedule.ScheduleTypeEnum.Continuous;
                    break;
            }
        }

        private void lvDisplays_DragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void lvDisplays_Drop(object sender, DragEventArgs e)
        {
            var displayViewModel = (DisplayViewModel)e.Data.GetData(typeof(DisplayViewModel));

            if(displayViewModel != null)
            {
                var dispGuids = new List<string>();

                foreach (DisplayViewModel item in lvDisplays.Items)
                {
                    dispGuids.Add(item.GUID);
                }

                if (!dispGuids.Contains(displayViewModel.GUID))
                    lvDisplays.Items.Add(displayViewModel);
            }

            e.Handled = true;
        }

        public void Clear()
        {
            btnUpdate.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;
            txtSchedName.Text = string.Empty;
            cbSchedType.SelectedIndex = 0;
            dpStart.Value = DateTime.Today;
            dpEnd.Value = DateTime.Today.AddDays(5);
            tpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8,0,0, DateTimeKind.Local);
            tpEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0, DateTimeKind.Local);
            lvDisplays.Items.Clear();
            txtSchedName.Focus();
            tbPlaybackDesc.Text = string.Empty;
            lbSlideInfoSlides.ItemsSource = null;
        }

        private void RemoveDisplay(object sender, RoutedEventArgs e)
        {
            MenuItem mItem = (MenuItem)sender;
            ContextMenu cMenu = (ContextMenu)mItem.Parent;
            DisplayViewModel displayViewModel = (DisplayViewModel)cMenu.DataContext;
            lvDisplays.Items.Remove(displayViewModel);
            e.Handled = true;
        }

        public void NewDefinedSchedule(Schedule schedule)
        {
            initialLoadFinished = false;
            Clear();
            btnUpdate.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;
            txtSchedName.Text = schedule.Name;
            cbSchedType.SelectedIndex = 0;
            dpStart.Value = schedule.StartDate;
            dpEnd.Value = schedule.EndDate;
            tpStart.Value = schedule.StartTime;
            tpEnd.Value = schedule.EndTime;

            tbPlaybackDesc.Text = "Continuously, until " + schedule.EndDate.Value.Month + "/" + schedule.EndDate.Value.Day + "/" + schedule.EndDate.Value.Year;

            txtSchedName.Focus();

            initialLoadFinished = true;
        }

        public void FillScheduledSlides(IEnumerable<ScheduledSlide> scheduledSlides)
        {
            lbSlideInfoSlides.ItemsSource = new ObservableCollection<ScheduledSlide>(scheduledSlides);
        }

        public void FillSchedulerInfo(Schedule schedule)
        {
            initialLoadFinished = false;
            Clear();
            btnUpdate.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;
            txtSchedName.Text = schedule.Name;
            cbSchedType.Text = schedule.Type.ToString();
            dpStart.Value = schedule.StartDate;
            dpEnd.Value = schedule.EndDate;
            tpStart.Value = schedule.StartTime;
            tpEnd.Value = schedule.EndTime;
            if(schedule.StartTime.Value.Hour == 0 && schedule.StartTime.Value.Minute == 0 && schedule.EndTime.Value.Hour == 23 && schedule.EndTime.Value.Minute == 59)
                cbAllDay.IsChecked = true;
            else
                cbAllDay.IsChecked = false;

            ChangeDescription(schedule);

            txtSchedName.Focus();

            initialLoadFinished = true;
        }

        private void ChangeDescription(Schedule schedule)
        {
            switch (schedule.Type.ToString())
            {
                case ("Daily"):
                    tbPlaybackDesc.Text = "Daily, until " + schedule.EndDate.Value.Month + "/" + schedule.EndDate.Value.Day + "/" + schedule.EndDate.Value.Year;
                    break;
                case ("Continuous"):
                    tbPlaybackDesc.Text = "Continuously, until " + schedule.EndDate.Value.Month + "/" + schedule.EndDate.Value.Day + "/" + schedule.EndDate.Value.Year;
                    break;
                case ("Touchscreen"):
                    tbPlaybackDesc.Text = "Continuously, until " + schedule.EndDate.Value.Month + "/" + schedule.EndDate.Value.Day + "/" + schedule.EndDate.Value.Year;
                    break;
                case ("Weekly"):
                    {
                        tbPlaybackDesc.Text = BuildWeeklyText(schedule) + "until " + schedule.EndDate.Value.Month + "/" + schedule.EndDate.Value.Day;
                        break;
                    }
                case ("Monthly"):
                    {
                        tbPlaybackDesc.Text = "Every Month on the " + schedule.StartDate.Value.Day + "th";
                        break;
                    }
                case ("Yearly"):
                    {
                        tbPlaybackDesc.Text = "Every year on " + schedule.StartDate.Value.Month + "/" +
                                              schedule.StartDate.Value.Day;
                        break;
                    }
                case ("Sleep"):
                    {
                        tbPlaybackDesc.Text = "Every Day from start time until end time.";
                        break;
                    }
            }
        }

        private static string BuildWeeklyText(Schedule schedule)
        {
            string txt = "Weekly, ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Monday))
                txt += "Monday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Tuesday))
                txt += "Tuesday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Wednesday))
                txt += "Wednesday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Thursday))
                txt += "Thursday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Friday))
                txt += "Friday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Saturday))
                txt += "Saturday & ";
            if (Schedule.GetSelectedEnumValues(schedule.Days).Contains(Schedule.DaysEnum.Sunday))
                txt += "Sunday & ";
            return txt;
        }

        public void SetUpdateSchedule(Schedule schedule)
        {
            UpdateSchedule = schedule;
        }

        private void lbSlideInfoSlides_Drop(object sender, DragEventArgs e)
        {
            DropGrabber.Visibility = Visibility.Collapsed;

            var slideControlItem = e.Data.GetData(typeof(ScheduledSlide)) as ScheduledSlide;

            if (slideControlItem != null)
            {
                var slideTimeDialog = new SlideTimeDialog(slideControlItem, UpdateSchedule.Type, slideControlItem.Transition);
                slideTimeDialog.ShowDialog();
                if(slideTimeDialog.DialogResult == true)
                {
                    slideControlItem.ScheduleId = UpdateSchedule.GUID;
                    slideControlItem.Duration = slideTimeDialog.SelectedDateTime;

                    slideControlItem.Transition = slideTimeDialog.SelectedTransition;

                    var schedSlides = lbSlideInfoSlides.ItemsSource as ObservableCollection<ScheduledSlide>;
                    if (schedSlides != null)
                        schedSlides.Add(slideControlItem);
                    else
                    {
                        try
                        {
                            lbSlideInfoSlides.Items.Clear();
                        }
                        catch (Exception)
                        {
                            //TODO: Take out last minute trade show fix
                        }

                        var newCollection = new ObservableCollection<ScheduledSlide> { slideControlItem };

                        lbSlideInfoSlides.ItemsSource = newCollection;
                    }
                    return;
                }
            }
            lbSlideInfoSlides.Focus();
        }

        private void lbSlideInfoSlides_DragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        //private void SlideGrid_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    DropGrabber.Visibility = Visibility.Collapsed;
        //    e.Handled = false;
        //}

        private void DeleteSlide(object sender, RoutedEventArgs e)
        {
            var schedSlide = ((FrameworkElement) sender).DataContext as ScheduledSlide;

            var itemCollection = lbSlideInfoSlides.ItemsSource as ObservableCollection<ScheduledSlide>;
            if (itemCollection != null) itemCollection.Remove(schedSlide);
        }

        private void SelectedTemplate_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lbSlideInfoSlides.SelectedItem = ((FrameworkElement)sender).DataContext as ScheduledSlide;
            //this.ReleaseAllTouchCaptures();
        }

    }
}
