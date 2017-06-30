using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Inspire.Client.Designer.Dialogs
{
    /// <summary>
    /// Interaction logic for CustomSlide.xaml
    /// </summary>
    public partial class CustomSlide
    {
        public CustomSlide()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
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

                        var dragCanvas = new DragCanvas.DragCanvas();

                        InspireApp.CurrentDragCanvas = dragCanvas;

                        if (intHor.Value > 0 && intVer.Value > 0)
                        {
                            dragCanvas.Width = Convert.ToDouble(intHor.Value);
                            dragCanvas.Height = Convert.ToDouble(intVer.Value);
                        }
                        else
                        {
                            dragCanvas.Width = 1024;
                            dragCanvas.Height = 768;
                        }

                        dragCanvas.Background = Brushes.White;

                        tabItem.Header = "untitled-" + (tabControl.Items.Count + 1);
                        tabItem.Content = dragCanvas;

                        tabControl.Items.Add(tabItem);

                        tabControl.SelectedItem = tabItem;
                    }

                }
            }
            DialogResult = true;
            Close();
        }
    }
}
