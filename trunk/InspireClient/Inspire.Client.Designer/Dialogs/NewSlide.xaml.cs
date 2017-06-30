using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.Designer.Dialogs
{
    /// <summary>
    /// Interaction logic for NewSlide.xaml
    /// </summary>
    public partial class NewSlide : IWeakEventListener
    {
        private List<Display> _displays;

        public NewSlide(List<Display> displays)
        {
            InitializeComponent();
            _displays = displays;
            LoadedEventManager.AddListener(this, this);
        }

        void NewSlide_Loaded(object sender, EventArgs e)
        {
            if (_displays.Count > 0)
            {
                foreach (var display in _displays)
                {
                    lbDisplays.Items.Add(display);
                }
                lbDisplays.SelectedItem = lbDisplays.Items[0];
            }
        }

        private void btnCreateSlide_Click(object sender, RoutedEventArgs e)
        {
            if (lbDisplays.SelectedItem != null)
            {
                double hRes = ((Display) lbDisplays.SelectedItem).HResolution;
                double vRes = ((Display) lbDisplays.SelectedItem).VResolution;

                CreateCanvas(hRes, vRes);
            }
            Close();
        }

        private void CreateCanvas(double? hRes, double? vRes)
        {
            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                UserControl designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                if (designWindow != null)
                {
                    TabControl tabControl = designWindow.FindName("DesignerDragCanvasHolder") as TabControl;
                    if (tabControl != null)
                    {
                        Label label = (Label) designWindow.FindName("lblNewSlide");
                        label.Visibility = Visibility.Hidden;

                        InspireApp.CanvasExists = true;

                        var tabItem = new CloseableTabItem();
                        
                        DragCanvas.DragCanvas dragCanvas = new DragCanvas.DragCanvas();

                        InspireApp.CurrentDragCanvas = dragCanvas;

                        dragCanvas.Width = (double) hRes;
                        dragCanvas.Height = (double) vRes;
                        dragCanvas.Background = Brushes.White;

                        tabItem.Header = "untitled-" + (tabControl.Items.Count + 1);
                        tabItem.Content = dragCanvas;

                        tabControl.Items.Add(tabItem);

                        tabControl.SelectedItem = tabItem;

                        DialogResult = true;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                NewSlide_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void CreateCustomSlide_Click(object sender, RoutedEventArgs e)
        {
            var customSlide = new CustomSlide();
            customSlide.ShowDialog();
            if(customSlide.DialogResult == true)
            {
                if (customSlide.intHor.Value != null && customSlide.intVer.Value != null)
                {
                    double? hRes = customSlide.intHor.Value;
                    double? vRes = customSlide.intVer.Value;

                    CreateCanvas(hRes, vRes);
                    customSlide.Close();
                }
                Close();
            }
        }
    }
}
