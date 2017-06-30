using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Inspire;
using Inspire.AnimationLibrary;

namespace EventsModule
{
    public class LogoTextBlock : Image
    {
        public LogoTextBlock()
        {
            // Set the bitmap scaling mode for the image to render faster.
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.LowQuality);

            Width = 50;

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

        public LogoTextBlock(string logo, FrameworkElement textBlock) :this()
        {
            try
            {
                if(logo != null)
                    Source = new BitmapImage(new Uri(logo));
                Width = textBlock.Width;

                if(textBlock.Visibility != Visibility.Collapsed)
                    if (textBlock.Tag != null)
                        AnimationManager.ApplyAnimation(this, textBlock.Tag.ToString(), InspireApp.GetCanvasSize());

            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
