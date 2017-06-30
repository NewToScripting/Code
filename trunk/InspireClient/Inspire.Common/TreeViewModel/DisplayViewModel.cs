
using Inspire.Server.Proxy;

namespace Inspire.Common.TreeViewModel
{
    public class DisplayViewModel : TreeViewItemViewModel, IGUIDItem
    {
        readonly Display _display;

        public DisplayViewModel(Display display, DisplayGroupViewModel parentGroup)
            : base(parentGroup, true)
        {
            _display = display;
        }

        public DisplayViewModel(Display display)
            : base(null, true)
        {
            _display = display;
        }

        public int IsActive
        {
            get { return _display.ActiveFlag; }
        }

        public string DisplayName
        {
            get { return _display.DisplayName; }
        }

        public string HResolution
        {
            get { return _display.HResolution.ToString(); }
        }

        public string VResolution
        {
            get { return _display.VResolution.ToString(); }
        }

        public string GUID
        {
            get { return _display.GUID; }
        }

        public string DisplayHostName
        {
            get { return _display.HostName; }
        }

        protected override void LoadChildren()
        {
            foreach (Schedule schedule in ScheduleManager.GetSchedules(_display.GUID))
                Children.Add(new ScheduleViewModel(schedule, this));
        }

    }
}
