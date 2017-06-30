using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.Commands
{
    public class DisableHitTestCommand : IDesignerCommand
    {

        #region Properties

        public DesignControlHolder Element { get; set; }

        #endregion

        #region ctor

        public DisableHitTestCommand(DesignControlHolder element)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.IsHitTestVisible = false;
        }

        public void Undo()
        {
            Element.IsHitTestVisible = true;
        }

        public void Redo()
        {
            Element.IsHitTestVisible = false;
        }

        public string Title
        {
            get
            {
                return "Element is not selectable [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
