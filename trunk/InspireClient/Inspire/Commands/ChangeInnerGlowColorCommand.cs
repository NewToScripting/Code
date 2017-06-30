using System;
using System.Windows.Media;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeInnerGlowColorCommand : IDesignerCommand
    {

        #region Properties

        public DesignContentControl Element { get; set; }
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        #endregion

        #region ctor

        public ChangeInnerGlowColorCommand(DesignContentControl element, Color startColor, Color endColor)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartColor = startColor;
            EndColor = endColor;
        }
        #endregion


        public void Execute()
        {
            Element.InnerGlowColor = EndColor;
        }

        public void Undo()
        {
            Element.InnerGlowColor = StartColor;
        }

        public void Redo()
        {
            Element.InnerGlowColor = EndColor;
        }

        public string Title
        {
            get
            {
                return "Element InnerGlow Color Changed [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
