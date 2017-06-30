using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class AlignRightCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }
        public DragCanvas.DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public AlignRightCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, DragCanvas.DragCanvas dragCanvas)
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
                                select item;

            if (selectedItems.Count() > 1)
            {
                double right = Canvas.GetLeft(selectedItems.First()) + selectedItems.First().Width;

                foreach (ContentControl item in selectedItems)
                {
                    double delta = right - (Canvas.GetLeft(item) + item.Width);
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + delta);

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
                                select item;

            if (selectedItems.Count() > 1)
            {
                double right = Canvas.GetLeft(selectedItems.First()) + selectedItems.First().Width;

                foreach (ContentControl item in selectedItems)
                {
                    double delta = right - (Canvas.GetLeft(item) + item.Width);
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + delta);

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
