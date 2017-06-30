using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using Inspire;

namespace ScrollModule.Dialog
{
    /// <summary>
    /// Interaction logic for RSSDialog.xaml
    /// </summary>
    public partial class RSSDialog : Window
    {
        public TextBlock RSSTitleTextBlock { get; set; }

        public TextBlock RSSDescTextBlock { get; set; }

        private readonly int[] fontSizes = { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72 };

        private readonly int[] feedItems = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };

        public RSSDialog()
        {
            InitializeComponent();

            RSSTitleTextBlock = new TextBlock();
            RSSTitleTextBlock.Foreground = Brushes.White;
            RSSDescTextBlock = new TextBlock();
            RSSDescTextBlock.Foreground = Brushes.Bisque;
            RSSTitleTextBlock.FontSize = 32;

            RSSDescTextBlock.FontSize = 28;

            cbTitleFontSize.ItemsSource = fontSizes;
            cbDecriptionSize.ItemsSource = fontSizes;
            cbFeedNumber.ItemsSource = feedItems;
            cbFeedNumber.SelectedIndex = cbFeedNumber.Items.IndexOf(5);//(Convert.ToInt32(RSSDescTextBlock.FontSize));

            SetComboBoxes();
        }

        public RSSDialog(TextBlock titleTextBlock, TextBlock descTextBlock, string feedUrl)
        {
            InitializeComponent();

            RSSTitleTextBlock = new TextBlock();

            tbFeedUrl.Text = feedUrl;

            RSSTitleTextBlock.Foreground = titleTextBlock.Foreground;
            RSSDescTextBlock = new TextBlock();
            RSSDescTextBlock.Foreground = descTextBlock.Foreground;
            RSSTitleTextBlock.FontSize = titleTextBlock.FontSize;

            RSSDescTextBlock.FontSize = descTextBlock.FontSize;

            cbTitleFontSize.ItemsSource = fontSizes;
            cbDecriptionSize.ItemsSource = fontSizes;

            cbFeedNumber.ItemsSource = feedItems;

            int feedPull = 5;

            if(titleTextBlock.Tag != null)
                int.TryParse(titleTextBlock.Tag.ToString(), out feedPull);

            cbFeedNumber.SelectedIndex = cbFeedNumber.Items.IndexOf(feedPull);

            SetComboBoxes();
        }

        private void cbTitleFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSTitleTextBlock.FontFamily = (FontFamily)cbTitleFontFamily.SelectedItem;
        }

        private void cbDescriptionFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            RSSDescTextBlock.FontFamily = (FontFamily)cbDescriptionFontFamily.SelectedItem;
        }

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
                RSSTitleTextBlock.Foreground = selectedColor;
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
                RSSDescTextBlock.Foreground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
        
        private void SetComboBoxes()
        {
            cbTitleFontSize.SelectedIndex = cbTitleFontSize.Items.IndexOf(Convert.ToInt32(RSSTitleTextBlock.FontSize));
            cbTitleFontFamily.SelectedIndex = cbTitleFontFamily.Items.IndexOf(RSSTitleTextBlock.FontFamily);
            cbDecriptionSize.SelectedIndex = cbDecriptionSize.Items.IndexOf(Convert.ToInt32(RSSDescTextBlock.FontSize));
            cbDescriptionFontFamily.SelectedIndex = cbDescriptionFontFamily.Items.IndexOf(RSSDescTextBlock.FontFamily);

            TitleColorRectangle.Fill = RSSTitleTextBlock.Foreground;
            DescColorRectangle.Fill = RSSDescTextBlock.Foreground;
        }

        private void btnSaveFeed_Click(object sender, RoutedEventArgs e)
        {
            RSSTitleTextBlock.Text = tbFeedUrl.Text;
            RSSTitleTextBlock.Tag = cbFeedNumber.SelectedItem;
            RSSTitleTextBlock.FontFamily = (FontFamily)cbTitleFontFamily.SelectedItem;
            RSSDescTextBlock.FontFamily = (FontFamily)cbDescriptionFontFamily.SelectedItem;
            
            if (RSSTitleTextBlock.Foreground == null)
                RSSTitleTextBlock.Foreground = Brushes.Black;

            if (RSSDescTextBlock.Foreground == null)
                RSSDescTextBlock.Foreground = Brushes.DarkGray;

            RSSTitleTextBlock.FontSize = (int)cbTitleFontSize.SelectedItem;

            RSSDescTextBlock.FontSize = (int)cbDecriptionSize.SelectedItem;

            DialogResult = true;
            Close();
        }

        private void btnCancelFeed_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbFeedUrl.Text))
                MessageBox.Show("Enter a RSS feed url.");

            bool isValidUrl = Uri.IsWellFormedUriString(tbFeedUrl.Text, UriKind.Absolute);
            if (!isValidUrl)
            {
                MessageBox.Show("The URL is invalid. Please enter a valid RSS URL. ex: http://rssfeed.com/rssfeed");
            }
            else
            {
                SyndicationFeed BlogFeed = new SyndicationFeed();

                if (tbFeedUrl.Text.Length > 0)
                    using (XmlReader reader = XmlReader.Create(tbFeedUrl.Text))
                    {
                        BlogFeed = SyndicationFeed.Load(reader);
                        reader.Close();
                    }

                if(BlogFeed.Items.Count() > 0)
                    MessageBox.Show("The feed is valid and contains items.");
                else
                    MessageBox.Show("The feed is a valid format, but no RSS entries are found.");
            }
        }
    }
}
