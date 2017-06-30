using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using Inspire.MediaObjects;

namespace Inspire
{
    public class ControlPosition
    {
        public DesignControlHolder DesignerItem { get; set; }
        public Point DesignerCoordinate { get; set; }
        public Size DesignerSize { get; set; }
        public double DesignerRotateAngle { get; set; }
        public int DesignerZIndex { get; set; }

        public static List<ControlPosition> GetControlPositions(IEnumerable<ContentControl> controls)
        {
            var controlPos = new List<ControlPosition>();
            foreach (ContentControl item in controls)
            {
                controlPos.Add(new ControlPosition(item as DesignControlHolder));
            }
            return controlPos;
        }


        public ControlPosition(DesignControlHolder designerItem)
        {
            double left = Canvas.GetLeft(designerItem);
            double top = Canvas.GetTop(designerItem);

            double width = designerItem.ActualWidth;
            double height = designerItem.ActualHeight;

            int designerZIndex = Canvas.GetZIndex(designerItem);

            if (top.ToString() == "NaN")
                top = 0;
            if (left.ToString() == "NaN")
                left = 0;

            if (width.ToString() == "NaN")
                width = 0;
            if (height.ToString() == "NaN")
                height = 0;

            //var designContentControl = designerItem.Content as DesignContentControl;

            DesignerZIndex = designerZIndex;
            DesignerRotateAngle = designerItem.RotateTransform.Angle;
            DesignerCoordinate = new Point(Convert.ToInt32(left),Convert.ToInt32(top));
            DesignerSize = new Size(Convert.ToInt32(width), Convert.ToInt32(height));
            DesignerItem = designerItem;
        }
    }
}
