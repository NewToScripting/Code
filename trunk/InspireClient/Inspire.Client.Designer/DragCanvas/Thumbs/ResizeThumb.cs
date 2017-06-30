using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DragCanvas.Thumbs
{
    public class ResizeThumb : Thumb
    {
        private Point transformOrigin;
        private double angle;
        private double skewX;
        private double skewY;
        private double scaleX;
        private double scaleY;
        private Adorner adorner;
        private Canvas canvas;

        private ContentControl designerItem;

        private Control parentItem;
        private Control ParentItem
        {
            get
            {
                if (parentItem == null)
                {
                    parentItem = DataContext as Control;
                }
                return parentItem;
            }
        }

        public ResizeThumb()
        {
            DragStarted += ResizeThumb_DragStarted;
            DragDelta += ResizeThumb_DragDelta;
            DragCompleted += (ResizeThumb_DragCompleted);
        }

        void ResizeThumb_DragStarted(object sender, DragStartedEventArgs e)
        {

            this.designerItem = this.DataContext as ContentControl;

            if (ParentItem != null)
            {
                transformOrigin = ParentItem.RenderTransformOrigin;

                TransformGroup transformGroup = ParentItem.RenderTransform as TransformGroup;

                SkewTransform skewTransform = null; // transformGroup.Children[0] as SkewTransform;

                RotateTransform rotateTransform = null; // transformGroup.Children[1] as RotateTransform;

                ScaleTransform scaleTransform = null;

                if (transformGroup != null)
                    foreach (var child in transformGroup.Children)
                    {
                        switch (child.GetType().Name)
                        {
                            case ("RotateTransform"):
                                rotateTransform = child as RotateTransform;
                                break;
                            case ("SkewTransform"):
                                skewTransform = child as SkewTransform;
                                break;
                            case ("ScaleTransform"):
                                scaleTransform = child as ScaleTransform;
                                break;
                        }
                    }

                if (scaleTransform != null)
                {
                    scaleX = scaleTransform.ScaleX;
                    scaleY = scaleTransform.ScaleY;
                }
                if (rotateTransform != null)
                    angle = rotateTransform.Angle * Math.PI / 180.0;   //convert degrees to radians
                else
                    angle = 0.0d;

                if (skewTransform != null)
                {
                    skewX = skewTransform.AngleX; // *Math.PI / 180.0;
                    skewY = skewTransform.AngleY; // *Math.PI / 180.0;
                }
                else
                {
                    skewX = 0.0d;
                    skewY = 0.0d;
                }

                if (canvas != null)
                {
                    this.canvas = VisualTreeHelper.GetParent(designerItem) as Canvas;

                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.canvas);
                    if (adornerLayer != null)
                    {
                        this.adorner = new SizeAdorner(this.designerItem);
                        adornerLayer.Add(this.adorner);
                    }
                }
            }
        }

        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (ParentItem != null)
            {
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        if(scaleY == -1)
                            MoveTop(e);
                        else
                            MoveBottom(e);
                        break;
                    case VerticalAlignment.Top:
                        if(scaleY == -1)
                            MoveBottom(e);
                        else
                            MoveTop(e);
                        break;
                    default:
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        if(scaleX == -1)
                            MoveRight(e);
                        else
                            MoveLeft(e);
                        break;
                    case HorizontalAlignment.Right:
                        if(scaleX == -1)
                            MoveLeft(e);
                        else
                            MoveRight(e);
                        break;
                    default:
                        break;
                }
            }
            e.Handled = true;
        }

        private void MoveRight(DragDeltaEventArgs e)
        {
            double deltaHorizontal;
            deltaHorizontal = Math.Min(-e.HorizontalChange, ParentItem.ActualWidth - ParentItem.MinWidth);
            deltaHorizontal = deltaHorizontal * scaleX;
            Canvas.SetTop(ParentItem, Canvas.GetTop(ParentItem) - transformOrigin.X * deltaHorizontal * Math.Sin(angle)); 
            Canvas.SetLeft(ParentItem, Canvas.GetLeft(ParentItem) + (deltaHorizontal * transformOrigin.X * (1 - Math.Cos(angle)))); 
            if (ParentItem.Width != double.NaN)
                ParentItem.Width = ParentItem.ActualWidth;
            ParentItem.Width -= deltaHorizontal;
        }

        private void MoveLeft(DragDeltaEventArgs e)
        {
            double deltaHorizontal;
            deltaHorizontal = Math.Min(e.HorizontalChange, ParentItem.ActualWidth - ParentItem.MinWidth);
            deltaHorizontal = deltaHorizontal * scaleX;
            Canvas.SetTop(ParentItem, Canvas.GetTop(ParentItem) + deltaHorizontal * Math.Sin(angle) - transformOrigin.X * deltaHorizontal * Math.Sin(angle)); //TODO: BUGGY Fix this
            Canvas.SetLeft(ParentItem, Canvas.GetLeft(ParentItem) + deltaHorizontal * Math.Cos(angle) + (transformOrigin.X * deltaHorizontal * (1 - Math.Cos(angle)))); //TODO: BUGGY Fix this
            if (ParentItem.Width != double.NaN)
                ParentItem.Width = ParentItem.ActualWidth;
            ParentItem.Width -= deltaHorizontal;
        }

        private void MoveTop(DragDeltaEventArgs e)
        {
            double deltaVertical;
            deltaVertical = Math.Min(e.VerticalChange, ParentItem.ActualHeight - ParentItem.MinHeight);
            deltaVertical = deltaVertical*scaleY;
            double originalTTop = Canvas.GetTop(ParentItem);
            double topT = originalTTop + deltaVertical*Math.Cos(-angle) +
                          (transformOrigin.Y * deltaVertical * (1 - Math.Cos(-angle)));
            //topT = topT + (deltaVertical*scaleY);
            Canvas.SetTop(ParentItem, topT); //TODO: BUGGY Fix this
            Canvas.SetLeft(ParentItem, Canvas.GetLeft(ParentItem) + deltaVertical * Math.Sin(-angle) - (transformOrigin.Y * deltaVertical * Math.Sin(-angle))); //TODO: BUGGY Fix this
            if (ParentItem.Height != double.NaN)
                ParentItem.Height = ParentItem.ActualHeight;
            ParentItem.Height -= deltaVertical;
        }

        private void MoveBottom(DragDeltaEventArgs e)
        {
            double deltaVertical;
            deltaVertical = Math.Min(-e.VerticalChange, ParentItem.ActualHeight - ParentItem.MinHeight);
            deltaVertical = deltaVertical * scaleY;
            double originalBTop = Canvas.GetTop(ParentItem);
            double angleOffset = 1 - Math.Cos(-angle);
            double skewOffset = 1 - Math.Cos(-skewY);
            double topB = originalBTop + (transformOrigin.Y * deltaVertical * (angleOffset + skewOffset));
                        
            Canvas.SetTop(ParentItem, topB);           //TODO: BUGGY Fix this
            Canvas.SetLeft(ParentItem, Canvas.GetLeft(ParentItem) - deltaVertical * transformOrigin.Y * Math.Sin(-angle) - deltaVertical * transformOrigin.Y * Math.Sin(-skewY)); //TODO: BUGGY Fix this
            if (ParentItem.Height != double.NaN)
                ParentItem.Height = ParentItem.ActualHeight;
            ParentItem.Height -= deltaVertical;
        }

        private void ResizeThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (this.adorner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.canvas);
                if (adornerLayer != null)
                {
                    adornerLayer.Remove(this.adorner);
                }

                this.adorner = null;
            }
        }
    }
}