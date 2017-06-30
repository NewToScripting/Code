using System;
using Inspire.Client.ScheduleWindow.ScheduleTreeView;
using Transitionals.Transitions;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow// : IWeakEventListener
    {

        internal readonly ScheduleInfo SchedulerInfo;

        internal readonly ScheduleCalendar SchedulerCalendar;
        private static readonly ScheduleTreeControl _schedulerTreeControl;
        private static TouchScreenScheduler _touchScreenScheduler;

        internal bool IsEditMode { get; set; }

        public ScheduleWindow()
        {
            InitializeComponent();

            SchedulerInfo = new ScheduleInfo();

            SchedulerCalendar = new ScheduleCalendar();

           // LoadedEventManager.AddListener(this, this);

            var transition = new SlideInTransitionFX();
            transition.Direction = SlideInTransitionFX.SlideDirection.RightToLeft;

            SchedulerHolder.Transition = transition;

            SchedulerHolder.Content = SchedulerCalendar;
        }

        public void SetEditMode(bool editMode)
        {
            if (editMode)
            {
                IsEditMode = true;
            }
            else
            {
                IsEditMode = false;
            }
            SchedulerCalendar.SchedulerSlideControl.SetEditMode(editMode);
        }

        internal void GetPlayBackSettings(Schedule schedule)
        {
            switch (schedule.Mode)
            {
                case (Schedule.ModeEnum.Default):
                    {
                        SchedulerInfo.cbPlaybackMode.SelectedIndex = 0;
                        break;
                    }
                case (Schedule.ModeEnum.DoNotMix):
                    {
                        SchedulerInfo.cbPlaybackMode.SelectedIndex = 1;
                        break;
                    }
                case (Schedule.ModeEnum.Shuffle):
                    {
                        SchedulerInfo.cbPlaybackMode.SelectedIndex = 2;
                        break;
                    }
                case (Schedule.ModeEnum.Intersperse):
                    {
                        SchedulerInfo.cbPlaybackMode.SelectedIndex = 3;
                        break;
                    }
                default:
                    {
                        SchedulerInfo.cbPlaybackMode.SelectedIndex = 0;
                        break;
                    }
            }
        }

        internal void GetTypeSettings(Schedule schedule)
        {
            switch (schedule.Type)
            {
                case (Schedule.ScheduleTypeEnum.Continuous):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 0;
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Daily):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 1;
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Default):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 8;
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Monthly):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 6;
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Sleep):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 9;
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Touchscreen):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 10;
                        break;
                    }
                //case (Schedule.ScheduleTypeEnum.Triggerable):
                //    {
                //        SchedulerInfo.cbSchedType.SelectedIndex = 10;
                //        break;
                //    }
                case (Schedule.ScheduleTypeEnum.Weekly):
                    {
                        if (schedule.Days == (Schedule.DaysEnum)10)
                        {
                            SchedulerInfo.cbSchedType.SelectedIndex = 4;
                            SchedulerInfo.ckbTuesday.IsChecked = true;
                            SchedulerInfo.ckbThursday.IsChecked = true;
                        }
                        if (schedule.Days == (Schedule.DaysEnum)21)
                        {
                            SchedulerInfo.cbSchedType.SelectedIndex = 3;
                            SchedulerInfo.ckbMonday.IsChecked = true;
                            SchedulerInfo.ckbWednesday.IsChecked = true;
                            SchedulerInfo.ckbFriday.IsChecked = true;
                        }
                        if (schedule.Days == (Schedule.DaysEnum)31)
                        {
                            SchedulerInfo.cbSchedType.SelectedIndex = 2;
                            SchedulerInfo.ckbMonday.IsChecked = true;
                            SchedulerInfo.ckbTuesday.IsChecked = true;
                            SchedulerInfo.ckbWednesday.IsChecked = true;
                            SchedulerInfo.ckbThursday.IsChecked = true;
                            SchedulerInfo.ckbFriday.IsChecked = true;
                        }
                        else
                        {
                            foreach (Schedule.DaysEnum days in Schedule.GetSelectedEnumValues(schedule.Days))
                            {
                                if (days.ToString() == "Sunday")
                                    SchedulerInfo.ckbSunday.IsChecked = true;
                                if (days.ToString() == "Monday")
                                    SchedulerInfo.ckbMonday.IsChecked = true;
                                if (days.ToString() == "Tuesday")
                                    SchedulerInfo.ckbTuesday.IsChecked = true;
                                if (days.ToString() == "Wednesday")
                                    SchedulerInfo.ckbWednesday.IsChecked = true;
                                if (days.ToString() == "Thursday")
                                    SchedulerInfo.ckbThursday.IsChecked = true;
                                if (days.ToString() == "Friday")
                                    SchedulerInfo.ckbFriday.IsChecked = true;
                                if (days.ToString() == "Saturday")
                                    SchedulerInfo.ckbSaturday.IsChecked = true;
                            }
                        }
                        break;
                    }
                case (Schedule.ScheduleTypeEnum.Yearly):
                    {
                        SchedulerInfo.cbSchedType.SelectedIndex = 7;
                        break;
                    }
            }
        }

        internal void SetModeInfo(Schedule sched)
        {
            if (SchedulerInfo.cbPlaybackMode.SelectedIndex == 0)
                sched.Mode = Schedule.ModeEnum.Default;
            if (SchedulerInfo.cbPlaybackMode.SelectedIndex == 1)
                sched.Mode = Schedule.ModeEnum.DoNotMix;
            if (SchedulerInfo.cbPlaybackMode.SelectedIndex == 2)
                sched.Mode = Schedule.ModeEnum.Shuffle;
            if (SchedulerInfo.cbPlaybackMode.SelectedIndex == 3)
                sched.Mode = Schedule.ModeEnum.Intersperse;
        }

        internal void SetTypeInfo(Schedule sched)
        {
            switch (SchedulerInfo.cbSchedType.Text)
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
                    if (SchedulerInfo.ckbSunday.IsChecked == true)
                        days = days + 64;
                    if (SchedulerInfo.ckbMonday.IsChecked == true)
                        days = days + 1;
                    if (SchedulerInfo.ckbTuesday.IsChecked == true)
                        days = days + 2;
                    if (SchedulerInfo.ckbWednesday.IsChecked == true)
                        days = days + 4;
                    if (SchedulerInfo.ckbThursday.IsChecked == true)
                        days = days + 8;
                    if (SchedulerInfo.ckbFriday.IsChecked == true)
                        days = days + 16;
                    if (SchedulerInfo.ckbSaturday.IsChecked == true)
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

        //#region IWeakEventListener Members

        //public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        //{
        //    if (managerType == typeof(LoadedEventManager))
        //    {
        //        ScheduleWindow_Loaded(sender, e);
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

    }


}
