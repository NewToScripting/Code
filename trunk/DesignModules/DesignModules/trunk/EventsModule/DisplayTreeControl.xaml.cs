using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Common.TreeViewModel;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for DisplayTreeControl.xaml
    /// </summary>
    public partial class DisplayTreeControl
    {
        public DisplayTreeControl()
        {
            InitializeComponent();
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

        private void AdminDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AdminTree != null)
            {
                DisplayViewModel displaySelected = (DisplayViewModel)AdminTree.SelectedItem;

                DragDrop.DoDragDrop(AdminTree, displaySelected, DragDropEffects.Copy);
            }

            e.Handled = true;
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
    }
}
