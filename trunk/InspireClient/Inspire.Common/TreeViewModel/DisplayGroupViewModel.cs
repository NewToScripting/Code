using Inspire.Server.Proxy;

namespace Inspire.Common.TreeViewModel
{
    public class DisplayGroupViewModel : TreeViewItemViewModel
    {
        readonly DisplayGroup _displayGroup;

        public DisplayGroupViewModel(DisplayGroup displayGroup, PropertyViewModel parentProperty) 
            : base(parentProperty, true)
        {
            _displayGroup = displayGroup;
        }

        public string DisplayGroupDescription
        {
            get { return _displayGroup.GroupDescription; }
        }

        public string DisplayGroupName
        {
            get { return _displayGroup.GroupName; }
        }

        public string DisplayGroupGUID
        {
            get { return _displayGroup.GUID; }
        }

        protected override void LoadChildren()
        {
            foreach (Display display in DisplayManager.GetDisplays(_displayGroup.GUID))
               Children.Add(new DisplayViewModel(display, this));
        }
    }
}
