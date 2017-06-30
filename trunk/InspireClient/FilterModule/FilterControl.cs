using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;

namespace FilterModule
{
    public class FilterControl : ContentControl, IWeakEventListener, IDisposable, IFilter
    {
        private bool _isLoaded;

        private string _guidToFilterOn;
        public string GuidToFilterOn
        {
            get { return _guidToFilterOn; }
            set
            {
                _guidToFilterOn = value;
                if (Content is IFilter)
                    ((IFilter) Content).GuidToFilterOn = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FontFamily SelectedFontFamily
        {
            get { return (FontFamily)GetValue(SelectedFontFamilyProperty); }
            set { SetValue(SelectedFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedFontFamilyProperty =
            DependencyProperty.Register("SelectedFontFamily", typeof(FontFamily), typeof(FilterControl), new UIPropertyMetadata(new FontFamily("Arial")));

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SolidColorBrush CharacterForeground
        {
            get { return (SolidColorBrush)GetValue(CharacterForegroundProperty); }
            set { SetValue(CharacterForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CharacterForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CharacterForegroundProperty =
            DependencyProperty.Register("CharacterForeground", typeof(SolidColorBrush), typeof(FilterControl), new UIPropertyMetadata(Brushes.Black));

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SolidColorBrush SelectedCharacterBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedCharacterBrushProperty); }
            set { SetValue(SelectedCharacterBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCharacterBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCharacterBrushProperty =
            DependencyProperty.Register("SelectedCharacterBrush", typeof(SolidColorBrush), typeof(FilterControl), new UIPropertyMetadata(Brushes.White));

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SolidColorBrush GlowForeground
        {
            get { return (SolidColorBrush)GetValue(GlowForegroundProperty); }
            set { SetValue(GlowForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GlowForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlowForegroundProperty =
            DependencyProperty.Register("GlowForeground", typeof(SolidColorBrush), typeof(FilterControl), new UIPropertyMetadata(Brushes.Aqua));

        public FilterControl()
        {
            LoadedEventManager.AddListener(this, this);
        }

        public FilterControl(string guidToFilterOn, SolidColorBrush characterForeground, SolidColorBrush glowForeground, SolidColorBrush selectedCharForeground, FontFamily charFontFamily)
            : this()
        {
            GuidToFilterOn = guidToFilterOn;
            CharacterForeground = characterForeground;
            GlowForeground = glowForeground;
            SelectedCharacterBrush = selectedCharForeground;
            SelectedFontFamily = charFontFamily;
        }


        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                FilterControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                if (Content is IDisposable)
                    ((IDisposable)Content).Dispose();
                ClearValue(ContentProperty);
            }));
        }

        private void FilterControl_Loaded(object sender, EventArgs eventArgs)
        {
            if (!_isLoaded)
            {
                Content = new AlphabitFilter(GuidToFilterOn, CharacterForeground, GlowForeground, SelectedCharacterBrush, SelectedFontFamily);
                _isLoaded = true;
            }
        }
    }
}
