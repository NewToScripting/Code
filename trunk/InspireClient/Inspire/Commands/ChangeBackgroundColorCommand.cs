using System;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeBackgroundColorCommand : IDesignerCommand
    {

        #region Properties

        public DesignContentControl Element { get; set; }
        private Brush StartColor { get; set; }
        private Brush EndColor { get; set; }

        #endregion

        #region ctor

        public ChangeBackgroundColorCommand(DesignContentControl element, Brush startColor, Brush endColor)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartColor = startColor;
            EndColor = endColor;
        }
        #endregion


        public void Execute()
        {
            Element.ContentBackground = EndColor;
        }

        public void Undo()
        {
            Element.ContentBackground = StartColor;
        }

        public void Redo()
        {
            Element.ContentBackground = EndColor;
        }

        public string Title
        {
            get
            {
                return "Element Background Color Changed [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
