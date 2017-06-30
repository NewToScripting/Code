using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using EventsModule.Dialogs;
using Infragistics.Windows.DataPresenter;
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

        private ObservableCollection<DirectionalImage> directionalImages;

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
            lbFieldContracts.ItemsSource = currentEventSource.Fields;
        }

        void ConfigurationWindow_Loaded(object sender, EventArgs e)
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

                lbAliasList.ItemsSource = roomAliases;

                directionalImages = new ObservableCollection<DirectionalImage>();

                lbRoomList.ItemsSource = rooms;

                List<DirectionalImage> directionalImageList = DirectionProxy.GetDirectionalImages();

                foreach (var image in directionalImageList)
                {
                    directionalImages.Add(image);
                }

                lbDiectionalImages.ItemsSource = directionalImages;

                directions = new ObservableCollection<Direction>();

                DirectionsGrid.DataSource = directions;

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
                
                throw;
            }
        }

        private void lbRoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbRoomList.SelectedItem != null)
            {
                roomAliases = new ObservableCollection<Alias>(((Room)lbRoomList.SelectedItem).Aliases);
                lbAliasList.ItemsSource = roomAliases;
            }
        }

        private void btnAliasAdd(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.lblAddItem.Content = "Enter the name of the alias to add:";
            addItem.ShowDialog();
            {
                if (addItem.DialogResult == true)
                {
                    if (lbRoomList.SelectedItem != null && addItem.tbItemName.Text != "")
                    {
                        Room room = ((Room)lbRoomList.SelectedItem);
                        Alias alias = new Alias();
                        alias.Guid = Guid.NewGuid().ToString();
                        alias.RoomID = room.Guid;
                        alias.Value = addItem.tbItemName.Text;
                        room.Aliases.Add(alias);
                        AliaseProxy.AddAlias(alias);
                        roomAliases.Add(alias);
                    }
                }
            }
            e.Handled = true;
        }

        private void btnAliasRemove(object sender, RoutedEventArgs e)
        {
            if (lbRoomList.SelectedItem != null)
            {
                Room room = (Room)lbRoomList.SelectedItem;
                if (lbAliasList.SelectedItem != null)
                {
                    AliaseProxy.DeleteAlias(((Alias)lbAliasList.SelectedItem).Guid);
                    room.Aliases.Remove((Alias)lbAliasList.SelectedItem);
                    roomAliases.Remove((Alias)lbAliasList.SelectedItem);
                }
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

                    dispRooms = new ObservableCollection<Room>(RoomProxy.GetRoomsForDisplay(displaySelected.DisplayGUID));

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
            AddItem addItem = new AddItem();
            addItem.lblAddItem.Content = "Enter the name of the room to add:";
            addItem.ShowDialog();
            {
                if (addItem.DialogResult == true && addItem.tbItemName.Text != "")
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

        private void RoomRemove()
        {
            if (lbRoomList.SelectedItem != null)
            {
                Room room = (Room)lbRoomList.SelectedItem;
                rooms.Remove((Room)lbRoomList.SelectedItem);
                if (lbRoomList.SelectedItem == null && lbRoomList.Items.Count > 0)
                    lbRoomList.SelectedItem = lbRoomList.Items[0];
                if (lbRoomList.Items.Count < 1)
                    room.Aliases.Clear();
            }
        }

        private void AddDisplayRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayViewModel displaySelected = (DisplayViewModel)mapTreeControl.SelectedItem;
            if (displaySelected != null)
            {

                AddRooms addRooms = new AddRooms(displaySelected.DisplayName, displaySelected.DisplayGUID);
                addRooms.ShowDialog();

                if (addRooms.DialogResult == true)
                {
                    List<Room> displayRooms = RoomProxy.GetRoomsForDisplay(displaySelected.DisplayGUID);

                    if (dispRooms != null)
                        lbDisplayRooms.ItemsSource = displayRooms;
                }
            }
            else
            {
                //TODO: Show a dialog that tells the user to select a room, or show it on the form.
            }
            e.Handled = true;
        }

        private void AddDisplayRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RemoveDisplayRoomExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbDisplayRooms.SelectedItem != null && mapTreeControl.SelectedItem != null)
            {
                DisplayViewModel displaySelected = (DisplayViewModel)mapTreeControl.SelectedItem;
                Room dispRoom = (Room)lbDisplayRooms.SelectedItem;
                RoomProxy.DeleteRoomToDisplayAssn(dispRoom.Guid, displaySelected.DisplayGUID);
                dispRooms.Remove(dispRoom);
            }
            e.Handled = true;
        }

        private void RemoveDisplayRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RemoveRoomCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
            e.CanExecute = true;
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

                    directions = new ObservableCollection<Direction>(DirectionProxy.GetDirections(displaySelected.DisplayGUID));

                    if (directions != null)
                    {
                        DirectionsGrid.DataSource = directions;

                    }
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
            DirectionProxy.AddDirections(new List<Direction>((ObservableCollection<Direction>)DirectionsGrid.DataSource));
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

                    directions = new ObservableCollection<Direction>(DirectionProxy.GetDirections(displaySelected.DisplayGUID));

                    if (directions != null)
                        DirectionsGrid.DataSource = directions;

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
                DirectionalImage directionalImage = new DirectionalImage();
                directionalImage.Guid = Guid.NewGuid().ToString();
                directionalImage.FileExtention = Path.GetExtension(openFileDialogDirectionImage.FileName);
                directionalImage.WebPath = DirectionProxy.AddDirectionalImage(directionalImage, (byte[])ImageToByteConverter.Convert(image));
                directionalImages.Add(directionalImage);
            }
            e.Handled = true;
        }

        private void ShowDirectionalImageSelector(object sender, RoutedEventArgs e)
        {
            Direction directionalImage = (Direction)((DataRecord)((Button)sender).DataContext).DataItem;
            DirectionalImageSelector directionalImageSelector = new DirectionalImageSelector();
            directionalImageSelector.ShowDialog();
            if (directionalImageSelector.DialogResult == true)
            {
                directionalImage.DirectionImageWebPath = directionalImageSelector.ImageUrl;
                directionalImage.DirectionImageID = directionalImageSelector.ImageID;
                directionGridIsDirty = true;
            }
        }

        private void btnRemoveDirectionalImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirectionProxy.DeleteDirectionalImage((DirectionalImage)lbDiectionalImages.SelectedItem);
                directionalImages.Remove((DirectionalImage)lbDiectionalImages.SelectedItem);
            }
            catch (Exception)
            {
                {

                }
                throw;
            }
        }

        private void ClearDirectionalImage(object sender, RoutedEventArgs e)
        {
            try
            {
                Direction directionalImage = (Direction)((DataRecord)((MenuItem)sender).DataContext).DataItem;
                directionalImage.DirectionImageWebPath = null;
                directionalImage.DirectionImageID = "";
            }
            catch (Exception)
            {
                {

                }
                throw;
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

        private void Click_SaveDataSource(object sender, RoutedEventArgs e)
        {

        }

        private void Click_CancelDataSource(object sender, RoutedEventArgs e)
        {

        }

        private void btnEventSourceBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if(!String.IsNullOrEmpty(openFileDialog.FileName))
            {
                tbEventFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnAddEventSource_Click(object sender, RoutedEventArgs e)
        {
            ConfigureEventSource configureEventSource = new ConfigureEventSource();
            configureEventSource.ShowDialog();
            if(configureEventSource.DialogResult == true)
            {
                foreach (ListBoxItem lbItem in configureEventSource.lbSelectedFields.Items)
                {
                    currentEventSource.Fields.Add(new FieldContract(lbItem.Content.ToString(),0,0,"String"));
                }
                cbDataSource.Items.Add(configureEventSource.tbDataSourceName.Text);
                cbDataSource.SelectedIndex = cbDataSource.Items.Count - 1;
            }
            lbFieldContracts.ItemsSource = currentEventSource.Fields;
        }

        private void btnRemoveEventSource_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModifyFields_Click(object sender, RoutedEventArgs e)
        {
          //  lbFieldContracts.Items.Add(new FieldContract("Field " + (lbFieldContracts.Items.Count + 1), 0, 0, "String"));
        }

        private void btnPreviewData_Click(object sender, RoutedEventArgs e)
        {
            List<BagOfNuts> eventData = EventSource.GetEventData(@"S:\Share\Data\Fixed\Events.NSS", @"S:\Share\Data\Fixed\FileMap.xml");

            EventDataGrid.DataSource = eventData;

        }
    }
}
