using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Inspire
{
    /// <summary>
    /// Interaction logic for FontStyler.xaml
    /// </summary>
    public partial class FontStyler
    {
        public FontStyler()
        {
            InitializeComponent();
            //Loaded += FontStyler_Loaded;
            DataContextChanged += new DependencyPropertyChangedEventHandler(FontStyler_DataContextChanged);
        }

        void FontStyler_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is TextBlock)
            {
                tglBold.IsChecked = ((TextBlock)DataContext).FontWeight == FontWeights.Bold;
                tglUnd.IsChecked = ((TextBlock)DataContext).TextDecorations == TextDecorations.Underline;
                tglItl.IsChecked = ((TextBlock)DataContext).FontStyle == FontStyles.Italic;
                RaiseToggleChangedEvent();
            }
            else if (DataContext is TextBox)
            {
                tglBold.IsChecked = ((TextBox)DataContext).FontWeight == FontWeights.Bold;
                tglUnd.IsChecked = ((TextBox)DataContext).TextDecorations == TextDecorations.Underline;
                tglItl.IsChecked = ((TextBox)DataContext).FontStyle == FontStyles.Italic;
                RaiseToggleChangedEvent();
            }
        }

        //void FontStyler_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext is TextBlock)
        //    {
        //        tglBold.IsChecked = ((TextBlock)DataContext).FontWeight == FontWeights.Bold;
        //        tglUnd.IsChecked = ((TextBlock)DataContext).TextDecorations == TextDecorations.Underline;
        //        tglItl.IsChecked = ((TextBlock)DataContext).FontStyle == FontStyles.Italic;
        //    }
        //    else if (DataContext is TextBox)
        //    {
        //        tglBold.IsChecked = ((TextBox)DataContext).FontWeight == FontWeights.Bold;
        //        tglUnd.IsChecked = ((TextBox)DataContext).TextDecorations == TextDecorations.Underline;
        //        tglItl.IsChecked = ((TextBox)DataContext).FontStyle == FontStyles.Italic;
        //    }
        //}

        public static readonly RoutedEvent ToggleChangedEvent = EventManager.RegisterRoutedEvent(
            "ToggleChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FontStyler));

        // Provide CLR accessors for the event
        public event RoutedEventHandler ToggleChanged
        {
            add { AddHandler(ToggleChangedEvent, value); }
            remove { RemoveHandler(ToggleChangedEvent, value); }
        }

        // This method raises the Tap event
        void RaiseToggleChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ToggleChangedEvent);
            RaiseEvent(newEventArgs);
        }


        private void ToggleBold_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TextBlock)
            {
                if (((TextBlock)DataContext).FontWeight != FontWeights.Bold)
                {
                    ((TextBlock)DataContext).FontWeight = FontWeights.Bold;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBlock)DataContext).FontWeight = FontWeights.Normal;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            else if (DataContext is TextBox)
            {
                if (((TextBox)DataContext).FontWeight != FontWeights.Bold)
                {
                    ((TextBox)DataContext).FontWeight = FontWeights.Bold;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBox)DataContext).FontWeight = FontWeights.Normal;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            e.Handled = true;
        }

        private void ToggleUnderline_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TextBlock)
            {
                if (((TextBlock)DataContext).TextDecorations != TextDecorations.Underline)
                {
                    ((TextBlock)DataContext).TextDecorations = TextDecorations.Underline;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBlock)DataContext).TextDecorations = null;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            else if (DataContext is TextBox)
            {
                if (((TextBox)DataContext).TextDecorations != TextDecorations.Underline)
                {
                    ((TextBox)DataContext).TextDecorations = TextDecorations.Underline;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBox)DataContext).TextDecorations = null;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            e.Handled = true;
        }

        private void ToggleItalic_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TextBlock)
            {
                if (((TextBlock)DataContext).FontStyle != FontStyles.Italic)
                {
                    ((TextBlock)DataContext).FontStyle = FontStyles.Italic;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBlock)DataContext).FontStyle = FontStyles.Normal;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            else if (DataContext is TextBox)
            {
                if (((TextBox)DataContext).FontStyle != FontStyles.Italic)
                {
                    ((TextBox)DataContext).FontStyle = FontStyles.Italic;
                    ((ToggleButton)e.OriginalSource).IsChecked = true;
                    RaiseToggleChangedEvent();
                }
                else
                {
                    ((TextBox)DataContext).FontStyle = FontStyles.Normal;
                    ((ToggleButton)e.OriginalSource).IsChecked = false;
                    RaiseToggleChangedEvent();
                }
            }
            e.Handled = true;
        }
    }
}
