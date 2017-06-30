using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace DateTimeModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable, IWeakEventListener //, IPropertyPanel
    {

        private readonly int[] fontSizes = { 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72, 80, 84, 90, 96, 104, 110, 118 };

        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;

            cbFontSize.ItemsSource = fontSizes;

            LoadedEventManager.AddListener(this, this);

            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                propBase.SetDataContext();
                if (InspireApp.SelectedContext == null) return;
                fontStyler2.DataContext = ((ClockControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content).Content;
                SetComboBoxes();
            }
            catch (Exception)
            {
                // dont error
            }
            
        }

        void PropertyPanel_Loaded(object sender, EventArgs e)
        {
            if (cbFormat.ItemsSource == null && ((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content != null)
            {
                cbFormat.ItemsSource = ((ClockControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content).GetFormats();
                fontStyler2.DataContext = ((ClockControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content).Content;
                SetComboBoxes();
            }
        }

        private void SetComboBoxes()
        {
            ClockControl clockControl = (ClockControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content;
            if (clockControl != null)
                cbFormat.SelectedIndex = clockControl.DateTimeFormat;
        }


        private void cbFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClockControl clockControl = (ClockControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content;
            if (clockControl != null) clockControl.DateTimeFormat = cbFormat.SelectedIndex;
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
                ClockControl clockControl = (ClockControl)((ContentControl)((ContentControl)(((Rectangle)(sender)).DataContext)).Content).Content;
                if (clockControl != null)
                {
                    SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                    ((Clock) clockControl.Content).Foreground = selectedColor;
                    //RSSControl rssControl = (RSSControl)rssContentControl.Content;
                    //rssControl.RSSTitleForeground = selectedColor;
                    ((Rectangle) (sender)).Fill = selectedColor;
                }
            }
        }

        private void tbTitleFontSize_DropDownClosed(object sender, EventArgs e)
        {
            ClockControl clockControl = (ClockControl)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            if(clockControl != null)
                ((Clock)clockControl.Content).FontSize = Convert.ToInt32(((ComboBox)(sender)).Text);
        }

        private void titleFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            ClockControl clockControl = (ClockControl)((ContentControl)((ContentControl)(((ComboBox)(sender)).DataContext)).Content).Content;
            if (clockControl != null)
                ((Clock)clockControl.Content).FontFamily = (FontFamily)((ComboBox)sender).SelectedItem;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (propBase != null)
                propBase.Dispose();
            propBase = null;

            BindingOperations.ClearAllBindings(cbFormat);
            BindingOperations.ClearAllBindings(cbFontSize);

            if (Content != null)
                Content = null;
            if (PART_sliderGrid != null)
            {
                if (PART_sliderGrid.Child != null)
                    PART_sliderGrid.Child = null;

                PART_sliderGrid = null;
            }
        }

        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                PropertyPanel_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        //#region IPropertyPanel Members

        //public static readonly RoutedEvent HidePropertiesEvent = EventManager.RegisterRoutedEvent("HideProperties", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(FrameworkElement));

        //// Provide CLR accessors for the event
        //public event RoutedEventHandler HideProperties
        //{
        //    add { AddHandler(HidePropertiesEvent, value); }
        //    remove { RemoveHandler(HidePropertiesEvent, value); }
        //}


        //public void HidePropertyPanel()
        //{
        //    RaiseEvent(new RoutedEventArgs(HidePropertiesEvent));
        //}

        //#endregion
    }
}
