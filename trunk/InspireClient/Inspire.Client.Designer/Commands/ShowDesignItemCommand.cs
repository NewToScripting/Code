using System;
using System.Windows;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class ShowDesignItemCommand : IDesignerCommand
    {
        #region Properties

        public ContentControl Element { get; set; }

        #endregion

        #region ctor

        public ShowDesignItemCommand(ContentControl element)
        {
            if (element == null) throw new ArgumentNullException("element");

            Element = element;
        }
        #endregion


        public void Execute()
        {
            Element.Visibility = Visibility.Visible;
        }

        public void Undo()
        {
            Element.Visibility = Visibility.Collapsed;
        }

        public void Redo()
        {
            Element.Visibility = Visibility.Visible;
        }

        public string Title
        {
            get
            {
                return "Element shown [" + Element.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
