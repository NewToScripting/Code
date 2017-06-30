using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using ScrollModule.Dialog;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Windows.Media;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog : IWeakEventListener
    {
        public ObservableCollection<ScrollItem> ScrollItems { get; set; }

        public  double ScrollSpeed { get; set; }

        public string ScrollDirection { get; set; }

        public string ScrollStyle { get; set; }

        public ModuleDialog()
        {
            InitializeComponent();

            ScrollStyle = "Scroll";

            ScrollItems = new ObservableCollection<ScrollItem>();
            //cbScrollSpeed.ItemsSource = scrollSpeeds;
            //cbScrollSpeed.SelectedItem = cbScrollSpeed.Items[0];

            ScrollDirection = "Left";

            lbScrollItems.ItemsSource = ScrollItems;
            ScrollSpeed = .25;
        }

        public ModuleDialog(ScrollContentControl _control)
        {
            InitializeComponent();

            if(_control.Tag != null)
                ScrollStyle = _control.Tag.ToString();

            LoadedEventManager.AddListener(this, this);
            ScrollItems = new ObservableCollection<ScrollItem>();

            foreach (var item in _control.ScrollItems)
            {
                ScrollItems.Add(item);
            }

            //cbScrollSpeed.ItemsSource = scrollSpeeds;

            if (_control.ScrollDirection != null)
                if (_control.ScrollDirection.Length > 0)
                    ScrollDirection = _control.ScrollDirection;
                else
                    ScrollDirection = "Left";
            else
                ScrollDirection = "Left";

            lbScrollItems.ItemsSource = ScrollItems;
            ScrollSpeed = _control.ScrollSpeed;

            if (ScrollStyle == "ESPNStyle")
                cbScrollStyle.SelectedIndex = 1;
            else
            {
                ScrollStyle = "Scroll";
                cbScrollStyle.SelectedIndex = 0;
            }
            LoadScrollGrid();
        }

        private void LoadScrollGrid()
        {
            if (ScrollItems != null)
            {
                List<FrameworkElement> elements = new List<FrameworkElement>();

                foreach (var item in ScrollItems)
                {
                    try
                    {
                        elements.AddRange(item.GetScrollItems(ScrollDirection));
                    }
                    catch (Exception)
                    {
                        
                    }
                }

                scrollGrid.Children.Clear();

                if (ScrollStyle == "Scroll")
                    scrollGrid.Children.Add(new ScrollControl(ScrollSpeed, elements, ScrollDirection, false));
                else if (ScrollStyle == "ESPNStyle")
                    scrollGrid.Children.Add(new ESPNScroller(ScrollSpeed, elements, ScrollDirection, false));
                else
                    scrollGrid.Children.Add(new ScrollControl(ScrollSpeed, elements, ScrollDirection, false));
            }
        }

        void ModuleDialog_Loaded(object sender, EventArgs e)
        {
            //cbScrollSpeed.SelectedIndex = cbScrollSpeed.Items.IndexOf(ScrollSpeed);
            slFontSpeed.Value = ScrollSpeed;
        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {
            TextDialog textDialog = new TextDialog();
            textDialog.ShowDialog();
            if (textDialog.DialogResult == true)
            {
                ListBox listBox = new ListBox();

                TextBlock textBlock = textDialog.ScrollTextBlock;

                listBox.Items.Add(textBlock);

                ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);
                
                ScrollItems.Add(scrollItem);

                LoadScrollGrid();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (cbScrollStyle.SelectedIndex == 1)
                ScrollStyle = "ESPNStyle";
            else
                ScrollStyle = "Scroll";

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        {
            //ScrollSpeed = Convert.ToInt32(cbScrollSpeed.SelectedItem);

            LoadScrollGrid();
        }

        private void ContentControl_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lbScrollItems.SelectedItem != null)
            {
                //ScrollContentControl scrollContentControl = (ScrollContentControl)((ContentControl)(((Button)(sender)).DataContext)).Content;
                if (((ScrollItem)((ContentControl)sender).DataContext).ScrollType == "Text")
                {
                    TextDialog textDialog = new TextDialog((TextBlock)((ScrollItem)((ContentControl)sender).DataContext).GetScrollItems(ScrollDirection)[0]);
                    textDialog.ShowDialog();
                    if (textDialog.DialogResult == true)
                    {
                        ListBox listBox = new ListBox();

                        TextBlock textBlock = textDialog.ScrollTextBlock;

                        listBox.Items.Add(textBlock);

                        ScrollItem scrollItem = new ScrollItem("Text", textDialog.ScrollTextBlock.Text, listBox);

                        int index = lbScrollItems.SelectedIndex;
                        {
                            var scrollCol = lbScrollItems.ItemsSource as ObservableCollection<ScrollItem>;
                            scrollCol[index] = scrollItem;

                            LoadScrollGrid();
                            //lbScrollItems.Items[index] = scrollItem;
                        }

                        //((DesignContentControl)(((Button)(sender)).DataContext)).Content = new ScrollContentControl(scrollContentControl);

                        if (lbScrollItems.Items.Count > 0)
                            lbScrollItems.SelectedIndex = 0;
                    }
                }
                else if (((ScrollItem)((ContentControl)sender).DataContext).ScrollType == "RSS")
                {
                    var tTextBlock =
                        ((StackPanel)
                         ((ScrollItem) ((ContentControl) sender).DataContext).GetScrollItems(ScrollDirection)[0]).
                            Children[0] as TextBlock;

                    var dTextBlock = ((StackPanel)
                         ((ScrollItem)((ContentControl)sender).DataContext).GetScrollItems(ScrollDirection)[0]).
                            Children[1] as TextBlock;

                    if (tTextBlock != null && dTextBlock != null)
                    {

                        string scrollFeed = ((ScrollItem) ((ContentControl) sender).DataContext).ScrollContent;
                        RSSDialog rssDialog = new RSSDialog(tTextBlock, dTextBlock, scrollFeed);
                        rssDialog.ShowDialog();
                        if (rssDialog.DialogResult == true)
                        {
                            ListBox listBox = new ListBox();

                            TextBlock titleTextBlock = rssDialog.RSSTitleTextBlock;
                            TextBlock descTextBlock = rssDialog.RSSDescTextBlock;

                            listBox.Items.Add(titleTextBlock);
                            listBox.Items.Add(descTextBlock);

                            ScrollItem scrollItem = new ScrollItem("RSS", rssDialog.RSSTitleTextBlock.Text, listBox);

                            int index = lbScrollItems.SelectedIndex;
                            {
                                var scrollCol = lbScrollItems.ItemsSource as ObservableCollection<ScrollItem>;
                                scrollCol[index] = scrollItem;

                                LoadScrollGrid();
                                //lbScrollItems.Items[index] = scrollItem;
                            }

                            //((DesignContentControl)(((Button)(sender)).DataContext)).Content = new ScrollContentControl(scrollContentControl);

                            if (lbScrollItems.Items.Count > 0)
                                lbScrollItems.SelectedIndex = 0;
                        }
                    }
                }
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ModuleDialog_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void StopScrollExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((IPlayable)scrollGrid.Children[0]).Stop();
            slFontSpeed.IsEnabled = true;
        }

        private void StopScrollCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (((IPlayable)scrollGrid.Children[0]).IsPlaying())
                    e.CanExecute = true;
            }
            catch (Exception)
            {
                e.CanExecute = false;
            }
            
        }

        private void PlayScrollExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            LoadScrollGrid();
            slFontSpeed.IsEnabled = false;
            ((IPlayable)scrollGrid.Children[0]).Play();
        }

        private void PlayScrollCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (!((IPlayable)scrollGrid.Children[0]).IsPlaying())
                    e.CanExecute = true;
            }
            catch (Exception)
            {
                e.CanExecute = false;
            }
        }

        private void UpScrollItemExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbScrollItems.SelectedIndex > -1)
                if (lbScrollItems.SelectedIndex > 0)
                {
                    ScrollItems.Move(lbScrollItems.SelectedIndex, lbScrollItems.SelectedIndex - 1);
                    LoadScrollGrid();
                }
            e.Handled = true;
        }

        private void UpScrollItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DownScrollItemExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(lbScrollItems.SelectedIndex > -1)
                if (ScrollItems.Count > 0 && lbScrollItems.SelectedIndex < ScrollItems.Count - 1)
                {
                    ScrollItems.Move(lbScrollItems.SelectedIndex, lbScrollItems.SelectedIndex + 1);
                    LoadScrollGrid();
                }
            e.Handled = true;
        }

        private void DownScrollItemCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteScrollItem(object sender, RoutedEventArgs e)
        {
            if (lbScrollItems.SelectedIndex > -1)
            {
                ScrollItems.RemoveAt(lbScrollItems.SelectedIndex);
                LoadScrollGrid();
            }
        }

        private void slFontSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScrollSpeed = slFontSpeed.Value;
            //LoadScrollGrid();
        }

        private void btnRss_Click(object sender, RoutedEventArgs e)
        {
            RSSDialog rssDialog = new RSSDialog();
            rssDialog.ShowDialog();
            if (rssDialog.DialogResult == true)
            {
                ListBox listBox = new ListBox();

                TextBlock titleTextBlock = rssDialog.RSSTitleTextBlock;
                TextBlock descTextBlock = rssDialog.RSSDescTextBlock;

                listBox.Items.Add(titleTextBlock);
                listBox.Items.Add(descTextBlock);

                ScrollItem scrollItem = new ScrollItem("RSS", rssDialog.RSSTitleTextBlock.Text, listBox);

                ScrollItems.Add(scrollItem);

                LoadScrollGrid();
            }
        }

        private void cbScrollStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbScrollStyle.SelectedIndex == 1)
                ScrollStyle = "ESPNStyle";
            else
                ScrollStyle = "Scroll";
            LoadScrollGrid();
        }
    }
}
