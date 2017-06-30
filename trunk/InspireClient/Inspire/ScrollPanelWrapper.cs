using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Inspire
{
    public class ScrollPanelWrapper : ScrollViewer
    {
        private bool _isScrolling = false;
        //private Point mouseDragStartPoint;
        private TouchPoint mouseDragStartPoint;
        private DateTime mouseDownTime;
        //private Point scrollStartOffset;
        private Point scrollStartOffset;
        private const double DECELERATION = 980;
        private const double SPEED_RATIO = .5;
        private const double MAX_VELOCITY = 2500;
        private const double MIN_DISTANCE = 0;
        private const double TIME_THRESHOLD = .4;

        public static readonly DependencyProperty ScrollOffsetProperty = DependencyProperty.Register("ScrollOffset", typeof(double), typeof(ScrollPanelWrapper), new UIPropertyMetadata(ScrollOffsetValueChanged));
        public double ScrollOffset
        {
            get { return (double)GetValue(ScrollOffsetProperty); }

            set { SetValue(ScrollOffsetProperty, value); }
        }

        private static void ScrollOffsetValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollPanelWrapper myClass = (ScrollPanelWrapper)d;
            myClass.ScrollToVerticalOffset((double)e.NewValue);
        }

        private void Scroll(double startY, double endY, DateTime startTime, DateTime endTime)
        {
            double timeScrolled = endTime.Subtract(startTime).TotalSeconds;

            //if scrolling slowly, don't scroll with force
            if (timeScrolled < TIME_THRESHOLD)
            {
                double distanceScrolled = Math.Max(Math.Abs(endY - startY), MIN_DISTANCE);

                double velocity = distanceScrolled / timeScrolled;
                velocity = Math.Min(MAX_VELOCITY, velocity);
                int direction = 1;

                if (endY > startY)
                {
                    direction = -1;
                }

                double timeToScroll = (velocity / DECELERATION) * SPEED_RATIO;

                double distanceToScroll = ((velocity * velocity) / (2 * DECELERATION)) * SPEED_RATIO;

                if (distanceToScroll.Equals(double.NaN))
                    distanceToScroll = 0.0;

                if (timeToScroll.Equals(double.NaN))
                    timeToScroll = 0;

                DoubleAnimation scrollAnimation  = new DoubleAnimation();
                scrollAnimation.From = VerticalOffset;
                scrollAnimation.To = VerticalOffset + distanceToScroll * direction;
                scrollAnimation.DecelerationRatio = .9;
                scrollAnimation.SpeedRatio = SPEED_RATIO;
                scrollAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, Convert.ToInt32(timeToScroll), 0));
                scrollAnimation.Completed += new EventHandler(scrollAnimation_Completed);
                this.BeginAnimation(ScrollOffsetProperty, scrollAnimation);
                _isScrolling = true;
            }
        }

        void scrollAnimation_Completed(object sender, EventArgs e)
        {
            _isScrolling = false;
        }

        protected override void OnPreviewTouchDown(TouchEventArgs e)
        {
            if (_isScrolling)
                StopScroll(e);

            mouseDragStartPoint = e.GetTouchPoint(this);// e.GetPosition(this);
            mouseDownTime = DateTime.Now;
            scrollStartOffset.X = HorizontalOffset;
            scrollStartOffset.Y = VerticalOffset;

            // Update the cursor if scrolling is possible 
            this.Cursor = (ExtentWidth > ViewportWidth) ||
                (ExtentHeight > ViewportHeight) ?
                Cursors.ScrollAll : Cursors.Arrow;

            this.CaptureMouse();
            base.OnPreviewTouchDown(e);
        }

        protected override void OnPreviewTouchMove(TouchEventArgs e)
        {
            if (this.IsMouseCaptured)
            {
                // Get the new mouse position. 
                TouchPoint mouseDragCurrentPoint = e.GetTouchPoint(this);// e.GetPosition(this);

                // Determine the new amount to scroll. 
                Point delta = new Point(
                    (mouseDragCurrentPoint.Position.X > this.mouseDragStartPoint.Position.X) ?
                    -(mouseDragCurrentPoint.Position.X - this.mouseDragStartPoint.Position.X) :
                    (this.mouseDragStartPoint.Position.X - mouseDragCurrentPoint.Position.X),
                    (mouseDragCurrentPoint.Position.Y > this.mouseDragStartPoint.Position.Y) ?
                    -(mouseDragCurrentPoint.Position.Y - this.mouseDragStartPoint.Position.Y) :
                    (this.mouseDragStartPoint.Position.Y - mouseDragCurrentPoint.Position.Y));

                // Scroll to the new position. 
                ScrollToHorizontalOffset(this.scrollStartOffset.X + delta.X);
                ScrollToVerticalOffset(this.scrollStartOffset.Y + delta.Y);
            }
            base.OnPreviewTouchMove(e);
        }

        private void StopScroll(TouchEventArgs mouseEventArgs)
        {
            TouchPoint mouseDragCurrentPoint = mouseEventArgs.GetTouchPoint(this);
            Scroll(mouseDragCurrentPoint.Position.Y, mouseDragCurrentPoint.Position.Y, DateTime.Now, DateTime.Now);
        }

        protected override void OnPreviewTouchUp(TouchEventArgs e)
        {
            if (this.IsMouseCaptured)
            {
                //this.Cursor = Cursors.Arrow;
                this.ReleaseMouseCapture();
            }
            if(mouseDragStartPoint != null)
                Scroll(mouseDragStartPoint.Position.Y, e.GetTouchPoint(this).Position.Y, mouseDownTime, DateTime.Now);

            base.OnPreviewTouchUp(e);
        }


        //#region Mouse Overrides
        //protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        //{
        //    if (_isScrolling)
        //        StopScroll(e);

        //    mouseDragStartPoint = e.GetPosition(this);
        //    mouseDownTime = DateTime.Now;
        //    scrollStartOffset.X = HorizontalOffset;
        //    scrollStartOffset.Y = VerticalOffset;

        //    // Update the cursor if scrolling is possible 
        //    this.Cursor = (ExtentWidth > ViewportWidth) ||
        //        (ExtentHeight > ViewportHeight) ?
        //        Cursors.ScrollAll : Cursors.Arrow;

        //    this.CaptureMouse();
        //    base.OnPreviewMouseDown(e);
        //}

        //protected override void OnPreviewMouseMove(MouseEventArgs e)
        //{
        //    if (this.IsMouseCaptured)
        //    {
        //        // Get the new mouse position. 
        //        Point mouseDragCurrentPoint = e.GetPosition(this);

        //        // Determine the new amount to scroll. 
        //        Point delta = new Point(
        //            (mouseDragCurrentPoint.X > this.mouseDragStartPoint.X) ?
        //            -(mouseDragCurrentPoint.X - this.mouseDragStartPoint.X) :
        //            (this.mouseDragStartPoint.X - mouseDragCurrentPoint.X),
        //            (mouseDragCurrentPoint.Y > this.mouseDragStartPoint.Y) ?
        //            -(mouseDragCurrentPoint.Y - this.mouseDragStartPoint.Y) :
        //            (this.mouseDragStartPoint.Y - mouseDragCurrentPoint.Y));

        //        // Scroll to the new position. 
        //        ScrollToHorizontalOffset(this.scrollStartOffset.X + delta.X);
        //        ScrollToVerticalOffset(this.scrollStartOffset.Y + delta.Y);
        //    }
        //    base.OnPreviewMouseMove(e);
        //}

        //private void StopScroll(MouseEventArgs mouseEventArgs)
        //{
        //    Point mouseDragCurrentPoint = mouseEventArgs.GetPosition(this);
        //    Scroll(mouseDragCurrentPoint.Y, mouseDragCurrentPoint.Y, DateTime.Now, DateTime.Now);
        //}

        //protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        //{
        //    if (this.IsMouseCaptured)
        //    {
        //        this.Cursor = Cursors.Arrow;
        //        this.ReleaseMouseCapture();
        //    }

        //    Scroll(mouseDragStartPoint.Y, e.GetPosition(this).Y, mouseDownTime, DateTime.Now);

        //    base.OnPreviewMouseUp(e);
        //}

        //#endregion
    }
}
