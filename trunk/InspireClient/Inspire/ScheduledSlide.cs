using System;

namespace Inspire
{
    public class ScheduledSlide : Slide
    {
        public ScheduledSlide()
        {
            GUID = Guid.NewGuid().ToString();
            Duration = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 10);
            ThumbNail = null;
        }

        public ScheduledSlide(Slide _slide)
        {
            GUID = Guid.NewGuid().ToString();
            Name = _slide.Name;
            Description = _slide.Description;
            Duration = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0,0,10);
            ThumbNail = _slide.ThumbNail;
            OriginalSlideId = _slide.GUID;
            Buttons = _slide.Buttons;
            Transition = "Fade";
            TransitionSpeed = 1;
            Rules = _slide.Rules;
            DefaultDuration = _slide.DefaultDuration;
            Tags = _slide.Tags;
        }

        public string Transition { get; set; }
        public int? TransitionSpeed { get; set; }
        public DateTime? Duration { get; set; }
        public string ScheduleId { get; set; }
        public string OriginalSlideId { get; set; }

        public void ResetButtonSchedSlideGuids()
        {
            if (Buttons != null)
                foreach (var button in Buttons)
                    button.ScheduledSlideID = GUID;
        }
    }
}
