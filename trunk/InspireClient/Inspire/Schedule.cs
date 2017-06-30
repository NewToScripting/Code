using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Inspire
{
    public class Schedule : DependencyObject
    {

        public Schedule()
        {
            GUID = Guid.NewGuid().ToString();
            Name = "";
            Type = ScheduleTypeEnum.Continuous;
            StartDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            StartTime = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            EndDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            EndTime = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            Priority = 0;
            Mode = ModeEnum.Default;
        }

        [Flags]
        public enum DaysEnum
        {
            None = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64,
            All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
        }

        public enum ScheduleTypeEnum { Default, Continuous, Sleep, Daily, Weekly, Monthly, Yearly, Touchscreen }
        public enum ModeEnum { Default, Shuffle, Intersperse, DoNotMix }

        public string GUID { get; set; }
        public string Name { get; set; }
        public ScheduleTypeEnum Type { get; set; }
        public ModeEnum Mode { get; set; }
        public DaysEnum Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public int Priority { get; set; }
        public List<ScheduledSlide> ScheduledSlides { get; set; }
        public List<Display> Displays { get; set; }

        public bool IsTouchScreenSchedule
        {
            get { return (bool)GetValue(IsTouchScreenScheduleProperty); }
            set { SetValue(IsTouchScreenScheduleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsTouchScreenSchedule.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTouchScreenScheduleProperty =
            DependencyProperty.Register("IsTouchScreenSchedule", typeof(bool), typeof(Schedule), new UIPropertyMetadata(false));

        

        public static Collection<T> GetSelectedEnumValues<T>(T enumInputValue) where T : struct
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(enumType + " is not an Enum.", "enumInputValue", null);
            }

            Array enumValues = Enum.GetValues(enumType);
            long inputValueLong = Convert.ToInt64(enumInputValue);
            Collection<T> enumOutputCollection = new Collection<T>();

            foreach (T enumValue in enumValues)
            {
                long enumValueLong = Convert.ToInt64(enumValue);

                if ((enumValueLong & inputValueLong) == enumValueLong
                    && enumValueLong != 0)
                {
                    enumOutputCollection.Add(enumValue);
                }
            }

            if (enumOutputCollection.Count == 0 && enumValues.GetLength(0) > 1)
            {
                T enumNoneValue = (T)enumValues.GetValue(0);
                if (Convert.ToInt64(enumNoneValue) == 0)
                {
                    enumOutputCollection.Add(enumNoneValue);
                }
            }

            return enumOutputCollection;
        }


        public static List<Schedule> GetCurrentValidSchedules(List<Schedule> displaySchedules)
        {
            var validSchedules = new List<Schedule>();

            var defaultSchedules = new List<Schedule>();

            DateTime playbackDateTime;

            if(InspireApp.IsPreviewMode)
                playbackDateTime = InspireApp.PlaybackDateTime;
            else
            {
                playbackDateTime = DateTime.Now;
            }

            InspireApp.DisplaySleepModeOn = false;
            
            foreach (Schedule displaySchedule in displaySchedules)
            {

                var startDateTime = new DateTime(displaySchedule.StartDate.Value.Year, displaySchedule.StartDate.Value.Month, displaySchedule.StartDate.Value.Day, displaySchedule.StartTime.Value.Hour,
                                                 displaySchedule.StartTime.Value.Minute, displaySchedule.StartTime.Value.Second);

                var endDateTime = new DateTime(displaySchedule.EndDate.Value.Year, displaySchedule.EndDate.Value.Month, displaySchedule.EndDate.Value.Day, displaySchedule.EndTime.Value.Hour, displaySchedule.EndTime.Value.Minute, displaySchedule.EndTime.Value.Second);

                switch (displaySchedule.Type)
                {
                    case (ScheduleTypeEnum.Sleep):
                        {
                            if ((displaySchedule.StartDate.Value.Date <= playbackDateTime.Date) &&
                                (displaySchedule.EndDate.Value.Date >= playbackDateTime.Date) &&
                                (displaySchedule.StartTime < playbackDateTime) &&
                                (displaySchedule.EndTime > DateTime.Now))
                            {
                                InspireApp.DisplaySleepModeOn = true;
                                return null;
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Daily):
                        {

                            var todayStartDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
                                                                  DateTime.Today.Day, displaySchedule.StartTime.Value.Hour, displaySchedule.StartTime.Value.Minute,
                                                                  displaySchedule.StartTime.Value.Second);

                            var todayEndDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
                                                                DateTime.Today.Day, displaySchedule.EndTime.Value.Hour, displaySchedule.EndTime.Value.Minute,
                                                                displaySchedule.EndTime.Value.Second);



                            if ((startDateTime <= playbackDateTime) && (endDateTime > playbackDateTime) &&
                                (todayStartDateTime <= playbackDateTime) && (todayEndDateTime >= playbackDateTime))
                            {

                                validSchedules.Add(displaySchedule);
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Weekly):
                        {
                            if ((displaySchedule.StartDate <= playbackDateTime.Date) && (displaySchedule.EndDate >= playbackDateTime.Date) &&
                                (displaySchedule.StartTime <= playbackDateTime) && (displaySchedule.EndTime >= playbackDateTime))
                            {
                                validSchedules.Add(displaySchedule);
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Monthly):
                        {
                            if (displaySchedule.StartDate.Value.Day == playbackDateTime.Day)
                            {
                                if ((displaySchedule.StartDate <= playbackDateTime.Date) && (displaySchedule.EndDate >= playbackDateTime.Date) &&
                                    (displaySchedule.StartTime <= playbackDateTime) && (displaySchedule.EndTime >= playbackDateTime))
                                {

                                    validSchedules.Add(displaySchedule);
                                }
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Yearly):
                        {
                            if ((displaySchedule.StartDate.Value.Month == playbackDateTime.Month) &&
                                    (displaySchedule.StartDate.Value.Day == playbackDateTime.Day))
                            {
                                if ((displaySchedule.StartDate <= playbackDateTime.Date) && (displaySchedule.EndDate >= playbackDateTime.Date) &&
                                    (displaySchedule.StartTime <= playbackDateTime) && (displaySchedule.EndTime >= playbackDateTime))
                                {
                                    validSchedules.Add(displaySchedule);
                                }
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Continuous):
                        {
                            if ((startDateTime <= playbackDateTime && endDateTime > playbackDateTime))
                            {
                                validSchedules.Add(displaySchedule);
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Touchscreen):
                        {
                            if ((startDateTime <= playbackDateTime && endDateTime > playbackDateTime))
                            {
                                validSchedules.Add(displaySchedule);
                            }
                            break;
                        }
                    case (ScheduleTypeEnum.Default):
                        {
                            if ((startDateTime <= playbackDateTime && endDateTime > playbackDateTime))
                            {
                                defaultSchedules.Add(displaySchedule);
                            }
                            break;
                        }
                    default:
                        break;
                }

            }

            if (validSchedules.Count > 0)
                return validSchedules;

            return defaultSchedules;
        }

        public static DaysEnum ConvertToEnum(DayOfWeek dayOfWeek)
        {
            return (DaysEnum) dayOfWeek;
        }
    }

    public class ScheduleCollection
    {

        public List<Schedule> Items { get; set; }

    }
}
