using System;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.Commands
{
    public class LockDesignItemCommand : IDesignerCommand
    {

        #region Properties

        public DesignControlHolder Element { get; set; }

        #endregion

        #region ctor

        public LockDesignItemCommand(DesignControlHolder element)
        {
            if(element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.Lock();
        }

        public void Undo()
        {
            Element.UnLock();
        }

        public void Redo()
        {
            Element.Lock();
        }

        public string Title
        {
            get
            {
                return "Element locked [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
