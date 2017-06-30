using System.Windows;
using Transitionals;

namespace PlaylistModule
{
    public class PlaylistElement : DependencyObject
    {
        public object MediaElement
        {
            get { return GetValue(MediaElementProperty); }
            set { SetValue(MediaElementProperty, value); }
        }

        public static readonly DependencyProperty MediaElementProperty =
            DependencyProperty.Register("MediaElement",
                typeof(object),
                typeof(PlaylistElement),
                new UIPropertyMetadata(false));

        public Transition Transition
        {
            get { return (Transition)GetValue(TransitionProperty); }
            set { SetValue(TransitionProperty, value); }
        }

        public static readonly DependencyProperty TransitionProperty =
            DependencyProperty.Register("Transition",
                typeof(Transition),
                typeof(PlaylistElement));

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration",
                typeof(Duration),
                typeof(PlaylistElement));

    }
}
