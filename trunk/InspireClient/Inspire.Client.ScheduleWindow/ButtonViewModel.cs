using System;

namespace Inspire.Client.ScheduleWindow
{
    public class ButtonViewModel
    {
        public string ButtonName { get; set; }
        public string SlideName { get; set; }
        public Byte[] ThumbNail { get; set; }
        public string Duration { get; set; }
        public string SlideToGuid { get; set; }
        public string SlideFromGuid { get; set; }
        public string GUID { get; set; }
        public string OriginalSlideGuid { get; set; }

        public ButtonViewModel(ScheduledSlide scheduledSlide, string slideFromGuid, string btnName, string btnGuid, string originalSlideGuid)
        {
            if(scheduledSlide != null)
            {
                SlideToGuid = scheduledSlide.GUID;
                SlideName = scheduledSlide.Name;
                ThumbNail = scheduledSlide.ThumbNail;
                Duration = scheduledSlide.Duration.Value.Hour + ":" + scheduledSlide.Duration.Value.Minute + ":" +
                           scheduledSlide.Duration.Value.Second;
            }
            SlideFromGuid = slideFromGuid;
            OriginalSlideGuid = originalSlideGuid;
            ButtonName = btnName;
            GUID = btnGuid;
        }

        public ButtonViewModel(SlideButton touchScreenButton, string slideFromGuid)
        {
            ButtonName = touchScreenButton.ButtonName;
            GUID = touchScreenButton.GUID;
            SlideFromGuid = slideFromGuid;
            OriginalSlideGuid = touchScreenButton.SlideID;
        }
    }
}
