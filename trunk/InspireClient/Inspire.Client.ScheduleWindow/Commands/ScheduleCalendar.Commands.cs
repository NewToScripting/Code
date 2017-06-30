using System;
using System.Windows;
using System.Windows.Input;
using DevComponents.WpfSchedule;
using DevComponents.WpfSchedule.Model;

namespace Inspire.Client.ScheduleWindow
{
    public partial class ScheduleCalendar 
    {

        private void Appointment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                AppointmentView appointmentView = sender as AppointmentView;
                if (appointmentView != null)
                {
                    ScheduleAppointment appointment = appointmentView.Appointment as ScheduleAppointment;
                    if (appointment != null)
                    {
                        Commands.InspireCommands.EditScheduleCommand.Execute(appointment.GUID,null);
                    }
                }
            }
            else
            {
                AppointmentView appointmentView = sender as AppointmentView;
                if (appointmentView != null)
                {
                    ScheduleAppointment appointment = null;
                    
                    if (appointmentView.Appointment.GetType() == typeof(Appointment))
                    {
                        if (appointmentView.Appointment.IsRecurringInstance)
                            appointment = appointmentView.Appointment.RootAppointment as ScheduleAppointment;
                    }
                    else
                    {
                        appointment = appointmentView.Appointment as ScheduleAppointment;
                    }
                     
                    if (appointment != null)
                    {
                        if (InspireApp.CurrentScheduleGuidLoaded != appointment.GUID)
                        {
                            Commands.InspireCommands.FillScheduledSlidesCommand.Execute(appointment.GUID, null);
                            InspireApp.CurrentScheduleGuidLoaded = appointment.GUID;
                        }
                    }
                }
            }
        }



        private void RunEditScheduleCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            AppointmentView appointmentView = ((FrameworkElement)sender).TemplatedParent as AppointmentView;
            if (appointmentView != null)
            {
                ScheduleAppointment appointment = appointmentView.Appointment as ScheduleAppointment;
                if (appointment != null)
                {
                    Commands.InspireCommands.EditScheduleCommand.Execute(appointment.GUID, null);
                }
            }
        }

        private void RunEditScheduleCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
