using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire;
using Inspire.AnimationLibrary;

namespace EventsModule
{
    public class EventTextBlock : TextBlock , INotifyPropertyChanged
    {
        /// <summary>
        /// The IsHeader content property.
        /// </summary>
        public static readonly DependencyProperty IsHeaderProperty =
            DependencyProperty.Register("IsHeader", typeof(bool), typeof(TextBlock),
                                        new PropertyMetadata(new PropertyChangedCallback(IsHeader_Changed)));

        public bool IsHeader
        {
            get { return (bool)GetValue(IsHeaderProperty); }
            set { SetValue(IsHeaderProperty, value); }
        }

        public EventTextBlock()
        {
            FontSize = 14;
            Foreground = Brushes.Black;
            Width = 150;
           // Height = 50;
            Margin = new Thickness(2,5,2,5);
            TextWrapping = TextWrapping.Wrap;

            
            
            VerticalAlignment = VerticalAlignment.Bottom;

            RenderTransformOrigin = new Point(0.5, 0.5);

            var trGrp = new TransformGroup();

            var scaleTransform = new ScaleTransform(1, 1);

            trGrp.Children.Add(scaleTransform);

            var skewTransform = new SkewTransform(0, 0);
            trGrp.Children.Add(skewTransform);

            var rotateTransform = new RotateTransform(0);
            trGrp.Children.Add(rotateTransform);

            var translateTransform = new TranslateTransform(0, 0);
            trGrp.Children.Add(translateTransform);

            RenderTransform = trGrp;
        }

        public EventTextBlock(string fieldName): this()
        {
            Text = fieldName;
            if (fieldName == "DirectionalImage" || fieldName == "GroupLogo")
                Width = 50;
        }

        public EventTextBlock(string text, TextBlock textBlock) : this()
        {
            //Height = textBlock.Height;
            Width = textBlock.Width;
            Visibility = textBlock.Visibility;
            IsHitTestVisible = false;
            TextAlignment = textBlock.TextAlignment;
            Text = text;
            Foreground = textBlock.Foreground;
            TextWrapping = textBlock.TextWrapping;
            FontWeight = textBlock.FontWeight;
            FontSize = textBlock.FontSize;
            FontFamily = textBlock.FontFamily;
            FontStyle = textBlock.FontStyle;
            TextDecorations = textBlock.TextDecorations;
            if (Visibility == Visibility.Collapsed)
                Margin = new Thickness(0);
            else
            {
                Margin = textBlock.Margin;
                if (textBlock.Tag != null)
                {
                    Tag = textBlock.Tag;

                    AnimationManager.ApplyAnimation(this, textBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                }
            }
        }

        /// <summary>
        /// Updates the content clipping.
        /// </summary>
        /// <param name="dependencyObject">The clipping border.</param>
        /// <param name="eventArgs">Dependency Property Changed Event Args</param>
        private static void IsHeader_Changed(DependencyObject dependencyObject,
                                                DependencyPropertyChangedEventArgs eventArgs)
        {
            var clippingBorder = (EventTextBlock)dependencyObject;
            clippingBorder.IsHeader = (bool)eventArgs.NewValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
