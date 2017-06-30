using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;


namespace Inspire.Client.Designer.Commands
{
    public class AlignTopCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }
        public DragCanvas.DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public AlignTopCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, DragCanvas.DragCanvas dragCanvas)
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
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>() select item;

            if (selectedItems.Count() > 1)
            {
                double top = Canvas.GetTop(selectedItems.First());

                foreach (ContentControl item in selectedItems)
                {
                    double delta = top - Canvas.GetTop(item);
                    Canvas.SetTop(item, Canvas.GetTop(item) + delta);
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
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>() select item;

            if (selectedItems.Count() > 1)
            {
                double top = Canvas.GetTop(selectedItems.First());

                foreach (ContentControl item in selectedItems)
                {
                    double delta = top - Canvas.GetTop(item);
                    Canvas.SetTop(item, Canvas.GetTop(item) + delta);
                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements top aligned [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
