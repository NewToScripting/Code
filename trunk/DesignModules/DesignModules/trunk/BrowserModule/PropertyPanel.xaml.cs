using System;
using System.Windows.Controls;
using Inspire.MediaObjects;

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
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Content != null)
                Content = null;
            if (grid != null)
            {
                if (grid.Child != null)
                    grid.Child = null;

                grid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        private void btnGo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                DesignWebControl designWebControl =  (DesignWebControl)((DesignContentControl)button.DataContext).Content;
                if (designWebControl != null && tbBrowserURL.Text != String.Empty)
                {
                    designWebControl.Url = new Uri(tbBrowserURL.Text);
                    designWebControl.Stop(); //  TODO: Validate for correct URL
                }
            }
        }
    }
}
