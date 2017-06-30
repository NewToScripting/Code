using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Inspire;

namespace InspireDisplay
{
    public static class SlideManager
    {

        public static ObservableCollection<PlayListSlide> SlidePlaylist  = new ObservableCollection<PlayListSlide>();

        //public string SlideGuid { get; set; }

        //public DateTime ?Duration { get; set; }

        //public string SlideTransition { get; set; }

        public static bool IsTouchscreenMode { get; set; }

        public static List<KeyValuePair<string, string>> CurrentButtonNavigations;

        public static PlayListSlide GetCurrentSlide()
        {
            var currentSlide = new PlayListSlide();
            foreach (var playListSlide in SlidePlaylist)
            {
                if (playListSlide.IsActive)
                {
                    currentSlide = playListSlide;
                    break;
                }
            }

            if(!currentSlide.IsActive)
            {
                if (SlidePlaylist.Count > 0)
                {
                    currentSlide = SlidePlaylist[0];
                }
                currentSlide.IsActive = true;
            }
            return currentSlide;
        }

        public static DateTime? GetCurrentDuration()
        {
            try
            {
                var currentslide = GetCurrentSlide();
                return currentslide.Duration;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public static double GetNonDuplicateCount(ObservableCollection<PlayListSlide> slidePlaylist)
        {
            var playlistGuids = new List<string>();

            foreach (var playListSlide in slidePlaylist)
            {
                if(!playlistGuids.Contains(playListSlide.OriginalSlideId))
                    playlistGuids.Add(playListSlide.OriginalSlideId);
            }
            return playlistGuids.Count;
        }

        public static bool ShouldTimerStart(string slideGuid)
        {
            return SlidePlaylist.Count <= 0 || (!IsTouchscreenMode || SlidePlaylist[0].GUID == slideGuid);
        }

        public static bool TouchscreenOnFirstSlide
        {
            get
            {
                if (SlidePlaylist.Count > 0) return (IsTouchscreenMode && SlidePlaylist[0].IsActive);
                return false;
            }
        }

        internal static void SetActiveSlide()
        {
            bool hasActiveSlide = false;
            foreach (var playListSlide in SlidePlaylist)
            {
                if (CurrentSlideGuid == playListSlide.GUID)
                {
                    playListSlide.IsActive = true;
                    hasActiveSlide = true;
                    break;
                }
                else
                    playListSlide.IsActive = false;
            }

            if (!hasActiveSlide && SlidePlaylist.Count > 0)
                SlidePlaylist[0].IsActive = true;
        }

        public static string CurrentSlideGuid { get; set; }

        internal static int GetCurrentIndex()
        {
            for (int i = 0; i < SlidePlaylist.Count; i++)
            {
                if (SlidePlaylist[i].IsActive)
                    return i;
            }
            return 0;
        }
    }

    public class PlayListSlide : ScheduledSlide
    {
        public bool IsActive { get; set; }

        public PlayListSlide()
        {
            IsActive = false;
        }

        public PlayListSlide(ScheduledSlide scheduledSlide)
        {
            GUID = scheduledSlide.GUID;
            OriginalSlideId = scheduledSlide.OriginalSlideId;
            Name = scheduledSlide.Name;
            Duration = scheduledSlide.Duration;
            Transition = scheduledSlide.Transition;
            TransitionSpeed = scheduledSlide.TransitionSpeed;
            Buttons = scheduledSlide.Buttons;
            IsActive = false;
        }
    }
}
