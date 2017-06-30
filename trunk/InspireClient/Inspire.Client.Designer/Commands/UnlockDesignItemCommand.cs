using System;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.Commands
{
    public class UnlockDesignItemCommand : IDesignerCommand
    {
        #region Properties

        public DesignControlHolder Element { get; set; }

        #endregion

        #region ctor

        public UnlockDesignItemCommand(DesignControlHolder element)
        {
            if(element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.UnLock();
        }

        public void Undo()
        {
            Element.Lock();
        }

        public void Redo()
        {
            Element.UnLock();
        }

        public string Title
        {
            get
            {
                return "Element unlocked [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
