
using System;

namespace Inspire.Common.TreeViewModel
{
    public class ScheduleViewModel : TreeViewItemViewModel , IGUIDItem
    {
        readonly Schedule _schedule;

        public ScheduleViewModel(Schedule schedule, DisplayViewModel parentGroup)
            : base(parentGroup, true)
        {
            _schedule = schedule;
        }

        public string ScheduleName
        {
            get { return _schedule.Name; }
        }

        public bool IsActive
        {
            get { return (new DateTime(_schedule.EndDate.Value.Year,_schedule.EndDate.Value.Month, _schedule.EndDate.Value.Day, _schedule.EndTime.Value.Hour, _schedule.EndTime.Value.Minute, _schedule.EndTime.Value.Second) > DateTime.Now); }
        }

        public string GUID
        {
            get { return _schedule.GUID; }
        }

        public Schedule.ScheduleTypeEnum ScheduleType
        {
            get { return _schedule.Type; }
        }
    }
}
