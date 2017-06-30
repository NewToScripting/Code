using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DevComponents.WpfSchedule;
using DevComponents.WpfSchedule.Model;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for ScheduleCalendar.xaml
    /// </summary>
    public partial class ScheduleCalendar
    {
        public static RoutedCommand RunEditScheduleCommand = new RoutedCommand();

        public static List<Schedule> Schedules { get; set; }

        CalendarModel _Model = null;

        static ScheduleCalendar()
        {
            ScheduleColors.ChangeColorScheme(eScheduleVisualStyle.Office2007Black);
            DevComponents.WpfRibbon.Ribbon.SetColorScheme(DevComponents.WpfRibbon.eRibbonVisualStyle.Office2007Black);
            DevComponents.WpfEditors.EditColors.ChangeColorScheme(
                DevComponents.WpfEditors.eEditorsVisualStyle.Office2007Black);
        }

        public ScheduleCalendar()
        {
            InitializeComponent();

            // Initialize the Model which manages the appointments
            _Model = new CalendarModel();
            Calendar.SelectedView = eCalendarView.Week;

            Calendar.CalendarModel = _Model;

        }

        private DateTime SetCalendarEndTime(Schedule schedule)
        {
            if (schedule.StartDate != null && schedule.StartTime != null)
                    return new DateTime(schedule.EndDate.Value.Year, schedule.EndDate.Value.Month, schedule.EndDate.Value.Day, schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute, schedule.EndTime.Value.Second);
            return DateTime.Today;
        }

        private DateTime SetCalendarStartTime(Schedule schedule)
        {
            if (schedule.StartDate != null && schedule.StartTime != null)
                    return new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day, schedule.StartTime.Value.Hour, schedule.StartTime.Value.Minute, schedule.StartTime.Value.Second);
            return DateTime.Today;
        }

        internal void FillCalendar(List<Schedule> schedules)
        {
            _Model = new CalendarModel();
            
            if (schedules != null)
            {
                foreach (Schedule schedule in schedules)
                {
                    switch (schedule.Type)
                    {
                        case Schedule.ScheduleTypeEnum.Continuous:
                            {

                                //SchedulerInfo.ScheduleCalendar.CalendarModel = _Model;

                                // Create new appointment and add it to the model
                                // Appointment will show up in view automatically
                                var appointment = new ScheduleAppointment();
                                //       AppointmentChangeManager.AddListener(appointment, this);

                                appointment.Locked = true;

                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;
                                appointment.StartTime = SetCalendarStartTime(schedule);
                                appointment.EndTime = SetCalendarEndTime(schedule);
                                appointment.CategoryColor = Appointment.CategoryGreen;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                if(appointmentView != null)
                                    appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;

                              //  appointmentView.Appointment.PropertyChanged +=Appointment_PropertyChanged;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Touchscreen:
                            {

                                //SchedulerInfo.ScheduleCalendar.CalendarModel = _Model;

                                // Create new appointment and add it to the model
                                // Appointment will show up in view automatically
                                var appointment = new ScheduleAppointment();
                                //       AppointmentChangeManager.AddListener(appointment, this);

                                appointment.Locked = true;

                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;
                                appointment.StartTime = SetCalendarStartTime(schedule);
                                appointment.EndTime = SetCalendarEndTime(schedule);
                                appointment.CategoryColor = Appointment.CategoryGreen;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                if (appointmentView != null)
                                    appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;

                                //  appointmentView.Appointment.PropertyChanged +=Appointment_PropertyChanged;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Daily:
                            {
                                // SchedulerInfo.ScheduleCalendar.CalendarModel = _Model;

                                // Create new appointment and add it to the model
                                // Appointment will show up in view automatically

                                var appointment = new ScheduleAppointment();
                                // appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(appointment_PropertyChanged2);
                                // appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(appointment_SubPropertyChanged3);
                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;

                                appointment.StyleResourceName = new ComponentResourceKey(typeof(ScheduleCalendar), "AppView");

                                appointment.Locked = true;
  
                                appointment.StartTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month,
                                                                     schedule.StartDate.Value.Day, schedule.StartTime.Value.Hour,
                                                                     schedule.StartTime.Value.Minute,
                                                                     schedule.StartTime.Value.Second);
                                if (schedule.EndTime > schedule.StartTime)
                                    appointment.EndTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                else
                                {
                                    var endStarDate = schedule.StartDate.Value.Date + new TimeSpan(1, 0, 0, 0);
                                    appointment.EndTime = new DateTime(endStarDate.Year, endStarDate.Month, endStarDate.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                }
                                appointment.Recurrence = new AppointmentRecurrence();

                                // Set recurrence type to weekly
                                appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Daily;

                                // Recurrence properties are changed then on respective object Daily, Weekly, Monthly, Yearly
                                appointment.Recurrence.Daily.RepeatOnDaysOfWeek = eDailyRecurrenceRepeat.All;

                                //appointment.Recurrence.Daily.RepeatInterval = 1;

                                // End recurrence 30 days from today
                                appointment.Recurrence.RangeEndDate = schedule.EndDate.Value.Date + new TimeSpan(1, 0, 0, 0);
                                appointment.CategoryColor = Appointment.CategoryGreen;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;

                              //  appointmentView.Appointment.PropertyChanged += Appointment_PropertyChanged;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Weekly:
                            {
                                ScheduleAppointment appointment = new ScheduleAppointment();
                                // appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(appointment_PropertyChanged2);
                                // appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(appointment_SubPropertyChanged3);
                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;

                                appointment.Locked = true;

                               // schedule.Days = Schedule.DaysEnum.Wednesday;
                                if (schedule.Days != Schedule.DaysEnum.None)
                                {
                                    var schedulDays = Schedule.GetSelectedEnumValues(schedule.Days);
                                    
                                    //if(schedulDays.Contains(Schedule.ConvertToEnum(DateTime.Today.DayOfWeek)))

                                    bool esc = false;

                                    for (int i = 0; i < 7; i++)
                                    {
                                        DayOfWeek scheduleDay = DateTime.Today.AddDays(i).DayOfWeek;

                                        foreach (var schedulDay in schedulDays)
                                        {
                                            if(schedulDay.ToString() == scheduleDay.ToString())
                                            {
                                                schedule.StartDate = schedule.StartDate.Value.AddDays(i);
                                                if (schedule.StartDate > schedule.EndDate)
                                                    schedule.EndDate = schedule.StartDate;
                                                esc = true;
                                                break;
                                            }
                                        }

                                        if(esc)
                                            break;
                                    }

                                    appointment.StartTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month,
                                                                     schedule.StartDate.Value.Day, schedule.StartDate.Value.Hour,
                                                                     schedule.StartTime.Value.Minute,
                                                                     schedule.StartTime.Value.Second);

                                    if (schedule.EndTime > schedule.StartTime)
                                        appointment.EndTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day,
                                                                       schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                       schedule.EndTime.Value.Second);
                                    else
                                    {
                                        var endStarDate = schedule.StartDate.Value.Date + new TimeSpan(1, 0, 0, 0);
                                        appointment.EndTime = new DateTime(endStarDate.Year, endStarDate.Month, endStarDate.Day,
                                                                       schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                       schedule.EndTime.Value.Second);
                                    }
                                    appointment.Recurrence = new AppointmentRecurrence();
                                    //  appointment.Recurrence.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Recurrence_PropertyChanged);
                                    //  appointment.Recurrence.SubPropertyChanged += new SubPropertyChangedEventHandler(Recurrence_SubPropertyChanged1);
                                    //   appointment.Recurrence.Appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(Appointment_SubPropertyChanged);
                                    //   appointment.Recurrence.Appointment.Recurrence.Appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Appointment_PropertyChanged1);
                                    //   AppointmentChangeManager.AddListener(appointment.Recurrence.Appointment, this);

                                    // Set recurrence type to weekly
                                    appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Weekly;
                                    // Recurrence properties are changed then on respective object Daily, Weekly, Monthly, Yearly

                                    appointment.Recurrence.Weekly.RepeatOnDaysOfWeek =
                                        (eDayOfWeekRecurrence) schedule.Days;


                                    // End recurrence 30 days from today
                                    appointment.Recurrence.RangeEndDate = schedule.EndDate.Value.Date;
                                        // = new DateTime(2009, 8, 25); // schedule.EndDate.Value.Date;
                                    appointment.CategoryColor = Appointment.CategoryBlue;
                                    appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                    // Add appointment to the model
                                    _Model.Appointments.Add(appointment);

                                    Calendar.CalendarModel = _Model;

                                    // Make appointment visible in current view
                                    Calendar.EnsureVisible(appointment);

                                    AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                    appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;
                                }
                                else
                                {
                                    //appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Daily;

                                    Calendar.CalendarModel = _Model;

                                    // Make appointment visible in current view
                                    //Calendar.EnsureVisible(appointment);
                                }
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Monthly:
                            {
                                ScheduleAppointment appointment = new ScheduleAppointment();
                                // appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(appointment_PropertyChanged2);
                                // appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(appointment_SubPropertyChanged3);
                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;

                                appointment.Locked = true;

                                appointment.StartTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month,
                                                                     schedule.StartDate.Value.Day, schedule.StartDate.Value.Hour,
                                                                     schedule.StartTime.Value.Minute,
                                                                     schedule.StartTime.Value.Second);

                                appointment.EndTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                appointment.Recurrence = new AppointmentRecurrence();
                                //  appointment.Recurrence.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Recurrence_PropertyChanged);
                                //  appointment.Recurrence.SubPropertyChanged += new SubPropertyChangedEventHandler(Recurrence_SubPropertyChanged1);
                                //   appointment.Recurrence.Appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(Appointment_SubPropertyChanged);
                                //   appointment.Recurrence.Appointment.Recurrence.Appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Appointment_PropertyChanged1);
                                //   AppointmentChangeManager.AddListener(appointment.Recurrence.Appointment, this);

                                // Set recurrence type to weekly
                                appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Monthly;
                                // Recurrence properties are changed then on respective object Daily, Weekly, Monthly, Yearly


                                appointment.Recurrence.Monthly.RepeatOnDayOfMonth = schedule.StartDate.Value.Day;

                                // End recurrence 30 days from today
                                appointment.Recurrence.RangeEndDate = schedule.EndDate.Value.Date;// = new DateTime(2009, 8, 25); // schedule.EndDate.Value.Date;
                                appointment.CategoryColor = Appointment.CategoryBlue;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Yearly:
                            {
                                ScheduleAppointment appointment = new ScheduleAppointment();
                                // appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(appointment_PropertyChanged2);
                                // appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(appointment_SubPropertyChanged3);
                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;

                                appointment.Locked = true;

                                appointment.StartTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month,
                                                                     schedule.StartDate.Value.Day, schedule.StartDate.Value.Hour,
                                                                     schedule.StartTime.Value.Minute,
                                                                     schedule.StartTime.Value.Second);

                                appointment.EndTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                appointment.Recurrence = new AppointmentRecurrence();
                                //  appointment.Recurrence.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Recurrence_PropertyChanged);
                                //  appointment.Recurrence.SubPropertyChanged += new SubPropertyChangedEventHandler(Recurrence_SubPropertyChanged1);
                                //   appointment.Recurrence.Appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(Appointment_SubPropertyChanged);
                                //   appointment.Recurrence.Appointment.Recurrence.Appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Appointment_PropertyChanged1);
                                //   AppointmentChangeManager.AddListener(appointment.Recurrence.Appointment, this);

                                // Set recurrence type to weekly
                                appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Yearly;
                                // Recurrence properties are changed then on respective object Daily, Weekly, Monthly, Yearly


                                appointment.Recurrence.Yearly.RepeatOnMonth = schedule.StartDate.Value.Month;

                                appointment.Recurrence.Yearly.RepeatOnDayOfMonth = schedule.StartDate.Value.Day;

                                // End recurrence 30 days from today
                                appointment.Recurrence.RangeEndDate = schedule.EndDate.Value.Date;// = new DateTime(2009, 8, 25); // schedule.EndDate.Value.Date;
                                appointment.CategoryColor = Appointment.CategoryBlue;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Sleep:
                            {
                                var appointment = new ScheduleAppointment();
                                // appointment.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(appointment_PropertyChanged2);
                                // appointment.SubPropertyChanged += new SubPropertyChangedEventHandler(appointment_SubPropertyChanged3);
                                appointment.Subject = schedule.Name;
                                appointment.Description = "(" + schedule.Type + ")";
                                appointment.GUID = schedule.GUID;

                                appointment.StyleResourceName = new ComponentResourceKey(typeof(ScheduleCalendar), "AppView");

                                appointment.Locked = true;

                                appointment.StartTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month,
                                                                     schedule.StartDate.Value.Day, schedule.StartTime.Value.Hour,
                                                                     schedule.StartTime.Value.Minute,
                                                                     schedule.StartTime.Value.Second);
                                if (schedule.EndTime > schedule.StartTime)
                                    appointment.EndTime = new DateTime(schedule.StartDate.Value.Year, schedule.StartDate.Value.Month, schedule.StartDate.Value.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                else
                                {
                                    var endStarDate = schedule.StartDate.Value.Date + new TimeSpan(1, 0, 0, 0);
                                    appointment.EndTime = new DateTime(endStarDate.Year, endStarDate.Month, endStarDate.Day,
                                                                   schedule.EndTime.Value.Hour, schedule.EndTime.Value.Minute,
                                                                   schedule.EndTime.Value.Second);
                                }
                                appointment.Recurrence = new AppointmentRecurrence();

                                // Set recurrence type to weekly
                                appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Daily;

                                // Recurrence properties are changed then on respective object Daily, Weekly, Monthly, Yearly
                                appointment.Recurrence.Daily.RepeatOnDaysOfWeek = eDailyRecurrenceRepeat.All;

                                //appointment.Recurrence.Daily.RepeatInterval = 1;

                                // End recurrence 30 days from today
                                appointment.Recurrence.RangeEndDate = schedule.EndDate.Value.Date;
                                appointment.CategoryColor = Appointment.CategoryRed;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;
                            }
                            break;
                        case Schedule.ScheduleTypeEnum.Default:
                            {
                                //SchedulerInfo.ScheduleCalendar.CalendarModel = _Model;

                                // Create new appointment and add it to the model
                                // Appointment will show up in view automatically
                                var appointment = new ScheduleAppointment();
                                //       AppointmentChangeManager.AddListener(appointment, this);

                                appointment.Subject = schedule.Name;
                                appointment.GUID = schedule.GUID;

                                appointment.Locked = true;

                                appointment.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                                appointment.EndTime = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                                appointment.CategoryColor = Appointment.CategoryDefault;
                                appointment.TimeMarkedAs = Appointment.TimerMarkerBusy;

                                // Add appointment to the model
                                _Model.Appointments.Add(appointment);

                                Calendar.CalendarModel = _Model;

                                // Make appointment visible in current view
                                Calendar.EnsureVisible(appointment);

                                AppointmentView appointmentView = Calendar.GetAppointmentView(appointment);

                                appointmentView.Locked = true;

                                appointmentView.MouseDoubleClick += Appointment_MouseLeftButtonDown;

                             //   appointmentView.Appointment.PropertyChanged += Appointment_PropertyChanged;
                            }
                            break;
                    }
                }
            }
            if (Calendar.CalendarModel == null)
                Calendar.CalendarModel = _Model;
            else
            {
                Calendar.CalendarModel.InvalidateAppointmentCache();
            }
            Calendar.ShowDate(DateTime.Today);
        }

        void Appointment_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(sender.GetType() == typeof(ScheduleAppointment))
            {
                ScheduleAppointment appointment = sender as ScheduleAppointment;

                Schedule schedule = ScheduleConverter.GetSchedule(appointment);

                //ScheduleManager.UpdateSchedule(schedule, displays);

            }
        }
    }

    internal static class ScheduleConverter
    {
        public static Schedule GetSchedule(ScheduleAppointment appointment)
        {
            var schedule = new Schedule
                                    {
                                        Name = appointment.Subject,
                                        GUID = appointment.GUID,
                                        StartTime = appointment.StartTime,
                                        EndTime = appointment.EndTime,
                                        StartDate = appointment.StartTime,
                                        EndDate = appointment.EndTime
                                    };
            return schedule;
        }
    }
}
