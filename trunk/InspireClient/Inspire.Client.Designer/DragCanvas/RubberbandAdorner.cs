using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DragCanvas
{
    public class RubberbandAdorner : Adorner
    {
        private Point? startPoint;
        private Point? endPoint;
        private Pen rubberbandPen;

        private DragCanvas designerCanvas;
        private ObservableCollection<ContentControl> designerItems;

        public RubberbandAdorner(DragCanvas designerCanvas, ObservableCollection<ContentControl> canvasItems, Point? dragStartPoint)
            : base(designerCanvas)
        {
            this.designerCanvas = designerCanvas;
            designerItems = canvasItems;
            startPoint = dragStartPoint;
            rubberbandPen = new Pen(Brushes.LightSlateGray, 1);
            rubberbandPen.DashStyle = new DashStyle(new double[] { 2 }, 1);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!IsMouseCaptured)
                    CaptureMouse();

                endPoint = e.GetPosition(this);

                InvalidateVisual();
            }
            else
            {
                if (IsMouseCaptured) ReleaseMouseCapture();
            }

            e.Handled = true;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            // release mouse capture
            if (IsMouseCaptured) ReleaseMouseCapture();

            // Moved this from OnMouseMove to improve performance
            UpdateSelection();

            // remove this adorner from adorner layer
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(designerCanvas);
            if (adornerLayer != null)
                adornerLayer.Remove(this);

            e.Handled = true;
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            // without a background the OnMouseMove event would not be fired!
            // Alternative: implement a Canvas as a child of this adorner, like
            // the ConnectionAdorner does.
            dc.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            if (startPoint.HasValue && endPoint.HasValue)
                dc.DrawRectangle(Brushes.Transparent, rubberbandPen, new Rect(startPoint.Value, endPoint.Value));
        }

        private void UpdateSelection()
        {
            designerCanvas.selectionService.ClearSelection();
            if (startPoint != null && endPoint != null)
            {
                Rect rubberBand = new Rect(startPoint.Value, endPoint.Value);
                foreach (DesignControlHolder item in designerItems)
                {
                    Rect itemRect = VisualTreeHelper.GetDescendantBounds(item);
                    Rect itemBounds = item.TransformToAncestor(designerCanvas).TransformBounds(itemRect);

                    if (rubberBand.Contains(itemBounds))
                    {
                        if (!item.IsLocked)
                            designerCanvas.selectionService.AddToSelection(item);
                    }
                }
            }
        }
    }
}
