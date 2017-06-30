using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Events.Proxy;
using Microsoft.Windows.Controls;

namespace EventEntry
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EventManagementPanel
    {
        private BackgroundWorker backgroundWorker;

        private bool loaded;
        private bool _isDirty;

        private string defaultEventGuid;

        private string groupNameString;
        private string meetingName;
        private int roomNameIndex;
        private DateTime? startTime;
        private DateTime? endTime;
        private DateTime? startDate;
        private DateTime? endDate;


        public EventManagementPanel(ObservableCollection<Room> rooms)
        {
            InitializeComponent();

            cbRooms.DataContext = rooms;
            cbRooms.ItemsSource = rooms;

            Loaded += EventManagementPanel_Loaded;
            
        }

        void EventManagementPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (!loaded)
            {
                backgroundWorker = new BackgroundWorker();

                backgroundWorker.DoWork += backgroundWorker_DoWork;

                backgroundWorker.RunWorkerAsync();

                ClearFields();

                loaded = true;
            }

            e.Handled = true;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                

                //cbRooms.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                //                                                                         {
                //                                                                             var rooms = RoomProxy.GetRooms();

                //                                                                             cbRooms.DataContext = rooms;
                //                                                                             cbRooms.ItemsSource = rooms;
                //                                                                         })); 

                dgEvents.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                                                                          { 
                                                                                              
                                                                                              HospitalityEventDefinition eventDefinition = HospitalityEventDefinitionManager.GetDefaultEventDefinition();

                                                                                              defaultEventGuid = eventDefinition.EventDefinitionGUID;

                                                                                              var events = new ObservableCollection<HospitalityEvent>(HospitalityEventManager.GetEvents(eventDefinition.EventDefinitionGUID));

                                                                                              dgEvents.ItemsSource = events;

                                                                                              dgEvents.Visibility = Visibility.Visible;
                                                                                          }));
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void ClearFields()
        {
            tbGroupName.Text = string.Empty;
            tbMeetingName.Text = string.Empty;
            cbRooms.SelectedIndex = 0;
            dtStartTime.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            dtEndTime.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 0, 0);
            dtStartDate.Value = DateTime.Today.Date;
            dtEndDate.Value = DateTime.Today.Date;
        }

        private void dgEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HospitalityEvent hospitalityEvent = ((Microsoft.Windows.Controls.DataGrid)sender).SelectedItem as HospitalityEvent;
            if (hospitalityEvent != null)
            {
                int roomIndex = -1;
                int i = 0;
                foreach (Room room in cbRooms.Items)
                {
                    if(room.Name == hospitalityEvent.MeetingRoomName)
                        roomIndex = i;
                    i++;
                }

                tbGroupName.Text = groupNameString = hospitalityEvent.GroupName;
                tbMeetingName.Text = meetingName = hospitalityEvent.MeetingName;
                cbRooms.SelectedIndex = roomNameIndex = roomIndex;
                dtEndTime.Value = endTime = hospitalityEvent.EndTime;
                dtStartTime.Value = startTime = hospitalityEvent.StartTime;
                dtStartDate.Value = startDate = hospitalityEvent.StartTime;
                dtEndDate.Value = endDate = hospitalityEvent.EndTime;
            }
            e.Handled = true;
        }

        private void AddEventExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbGroupName.Text) && (!String.IsNullOrEmpty(tbMeetingName.Text)) && cbRooms.SelectedIndex != -1 && dtStartTime.Value != null && dtEndTime.Value != null)
            {
                HospitalityEvent hospitalityEvent = new HospitalityEvent();

                hospitalityEvent.GroupName = tbGroupName.Text;
                hospitalityEvent.MeetingName = tbMeetingName.Text;
                hospitalityEvent.MeetingRoomName = ((Room)cbRooms.SelectedItem).Name;
                hospitalityEvent.StartTime = new DateTime(dtStartDate.Value.Value.Year, dtStartDate.Value.Value.Month, dtStartDate.Value.Value.Day, dtStartTime.Value.Value.Hour, dtStartTime.Value.Value.Minute, 0);
                hospitalityEvent.EndTime = new DateTime(dtEndDate.Value.Value.Year, dtEndDate.Value.Value.Month, dtEndDate.Value.Value.Day, dtEndTime.Value.Value.Hour, dtEndTime.Value.Value.Minute, 0);
                hospitalityEvent.EventGUID = Guid.NewGuid().ToString();

                hospitalityEvent.EventDefinitionGUID = defaultEventGuid; //HospitalityEventDefinitionManager.GetDefaultEventDefinition().EventDefinitionGUID;

                try
                {
                    HospitalityEventManager.AddEvent(hospitalityEvent);

                    var events = dgEvents.ItemsSource as ObservableCollection<HospitalityEvent>;
                    if (events != null) events.Add(hospitalityEvent);

                    ClearFields();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            e.Handled = true;
        }

        private void AddEventRoomCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (!String.IsNullOrEmpty(tbGroupName.Text) && (!String.IsNullOrEmpty(tbMeetingName.Text)) &&
                            cbRooms.SelectedIndex != -1 && dtStartTime.Value != null && dtEndTime.Value != null
                             && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)));
        }

        private void UpdateEventExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HospitalityEvent hospitalityEvent = dgEvents.SelectedItem as HospitalityEvent;
            if (hospitalityEvent != null)
            {
                hospitalityEvent.GroupName = tbGroupName.Text;
                hospitalityEvent.MeetingName = tbMeetingName.Text;
                if(cbRooms.SelectedIndex > 0)
                    hospitalityEvent.MeetingRoomName = ((Room)cbRooms.SelectedItem).Name;
                hospitalityEvent.StartTime = new DateTime(dtStartDate.Value.Value.Year, dtStartDate.Value.Value.Month, dtStartDate.Value.Value.Day, dtStartTime.Value.Value.Hour, dtStartTime.Value.Value.Minute, 0);
                hospitalityEvent.EndTime = new DateTime(dtEndDate.Value.Value.Year, dtEndDate.Value.Value.Month, dtEndDate.Value.Value.Day, dtEndTime.Value.Value.Hour, dtEndTime.Value.Value.Minute, 0);

                HospitalityEventManager.UpdateEvent(hospitalityEvent);
            }
            e.Handled = true;
        }

        private void UpdateEventCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (!String.IsNullOrEmpty(tbGroupName.Text) && (!String.IsNullOrEmpty(tbMeetingName.Text)) && cbRooms.SelectedIndex != -1 && dtStartTime.Value != null && dtEndTime.Value != null && EventChanged() && dgEvents.SelectedIndex > -1
                             && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)));
        }

        private bool EventChanged()
        {
            if(tbGroupName.Text != groupNameString)
                return true;
            if(tbMeetingName.Text != meetingName)
                return true;
            if(cbRooms.SelectedIndex != roomNameIndex)
                return true;
            if(dtEndTime.Value != endTime)
                return true;
            if(dtStartTime.Value != startTime)
                return true;
            if (dtStartDate.Value != startDate)
                return true;
            if (dtEndDate.Value != endDate)
                return true;

            return false;
        }

        private void DeleteEventExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var events =
                dgEvents.ItemsSource as ObservableCollection<HospitalityEvent>;

            int n = dgEvents.SelectedItems.Count;
            for (int i = 0; i < n; i++)
            {
                HospitalityEventManager.DeleteEvent(((HospitalityEvent)dgEvents.SelectedItems[0]).EventGUID);
                events.Remove((HospitalityEvent)dgEvents.SelectedItems[0]);
            }

            ClearFields();

            e.Handled = true;
        }

        private void DeleteEventCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        }

        private void ClearEventsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private void ClearEventsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager));
        }

        private void RefreshEventsExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();

            ClearFields();
        }

        private void RefreshEventsCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
