using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Inspire.Helpers
{

    /// <summary>
    /// Helper methods for UI-related tasks.
    /// </summary>
    public static class UIHelper
    {
        /// <summary>
        /// Finds a parent of a given item on the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="child">A direct or indirect child of the
        /// queried item.</param>
        /// <returns>The first parent item that matches the submitted
        /// type parameter. If not matching item can be found, a null
        /// reference is being returned.</returns>
        public static T TryFindParent<T>(DependencyObject child)
          where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = GetParentObject(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }

            //use recursion to proceed with next level
            return TryFindParent<T>(parentObject);
        }

        /// <summary>
        /// This method is an alternative to WPF's
        /// <see cref="VisualTreeHelper.GetParent"/> method, which also
        /// supports content elements. Do note, that for content element,
        /// this method falls back to the logical tree of the element!
        /// </summary>
        /// <param name="child">The item to be processed.</param>
        /// <returns>The submitted item's parent, if available. Otherwise
        /// null.</returns>
        public static DependencyObject GetParentObject(DependencyObject child)
        {
            if (child == null) return null;
            ContentElement contentElement = child as ContentElement;

            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            //if it's not a ContentElement, rely on VisualTreeHelper
            return VisualTreeHelper.GetParent(child);
        }

        public static object GetCurrentDragCanvas()
        {
            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                UserControl designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                if (designWindow != null)
                {
                    TabControl tabControl = designWindow.FindName("DesignerDragCanvasHolder") as TabControl;

                    if (tabControl != null)
                    {
                        if (tabControl.SelectedContent != null)
                        {
                            return tabControl.SelectedContent;
                        }
                    }
                }
            }
            return null;
        }



        public static void RotateUIElement(UIElement uiElement, double rotationDegrees)
        {
            // and update the transformation
            TransformGroup transformGroup = uiElement.RenderTransform as TransformGroup;

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

            if (rotateTransform != null)
            {
                double initialAngle = rotateTransform.Angle;

                //SkewTransform skewTransform = transformGroup.Children[0] as SkewTransform;

                //RotateTransform rotateTransform = transformGroup.Children[1] as RotateTransform;

                //TranslateTransform translateTransform = transformGroup.Children[2] as TranslateTransform;

                //ScaleTransform scaleTransform = transformGroup.Children[3] as ScaleTransform;

                rotateTransform.Angle = initialAngle + Math.Round(rotationDegrees, 0);
            }
        }


        public static void SetAngleUIElement(UIElement uiElement, double angle)
        {
            // and update the transformation
            TransformGroup transformGroup = uiElement.RenderTransform as TransformGroup;

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

            if (rotateTransform != null)
            {
                rotateTransform.Angle = angle;
            }
        }

        public static void ScaleUIElement(UIElement uiElement, double? yScale, double? xScale)
        {
            // and update the transformation
            ScaleTransform scaleTransform = GetScaleTransform(uiElement);

            if (scaleTransform != null)
            {
                if (yScale != null)
                    scaleTransform.ScaleY = (double)yScale;

                if (xScale != null)
                    scaleTransform.ScaleX = (double) xScale;
            }
        }

        public static ScaleTransform GetScaleTransform(UIElement uiElement)
        {
            ScaleTransform scaleTransform = null;
            TransformGroup transformGroup = uiElement.RenderTransform as TransformGroup;

            if (transformGroup != null)
                foreach (var child in transformGroup.Children)
                {
                    switch (child.GetType().Name)
                    {
                        case ("ScaleTransform"):
                            scaleTransform = child as ScaleTransform;
                            break;
                    }
                }
            return scaleTransform;
        }
    }
}
