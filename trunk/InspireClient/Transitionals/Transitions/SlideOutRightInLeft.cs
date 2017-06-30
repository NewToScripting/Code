using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Transitionals.Controls;

namespace Transitionals.Transitions
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public class SlideOutRightInLeft : Transition
    {
        static SlideOutRightInLeft()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(SlideOutRightInLeft), new FrameworkPropertyMetadata(true));
        }

        public SlideOutRightInLeft()
        {
            this.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            this.StartPoint = new Point(1, 0);
        }

        public Duration Duration { get; set; }

        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point), typeof(SlideOutRightInLeft), new UIPropertyMetadata(new Point()));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "EndPoint")]
        public Point EndPoint
        {
            get { return (Point)GetValue(EndPointProperty); }
            set { SetValue(EndPointProperty, value); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "EndPoint")]
        public static readonly DependencyProperty EndPointProperty =
            DependencyProperty.Register("EndPoint", typeof(Point), typeof(SlideOutRightInLeft), new UIPropertyMetadata(new Point()));


        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            newContent.Visibility = Visibility.Collapsed;

            var tt = new TranslateTransform(EndPoint.X * transitionElement.ActualWidth, EndPoint.Y * transitionElement.ActualHeight);

            oldContent.RenderTransform = tt;


            DoubleAnimation da = new DoubleAnimation(StartPoint.X * transitionElement.ActualWidth, Duration);
            da.AccelerationRatio = 0.5;
            tt.BeginAnimation(TranslateTransform.XProperty, da);

            da.AccelerationRatio = 0.5;
            da.To = StartPoint.Y * transitionElement.ActualHeight;
            da.Completed += delegate
            {
                SlideInNew(transitionElement, oldContent, newContent);
            };
            tt.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void SlideInNew(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            oldContent.Visibility = Visibility.Collapsed;
            newContent.Visibility = Visibility.Visible;

            TranslateTransform tt = new TranslateTransform(StartPoint.X * - transitionElement.ActualWidth, StartPoint.Y * transitionElement.ActualHeight);

            newContent.RenderTransform = tt;

            DoubleAnimation da = new DoubleAnimation(EndPoint.X * transitionElement.ActualWidth, Duration);
            da.DecelerationRatio = 0.5;
            tt.BeginAnimation(TranslateTransform.XProperty, da);

            da.DecelerationRatio = 0.5;
            da.To = EndPoint.Y * transitionElement.ActualHeight;
            da.Completed += delegate
            {
                EndTransition(transitionElement, oldContent, newContent);
                oldContent.Visibility = Visibility.Visible;
            };
            tt.BeginAnimation(TranslateTransform.YProperty, da);
        }

        protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            newContent.ClearValue(ContentPresenter.RenderTransformProperty);
            oldContent.ClearValue(ContentPresenter.RenderTransformProperty);
        }
    }
}


