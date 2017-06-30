using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DragCanvas
{
    public class SizeAdorner : Adorner
    {
        private ResizeNotification chrome;
        private VisualCollection visuals;
        private ContentControl _designerItem;

        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        public SizeAdorner(ContentControl designerItem)
            : base(designerItem)
        {
            SnapsToDevicePixels = true;
            _designerItem = designerItem;
            chrome = new ResizeNotification();
            chrome.DataContext = designerItem;
            visuals = new VisualCollection(this);
            visuals.Add(chrome);
        }

        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            chrome.Arrange(new Rect(new Point(0.0, 0.0), arrangeBounds));
            chrome.UpdateLayout();
            return arrangeBounds;
        }
    }
}
