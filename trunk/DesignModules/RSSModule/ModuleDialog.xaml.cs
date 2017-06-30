using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Inspire;
using RSSModule.Commands;

namespace RSSModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog
    {
        public ObservableCollection<string> RSSFeedItems { get; set; } // TODO: Change to a collection of RSS feeds

        public TextBlock RSSTitle { get; set; }

        public TextBlock RSSDescription { get; set; }

        public int RSSSpeed { get; set; }

        public bool IsTouchPanel
        {
            get { return (bool)cbTouchPanel.IsChecked; }
        }

        private readonly int[] fontSizes = { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72 };

        private readonly int[] rssSpeeds = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 25, 30 };

        public ModuleDialog()
        {
            InitializeComponent();

            RSSFeedItems = new ObservableCollection<string>();
            RSSTitle = new TextBlock();
            RSSTitle.Foreground = Brushes.Black;
            RSSDescription = new TextBlock();
            RSSSpeed = 10;

            RSSTitle.FontSize = 18;

            RSSDescription.FontSize = 16;

           // CommandBindings.Add(new CommandBinding(RSSModuleCommands.ApplyTitleForeground, OnApplyTitleForegroundExecute, OnApplyTitleForegroundCanExecute));
            //CommandBindings.Add(new CommandBinding(RSSModuleCommands.ApplyDescriptionForeground, OnApplyDescriptionForegroundExecute, OnApplyDescriptionForegroundCanExecute));

            cbTitleFontSize.ItemsSource = fontSizes;
            cbDecriptionSize.ItemsSource = fontSizes;
            cbFeedSpeed.ItemsSource = rssSpeeds;

            SetComboBoxes();

            lbRSSFeeds.ItemsSource = RSSFeedItems;

        }

        private void SetComboBoxes()
        {
            cbTitleFontSize.SelectedIndex = cbTitleFontSize.Items.IndexOf(Convert.ToInt32(RSSTitle.FontSize));
            cbTitleFontFamily.SelectedIndex = cbTitleFontFamily.Items.IndexOf(RSSTitle.FontFamily);
            cbDecriptionSize.SelectedIndex = cbDecriptionSize.Items.IndexOf(Convert.ToInt32(RSSDescription.FontSize));
            cbDescriptionFontFamily.SelectedIndex = cbDescriptionFontFamily.Items.IndexOf(RSSDescription.FontFamily);
            cbFeedSpeed.SelectedIndex = cbFeedSpeed.Items.IndexOf(Convert.ToInt32(RSSSpeed));
            TitleColorRectangle.Fill = RSSTitle.Foreground;
            DescColorRectangle.Fill = RSSDescription.Foreground;
        }

        public ModuleDialog(RSSControlHolder _rssContentControl)
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(RSSModuleCommands.ApplyTitleForeground, OnApplyTitleForegroundExecute, OnApplyTitleForegroundCanExecute));
            CommandBindings.Add(new CommandBinding(RSSModuleCommands.ApplyDescriptionForeground, OnApplyDescriptionForegroundExecute, OnApplyDescriptionForegroundCanExecute));

            cbTitleFontSize.ItemsSource = fontSizes;
            cbDecriptionSize.ItemsSource = fontSizes;
            cbFeedSpeed.ItemsSource = rssSpeeds;

            List<string> rssFeeds = new List<string>();

            foreach (var item in _rssContentControl.RSSItems.Items)
            {
                rssFeeds.Add((string)item);
            }

            RSSFeedItems = new ObservableCollection<string>(rssFeeds);
            RSSTitle = new TextBlock();
            RSSTitle.Foreground = _rssContentControl.RSSHolderTitleForeground;
            RSSTitle.FontSize = _rssContentControl.RSSHolderTitleFontSize;
            RSSTitle.FontFamily = _rssContentControl.RSSHolderTitleFontFamily;

            RSSDescription = new TextBlock();
            RSSDescription.FontFamily = _rssContentControl.RSSHolderDescriptionFontFamily;
            RSSDescription.Foreground = _rssContentControl.RSSHolderDescriptionForeground;
            RSSDescription.FontSize = _rssContentControl.RSSHolderDescriptionFontSize;

            RSSSpeed = _rssContentControl.RSSHolderFeedSpeed;

            SetComboBoxes();

            lbRSSFeeds.ItemsSource = RSSFeedItems;

        }

        private void OnApplyDescriptionForegroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnApplyDescriptionForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if (parameter != null)
            {
                switch (parameter.Action)
                {
                    case ValueCommandParameterAction.Commit:
                        RSSDescription.Foreground = parameter.Value;
                        break;
                    case ValueCommandParameterAction.Preview:
                       // tbScrollText.Foreground = parameter.PreviewValue;
                        break;
                }
            }
            e.Handled = true;
        }

        private void OnApplyTitleForegroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnApplyTitleForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if (parameter != null)
            {
                switch (parameter.Action)
                {
                    case ValueCommandParameterAction.Commit:
                        RSSTitle.Foreground = parameter.Value;
                        break;
                    case ValueCommandParameterAction.Preview:
                     //   tbScrollText.Foreground = parameter.PreviewValue;
                        break;
                }
            }
            e.Handled = true;
        }

        private void RSSFeed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //tbFeedUrl.Text = 
        }

        private void btnSaveFeed_Click(object sender, RoutedEventArgs e)
        {
            RSSTitle.FontFamily = (FontFamily)cbTitleFontFamily.SelectedItem;
            RSSDescription.FontFamily = (FontFamily)cbDescriptionFontFamily.SelectedItem;
            if (RSSTitle.Foreground == null)
                RSSTitle.Foreground = Brushes.Black;
            if (RSSDescription.Foreground == null)
                RSSDescription.Foreground = Brushes.DarkGray;
            if (cbTitleFontSize.SelectedItem != null)
            {
                RSSTitle.FontSize = (int)cbTitleFontSize.SelectedItem;
                RSSDescription.FontSize = (int) cbDecriptionSize.SelectedItem;
            }

            DialogResult = true;
            Close();
        }

        private void btnCancelFeed_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbDescriptionFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSTitle.FontFamily = (FontFamily)cbTitleFontFamily.SelectedItem;
        }

        private void cbTitleFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSDescription.FontFamily = (FontFamily)cbDescriptionFontFamily.SelectedItem;
        }

        private void AddRSSFeedExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbFeedUrl.Text))
                throw new ArgumentNullException(tbFeedUrl.Text);

            bool alreadyExists = RSSFeedItems.Any(p => String.Compare(p, tbFeedUrl.Text, true) == 0);
            if (alreadyExists)
                return;

            bool isValidUrl = Uri.IsWellFormedUriString(tbFeedUrl.Text, UriKind.Absolute);
            if (!isValidUrl)
            {
                MessageBox.Show("The URL is invalid. Please enter a valid RSS URL. ex: http://rssfeed.com/rssfeed");
                return;
            }
            RSSFeedItems.Add(tbFeedUrl.Text);
            tbFeedUrl.Text = String.Empty;
        }

        private void AddRSSFeedCanExecute(object sender, CanExecuteRoutedEventArgs e)
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

        private void ChangeTitleColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                RSSTitle.Foreground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void ChangeDescriptionColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                RSSDescription.Foreground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void UpScrollItemExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbRSSFeeds.SelectedIndex > -1)
                if (lbRSSFeeds.SelectedIndex > 0)
                {
                    RSSFeedItems.Move(lbRSSFeeds.SelectedIndex, lbRSSFeeds.SelectedIndex - 1);
                }
            e.Handled = true;
        }

        private void UpScrollItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DownScrollItemExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbRSSFeeds.SelectedIndex > -1)
                if (RSSFeedItems.Count > 0 && lbRSSFeeds.SelectedIndex < RSSFeedItems.Count - 1)
                {
                    RSSFeedItems.Move(lbRSSFeeds.SelectedIndex, lbRSSFeeds.SelectedIndex + 1);
                }
            e.Handled = true;
        }

        private void DownScrollItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteRSSFeed(object sender, RoutedEventArgs e)
        {
            if(lbRSSFeeds.SelectedIndex > -1)
                RSSFeedItems.RemoveAt(lbRSSFeeds.SelectedIndex);
        }

        private void cbFeedSpeed_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFeedSpeed.SelectedIndex > -1)
                RSSSpeed = Convert.ToInt32(cbFeedSpeed.Text);
        }
    }
}
