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
        }

        private void tbTitleFontSize_DropDownClosed(object sender, EventArgs e)
        {
            RSSContentControl rssContentControl = (RSSContentControl) ((DesignContentControl)(((ComboBox) (sender)).DataContext)).Content;
            rssContentControl.RSSTitleFontSize = Convert.ToInt32(((ComboBox) (sender)).Text);
        }

        private void tbDescriptionFontSize_DropDownClosed(object sender, EventArgs e)
        {
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            rssContentControl.RSSDescriptionFontSize = Convert.ToInt32(((ComboBox)(sender)).Text);
            //RSSControl rssControl = (RSSControl)rssContentControl.Content;
            //rssControl.RSSDescriptionFontSize = Convert.ToInt32(((ComboBox)(sender)).Text);
        }

        private void ChangeTitleColor_Click(object sender, RoutedEventArgs e)
        {
           ColorPickerDialog cPicker= new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle) sender).Fill;

           cPicker.StartingColor = fontBrush.Color ;
           //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((Rectangle)(sender)).DataContext)).Content;
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                rssContentControl.RSSTitleForeground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void ChangeDescriptionColor_Click(object sender, RoutedEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((Rectangle)(sender)).DataContext)).Content;
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                rssContentControl.RSSDescriptionForeground = selectedColor;
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
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            rssContentControl.RSSTitleFontFamily = (FontFamily)((ComboBox)sender).SelectedItem;
            //RSSControl rssControl = (RSSControl)rssContentControl.Content;
            //rssControl.RSSTitleFontFamily = rssContentControl.RSSTitleFFamily;
        }

        private void descFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            rssContentControl.RSSDescriptionFontFamily = (FontFamily)((ComboBox)sender).SelectedItem;
            //RSSControl rssControl = (RSSControl)rssContentControl.Content;
            //rssControl.RSSDescriptionFontFamily = rssContentControl.RSSDescriptionFFamily;
        }

        private void tbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        {
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            int rssSpeed = Convert.ToInt32(((ComboBox) (sender)).Text);
            rssContentControl.RSSFeedSpeed = rssSpeed;
        }

        private void AddRSSFeed_Click(object sender, RoutedEventArgs e)
        {
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((Button)(sender)).DataContext)).Content;
            AddItem addItem = new AddItem();
            addItem.Title = "Add RSS Feed";
            addItem.lblAddItem.Content = "Enter RSS Feed Url:";
            addItem.ShowDialog();
            if (addItem.DialogResult == true)
            {
                List<string> rssFeeds = new List<string>();

                foreach (string item in rssContentControl.RSSItems.Items)
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

                rssContentControl.RSSItems.Items.Add(addItem.tbFeedUrl.Text);

                rssFeeds.Add(addItem.tbFeedUrl.Text);
                
                rssContentControl.ReloadRSSFeeds();

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
            RSSContentControl rssContentControl = (RSSContentControl)((DesignContentControl)(((Button)(sender)).DataContext)).Content;
            if(lbRSSFeeds.SelectedItem == null) return;
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
    }
}
