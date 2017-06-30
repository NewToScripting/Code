using System;
using System.Windows;
using DevComponents.WpfSchedule.Model;

namespace Inspire.Client.ScheduleWindow.WeakEventHandlers
{
    public class AppointmentChangeManager : WeakEventManager
    {
        public static void AddListener(object source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(object source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnPropertyChanged(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            var appointment = (Appointment)source;
            appointment.PropertyChanged += OnPropertyChanged;
        }

        protected override void StopListening(Object source)
        {
            var appointment = (Appointment)source;
            appointment.PropertyChanged -= OnPropertyChanged;
        }

        private static AppointmentChangeManager CurrentManager
        {
            get
            {
                Type managerType = typeof(AppointmentChangeManager);
                var manager = (AppointmentChangeManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new AppointmentChangeManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
