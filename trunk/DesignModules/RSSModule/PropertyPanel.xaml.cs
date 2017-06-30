using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire.MediaObjects;
using Inspire;
using RSSModule.Dialogs;

namespace RSSModule
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

        private void tbTitleFontSize_DropDownClosed(object sender, EventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            rssControlHolder.RSSHolderTitleFontSize = Convert.ToInt32(((ComboBox)(sender)).Text);
        }

        private void tbDescriptionFontSize_DropDownClosed(object sender, EventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            rssControlHolder.RSSHolderDescriptionFontSize = Convert.ToInt32(((ComboBox)(sender)).Text);
        }

        private void ChangeTitleColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           ColorPickerDialog cPicker= new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle) sender).Fill;

           cPicker.StartingColor = fontBrush.Color ;
           //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((Rectangle)(sender)).DataContext)).Content).Content;
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                rssControlHolder.RSSHolderTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void ChangeDescriptionColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((Rectangle)(sender)).DataContext)).Content).Content;
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                rssControlHolder.RSSHolderDescriptionForeground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSDescriptionForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
                //if (selectedShape != null)
                //    selectedShape.Stroke = new SolidColorBrush(cPicker.SelectedColor);
                //StrokeColor = cPicker.SelectedColor;
            }
        }

        private void titleFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            rssControlHolder.RSSHolderTitleFontFamily= (FontFamily)((ComboBox)sender).SelectedItem;
            //RSSControl rssControl = (RSSControl)rssContentControl.Content;
            //rssControl.RSSTitleFontFamily = rssContentControl.RSSTitleFFamily;
        }

        private void descFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            rssControlHolder.RSSHolderDescriptionFontFamily = (FontFamily)((ComboBox)sender).SelectedItem;
            //RSSControl rssControl = (RSSControl)rssContentControl.Content;
            //rssControl.RSSDescriptionFontFamily = rssContentControl.RSSDescriptionFFamily;
        }

        private void tbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            int rssSpeed = Convert.ToInt32(((ComboBox) (sender)).Text);
            rssControlHolder.RSSHolderFeedSpeed = rssSpeed;
        }

        private void AddRSSFeed_Click(object sender, RoutedEventArgs e)
        {
            RSSControlHolder rssControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content;
            AddItem addItem = new AddItem();
            addItem.Title = "Add RSS Feed";
            addItem.lblAddItem.Content = "Enter RSS Feed Url:";
            addItem.ShowDialog();
            if (addItem.DialogResult == true)
            {
                List<string> rssFeeds = new List<string>();

                foreach (string item in rssControlHolder.RSSItems.Items)
                {
                    rssFeeds.Add(item);
                }

                if (String.IsNullOrEmpty(addItem.tbFeedUrl.Text))
                    throw new ArgumentNullException(addItem.tbFeedUrl.Text);

                bool alreadyExists = rssFeeds.Any(p => String.Compare(p, addItem.tbFeedUrl.Text, true) == 0);
                if (alreadyExists)
                    return;

                bool isValidUrl = Uri.IsWellFormedUriString(addItem.tbFeedUrl.Text, UriKind.Absolute);
                if (!isValidUrl)
                {
                    MessageBox.Show("The URL is invalid. Please enter a valid RSS URL. ex: http://rssfeed.com/rssfeed");
                    return;
                }

                rssControlHolder.RSSItems.Items.Add(addItem.tbFeedUrl.Text);

                rssFeeds.Add(addItem.tbFeedUrl.Text);

                if(rssControlHolder.Content is RSSContentControl)
                    ((RSSContentControl)(rssControlHolder).Content).ReloadRSSFeeds();

                //RSSControl rssControl = (RSSControl) rssContentControl.Content;
               // rssControl.Dispose();

                
                //RSSControl rssNewControl = new RSSControl(rssFeeds, rssContentControl.RSSSpeed,
                //                                          rssContentControl.RSSTitleFSize,
                //                                          rssContentControl.RSSTitleFFamily,
                //                                          rssContentControl.RSSTitleFForeground,
                //                                          rssContentControl.RSSDescriptionFSize,
                //                                          rssContentControl.RSSDescriptionFFamily,
                //                                          rssContentControl.RSSDescriptionFForeground);
                //rssContentControl.Content = rssNewControl;
            }
        }

        private void RemoveRSSFeed_Click(object sender, RoutedEventArgs e)
        {
            RSSControlHolder rssContentControlHolder = (RSSControlHolder)((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content;
            if (rssContentControlHolder.Content is RSSContentControl)
            {
                RSSContentControl rssContentControl = (RSSContentControl) rssContentControlHolder.Content;
                if (lbRSSFeeds.SelectedItem == null) return;
                rssContentControl.RSSItems.Items.RemoveAt(lbRSSFeeds.SelectedIndex);
                // RSSControl rssControl = (RSSControl)rssContentControl.Content;
                // rssControl.Dispose();

                List<string> rssFeeds = new List<string>();
                foreach (string item in rssContentControl.RSSItems.Items)
                {
                    rssFeeds.Add(item);
                }

                rssContentControl.ReloadRSSFeeds();
                //RSSControl rssNewControl = new RSSControl(rssFeeds, rssContentControl.RSSSpeed, rssContentControl.RSSTitleFSize, rssContentControl.RSSTitleFFamily, rssContentControl.RSSTitleFForeground, rssContentControl.RSSDescriptionFSize, rssContentControl.RSSDescriptionFFamily, rssContentControl.RSSDescriptionFForeground);
                //rssContentControl.Content = rssNewControl;
            }
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
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
