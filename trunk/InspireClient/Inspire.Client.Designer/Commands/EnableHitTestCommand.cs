using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Inspire.MediaObjects;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class EnableHitTestCommand : IDesignerCommand
    {

        #region Properties

        public DesignControlHolder Element { get; set; }

        #endregion

        #region ctor

        public EnableHitTestCommand(DesignControlHolder element)
        {
            if(element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.IsHitTestVisible = true;

            var content = Element.Content as FrameworkElement;
            if (content != null) if (!content.IsHitTestVisible)
                    content.IsHitTestVisible = true;
        }

        public void Undo()
        {
            Element.IsHitTestVisible = false;
        }

        public void Redo()
        {
            Element.IsHitTestVisible = true;

            var content = Element.Content as FrameworkElement;
            if (content != null) if (!content.IsHitTestVisible)
                    content.IsHitTestVisible = true;
        }

        public string Title
        {
            get
            {
                return "Element is selectable [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
