using System;
using System.Windows;
using System.Windows.Controls;
using Infragistics.ToyBox;

namespace Inspire.MediaObjects
{
    public class DesignReflection : Reflector
    {
        public string TargetGuid { get; set; }

        public static ContentControl GetReflectionContentControl(DesignControlHolder originalContentControl)
        {
            //FrameworkElement frameworkElement = (FrameworkElement)originalContentControl.Content;

            DesignReflection designReflection = new DesignReflection();
            designReflection.IsHitTestVisible = false;
            designReflection.TargetGuid = ((DesignContentControl)originalContentControl.Content).GUID;
            designReflection.ReflectionTarget = (DesignContentControl)originalContentControl.Content;

           // Viewbox viewbox = new Viewbox();
           // viewbox.Child = designReflection;

            DesignContentControl designContentControl = new DesignContentControl();

            designContentControl.IsHitTestVisible = true;
            designContentControl.Type = MediaType.Reflection;
            designContentControl.Tag = originalContentControl.Tag + " - Reflection";
            designContentControl.Content = designReflection;
            designContentControl.IsRotatable = true;
            designContentControl.Width = originalContentControl.Width;
            designContentControl.Height = originalContentControl.Height;
            designContentControl.GUID = Guid.NewGuid().ToString();
            designContentControl.AssemblyInfo = "ReflectionModule";
            //designContentControl.IsSelected = false;
            designContentControl.RotateTransform.Angle = 360 - originalContentControl.RotateTransform.Angle;

            var designHolder = new DesignControlHolder(designContentControl);

            Canvas.SetLeft(designHolder, Canvas.GetLeft(originalContentControl));
            Canvas.SetTop(designHolder, Canvas.GetTop(originalContentControl) + originalContentControl.Height);


            return designHolder;
        }
    }
}
