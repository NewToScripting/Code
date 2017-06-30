using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using EventEntry;
using EventsModule.Dialogs;
using Inspire;
using Inspire.Common.TreeViewModel;
using Inspire.Events.Proxy;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;
using Microsoft.Win32;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationControl : IWeakEventListener
    {

        private ObservableCollection<EventImage> directionalImages;

        private ObservableCollection<Room> rooms;

        private ObservableCollection<Direction> directions;

        private ObservableCollection<Alias> roomAliases;

        private ObservableCollection<Room> dispRooms;

        private EventSource currentEventSource;

        private List<EventSource> eventSources;

        private bool directionGridIsDirty = false;

        public ConfigurationControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
            currentEventSource = new EventSource();
            //lbFieldContracts.ItemsSource = currentEventSource.Fields;
        }

        private bool _isLoaded;

        void ConfigurationWindow_Loaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                try
                {
                    rooms = new ObservableCollection<Room>();

                    List<Room> roomList = RoomProxy.GetRooms();

                    foreach (var room in roomList)
                    {
                        rooms.Add(room);
                    }

                    roomAliases = new ObservableCollection<Alias>();

                    tiEventEntry.Content = new EventManagementPanel(rooms);

                    lbAliasList.ItemsSource = roomAliases;

                    directionalImages = new ObservableCollection<EventImage>();

                    lbRoomList.ItemsSource = rooms;

                    List<EventImage> directionalImageList = EventImagesProxy.GetEventImages(EventImageType.Directional);

                    foreach (var image in directionalImageList)
                    {
                        directionalImages.Add(image);
                    }

                    lbDiectionalImages.ItemsSource = directionalImages;

                    directions = new ObservableCollection<Direction>();

                    DirectionsGrid.ItemsSource = directions;

                    // lbAvailableFields.ItemsSource = EventSource.GetAllFieldContracts();

                    DisplayProperty[] roomDisplayProperties = DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                    CorporationViewModel roomViewModel = new CorporationViewModel(roomDisplayProperties);
                    mapTreeControl.DataContext = roomViewModel;

                    DisplayProperty[] directionDisplayProperties =
                        DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                    CorporationViewModel directionViewModel = new CorporationViewModel(directionDisplayProperties);
                    directionTreeControl.DataContext = directionViewModel;
                }
                catch (Exception)
                {

                    // throw;
                }
                _isLoaded = true;
            }
        }

        private void lbRoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbRoomList.SelectedItem != null)
            {
                roomAliases = new ObservableCollection<Alias>(((Room)lbRoomList.SelectedItem).Aliases);
                lbAliasList.ItemsSource = roomAliases;
            }
            else
                roomAliases.Clear();
        }

        private void btnAliasAdd(object sender, RoutedEventArgs e)
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)))
            {
                AddItem addItem = new AddItem("Add Room Alias", "Enter the name of the alias to add:");
                addItem.ShowDialog();
                if (addItem.DialogResult == true)
                {
                    if (lbRoomList.SelectedItem != null && addItem.tbItemName.Text != string.Empty)
                    {
                        Room room = ((Room) lbRoomList.SelectedItem);
                        Alias alias = new Alias();
                        alias.Guid = Guid.NewGuid().ToString();
                        alias.RoomID = room.Guid;
                        alias.Value = addItem.tbItemName.Text;
                        room.Aliases.Add(alias);
                        RoomAliaseProxy.AddAlias(alias);
                        roomAliases.Add(alias);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must be a Content Manager or Administrator to Add/Remove Groups.");
            }
            e.Handled = true;
        }

        private void btnAliasRemove(object sender, RoutedEventArgs e)
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)))
            {
                if (lbRoomList.SelectedItem != null)
                {
                    Room room = (Room) lbRoomList.SelectedItem;
                    if (lbAliasList.SelectedItem != null)
                    {
                        int selectedIndex = lbAliasList.SelectedIndex;
                        RoomAliaseProxy.DeleteAlias(((Alias) lbAliasList.SelectedItem).Guid);
                        room.Aliases.Remove((Alias) lbAliasList.SelectedItem);
                        roomAliases.Remove((Alias) lbAliasList.SelectedItem);
                        if ((selectedIndex - 1) > -1)
                            lbAliasList.SelectedIndex = selectedIndex - 1;
                        else
                            lbAliasList.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must be a Content Manager or Administrator to Add/Remove Groups.");
            }
            e.Handled = true;
        }

        private void AdminDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mapTreeControl != null)
            {
                try
                {
                    lbDisplayRooms.ItemsSource = null;
                    DisplayViewModel displaySelected = (DisplayViewModel)mapTreeControl.SelectedItem;

                    dispRooms = new ObservableCollection<Room>(RoomProxy.GetRoomsForDisplay(displaySelected.GUID));

                    if (dispRooms != null)
                        lbDisplayRooms.ItemsSource = dispRooms;

                }
                catch (Exception)
                {

                    throw;
                }


            }

            e.Handled = true;
        }

        private void OnRightMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var treeViewItemText = e.Source as FrameworkElement;

            if (treeViewItemText != null)
            {
                StackPanel treeViewStackPanel = treeViewItemText.Parent as StackPanel;

                if (treeViewStackPanel == null)
                {
                    Grid grid = treeViewItemText.Parent as Grid;
                    if (grid != null) treeViewStackPanel = grid.Parent as StackPanel;
                }
                if (treeViewStackPanel != null)
                {
                    ContentPresenter treeViewContentPres = treeViewStackPanel.TemplatedParent as ContentPresenter;
                    if (treeViewContentPres != null)
                    {
                        Grid treeViewContentGrid = treeViewContentPres.Parent as Grid;
                        if (treeViewContentGrid != null)
                        {
                            Border treeViewItemBorder = treeViewContentGrid.Parent as Border;
                            if (treeViewItemBorder != null)
                            {
                                Grid treeViewItemGrid2 = treeViewItemBorder.Parent as Grid;


                                if (treeViewItemGrid2 != null)
                                {
                                    TreeViewItem treeViewItem = treeViewItemGrid2.TemplatedParent as TreeViewItem;
                                    if (treeViewItem == null) return;

                                    treeViewItem.IsSelected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TreeItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItemText = e.Source as FrameworkElement;

            if (treeViewItemText != null)
            {
                StackPanel treeViewStackPanel = treeViewItemText.Parent as StackPanel;

                if (treeViewStackPanel == null)
                {
                    Grid grid = treeViewItemText.Parent as Grid;
                    if (grid != null) treeViewStackPanel = grid.Parent as StackPanel;
                }

                if (treeViewStackPanel != null)
                {
                    ContentPresenter treeViewContentPres = treeViewStackPanel.TemplatedParent as ContentPresenter;
                    if (treeViewContentPres != null)
                    {
                        Grid treeViewContentGrid = treeViewContentPres.Parent as Grid;
                        if (treeViewContentGrid != null)
                        {
                            Border treeViewItemBorder = treeViewContentGrid.Parent as Border;
                            if (treeViewItemBorder != null)
                            {
                                Grid treeViewItemGrid2 = treeViewItemBorder.Parent as Grid;


                                if (treeViewItemGrid2 != null)
                                {
                                    TreeViewItem treeViewItem = treeViewItemGrid2.TemplatedParent as TreeViewItem;
                                    if (treeViewItem == null) return;

                                    treeViewItem.IsSelected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RoomAdd()
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator)))
            {
                AddItem addItem = new AddItem();
                addItem.lblAddItem.Content = "Enter the name of the room to add:";
                addItem.ShowDialog();
                {
                    if (addItem.DialogResult == true && addItem.tbItemName.Text != string.Empty)
                    {
                        Room room = new Room();
                        room.Guid = Guid.NewGuid().ToString();
                        room.Name = addItem.tbItemName.Text;
                        room.Aliases = new List<Alias>();
                        rooms.Add(room);
                        RoomProxy.AddRoom(room);
                    }
                }
            }
            else
            {
                MessageBox.Show("Only Administrators can add or remove rooms.");  
            }
        }

        private void RoomRemove()
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator)))
            {
                if (lbRoomList.SelectedItem != null)
                {
                    Room room = (Room) lbRoomList.SelectedItem;
                    rooms.Remove((Room) lbRoomList.SelectedItem);
                    RoomProxy.DeleteRoom(room.Guid);
                    if (lbRoomList.SelectedItem == null && lbRoomList.Items.Count > 0)
                        lbRoomList.SelectedItem = lbRoomList.Items[0];
                    if (lbRoomList.Items.Count < 1)
                        room.Aliases.Clear();
                }
            }
            else
            {
                MessageBox.Show("Only Administrators can add or remove rooms.");
            }
        }

        private void AddDisplayRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayViewModel displaySelected = (DisplayViewModel)mapTreeControl.SelectedItem;
            if (displaySelected != null)
            {

                AddRooms addRooms = new AddRooms(displaySelected.DisplayName, displaySelected.GUID);
                addRooms.ShowDialog();

                if (addRooms.DialogResult == true)
                {
                    List<Room> displayRooms = RoomProxy.GetRoomsForDisplay(displaySelected.GUID);

                    if (dispRooms != null)
                        lbDisplayRooms.ItemsSource = displayRooms;
                }
            }
            else
            {
                //TODO: Show a dialog that tells the user to select a room, or show it on the form.
                MessageBox.Show("Please select a room.");
            }
            e.Handled = true;
        }

        private void AddDisplayRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (mapTreeControl.SelectedItem is DisplayViewModel && (User.UserPermision.Contains(PermissionTypes.Administrator)));
        }

        private void RemoveDisplayRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbDisplayRooms.SelectedItems != null && mapTreeControl.SelectedItem != null)
            {
                DisplayViewModel displaySelected = (DisplayViewModel)mapTreeControl.SelectedItem;
                var dRooms = lbDisplayRooms.SelectedItems;
                for (int index = dRooms.Count - 1; index >= 0; index--)
                {
                    Room dispRoom = dRooms[index] as Room;
                    RoomProxy.DeleteRoomToDisplayAssn(dispRoom.Guid, displaySelected.GUID);
                    dispRooms.Remove(dispRoom);
                }
            }
            e.Handled = true;
        }

        private void RemoveDisplayRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (mapTreeControl.SelectedItem is DisplayViewModel && (User.UserPermision.Contains(PermissionTypes.Administrator)));
        }

        private void RemoveRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator));
        }

        private void RemoveRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RoomRemove();
            e.Handled = true;
        }

        private void AddRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RoomAdd();
            e.Handled = true;
        }

        private void AddRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator));
        }

        private void directionTree_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (directionTreeControl != null)
            {
                if (directions != null)
                {
                    directions.Clear();
                    directions = null;
                }
                try
                {
                    lbDisplayRooms.ItemsSource = null;
                    DisplayViewModel displaySelected = (DisplayViewModel)directionTreeControl.SelectedItem;

                    DirectionsGrid.ItemsSource = directions = new ObservableCollection<Direction>(DirectionProxy.GetDirections(displaySelected.GUID));

                }
                catch (Exception)
                {

                    throw;
                }
            }
            // e.Handled = true;
        }

        private void btnDirectionSave_Click(object sender, RoutedEventArgs e)
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator)))
            {
                DirectionProxy.AddDirections(new List<Direction>((ObservableCollection<Direction>) DirectionsGrid.ItemsSource));
            }
            else
            {
                MessageBox.Show("Only Administrators can save directions.");
            }
            e.Handled = true;
        }

        private void btnDirectionCancel_Click(object sender, RoutedEventArgs e)
        {
            if (directionTreeControl != null)
            {
                try
                {
                    lbDisplayRooms.ItemsSource = null;
                    DisplayViewModel displaySelected = (DisplayViewModel)directionTreeControl.SelectedItem;

                    directions = new ObservableCollection<Direction>(DirectionProxy.GetDirections(displaySelected.GUID));

                    if (directions != null)
                        DirectionsGrid.ItemsSource = directions;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            e.Handled = true;
        }

        private void btnAddDirectionalImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialogDirectionImage = new OpenFileDialog();
            openFileDialogDirectionImage.Multiselect = false;
            openFileDialogDirectionImage.Filter = "Images (*.jpg, *.png, *.gif, *.bmp, *.jpeg) |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialogDirectionImage.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialogDirectionImage.FileName))
            {
                Image image = new Image();
                BitmapFrame bitmapFrame = BitmapFrame.Create(new Uri(openFileDialogDirectionImage.FileName, UriKind.RelativeOrAbsolute));
                image.Source = bitmapFrame;
                EventImage directionalImage = new EventImage();
                directionalImage.Guid = Guid.NewGuid().ToString();
                directionalImage.FileExtention = Path.GetExtension(openFileDialogDirectionImage.FileName);
                directionalImage.Type = EventImageType.Directional;
                directionalImage.WebPath = EventImagesProxy.AddEventImage(directionalImage, (byte[])ImageToByteConverter.Convert(image));
                directionalImages.Add(directionalImage);
            }
            e.Handled = true;
        }

        private void ShowDirectionalImageSelector(object sender, RoutedEventArgs e)
        {

            if ((User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentManager)))
            {
                if (((Button) sender).DataContext.GetType() == typeof (Direction))
                {
                    Direction directionalImage = (Direction) ((Button) sender).DataContext;
                    DirectionalImageSelector directionalImageSelector = new DirectionalImageSelector();
                    directionalImageSelector.ShowDialog();
                    if (directionalImageSelector.DialogResult == true)
                    {
                        directionalImage.DirectionImageWebPath = directionalImageSelector.ImageUrl;
                        directionalImage.DirectionImageID = directionalImageSelector.ImageID;
                        directionGridIsDirty = true;
                        DirectionsGrid.ItemsSource = directions;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must be a Content Manager or Administrator to Add/Remove Directional Images.");
            }
        }

        private void btnRemoveDirectionalImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventImagesProxy.DeleteEventImage((EventImage)lbDiectionalImages.SelectedItem);
                directionalImages.Remove((EventImage)lbDiectionalImages.SelectedItem);
            }
            catch (Exception)
            {
                {

                }
                //throw;
            }
        }

        private void ClearDirectionalImage(object sender, RoutedEventArgs e)
        {
            try
            {
                Direction directionalImage = (Direction)((MenuItem)sender).DataContext;
                directionalImage.DirectionImageWebPath = null;
                directionalImage.DirectionImageID = string.Empty;
            }
            catch (Exception)
            {
                {

                }
               // throw;
            }
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ConfigurationWindow_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
