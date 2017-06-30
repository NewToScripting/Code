using System;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeSkewCommand : IDesignerCommand
    {

        #region Properties

        public DesignContentControl Element { get; set; }
        private double StartXSkew { get; set; }
        private double EndXSkew { get; set; }
        private double StartYSkew { get; set; }
        private double EndYSkew { get; set; }

        #endregion

        #region ctor

        public ChangeSkewCommand(DesignContentControl element, double startXSkew, double startYSkew, double endYSkew, double endXSkew)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartXSkew = startXSkew;
            StartYSkew = startYSkew;
            EndXSkew = endXSkew;
            EndYSkew = endYSkew;
        }
        #endregion


        public void Execute()
        {
            Element.SkewTransform.AngleX = EndXSkew;
            Element.SkewTransform.AngleY = EndYSkew;
        }

        public void Undo()
        {
            Element.SkewTransform.AngleX = StartXSkew;
            Element.SkewTransform.AngleY = StartYSkew;
        }

        public void Redo()
        {
            Element.SkewTransform.AngleX = EndXSkew;
            Element.SkewTransform.AngleY = EndYSkew;
        }

        public string Title
        {
            get
            {
                return "Element Skew Changed [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
