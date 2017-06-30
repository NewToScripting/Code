using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Designer.Commands
{
    class BringToFrontCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }

        #endregion

        #region ctor

        public BringToFrontCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements)
        {

            if(canvasItems == null) throw new ArgumentNullException ("canvasItems");
            if(elements == null) throw new ArgumentNullException("elements");

            Elements = elements;
            CanvasItems = canvasItems;

            StartControlPositions = ControlPosition.GetControlPositions(canvasItems);
        }
        #endregion

        public void Execute()
        {
            if(Elements != null)
            {
                List<ISelectable> selectionSorted = (Elements.OrderBy(item => Canvas.GetZIndex(item as DesignControlHolder))).ToList();

                List<DesignControlHolder> childrenSorted = (CanvasItems.Cast<DesignControlHolder>().OrderBy(
                    item => Canvas.GetZIndex(item))).ToList();

                int i = 0;
                int j = 0;
                foreach (DesignControlHolder item in childrenSorted)
                {
                    if (selectionSorted.Contains(item))
                    {
                        Canvas.SetZIndex(item, childrenSorted.Count - selectionSorted.Count + j++);
                    }
                    else
                    {
                        Canvas.SetZIndex(item, i++);
                    }
                }
            }
        }

        public void Undo()
        {
            foreach (ControlPosition controlPosition in StartControlPositions)
            {
                Canvas.SetZIndex(controlPosition.DesignerItem, controlPosition.DesignerZIndex);
            }
        }

        public void Redo()
        {
            if (Elements != null)
            {
                List<ISelectable> selectionSorted = (Elements.OrderBy(
                    item => Canvas.GetZIndex(item as ContentControl))).ToList();

                List<DesignControlHolder> childrenSorted = (CanvasItems.Cast<DesignControlHolder>().OrderBy(
                    item => Canvas.GetZIndex(item))).ToList();

                int i = 0;
                int j = 0;
                foreach (DesignControlHolder item in childrenSorted)
                {
                    if (selectionSorted.Contains(item))
                    {
                        Canvas.SetZIndex(item, childrenSorted.Count - selectionSorted.Count + j++);
                    }
                    else
                    {
                        Canvas.SetZIndex(item, i++);
                    }
                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements moved to front [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
