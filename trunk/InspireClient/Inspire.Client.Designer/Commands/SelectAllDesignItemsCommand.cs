using Inspire.Helpers;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class SelectAllDesignItemsCommand : IDesignerCommand
    {

        public void Execute()
        {
            var dragCanvas = UIHelper.GetCurrentDragCanvas() as DragCanvas.DragCanvas;
            if (dragCanvas != null) dragCanvas.selectionService.SelectAll();
        }

        public void Undo()
        {

        }

        public void Redo()
        {

        }

        public string Title
        {
            get
            {
                return "All Elements Selected.";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
