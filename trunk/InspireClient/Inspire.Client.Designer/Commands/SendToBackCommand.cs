using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Designer.Commands
{
    class SendToBackCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public List<ControlPosition> StartControlPositions { get; set; }

        #endregion

        #region ctor

        public SendToBackCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements)
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
            List<ISelectable> selectionSorted = (from item in Elements
                                                 orderby Canvas.GetZIndex(item as DesignControlHolder) ascending
                                               select item).ToList();

            List<DesignControlHolder> childrenSorted = (from DesignControlHolder item in CanvasItems
                                              orderby Canvas.GetZIndex(item) ascending
                                              select item).ToList();
            int i = 0;
            int j = 0;
            foreach (DesignControlHolder item in childrenSorted)
            {
                if (selectionSorted.Contains(item))
                {
                    Canvas.SetZIndex(item, j++);

                }
                else
                {
                    Canvas.SetZIndex(item, selectionSorted.Count + i++);
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
                List<ISelectable> selectionSorted = (from item in Elements
                                                     orderby Canvas.GetZIndex(item as DesignControlHolder) ascending
                                                              select item).ToList();

                List<DesignControlHolder> childrenSorted = (from DesignControlHolder item in CanvasItems
                                                             orderby Canvas.GetZIndex(item) ascending
                                                             select item).ToList();
                int i = 0;
                int j = 0;
                foreach (DesignControlHolder item in childrenSorted)
                {
                    if (selectionSorted.Contains(item))
                    {
                        Canvas.SetZIndex(item, j++);

                    }
                    else
                    {
                        Canvas.SetZIndex(item, selectionSorted.Count + i++);
                    }
                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements moved to back [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
