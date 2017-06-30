using System.Windows;
using System.Windows.Controls;

namespace ImageModule
{
    public class DesignImage : Image
    {

        #region IsNewFile Members

        public bool IsNewFile
        {
            get
            {
                return (bool)GetValue(IsNewFileProperty);
            }
            set
            {
                SetValue(IsNewFileProperty, value);
            }
        }

        public static readonly DependencyProperty IsNewFileProperty =
          DependencyProperty.Register("IsNewFile",
                                       typeof(bool),
                                       typeof(DesignImage),
                                       new FrameworkPropertyMetadata(false));

        #endregion

        public string Extension
        {
            get
            {
                return (string)GetValue(ExtensionProperty);
            }
            set
            {
                SetValue(ExtensionProperty, value);
            }
        }

        public static readonly DependencyProperty ExtensionProperty =
          DependencyProperty.Register("Extension",
                                       typeof(string),
                                       typeof(DesignImage));
    }
}
