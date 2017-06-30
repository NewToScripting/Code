using System;
using System.Windows;
using System.Windows.Controls;
using Inspire.MediaObjects;
using Inspire;

namespace BrowserModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            DataContext = null;

            if (Content != null)
                Content = null;
            if (grid != null)
            {
                if (grid.Child != null)
                    grid.Child = null;

                grid = null;
            }
        }

        #endregion

        private void btnGo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                DesignWebControl designWebControl =  (DesignWebControl)((ContentControl)((ContentControl)button.DataContext).Content).Content;
                if (designWebControl != null && tbBrowserURL.Text != String.Empty)
                {
                    designWebControl.Url = tbBrowserURL.Text;
                    designWebControl.Stop(); //  TODO: Validate for correct URL
                }
            }
        }
    }
}
