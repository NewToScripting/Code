using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ScrollModule
{
    public interface IScrollItem
    {
        string ScrollType { get; set; }
        string ScrollContent { get; set; }
        ListBox ScrollItemHelpers { get; set; }

        List<FrameworkElement> GetScrollItems(string scrollinfo);
    }
}
