using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Inspire.Helpers;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DragCanvas.Thumbs
{
    public class DragThumb : Thumb
    {
        private DragCanvas dragCanvas; 

        public DragThumb()
        {
            dragCanvas = UIHelper.GetCurrentDragCanvas() as DragCanvas;
            DragDelta += DragThumb_DragDelta;
        }

        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var designerItemChild = DataContext as ContentControl;

            var designerItem = designerItemChild.Parent as DesignControlHolder;

            if (designerItem != null)
            {
                if (designerItem.IsSelected && !DesignWindow.GetDesignerWindow().IsPlaying)
                {
                    // we only move DesignerItems
                    var designerItems = dragCanvas.selectionService.CurrentSelection.OfType<DesignControlHolder>();

                    Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);
                     
                    TransformGroup transformGroup = designerItem.RenderTransform as TransformGroup;

                    TransformGroup newTransForm = transformGroup.Clone();

                    newTransForm.Children[1] = ((DesignContentControl)designerItemChild).SkewTransform;

                    if (newTransForm != null)
                        dragDelta = newTransForm.Transform(dragDelta);

                    foreach (DesignControlHolder item in designerItems)
                    {
                        if (!item.IsLocked)
                        {
                            double left = Canvas.GetLeft(item);
                            double top = Canvas.GetTop(item);

                            left = double.IsNaN(left) ? 0 : left;
                            top = double.IsNaN(top) ? 0 : top;

                            Canvas.SetLeft(item, left + dragDelta.X);
                            Canvas.SetTop(item, top + dragDelta.Y);
                        }
                    }

                    //designer.InvalidateMeasure();
                    e.Handled = true;
                }
            }
        }
    }
}