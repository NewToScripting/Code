using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Inspire.Client.Designer.DragCanvas.Thumbs
{
    public class RotateThumb : Thumb
    {
        double initialAngle;
        private Vector startVector;
        private Point centerPoint;

        private ContentControl designerItem;
        private ContentControl DesignerItem
        {
            get
            {
                if (designerItem == null)
                {
                    designerItem = DataContext as ContentControl;
                }
                return designerItem;
            }
        }

        public RotateThumb()
        {
            DragDelta += RotateThumb_DragDelta;
            DragStarted += RotateThumb_DragStarted;
        }

        void RotateThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var canvas = VisualTreeHelper.GetParent(DesignerItem) as Canvas;
            if (DesignerItem != null && canvas != null)
            {
                // the RenderTransformOrigin property of DesignerItem defines
                // transformation center relative to its bounds
                centerPoint = DesignerItem.TranslatePoint(
                    new Point(DesignerItem.Width * DesignerItem.RenderTransformOrigin.X,
                              DesignerItem.Height * DesignerItem.RenderTransformOrigin.Y),
                    canvas);

                // calculate startVector, that is the vector from centerPoint to startPoint
                Point startPoint = Mouse.GetPosition(canvas);
                startVector = Point.Subtract(startPoint, centerPoint);

                // check if the DesignerItem already has a RotateTransform set ...
                TransformGroup transformGroup = DesignerItem.RenderTransform as TransformGroup;

                //RotateTransform rotateTransform = transformGroup.Children[1] as RotateTransform;

                RotateTransform rotateTransform = null; // transformGroup.Children[1] as RotateTransform;

                if (transformGroup != null)
                    foreach (var child in transformGroup.Children)
                    {
                        switch (child.GetType().Name)
                        {
                            case ("RotateTransform"):
                                rotateTransform = child as RotateTransform;
                                break;
                        }
                    }


                if (rotateTransform == null)
                {
                    // if not we create one with zero angle 
                    transformGroup.Children.Add(new RotateTransform(0));
                    
                    DesignerItem.RenderTransform = transformGroup;
                    initialAngle = 0;
                }
                else
                    initialAngle = rotateTransform.Angle;
            }
        }

        void RotateThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var canvas = VisualTreeHelper.GetParent(DesignerItem) as Canvas;

            if (DesignerItem != null && canvas != null)
            {
                // calculate deltaVector, that is the vector from centerPoint to current mouse position                
                Point currentPoint = Mouse.GetPosition(canvas);
                Vector deltaVector = Point.Subtract(currentPoint, centerPoint);

                //calculate the angle between startVector and dragVector
                double angle = Vector.AngleBetween(startVector, deltaVector);

                // and update the transformation
                TransformGroup transformGroup = DesignerItem.RenderTransform as TransformGroup;

                RotateTransform rotateTransform = null;

                if (transformGroup != null)
                    foreach (var child in transformGroup.Children)
                    {
                        switch (child.GetType().Name)
                        {
                            case ("RotateTransform"):
                                rotateTransform = child as RotateTransform;
                                break;
                        }
                    }

                //SkewTransform skewTransform = transformGroup.Children[0] as SkewTransform;

                //RotateTransform rotateTransform = transformGroup.Children[1] as RotateTransform;

                //TranslateTransform translateTransform = transformGroup.Children[2] as TranslateTransform;

                //ScaleTransform scaleTransform = transformGroup.Children[3] as ScaleTransform;

                if (rotateTransform != null) 
                    rotateTransform.Angle = initialAngle + Math.Round(angle, 0);
            }
        }
    }
}
