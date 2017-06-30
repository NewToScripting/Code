using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Interfaces;

namespace Inspire.Designer.Commands
{
    public class AddDesignItemCommand : IDesignerCommand
    {

        #region Properties

        public ContentControl Element { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public AddDesignItemCommand(ObservableCollection<ContentControl> canvasItems, ContentControl element, DragCanvas dragCanvas, bool dropped)
        {
            if(canvasItems == null) throw new ArgumentNullException ("canvasItems");
            if (element == null) throw new ArgumentNullException("element");      // TODO: Handle Create and dispose through Factory
            if (dragCanvas == null) throw new ArgumentNullException("dragCanvas");
            Element = element;

            if (Element.Width < 50)
                Element.Width = 200;

            double elementWidth = 0;
            double elementHeight = 0;

            if (!Element.Width.Equals(double.NaN))
                elementWidth = Element.Width;

            if (!Element.Height.Equals(double.NaN))
                elementHeight = Element.Height;

            CanvasItems = canvasItems;
            Canvas.SetZIndex(Element, CanvasItems.Count);

            if (dropped)
            {
                Canvas.SetLeft(Element, dragCanvas.DropPoint.X - .5*elementWidth);
                Canvas.SetTop(Element, dragCanvas.DropPoint.Y - .5*elementHeight);
            }

            DragCanvas = dragCanvas;
        }
        #endregion

        public void Execute()
        {
            // This is where we will show Dialogs, Wizards or other things

            if (Element != null && !CanvasItems.Contains(Element))            // TODO: Handle Create and dispose through Factory
            {
                CanvasItems.Add(Element);

                // May want to do the selection here for the selection service
            }
        }

        public void Undo()
        {
            if (Element != null && CanvasItems.Contains(Element))            // TODO: Handle Create and dispose through Factory
            {
                CanvasItems.Remove(Element);

                DragCanvas.GarbageItems.Add(Element);
                // May want to unselect for the selectionservice here
            }
        }

        public void Redo()
        {
            if(Element != null && !CanvasItems.Contains(Element))
            {
                //if (Element.Type == MediaType.Video || Element.Type == MediaType.QuickTime)
                //{
                //    Element.Content = DesignVideo.GetMediaImage((DesignVideo)Element.Content);
                //}
                DragCanvas.GarbageItems.Remove(Element);
                CanvasItems.Add(Element);
            }
        }

        public string Title
        {
            get
            {
                return "Element added [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
