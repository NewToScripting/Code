using System;
using System.Windows.Media;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeBorderColorCommand : IDesignerCommand
    {

        #region Properties

        public DesignContentControl Element { get; set; }
        private Brush StartColor { get; set; }
        private Brush EndColor { get; set; }

        #endregion

        #region ctor

        public ChangeBorderColorCommand(DesignContentControl element, Brush startColor, Brush endColor)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartColor = startColor;
            EndColor = endColor;
        }
        #endregion


        public void Execute()
        {
            Element.BorderBrush = EndColor;
        }

        public void Undo()
        {
            Element.BorderBrush = StartColor;
        }

        public void Redo()
        {
            Element.BorderBrush = EndColor;
        }

        public string Title
        {
            get
            {
                return "Element Border Color Changed [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
