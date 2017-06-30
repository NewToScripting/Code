using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Inspire;
using Inspire.Commands;

namespace FilterModule
{
    /// <summary>
    /// Interaction logic for AlphabitFilter.xaml
    /// </summary>
    public partial class AlphabitFilter : IFilter
    {
        readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        readonly DispatcherTimer _itemChangeTimer = new DispatcherTimer();
        readonly ListBox _itemContainer;

        private readonly string[] alphaList = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private int[] numberList = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private string[] timeList = new string[] { "12:00am", "1:00am", "2:00am", "3:00am", "4:00am", "5:00am", "6:00am", "7:00am", "8:00am", "9:00am", "10:00am", "11:00am", "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm", "6:00pm", "7:00pm", "8:00pm", "9:00pm", "10:00pm", "11:00pm" };

        public string GuidToFilterOn { get; set; }

        public FontFamily SelectedFontFamily
        {
            get { return (FontFamily)GetValue(SelectedFontFamilyProperty); }
            set { SetValue(SelectedFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedFontFamilyProperty =
            DependencyProperty.Register("SelectedFontFamily", typeof(FontFamily), typeof(AlphabitFilter), new UIPropertyMetadata(new FontFamily("Arial")));

        
        public SolidColorBrush CharacterForeground
        {
            get { return (SolidColorBrush)GetValue(CharacterForegroundProperty); }
            set { SetValue(CharacterForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CharacterForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CharacterForegroundProperty =
            DependencyProperty.Register("CharacterForeground", typeof(SolidColorBrush), typeof(AlphabitFilter), new UIPropertyMetadata(Brushes.Black));


        public SolidColorBrush SelectedCharacterBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedCharacterBrushProperty); }
            set { SetValue(SelectedCharacterBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCharacterBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCharacterBrushProperty =
            DependencyProperty.Register("SelectedCharacterBrush", typeof(SolidColorBrush), typeof(AlphabitFilter), new UIPropertyMetadata(Brushes.White));


        public SolidColorBrush GlowForeground
        {
            get { return (SolidColorBrush)GetValue(GlowForegroundProperty); }
            set { SetValue(GlowForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GlowForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlowForegroundProperty =
            DependencyProperty.Register("GlowForeground", typeof(SolidColorBrush), typeof(AlphabitFilter), new UIPropertyMetadata(Brushes.Aqua));


        public AlphabitFilter(string guidToFilterOn, SolidColorBrush characterForeground, SolidColorBrush glowForeground, SolidColorBrush selectedCharForeground, FontFamily charFontFamily)
        {
            InitializeComponent();

            CharacterForeground = characterForeground;
            SelectedFontFamily = charFontFamily;
            SelectedCharacterBrush = selectedCharForeground;
            GlowForeground = glowForeground;


            GuidToFilterOn = guidToFilterOn;

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _itemChangeTimer.Tick += ItemChangeTimerTick;

            _itemContainer = Content as ListBox;
            _itemContainer.ItemsSource = alphaList;
        }

        void ItemChangeTimerTick(object sender, EventArgs e)
        {
            _itemChangeTimer.Stop();
            var selItem = _itemContainer.SelectedItem;

            if (selItem != null)
            {
                var itemToFilterOn = RoutingHelper.FindControl(GuidToFilterOn);
                FrameworkElement filterItem = null;

                if (itemToFilterOn != null)
                    if (((ContentControl)itemToFilterOn).Content is IFilterable)
                        filterItem = ((ContentControl) itemToFilterOn).Content as FrameworkElement;

                InspireCommands.FilterListCommand.Execute(
                    new KeyValuePair<string, IEnumerable<object>>(selItem.ToString(), alphaList), filterItem);
            }
        }

        void DispatcherTimerTick(object sender, EventArgs e)
        {
            _itemContainer.SelectedItem = null;
            _dispatcherTimer.Stop();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _dispatcherTimer.Interval = TimeSpan.FromSeconds(4.0);
                _dispatcherTimer.Start();

                _itemChangeTimer.Interval = TimeSpan.FromSeconds(.8);
                _itemChangeTimer.Start();

                InspireCommands.RestartTimerCommand.Execute(null, InspireApp.CurrentPlayerCanvas);
            }
        }

        private void Bd_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _itemContainer.SelectedIndex = _itemContainer.Items.IndexOf(((ContentPresenter) sender).Content);
        }

        private void ListBox_TouchDown(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

    }
}
