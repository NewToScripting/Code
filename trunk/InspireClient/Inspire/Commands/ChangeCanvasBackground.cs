using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Commands
{
    public class ChangeCanvasBackground : IDesignerCommand
    {

        #region Properties

        public ContentControl Element { get; set; }
        private Brush StartColor { get; set; }
        private Brush EndColor { get; set; }

        #endregion

        #region ctor

        public ChangeCanvasBackground(ContentControl element, Brush startColor, Brush endColor)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
            StartColor = startColor;
            EndColor = endColor;
        }
        #endregion


        public void Execute()
        {
            Element.Background = EndColor;
        }

        public void Undo()
        {
            Element.Background = StartColor;
        }

        public void Redo()
        {
            Element.Background = EndColor;
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
