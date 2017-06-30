using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using EventsModule.Dialogs;
using Inspire;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;
using ComboBox=System.Windows.Controls.ComboBox;
using CommonDialog=Inspire.Common.Dialogs.CommonDialog;

namespace EventsModule
{

    /// <summary>
    /// Interaction logic for GroupIconPanel.xaml
    /// </summary>
    public partial class GroupIconPanel : IWeakEventListener
    {

        private ObservableCollection<Group> _groups;

        public GroupIconPanel()
        {
            InitializeComponent();

            LoadedEventManager.AddListener(this, this);
        }

        private bool _isLoaded;

        void GroupIconPanelLoaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                try
                {
                    _groups = new ObservableCollection<Group>(GroupProxy.GetGroups());

                    GroupsGrid.ItemsSource = _groups;

                }
                catch (Exception)
                {
                    var commonDialog = new CommonDialog("Error Loading Groups",
                                                        "There was an error loading the groups / group images. Try restarting the application. If the problem persists contact technical support.");
                    commonDialog.ShowDialog();
                }
                _isLoaded = true;
            }
        }

        private void btnAddGroupAlias_Click(object sender, RoutedEventArgs e)
        {
            var addItemDialog = new AddItem("Add Group Alias", "Enter an Alias that the group is referenced as in your Event Entry System:");
            addItemDialog.ShowDialog();
            if (addItemDialog.DialogResult == true)
            {
                var frameworkElement = (FrameworkElement) sender;
                var comboBox = frameworkElement.FindName("cbAliases") as ComboBox;
                var group = frameworkElement.DataContext as Group;
                if (group != null) 
                {
                    if (comboBox != null)
                    {
                        ObservableCollection<GroupAlias> groupAliases = comboBox.ItemsSource as ObservableCollection<GroupAlias>;

                        var groupAlias = new GroupAlias(addItemDialog.tbItemName.Text, group.Guid);

                        GroupAliaseProxy.AddAlias(groupAlias);

                        if (groupAliases != null)
                        {
                            groupAliases.Add(groupAlias);

                            group.Aliases = new List<GroupAlias>(groupAliases);
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void btnRemoveGroupAlias_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = (FrameworkElement) sender;
                var comboBox = frameworkElement.FindName("cbAliases") as ComboBox;
                var group = frameworkElement.DataContext as Group;
                if (group != null)
                {
                    if (comboBox != null)
                    {
                        var groupAliases = comboBox.ItemsSource as ObservableCollection<GroupAlias>;

                        if(groupAliases != null)
                        {
                            var groupAlias = comboBox.SelectedValue as GroupAlias;
                            if (groupAlias != null)
                            {
                                GroupAliaseProxy.DeleteAlias(groupAlias.Guid);
                                groupAliases.Remove(groupAlias);
                                if (comboBox.Items.Count > 0)
                                    comboBox.SelectedIndex = 0;
                            }
                        }
                    }
                }

            e.Handled = true;
        }

        private void btnGroupAdd(object sender, RoutedEventArgs e)
        {
            var addItemDialog = new AddItem("Add Group", "Enter the Group Name that will show on the Displays:");
            addItemDialog.ShowDialog();
            if (addItemDialog.DialogResult == true)
            {
                var group = new Group();

                group.Guid = Guid.NewGuid().ToString();
                group.Name = addItemDialog.tbItemName.Text;
                group.Aliases = new List<GroupAlias>();

                GroupProxy.AddGroup(group);
                _groups.Add(group);
            }
            e.Handled = true;
        }

        private void btnGroupRemove(object sender, RoutedEventArgs e)
        {
            if (GroupsGrid.SelectedItem != null)
            {
                var groups = GroupsGrid.ItemsSource as ObservableCollection<Group>;
                var group = GroupsGrid.SelectedValue as Group;
                if (group != null)
                {
                    GroupProxy.DeleteGroup(group.Guid);
                    if (groups != null) groups.Remove(group);
                }
            }

            e.Handled = true;
        }

        private void ShowGroupImageSelector(object sender, RoutedEventArgs e)
        {
            var group = ((FrameworkElement) sender).DataContext as Group;
            if (group != null)
            {
                OpenFileDialog openFileDialogDirectionImage = new OpenFileDialog();
                openFileDialogDirectionImage.Multiselect = false;
                openFileDialogDirectionImage.Filter =
                    "Images (*.jpg, *.png, *.gif, *.bmp, *.jpeg) |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialogDirectionImage.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialogDirectionImage.FileName))
                {
                    Image image = new Image();
                    if (File.Exists(openFileDialogDirectionImage.FileName))
                    {
                        BitmapFrame bitmapFrame =
                            BitmapFrame.Create(new Uri(openFileDialogDirectionImage.FileName, UriKind.RelativeOrAbsolute));
                        image.Source = bitmapFrame;

                        EventImage eventImage = new EventImage();
                        eventImage.Guid = Guid.NewGuid().ToString();
                        eventImage.Type = EventImageType.Group;
                        eventImage.FileExtention = Path.GetExtension(openFileDialogDirectionImage.FileName);
                        group.GroupImageWebPath = EventImagesProxy.AddEventImage(eventImage,
                                                                            (byte[]) ImageToByteConverter.Convert(image));
                        group.GroupImageID = eventImage.Guid;
                        GroupProxy.UpdateGroup(group);
                    }
                }
                ((FrameworkElement) sender).Focus();
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                GroupIconPanelLoaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void ClearGroupImage(object sender, RoutedEventArgs e)
        {
            var group = ((FrameworkElement)sender).DataContext as Group;
            if (group != null)
            {
                group.GroupImageWebPath = null;
                group.GroupImageID = null;
                GroupProxy.UpdateGroup(group);
            }
        }

        private void cbAliases_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<GroupAlias> groupAliases = new ObservableCollection<GroupAlias>(((Group) ((ComboBox) sender).DataContext).Aliases);

            ((ComboBox) sender).ItemsSource = groupAliases;
        }

    }
}
