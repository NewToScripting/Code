using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Inspire;
using Inspire.Services.WeakEventHandlers;
using ScrollModule.Commands;

namespace ScrollModule.Dialog
{
    /// <summary>
    /// Interaction logic for TextDialog.xaml
    /// </summary>
    public partial class TextDialog : IWeakEventListener
    {
        public TextBlock ScrollTextBlock { get; set; }

        private readonly int[] fontSizes = { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72 };

        public TextDialog()
        {
            InitializeComponent();

            //CommandBindings.Add(new CommandBinding(ScrollModuleCommands.ApplyForeground, OnApplyForegroundExecute, OnApplyForegroundCanExecute));

            ScrollTextBlock = new TextBlock();

            tbScrollText.FontSize = 32;

            SetComboBoxes();

            cbFontSize.ItemsSource = fontSizes;

            LoadedEventManager.AddListener(this, this);
        }

        public TextDialog(TextBlock _scrollTextBlock)
        {
            InitializeComponent();

          //  CommandBindings.Add(new CommandBinding(ScrollModuleCommands.ApplyForeground, OnApplyForegroundExecute, OnApplyForegroundCanExecute));

            ScrollTextBlock = new TextBlock();

            tbScrollText.Text = _scrollTextBlock.Text;
            tbScrollText.FontFamily = _scrollTextBlock.FontFamily;
            tbScrollText.Foreground = _scrollTextBlock.Foreground;
            tbScrollText.FontSize = _scrollTextBlock.FontSize;

            SetComboBoxes();

            cbFontSize.ItemsSource = fontSizes;

            LoadedEventManager.AddListener(this, this);
        }

        void TextDialog_Loaded(object sender, EventArgs e)
        {
            cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(Convert.ToInt32(tbScrollText.FontSize));
            cbFontFamily.SelectedIndex = cbFontFamily.Items.IndexOf(tbScrollText.FontFamily);
        }

        private void SetComboBoxes()
        {
            if (tbScrollText != null)
            {
                cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(tbScrollText.FontSize);
                cbFontFamily.SelectedIndex = cbFontFamily.Items.IndexOf(tbScrollText.FontFamily);
                TextColorRectangle.Fill = tbScrollText.Foreground;
            }
        }

        private void cbFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            tbScrollText.FontFamily = (FontFamily) cbFontFamily.SelectedItem;
        }

        private void cbFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if(cbFontSize.SelectedItem != null)
                tbScrollText.FontSize = Convert.ToInt32(cbFontSize.SelectedItem);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            ScrollTextBlock.Text = tbScrollText.Text;
            ScrollTextBlock.Foreground = tbScrollText.Foreground;
            ScrollTextBlock.FontFamily = tbScrollText.FontFamily;
            ScrollTextBlock.FontSize = tbScrollText.FontSize;
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        ///// <summary>
        ///// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        ///// </summary>
        ///// <param name="sender">The sender of the event.</param>
        ///// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        //private void OnApplyForegroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        ///// <summary>
        ///// Occurs when the <see cref="RoutedCommand"/> is executed.
        ///// </summary>
        ///// <param name="sender">The sender of the event.</param>
        ///// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        //private void OnApplyForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        //{
        //    BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
        //    if (parameter != null)
        //    {
        //        switch (parameter.Action)
        //        {
        //            case ValueCommandParameterAction.Commit:
        //                tbScrollText.Foreground = parameter.Value;
        //                break;
        //            case ValueCommandParameterAction.Preview:
        //                tbScrollText.Foreground = parameter.PreviewValue;
        //                break;
        //        }
        //    }
        //    e.Handled = true;
        //}

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                TextDialog_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void ChangeTextColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                tbScrollText.Foreground = selectedColor;
                //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                //rssControl.RSSTitleForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
    }

}
