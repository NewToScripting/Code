using System;
using System.Windows;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class HideDesignItemCommand : IDesignerCommand
    {
        #region Properties

        public ContentControl Element { get; set; }

        #endregion

        #region ctor

        public HideDesignItemCommand(ContentControl element)
        {
            if(element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.Visibility = Visibility.Hidden;
        }

        public void Undo()
        {
            Element.Visibility = Visibility.Visible;
        }

        public void Redo()
        {
            Element.Visibility = Visibility.Hidden;
        }

        public string Title
        {
            get
            {
                return "Element hidden [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
