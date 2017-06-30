using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Client.ConfigurationWindow.Dialogs;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Common.Dialogs;
using Inspire.Common.TreeViewModel;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.ConfigurationWindow.AdminTreeView
{
    /// <summary>
    /// Interaction logic for AdminTreeControl.xaml
    /// </summary>
    public partial class AdminTreeControl : IWeakEventListener
    {
        public AdminTreeControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        void AdminTreeControl_Loaded(object sender, EventArgs e)
        {
            if (!Designer.DesignWindow.IsDesignerMode)
            {
                RefreshTree();
            }
        }

        private void NewDisplayExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayGroupViewModel treeViewItemModel = (DisplayGroupViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayForm disp = new DisplayForm(treeViewItemModel.DisplayGroupGUID);
                    disp.ShowDialog();
                    if (disp.DialogResult == true)
                    {
                        DisplayManager.AddDisplay(disp.TempDisplay);
                        if (!treeViewItemModel.HasDummyChild)
                        {
                            DisplayViewModel displayViewModel = new DisplayViewModel(disp.TempDisplay, treeViewItemModel);
                            treeViewItemModel.Children.Add(displayViewModel);
                        }
                        disp.ClearForm();
                    }
                }
            }
            e.Handled = true;
        }

        private void EditDisplayExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayViewModel treeViewItemModel = (DisplayViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayForm displayForm = new DisplayForm(DisplayManager.GetSingleDisplay(treeViewItemModel.GUID));
                    displayForm.ShowDialog();
                    if (displayForm.DialogResult == true)
                    {
                        displayForm.TempDisplay.GUID = treeViewItemModel.GUID;
                        DisplayManager.UpdateDisplay(displayForm.TempDisplay);
                        // Delete from Tree
                        DisplayGroupViewModel displayGroupViewModel = treeViewItemModel.Parent as DisplayGroupViewModel;
                        if (displayGroupViewModel != null) displayGroupViewModel.Children.Remove(treeViewItemModel);
                        // Add to Tree
                        DisplayViewModel displayViewModel = new DisplayViewModel(displayForm.TempDisplay, displayGroupViewModel);
                        if (displayGroupViewModel != null) displayGroupViewModel.Children.Add(displayViewModel);
                        displayForm.ClearForm();
                    }
                }
            }
            e.Handled = true;
        }

        private void DeleteDisplayExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayViewModel treeViewItemModel = (DisplayViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    CommonDialog commonDialog = new CommonDialog("Delete Display?", "Are you sure you like to delete the display?");
                    commonDialog.ShowDialog();
                    if (commonDialog.DialogResult == true)
                    {
                        DisplayManager.DeleteDisplay(treeViewItemModel.GUID);
                        DisplayGroupViewModel displayGroupViewModel = treeViewItemModel.Parent as DisplayGroupViewModel;
                        if (displayGroupViewModel != null) displayGroupViewModel.Children.Remove(treeViewItemModel);
                    }
                }
            }
            e.Handled = true;
        }

        private void NewDisplayCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "DisplayGroupViewModel")
                e.CanExecute = true;
        }

        private void EditDisplayCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "DisplayViewModel")
                e.CanExecute = true;
        }

        private void DeleteDisplayCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "DisplayViewModel")
                e.CanExecute = true;
        }


        private void NewPropertyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayPropertyForm propertyForm = new DisplayPropertyForm();
            propertyForm.ShowDialog();
            if (propertyForm.DialogResult == true)
            {
                DisplayProperty displayPropterty = new DisplayProperty(propertyForm.PropertyName);
                DisplayPropertyManager.AddDisplayProperty(displayPropterty);

                RefreshTree();
            }
            e.Handled = true;
        }

        private void EditPropertyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                PropertyViewModel treeViewItemModel = (PropertyViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayPropertyForm propertyForm = new DisplayPropertyForm(treeViewItemModel);
                    propertyForm.ShowDialog();
                    if (propertyForm.DialogResult == true)
                    {
                        DisplayProperty displayProperty = new DisplayProperty(propertyForm.PropertyName);
                        displayProperty.GUID = treeViewItemModel.PropertyGUID;
                        displayProperty.PropertyName = propertyForm.PropertyName;
                        displayProperty.PropertyDescription = propertyForm.PropertyDescription;
                        DisplayPropertyManager.UpdateDisplayProperty(displayProperty);

                        RefreshTree();
                    }
                }
            }
            e.Handled = true;
        }

        private void DeletePropertyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //Todo: add Dialog to confirm delete
            if (AdminTree != null)
            {
                PropertyViewModel treeViewItemModel = (PropertyViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayPropertyManager.DeleteDisplayProperty(treeViewItemModel.PropertyGUID);

                    RefreshTree();
                }
            }
            e.Handled = true;
        }

        private void NewPropertyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator))
                e.CanExecute = true;
        }

        private void EditPropertyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "PropertyViewModel")
                e.CanExecute = true;
        }

        private void DeletePropertyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "PropertyViewModel")
                e.CanExecute = true;
        }


        private void NewGroupExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: add description to New Group Dialog
            if (AdminTree != null)
            {
                PropertyViewModel treeViewItemModel = (PropertyViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayGroupForm groupForm = new DisplayGroupForm();
                    groupForm.ShowDialog();
                    if (groupForm.DialogResult == true)
                    {
                        DisplayGroup displayGroup = new DisplayGroup(groupForm.GroupName, groupForm.GroupDescription);
                        displayGroup.PropertyID = treeViewItemModel.PropertyGUID;
                        DisplayGroupManager.AddDisplayGroup(displayGroup);
                        if (!treeViewItemModel.HasDummyChild)
                        {
                            DisplayGroupViewModel displayViewModel = new DisplayGroupViewModel(displayGroup, treeViewItemModel);
                            treeViewItemModel.Children.Add(displayViewModel);
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void EditGroupExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayGroupViewModel treeViewItemModel = (DisplayGroupViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayGroupForm groupForm = new DisplayGroupForm(treeViewItemModel);
                    groupForm.ShowDialog();
                    if (groupForm.DialogResult == true)
                    {
                        DisplayGroup displayGroup = new DisplayGroup(groupForm.GroupName, groupForm.GroupDescription);
                        displayGroup.GUID = treeViewItemModel.DisplayGroupGUID;
                        displayGroup.GroupName = groupForm.GroupName;
                        displayGroup.GroupDescription = groupForm.GroupDescription;
                        DisplayGroupManager.UpdateDisplayGroup(displayGroup);
                        displayGroup.PropertyID = ((PropertyViewModel)treeViewItemModel.Parent).PropertyGUID;

                        PropertyViewModel propertyViewModel = treeViewItemModel.Parent as PropertyViewModel;
                        if (propertyViewModel != null)
                        {
                            propertyViewModel.Children.Remove(treeViewItemModel);

                            DisplayGroupViewModel displayViewModel = new DisplayGroupViewModel(displayGroup,
                                                                                               (PropertyViewModel)
                                                                                               treeViewItemModel.Parent);
                            propertyViewModel.Children.Add(displayViewModel);
                        }

                    }
                }
            }
            e.Handled = true;
        }

        private void DeleteGroupExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayGroupViewModel treeViewItemModel = (DisplayGroupViewModel)AdminTree.SelectedItem;
                if (treeViewItemModel != null)
                {
                    DisplayGroupManager.DeleteDisplayGroup(treeViewItemModel.DisplayGroupGUID);
                    PropertyViewModel propertyViewModel = treeViewItemModel.Parent as PropertyViewModel;
                    if (propertyViewModel != null) propertyViewModel.Children.Remove(treeViewItemModel);
                }
            }
            e.Handled = true;
        }

        private void NewGroupCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "PropertyViewModel")
                e.CanExecute = true;
        }

        private void EditGroupCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "DisplayGroupViewModel")
                e.CanExecute = true;
        }

        private void DeleteGroupCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && AdminTree.SelectedItem != null && AdminTree.SelectedItem.GetType().Name == "DisplayGroupViewModel")
                e.CanExecute = true;
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
                                    Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AdminDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayViewModel displaySelected = (DisplayViewModel)AdminTree.SelectedItem;

                DragDrop.DoDragDrop(AdminTree, displaySelected, DragDropEffects.Copy);
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
                                    Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RefreshTree()
        {
            try
            {
                DisplayProperty[] displayProperties = DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                CorporationViewModel viewModel = new CorporationViewModel(displayProperties);
                DataContext = viewModel;
            }
            catch (Exception)
            {
                // Check for database to be off line, also handle adding properties because an exception is thrown there
                //MessageBox.Show("Loading the AdminTree Failed." + ex);
            }
        }

        private void UserControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(AdminTree.Items.Count < 1)
            {
                DisplayPropertyForm propertyForm = new DisplayPropertyForm();
                propertyForm.ShowDialog();
                if (propertyForm.DialogResult == true)
                {
                    DisplayProperty displayPropterty = new DisplayProperty(propertyForm.PropertyName);
                    DisplayPropertyManager.AddDisplayProperty(displayPropterty);

                    DisplayProperty[] displayProperties = DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                    CorporationViewModel viewModel = new CorporationViewModel(displayProperties);
                    DataContext = viewModel;
                }
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                AdminTreeControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void RefreshAdminDisplaysCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(AdminTree != null)
            {
                e.CanExecute = true;
            }
        }

        private void RefreshAdminDisplaysExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RefreshTree();
        }
    }
}
