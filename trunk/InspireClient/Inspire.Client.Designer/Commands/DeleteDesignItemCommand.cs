using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Designer.Commands
{
    public class DeleteDesignItemCommand : IDesignerCommand
    {
        #region Properties

        public ContentControl Element { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public DragCanvas DragCanvas { get; set; }

        #endregion

        #region ctor

        public DeleteDesignItemCommand(ObservableCollection<ContentControl> canvasItems, ContentControl element, DragCanvas dragCanvas)
        {
            if(canvasItems == null) throw new ArgumentNullException ("canvasItems");
            if(element == null) throw new ArgumentNullException("element");

            Element = element;
            CanvasItems = canvasItems;
            DragCanvas = dragCanvas;
        }
        #endregion

        public void Execute()
        {
            if(Element == null && CanvasItems == null) return;

            if(CanvasItems.Contains(Element))
            {
                CanvasItems.Remove(Element);  

                DragCanvas.DeleteReflection(((DesignContentControl)Element.Content).GUID, CanvasItems);
                DragCanvas.GarbageItems.Add(Element);
            }
        }

        public void Undo()
        {
            if (Element == null && CanvasItems == null) return;      // TODO: Handle Create and dispose through Factory

            if (DragCanvas.GarbageItems.Contains(Element))
                DragCanvas.GarbageItems.Remove(Element);

            if (!CanvasItems.Contains(Element))
                CanvasItems.Add(Element);
        }

        public void Redo()
        {
            if (Element == null && CanvasItems == null) return;

            if (CanvasItems.Contains(Element))
            {
                CanvasItems.Remove(Element);            // TODO: Handle Create and dispose through Factory

                DragCanvas.DeleteReflection(((DesignContentControl)Element.Content).GUID, CanvasItems);
                DragCanvas.GarbageItems.Add(Element);
            }
        }

        public string Title
        {
            get
            {
                return "Element deleted [" + Element.GetType().Name + "]";
            }
            set
            {
                //
            }
        }
    }
}
