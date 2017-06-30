using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;

namespace FlightInfoModule
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
            DataContextChanged += PropertyPanel_DataContextChanged;
            cbRowStyle.ItemsSource = FlightStyles.GetFlightStyles;
            cbPanelAnimation.ItemsSource = PanelAnimations.GetPanelAnimations;
            Loaded += new RoutedEventHandler(PropertyPanel_Loaded);
        }

        void PropertyPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext == null) return;
            if (((ContentControl)DataContext).Content == null) return;
            var content = ((ContentControl)((ContentControl)DataContext).Content).Content as FlightContentControl;
            if (content == null) return;
            if (content.FlightRequest == null) return;

            if (!string.IsNullOrEmpty(content.FlightRequest.AirportCodeOrGuid))
                tbAirportCode.Text = content.FlightRequest.AirportCodeOrGuid;
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            DataContext = null;

            Content = null;
            if (grid != null)
            {
                grid.Child = null;

                grid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        private void ChangeColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var rectangle = (Rectangle)sender;

            SolidColorBrush startingColor = null;

            var flightContentControl =
                ((FlightContentControl)
                 ((ContentControl)((ContentControl)rectangle.DataContext).Content).Content).Content as IFlightPanel;

            if (flightContentControl != null)
                switch (rectangle.Name)
                {
                    case ("btnBg1Color"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.BackgroundColor1;
                        break;
                    case ("btnBg2Color"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.BackgroundColor2;
                        break;
                    case ("btnHdrBgColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.HeaderBackground;
                        break;
                    case ("btnHdrFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.HeaderForeground;
                        break;
                    case ("btnDestinationCityFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.DestinationCityForeground;
                        break;
                    case ("btnAirlineNameFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.AirlineNameForeground;
                        break;
                    case ("btnScheduleArrivalDepartureWidthFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.ScheduleArrivalDepartureForeground;
                        break;
                    case ("btnStatusFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.StatusForeground;
                        break;
                    case ("btnFlightNumberFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.FlightNumberForeground;
                        break;
                    case ("btnFlightGateFontColor"):
                        startingColor = (SolidColorBrush)flightContentControl.FlightTemplate.FlightGateForeground;
                        break;
                }

            ColorPickerDialog cPicker = new ColorPickerDialog();

            cPicker.StartingColor = startingColor.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);


                if (flightContentControl != null)
                    switch (rectangle.Name)
                    {
                        case ("btnBg1Color"):
                            flightContentControl.FlightTemplate.BackgroundColor1 = selectedColor;
                            break;
                        case ("btnBg2Color"):
                            flightContentControl.FlightTemplate.BackgroundColor2 = selectedColor;
                            break;
                        case ("btnHdrBgColor"):
                            flightContentControl.FlightTemplate.HeaderBackground = selectedColor;
                            break;
                        case ("btnHdrFontColor"):
                            flightContentControl.FlightTemplate.HeaderForeground = selectedColor;
                            break;
                        case ("btnDestinationCityFontColor"):
                            flightContentControl.FlightTemplate.DestinationCityForeground = selectedColor;
                            break;
                        case ("btnAirlineNameFontColor"):
                            flightContentControl.FlightTemplate.AirlineNameForeground = selectedColor;
                            break;
                        case ("btnScheduleArrivalDepartureWidthFontColor"):
                            flightContentControl.FlightTemplate.ScheduleArrivalDepartureForeground = selectedColor;
                            break;
                        case ("btnStatusFontColor"):
                            flightContentControl.FlightTemplate.StatusForeground = selectedColor;
                            break;
                        case ("btnFlightNumberFontColor"):
                            flightContentControl.FlightTemplate.FlightNumberForeground = selectedColor;
                            break;
                        case ("btnFlightGateFontColor"):
                            flightContentControl.FlightTemplate.FlightGateForeground = selectedColor;
                            break;
                    }

                rectangle.Fill = selectedColor;
                if (flightContentControl != null)
                    flightContentControl.RefreshCollection(true, true);
            }

            e.Handled = true;
        }

        private void cbShowHeader_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cbTouchscreen_Checked(object sender, RoutedEventArgs e)
        {
            //var checkBox = (CheckBox)sender;

            //if (checkBox.DataContext != null)
            //    if (((ContentControl)checkBox.DataContext).Content != null)
            //    {
            //        var content = ((ContentControl)((ContentControl)checkBox.DataContext).Content).Content;
            //        if (content != null)
            //        {
            //            var flightContentControl =
            //                ((FlightContentControl)content).Content as IFlightPanel;
            //            if (flightContentControl != null)
            //                flightContentControl.RefreshCollection(true);
            //        }
            //    }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (textBox.DataContext != null)
                if (((ContentControl)textBox.DataContext).Content != null)
                {
                    var content = ((ContentControl)((ContentControl)textBox.DataContext).Content).Content;
                    if (content != null)
                    {
                        var flightContentControl =
                            ((FlightContentControl)content).Content as IFlightPanel;
                        if (flightContentControl != null)
                            flightContentControl.RefreshCollection(true, true);
                    }
                }
        }

        private void cbRowStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (comboBox.DataContext != null)
                if (((ContentControl)comboBox.DataContext).Content != null)
                {
                    var content = ((ContentControl)((ContentControl)comboBox.DataContext).Content).Content as FlightContentControl;
                    if (content != null)
                    {
                        var flightStyle = comboBox.SelectedValue.ToString();
                        if (content.FlightStyle != flightStyle)
                        {
                            content.FlightStyle = flightStyle;
                            var flightContentControl =
                            content.Content as IFlightPanel;
                            flightContentControl.RefreshItemsTemplate();
                        }
                    }
                }
        }

        private void cbPanelAnimation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (comboBox.DataContext != null)
                if (((ContentControl)comboBox.DataContext).Content != null)
                {
                    var content = ((ContentControl)((ContentControl)comboBox.DataContext).Content).Content as FlightContentControl;
                    if (content != null)
                    {
                        var panelAnimation = comboBox.SelectedValue.ToString();
                        if (content.PanelAnimation != panelAnimation)
                        {
                            content.PanelAnimation = panelAnimation;
                            var flightContentControl =
                            content.Content as IFlightPanel;
                            flightContentControl.PanelAnimation = panelAnimation;
                        }
                    }
                }
        }

        private void AirlineCodeChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            if (textBox.DataContext == null) return;
            if (((ContentControl)textBox.DataContext).Content == null) return;
            var content = ((ContentControl)((ContentControl)textBox.DataContext).Content).Content as FlightContentControl;
            if (content == null) return;
            if (content.FlightRequest == null) return;
            if (content.FlightRequest.AirportCodeOrGuid != textBox.Text)
                content.FlightRequest.AirportCodeOrGuid = textBox.Text;
        }
    }
}
