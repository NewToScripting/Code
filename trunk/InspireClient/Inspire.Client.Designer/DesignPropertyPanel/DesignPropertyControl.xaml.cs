using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Inspire.Client.Designer.Commands;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DesignPropertyPanel
{
    /// <summary>
    /// Interaction logic for DesignPropertyControl.xaml
    /// </summary>
    public partial class DesignPropertyControl
    {

        private DragCanvas.DragCanvas _dragCanvas;

        public DesignPropertyControl()
        {
            InitializeComponent();
        }


        public void ReloadLayers(UserControl dragCanvas)
        {
            if (dragCanvas != null)
            {
                ObservableCollection<ContentControl> dataItems = ((DragCanvas.DragCanvas)dragCanvas).DataItems;
                _dragCanvas = ((DragCanvas.DragCanvas)dragCanvas);
                if (dataItems != null)
                    LayerPanel.ItemsSource = dataItems;

                if (_dragCanvas.selectionService.CurrentSelection != null && _dragCanvas.selectionService.CurrentSelection.Count > 0)
                    InspireApp.SelectedContext = _dragCanvas.selectionService.CurrentSelection[0];
                else
                    InspireApp.SelectedContext = null;

                SetDataContext();

                CanvasPropPanel.SetDataContext();
            }
        }

        public void ShowPropertyPanel(UserControl propertyControl)
        {
            PropertiesPane.IsSelected = true;
            PropertyTab.IsSelected = true;
            while (ControlPropertyGrid.Children.Count > 0)
            {
                UIElement disposable = ControlPropertyGrid.Children[0];
                ControlPropertyGrid.Children.Remove(ControlPropertyGrid.Children[0]);
                //if (disposable is IDisposable) ((IDisposable)disposable).Dispose();
            }

           ControlPropertyGrid.Children.Add(propertyControl);
            //propertyControl.BeginInit();
        }

        public void ClearPropertyPanel()
        {
            ControlPropertyGrid.Children.Clear();
        }

        private void Visible_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                var designContentControl = (ContentControl) image.DataContext;
                HideDesignItemCommand command = new HideDesignItemCommand(designContentControl);
                
                if(_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas) _dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        private void Hide_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                var designContentControl = (ContentControl)image.DataContext;
                ShowDesignItemCommand command = new ShowDesignItemCommand(designContentControl);

                if (_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas)_dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        private void Lock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                DesignControlHolder designContentControl = (DesignControlHolder)image.DataContext;
                UnlockDesignItemCommand command = new UnlockDesignItemCommand(designContentControl);

                if (_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas)_dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        private void UnLock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                DesignControlHolder designContentControl = (DesignControlHolder)image.DataContext;
                LockDesignItemCommand command = new LockDesignItemCommand(designContentControl);

                if (_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas)_dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        private void LayerTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.IsReadOnly = false;
            textBox.Background = Brushes.White;
            textBox.Height = 20;
            textBox.Foreground = Brushes.Black;
            textBox.BorderThickness = new Thickness(1);
            e.Handled = true;
        }

        private void LayerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.IsReadOnly = true;
            textBox.BorderThickness = new Thickness(0);
            textBox.Height = 14.7;
            textBox.Background = Brushes.Transparent;
            textBox.Foreground = Brushes.White;
            e.Handled = true;
        }

        private void grLayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var lbi = sender as ListBoxItem;
            if (lbi != null)
            {
                
                ISelectable designContentControl;
                
                if(lbi.DataContext is DesignContentControl)
                    designContentControl = ((DesignContentControl)lbi.DataContext).Parent as DesignControlHolder;
                else
                    designContentControl = (DesignControlHolder)lbi.DataContext;

                if (_dragCanvas != null)
                {
                    _dragCanvas.selectionService.ClearSelection();
                    _dragCanvas.selectionService.SelectItem(designContentControl);
                }
            }
        }

        private void imgUnSelectable_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                DesignControlHolder designContentControl = (DesignControlHolder)image.DataContext;
                var command = new DisableHitTestCommand(designContentControl);

                if (_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas)_dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        private void imgSelectable_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                DesignControlHolder designContentControl = (DesignControlHolder)image.DataContext;
                var command = new EnableHitTestCommand(designContentControl);

                if (_dragCanvas != null)
                    if (((IDragCanvas)_dragCanvas).UndoService != null)
                    {
                        ((IDragCanvas)_dragCanvas).UndoService.Execute(command);
                    }
                    else
                        command.Execute();
            }
            e.Handled = true;
        }

        public string GetCurrentPanelAssemblyName()
        {
            string assemblyName = string.Empty;

            if (ControlPropertyGrid.Children.Count > 0)
                assemblyName = ControlPropertyGrid.Children[0].GetType().Assembly.GetName().Name;
            return assemblyName;
        }

        public void ClearAnimationPanel()
        {
            AnimationPanel.DataContext = null;
        }

        public void SetDataContext()
        {
            try
            {
                if (ControlPropertyGrid.Children.Count > 0)
                    ((FrameworkElement)ControlPropertyGrid.Children[0]).DataContext = InspireApp.SelectedContext;
                AnimationPanel.DataContext = InspireApp.SelectedContext;
            }
            catch (Exception)
            {
                AnimationPanel.DataContext = InspireApp.SelectedContext;
            }
            
        }
    }
}
