using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Helpers;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class Rotate90LeftCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }
        public DragCanvas.DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public Rotate90LeftCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, DragCanvas.DragCanvas dragCanvas)
        {

            if (canvasItems == null) throw new ArgumentNullException("canvasItems");
            if (elements == null) throw new ArgumentNullException("elements");
            if (dragCanvas == null) throw new ArgumentNullException("elements");

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

            if (selectedItems.Count() > 0)
            {
                foreach (ContentControl item in selectedItems)
                {
                    UIHelper.RotateUIElement(item, -90);
                }
            }
        }

        public void Undo()
        {
            foreach (ControlPosition controlPosition in StartControlPositions)
            {
                UIHelper.SetAngleUIElement(controlPosition.DesignerItem, controlPosition.DesignerRotateAngle);
            }
        }

        public void Redo()
        {
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>()
                                select item;

            if (selectedItems.Count() > 0)
            {
                foreach (ContentControl item in selectedItems)
                {
                    UIHelper.RotateUIElement(item, -90);
                }
            }
        }

        public string Title
        {
            get
            {
                return "Rotated Left 90[" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
