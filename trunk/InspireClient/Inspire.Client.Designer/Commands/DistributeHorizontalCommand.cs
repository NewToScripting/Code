using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class DistributeHorizontalCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }
        public DragCanvas.DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public DistributeHorizontalCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, DragCanvas.DragCanvas dragCanvas)
        {

            if (canvasItems == null) throw new ArgumentNullException("canvasItems");
            if (elements == null) throw new ArgumentNullException("elements");

            Elements = elements;
            CanvasItems = canvasItems;
            DragCanvas = dragCanvas;

            StartControlPositions = ControlPosition.GetControlPositions(canvasItems);
        }
        #endregion

        public void Execute()
        {
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>()
                                let itemLeft = Canvas.GetLeft(item)
                                orderby itemLeft
                                select item;

            if (selectedItems.Count() > 1)
            {
                double left = Double.MaxValue;
                double right = Double.MinValue;
                double sumWidth = 0;
                foreach (ContentControl item in selectedItems)
                {
                    left = Math.Min(left, Canvas.GetLeft(item));
                    right = Math.Max(right, Canvas.GetLeft(item) + item.Width);
                    sumWidth += item.Width;
                }

                double distance = Math.Max(0, (right - left - sumWidth) / (selectedItems.Count() - 1));
                double offset = Canvas.GetLeft(selectedItems.First());

                foreach (ContentControl item in selectedItems)
                {
                    double delta = offset - Canvas.GetLeft(item);
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + delta);
                    offset = offset + item.Width + distance;
                }
            }
        }

        public void Undo()
        {
            foreach (ControlPosition controlPosition in StartControlPositions)
            {
                Canvas.SetLeft(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.X);
                Canvas.SetTop(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.Y);
            }
        }

        public void Redo()
        {
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>()
                                let itemLeft = Canvas.GetLeft(item)
                                orderby itemLeft
                                select item;

            if (selectedItems.Count() > 1)
            {
                double left = Double.MaxValue;
                double right = Double.MinValue;
                double sumWidth = 0;
                foreach (ContentControl item in selectedItems)
                {
                    left = Math.Min(left, Canvas.GetLeft(item));
                    right = Math.Max(right, Canvas.GetLeft(item) + item.Width);
                    sumWidth += item.Width;
                }

                double distance = Math.Max(0, (right - left - sumWidth) / (selectedItems.Count() - 1));
                double offset = Canvas.GetLeft(selectedItems.First());

                foreach (ContentControl item in selectedItems)
                {
                    double delta = offset - Canvas.GetLeft(item);
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + delta);
                    offset = offset + item.Width + distance;
                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements bottom aligned [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
