using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Services.WeakEventHandlers;
using ScrollModule.Dialog;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog : IWeakEventListener
    {

        public ObservableCollection<ScrollItem> ScrollItems { get; set; }

        public int ScrollSpeed { get; set; }

        private readonly int[] scrollSpeeds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        public ModuleDialog()
        {
            InitializeComponent();

            ScrollItems = new ObservableCollection<ScrollItem>();
            cbScrollSpeed.ItemsSource = scrollSpeeds;
            cbScrollSpeed.SelectedItem = cbScrollSpeed.Items[0];

            

            lbScrollItems.ItemsSource = ScrollItems;
            ScrollSpeed = 1;
        }

        public ModuleDialog(ScrollContentControl _control)
        {
            InitializeComponent();

            LoadedEventManager.AddListener(this, this);
            ScrollItems = new ObservableCollection<ScrollItem>();

            foreach (var item in _control.ScrollItems)
            {
                ScrollItems.Add(item);
            }

            cbScrollSpeed.ItemsSource = scrollSpeeds;

            lbScrollItems.ItemsSource = ScrollItems;
            ScrollSpeed = _control.ScrollSpeed;

            LoadScrollGrid();
        }

        private void LoadScrollGrid()
        {
            List<FrameworkElement> elements = new List<FrameworkElement>();

            foreach (var item in ScrollItems)
            {
                elements.Add(item.GetScrollItem());
            }

            scrollGrid.Children.Clear();

            scrollGrid.Children.Add(new ScrollControl(ScrollSpeed, elements, false));
        }

        void ModuleDialog_Loaded(object sender, EventArgs e)
        {
            cbScrollSpeed.SelectedIndex = cbScrollSpeed.Items.IndexOf(ScrollSpeed);
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
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbScrollSpeed_DropDownClosed(object sender, EventArgs e)
        {
            ScrollSpeed = Convert.ToInt32(cbScrollSpeed.SelectedItem);

            LoadScrollGrid();
        }

        private void ContentControl_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (((ContentControl)sender).DataContext.GetType().Name == "TextBlock")
            //{
            //    TextDialog textDialog = new TextDialog((TextBlock) ((ContentControl) sender).DataContext);
            //    textDialog.ShowDialog();
            //    if (textDialog.DialogResult == true)
            //    {
            //        ScrollItems[lbScrollItems.SelectedIndex] = textDialog.ScrollTextBlock;

            //        List<FrameworkElement> elements = new List<FrameworkElement>();

            //        foreach (var item in ScrollItems)
            //        {
            //            elements.Add(item);
            //        }

            //        ScrollControl scrollControl = new ScrollControl(ScrollSpeed, elements);
            //        scrollGrid.Children.Clear();
            //        scrollGrid.Children.Add(scrollControl);
            //    }
            //}
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
            ((ScrollControl)scrollGrid.Children[0]).Stop();
        }

        private void StopScrollCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (((ScrollControl)scrollGrid.Children[0]).IsPlaying)
                    e.CanExecute = true;
            }
            catch (Exception)
            {
                e.CanExecute = false;
            }
            
        }

        private void PlayScrollExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((ScrollControl)scrollGrid.Children[0]).Play();
        }

        private void PlayScrollCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (!((ScrollControl)scrollGrid.Children[0]).IsPlaying)
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
    }
}
