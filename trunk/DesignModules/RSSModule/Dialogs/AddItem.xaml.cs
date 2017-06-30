using System;

namespace RSSModule.Dialogs
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddRSSFeedExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddRSSFeedCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (IsValidUrl(tbFeedUrl.Text));
        }

        #region Private Helpers

        static bool IsValidUrl(string url)
        {
            string feedUrl = Inspire.Utilities.PrepareUrl(url);

            Uri uri = null;
            if (Uri.TryCreate(feedUrl, UriKind.Absolute, out uri))
            {
                // If the URL references a local file, but the file does not
                // exist, then the URL is considered to be invalid.
                bool isLocalFile = uri.IsLoopback;
                if (isLocalFile && !System.IO.File.Exists(uri.LocalPath))
                    uri = null;
            }

            return uri != null;
        }

        #endregion // Private Helpers
    }
}
