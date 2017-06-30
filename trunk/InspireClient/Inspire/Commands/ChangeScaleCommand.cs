using System;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeScaleCommand : IDesignerCommand
    {

        #region Properties

        public DesignContentControl Element { get; set; }
        private double StartXScale { get; set; }
        private double EndXScale { get; set; }
        private double StartYScale { get; set; }
        private double EndYScale { get; set; }

        #endregion

        #region ctor

        public ChangeScaleCommand(DesignContentControl element, double startXScale, double startYScale, double endYScale, double endXScale)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartXScale = startXScale;
            StartYScale = startYScale;
            EndXScale = endXScale;
            EndYScale = endYScale;
        }
        #endregion


        public void Execute()
        {
            Element.ScaleTransform.ScaleX = EndXScale;
            Element.ScaleTransform.ScaleY = EndYScale;
        }

        public void Undo()
        {
            Element.ScaleTransform.ScaleX = StartXScale;
            Element.ScaleTransform.ScaleY = StartYScale;
        }

        public void Redo()
        {
            Element.ScaleTransform.ScaleX = EndXScale;
            Element.ScaleTransform.ScaleY = EndYScale;
        }

        public string Title
        {
            get
            {
                return "Element Scale Changed [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
