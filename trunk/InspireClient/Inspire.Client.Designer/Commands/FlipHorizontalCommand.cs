﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Helpers;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class FlipHorizontalCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public DragCanvas.DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public FlipHorizontalCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, DragCanvas.DragCanvas dragCanvas)
        {

            if (canvasItems == null) throw new ArgumentNullException("canvasItems");
            if (elements == null) throw new ArgumentNullException("elements");
            if (dragCanvas == null) throw new ArgumentNullException("elements");

            Elements = elements;
            CanvasItems = canvasItems;
            DragCanvas = dragCanvas;
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
                    if (UIHelper.GetScaleTransform(item).ScaleX == -1)
                        UIHelper.ScaleUIElement(item, null, 1);
                    else
                        UIHelper.ScaleUIElement(item, null, -1);
                }
            }
        }

        public void Undo()
        {
            var selectedItems = from item in DragCanvas.selectionService.CurrentSelection.OfType<ContentControl>()
                                select item;

            if (selectedItems.Count() > 0)
            {
                foreach (ContentControl item in selectedItems)
                {
                    if (UIHelper.GetScaleTransform(item).ScaleX == 1)
                        UIHelper.ScaleUIElement(item, null, -1);
                    else
                        UIHelper.ScaleUIElement(item, null, 1);
                }
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
                    if (UIHelper.GetScaleTransform(item).ScaleX == -1)
                        UIHelper.ScaleUIElement(item, null, 1);
                    else
                        UIHelper.ScaleUIElement(item, null, -1);
                }
            }
        }

        public string Title
        {
            get
            {
                return "Flip Horizontal - [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
