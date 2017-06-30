using System;
using System.Windows;
using System.Windows.Controls;
using Inspire.MediaObjects;
using ScrollModule.Dialog;
using Inspire;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        //private readonly int[] scrollSpeeds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            //cbScrollSpeed.ItemsSource = scrollSpeeds;

           // Loaded += new RoutedEventHandler(PropertyPanel_Loaded);

            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        //void PropertyPanel_Loaded(object sender, RoutedEventArgs e)
        //{
        //    lbScrollItems.ItemsSource = ((ScrollContentControl)((ContentControl)((ContentControl)(DataContext)).Content).Content).ScrollItems;
        //}

        //private void tbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        //{
        //    ScrollContentControl scrollContentControl = (ScrollContentControl)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
        //    int scrollSpeed = Convert.ToInt32(((ComboBox)(sender)).Text);
        //    scrollContentControl.ScrollSpeed = scrollSpeed;
        //    ScrollContentControl newScrollContentControl = new ScrollContentControl(scrollContentControl);
        //    scrollContentControl = null;
        //    ((ContentControl)((ContentControl) (((ComboBox) (sender)).DataContext)).Content).Content = newScrollContentControl;


        //}

        private void AddScrollItem_Click(object sender, RoutedEventArgs e)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content;

            TextDialog textDialog = new TextDialog();
            textDialog.ShowDialog();
            if (textDialog.DialogResult == true)
            {
                ListBox listBox = new ListBox();

                TextBlock textBlock = textDialog.ScrollTextBlock;

                listBox.Items.Add(textBlock);

                ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);

                scrollContentControl.ScrollItems.Add(scrollItem);

                ((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content = new ScrollContentControl(scrollContentControl);

                scrollContentControl.Dispose();
                scrollContentControl = null;

                if (lbScrollItems.Items.Count > 0)
                    lbScrollItems.SelectedIndex = 0;
            }

            e.Handled = true;
        }

        private void RemoveScrollItem_Click(object sender, RoutedEventArgs e)
        {
            if (lbScrollItems.SelectedItem != null)
            {
                ScrollContentControl scrollContentControl = (ScrollContentControl)((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content;

                scrollContentControl.ScrollItems.RemoveAt(lbScrollItems.SelectedIndex);

                ((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content = new ScrollContentControl(scrollContentControl);

                scrollContentControl.Dispose();
                scrollContentControl = null;

                if (lbScrollItems.Items.Count > 0)
                    lbScrollItems.SelectedIndex = 0;
            }
            e.Handled = true;
        }

        private void EditScrollItem_Click(object sender, RoutedEventArgs e)
        {
            if (lbScrollItems.SelectedItem != null)
            {
                ScrollContentControl scrollContentControl = (ScrollContentControl)((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content;
                if (((ScrollItem)lbScrollItems.SelectedItem).ScrollType == "Text")
                {
                    TextDialog textDialog = new TextDialog((TextBlock)((ScrollItem)lbScrollItems.SelectedItem).GetScrollItems(scrollContentControl.ScrollDirection)[0]);
                    textDialog.ShowDialog();
                    if (textDialog.DialogResult == true)
                    {
                        ListBox listBox = new ListBox();

                        TextBlock textBlock = textDialog.ScrollTextBlock;

                        listBox.Items.Add(textBlock);

                        ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);

                        int index = lbScrollItems.SelectedIndex;
                        scrollContentControl.ScrollItems[index] = scrollItem;

                        ((ContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content).Content = new ScrollContentControl(scrollContentControl);

                        scrollContentControl.Dispose();
                        scrollContentControl = null;

                        if (lbScrollItems.Items.Count > 0)
                            lbScrollItems.SelectedIndex = 0;
                    }
                }
            }
            e.Handled = true;
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

        private void slFontSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (((Slider)(sender)).DataContext != null && ((ContentControl)((Slider)(sender)).DataContext).Content != null)
            {
                if(DataContext is ContentControl && ((ContentControl)((ContentControl)(((Slider)(sender)).DataContext)).Content != null))
                if (((ContentControl)((ContentControl)(((Slider)(sender)).DataContext)).Content).Content is ScrollContentControl)
                {
                    ScrollContentControl scrollContentControl =
                        (ScrollContentControl) ((ContentControl)((ContentControl) (((Slider) (sender)).DataContext)).Content).Content;
                    if (scrollContentControl != null)
                    {
                        scrollContentControl.ScrollSpeed = e.NewValue;

                        ((ContentControl) ((ContentControl) (((Slider) (sender)).DataContext)).Content).Content =
                            scrollContentControl;
                        //ScrollContentControl newScrollContentControl = new ScrollContentControl(scrollContentControl);
                        //((ContentControl)((ContentControl) (((Slider) (sender)).DataContext)).Content).Content = newScrollContentControl;

                        //scrollContentControl.Dispose();
                        //scrollContentControl = null;
                    }
                }
            }
        }
    }
}
