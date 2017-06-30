using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Inspire.MediaObjects;
using ScrollModule.Dialog;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        private readonly int[] scrollSpeeds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public PropertyPanel()
        {
            InitializeComponent();
            cbScrollSpeed.ItemsSource = scrollSpeeds;

           // Loaded += new RoutedEventHandler(PropertyPanel_Loaded);

        }

        void PropertyPanel_Loaded(object sender, RoutedEventArgs e)
        {
            lbScrollItems.ItemsSource = ((ScrollContentControl)((DesignContentControl)(this.DataContext)).Content).ScrollItems;
        }

        private void tbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            int scrollSpeed = Convert.ToInt32(((ComboBox)(sender)).Text);
            scrollContentControl.ScrollSpeed = scrollSpeed;
            ScrollContentControl newScrollContentControl = new ScrollContentControl(scrollContentControl);
            scrollContentControl = null;
            ((DesignContentControl) (((ComboBox) (sender)).DataContext)).Content = newScrollContentControl;
        }

        private void AddScrollItem_Click(object sender, RoutedEventArgs e)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)((DesignContentControl)(((Button)(sender)).DataContext)).Content;

            TextDialog textDialog = new TextDialog();
            textDialog.ShowDialog();
            if (textDialog.DialogResult == true)
            {
                ListBox listBox = new ListBox();

                TextBlock textBlock = textDialog.ScrollTextBlock;

                listBox.Items.Add(textBlock);

                ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);

                scrollContentControl.ScrollItems.Add(scrollItem);

                ((DesignContentControl)(((Button)(sender)).DataContext)).Content = new ScrollContentControl(scrollContentControl);

                if (lbScrollItems.Items.Count > 0)
                    lbScrollItems.SelectedIndex = 0;
            }

            e.Handled = true;
        }

        private void RemoveScrollItem_Click(object sender, RoutedEventArgs e)
        {
            if (lbScrollItems.SelectedItem != null)
            {
                ScrollContentControl scrollContentControl = (ScrollContentControl)((DesignContentControl)(((Button)(sender)).DataContext)).Content;

                scrollContentControl.ScrollItems.RemoveAt(lbScrollItems.SelectedIndex);

                ((DesignContentControl)(((Button)(sender)).DataContext)).Content = new ScrollContentControl(scrollContentControl);

                if (lbScrollItems.Items.Count > 0)
                    lbScrollItems.SelectedIndex = 0;
            }
            e.Handled = true;
        }

        private void EditScrollItem_Click(object sender, RoutedEventArgs e)
        {
            if (lbScrollItems.SelectedItem != null)
            {
                ScrollContentControl scrollContentControl = (ScrollContentControl)((DesignContentControl)(((Button)(sender)).DataContext)).Content;
                if (((ScrollItem)lbScrollItems.SelectedItem).ScrollType == "Text")
                {
                    TextDialog textDialog = new TextDialog((TextBlock)((ScrollItem)lbScrollItems.SelectedItem).GetScrollItem());
                    textDialog.ShowDialog();
                    if (textDialog.DialogResult == true)
                    {
                        ListBox listBox = new ListBox();

                        TextBlock textBlock = textDialog.ScrollTextBlock;

                        listBox.Items.Add(textBlock);

                        ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);

                        int index = lbScrollItems.SelectedIndex;
                        scrollContentControl.ScrollItems[index] = scrollItem;

                        ((DesignContentControl)(((Button)(sender)).DataContext)).Content = new ScrollContentControl(scrollContentControl);

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
