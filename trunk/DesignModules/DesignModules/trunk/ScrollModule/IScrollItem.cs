using System.Windows;
using System.Windows.Controls;

namespace ScrollModule
{
    public interface IScrollItem
    {
        string ScrollType { get; set; }
        string ScrollContent { get; set; }
        ListBox ScrollItemHelpers { get; set; }

        FrameworkElement GetScrollItem();
    }
}
