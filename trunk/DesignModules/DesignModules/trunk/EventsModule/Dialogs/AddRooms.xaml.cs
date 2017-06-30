using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Events.Proxy;

namespace EventsModule.Dialogs
{
    /// <summary>
    /// Interaction logic for AddRooms.xaml
    /// </summary>
    public partial class AddRooms
    {
        public AddRooms()
        {
            InitializeComponent();
        }

        private ObservableCollection<Room> RoomList;
        private ObservableCollection<Room> DisplayRoomList;
        private string DisplayGuid;

        private bool dragRoom;
        private bool dragDisplayRoom;

        public AddRooms(string title, string displayGuid)
        {
            InitializeComponent();

            DisplayGuid = displayGuid;

            DisplayRoomList = new ObservableCollection<Room>(Inspire.Events.Proxy.RoomProxy.GetRoomsForDisplay(displayGuid));

            List<Room> NewRoomList = new List<Room>(Inspire.Events.Proxy.RoomProxy.GetRooms());

            RoomList = new ObservableCollection<Room>(NewRoomList);

            int i = 0;
            while (NewRoomList.Count > 0)
            {
                Room removeMe = new Room();

                foreach (var room in DisplayRoomList)
                {
                    if (NewRoomList[i].Guid == room.Guid)
                        removeMe = room;
                }
                if(removeMe.Guid != null)
                {
                    int removeIndex = 0;
                    foreach (var room in RoomList)
                    {
                        if (room.Guid == removeMe.Guid)
                            removeIndex = RoomList.IndexOf(room);
                    }
                    RoomList.RemoveAt(removeIndex);
                }
                NewRoomList.RemoveAt(i);
            }

            Title = title;
            lbRoomList.ItemsSource = RoomList;
            lbDisplayRoomList.ItemsSource = DisplayRoomList;
        }

        private void RoomItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (lbRoomList.SelectedItem != null)
            {
                dragDisplayRoom = false;
                dragRoom = true;

                Room roomSelected = (Room)lbRoomList.SelectedItem;

                DragDrop.DoDragDrop(lbRoomList, roomSelected, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void lbDisplayRoomList_Drop(object sender, DragEventArgs e)
        {
            if (dragRoom)
            {
                Room room = (Room) e.Data.GetData(typeof (Room));
                DisplayRoomList.Add(room);
                RoomList.Remove(room);
            }
            e.Handled = true;
        }

        private void DisplayRoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (lbDisplayRoomList.SelectedItem != null)
            {
                dragDisplayRoom = true;
                dragRoom = false;

                Room roomSelected = (Room)lbDisplayRoomList.SelectedItem;

                DragDrop.DoDragDrop(lbDisplayRoomList, roomSelected, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void lbRoomList_Drop(object sender, DragEventArgs e)
        {
            if (dragDisplayRoom)
            {
                Room room = (Room) e.Data.GetData(typeof (Room));
                RoomList.Add(room);
                DisplayRoomList.Remove(room);
            }
            e.Handled = true;
        }

        private void RoomItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Room roomSelected = (Room)((TextBlock)sender).DataContext;
            lbRoomList.SelectedItem = roomSelected;
        }

        private void DisplayRoom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Room roomSelected = (Room)((TextBlock)sender).DataContext;
            lbDisplayRoomList.SelectedItem = roomSelected;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(lbDisplayRoomList.Items.Count > 0)
            {
                foreach (Room room in lbDisplayRoomList.Items)
                {
                    Inspire.Events.Proxy.RoomProxy.AddRoomToDisplayAssn(room.Guid, DisplayGuid);
                }
            }
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
