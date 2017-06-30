
using Inspire.Server.Proxy;

namespace Inspire.Common.TreeViewModel
{
    public class PropertyViewModel : TreeViewItemViewModel
    {
        readonly DisplayProperty _displayProperty;

        public PropertyViewModel(DisplayProperty displayProperty) 
            : base(null, true)
        {
            _displayProperty = displayProperty;
        }

        public string PropertyDescription
        {
            get { return _displayProperty.PropertyDescription; }
        }

        public string PropertyName
        {
            get { return _displayProperty.PropertyName; }
        }

        public string PropertyGUID
        {
            get { return _displayProperty.GUID; }
        }

        protected override void LoadChildren()
        {
            foreach (DisplayGroup displayGroup in DisplayGroupManager.GetDisplayGroups(_displayProperty.GUID))
                Children.Add(new DisplayGroupViewModel(displayGroup, this));
        }

    }
}
