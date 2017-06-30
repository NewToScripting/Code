using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
        private readonly List<string> _origDisplayRoomList = new List<string>();

        public AddRooms(string title, string displayGuid)
        {
            InitializeComponent();

            DisplayGuid = displayGuid;

            DisplayRoomList = new ObservableCollection<Room>(Inspire.Events.Proxy.RoomProxy.GetRoomsForDisplay(displayGuid));

            foreach (var room in DisplayRoomList)
                _origDisplayRoomList.Add(room.Guid);

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

        //private void RoomItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (lbRoomList.SelectedItems != null)
        //    {
        //        dragDisplayRoom = false;
        //        dragRoom = true;

        //        var roomsSelected = lbRoomList.SelectedItems;

        //        DragDrop.DoDragDrop(lbRoomList, roomsSelected, DragDropEffects.Copy);
        //    }
        //    e.Handled = true;
        //}

        //private void lbDisplayRoomList_Drop(object sender, DragEventArgs e)
        //{
        //    if (dragRoom)
        //    {
        //        var rooms = (IList<Room>)e.Data.GetData(typeof(IList<Room>));
        //        foreach (var room in rooms)
        //        {
        //            DisplayRoomList.Add(room);
        //            RoomList.Remove(room);
        //        }
                
        //    }
        //    e.Handled = true;
        //}

        //private void DisplayRoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (lbDisplayRoomList.SelectedItems != null)
        //    {
        //        dragDisplayRoom = true;
        //        dragRoom = false;

        //        var roomsSelected = lbRoomList.SelectedItems;

        //        DragDrop.DoDragDrop(lbDisplayRoomList, roomsSelected, DragDropEffects.Copy);
        //    }
        //    e.Handled = true;
        //}

        //private void lbRoomList_Drop(object sender, DragEventArgs e)
        //{
        //    if (dragDisplayRoom)
        //    {
        //        var rooms = (IList<Room>)e.Data.GetData(typeof(IList));

        //        foreach (var room in rooms)
        //        {
        //            RoomList.Add(room);
        //            DisplayRoomList.Remove(room);
        //        }
        //    }
        //    e.Handled = true;
        //}

        //private void RoomItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Room roomSelected = (Room)((TextBlock)sender).DataContext;
        //    lbRoomList.SelectedItem = roomSelected;
        //}

        //private void DisplayRoom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Room roomSelected = (Room)((TextBlock)sender).DataContext;
        //    lbDisplayRoomList.SelectedItem = roomSelected;
        //}

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var displaysToAdd = DisplayRoomList.Where(rm => !_origDisplayRoomList.Contains(rm.Guid));

            var displaysToRemove = RoomList.Where(rrm => _origDisplayRoomList.Contains(rrm.Guid));

            foreach (Room room in displaysToAdd)
                RoomProxy.AddRoomToDisplayAssn(room.Guid, DisplayGuid);

            foreach (var room in displaysToRemove)
                RoomProxy.DeleteRoomToDisplayAssn(room.Guid, DisplayGuid);

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void IncludeRoom_Click(object sender, RoutedEventArgs e)
        {
            if (lbRoomList.SelectedItems != null)
            {
                dragDisplayRoom = false;
                dragRoom = true;

                var roomsSelected = lbRoomList.SelectedItems;

                for (int index = roomsSelected.Count - 1; index >= 0; index--)
                {
                    var room = roomsSelected[index] as Room;
                    DisplayRoomList.Add(room);
                    RoomList.Remove(room);
                }
            }
            e.Handled = true;
        }

        private void IncludeAllRooms_Click(object sender, RoutedEventArgs e)
        {
            if (lbRoomList.Items != null)
                if(lbRoomList.Items.Count > 0)
                    for (int index = lbRoomList.Items.Count - 1; index >= 0; index--)
                    {
                        var room = lbRoomList.Items[index] as Room;
                        RoomList.Remove(room);
                        DisplayRoomList.Add(room);
                    }
        }

        private void ExcludeRoom_Click(object sender, RoutedEventArgs e)
        {
            if (lbDisplayRoomList.SelectedItems != null)
            {
                dragDisplayRoom = true;
                dragRoom = false;

                var roomsSelected = lbDisplayRoomList.SelectedItems;

                for (int index = roomsSelected.Count - 1; index >= 0; index--)
                {
                    Room room = roomsSelected[index] as Room;
                    RoomList.Add(room);
                    DisplayRoomList.Remove(room);
                }
            }
            e.Handled = true;
        }

        private void ExcludeAllRooms_Click(object sender, RoutedEventArgs e)
        {
            if (lbDisplayRoomList.Items != null)
                if(lbDisplayRoomList.Items.Count > 0)
                    for (int index = lbDisplayRoomList.Items.Count - 1; index >= 0; index--)
                    {
                        var room = lbDisplayRoomList.Items[index] as Room;
                        DisplayRoomList.Remove(room);
                        RoomList.Add(room);
                    }
        }
    }
}
