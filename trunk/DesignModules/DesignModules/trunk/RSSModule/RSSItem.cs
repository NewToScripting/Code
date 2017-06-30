using System.Windows.Documents;
using System.Windows.Media;

namespace RSSModule
{
    public class RSSItem
    {
        public RSSItem()
        {
            
        }

        public RSSItem(string title, FlowDocument description) //, double _RSSTitleFSize, FontFamily _RSSTitleFFamily, Brush _RSSTitleFForeground, double _RSSDescriptionFSize, FontFamily _RSSDescriptionFFamily, Brush _RSSDescriptionFForeground
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public FlowDocument Description { get; set; }

    }
}
