using System.Windows;
using System.Windows.Media.Animation;

namespace Inspire.AnimationLibrary
{
    public class CustomStoryboard : Storyboard
    {
        public CustomStoryboard()
        {

        }

        public CustomStoryboard(CustomStoryboard storyboard)
        {
            AccelerationRatio = storyboard.AccelerationRatio;
            AnimationType = storyboard.AnimationType;
            AutoReverse = storyboard.AutoReverse;
            BeginTime = storyboard.BeginTime;
            Children = storyboard.Children;
            DecelerationRatio = storyboard.DecelerationRatio;
            Duration = storyboard.Duration;
            FillBehavior = storyboard.FillBehavior;
            Name = storyboard.Name;
            RepeatBehavior = storyboard.RepeatBehavior;
            SlipBehavior = storyboard.SlipBehavior;
            SpeedRatio = storyboard.SpeedRatio;
            FriendlyName = storyboard.FriendlyName;
        }

        public enum AnimType { In, Animation, Out }

        public string FriendlyName
        {
            get { return (string)GetValue(FriendlyNameProperty); }
            set { SetValue(FriendlyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FriendlyNamee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FriendlyNameProperty =
            DependencyProperty.Register("FriendlyName", typeof(string), typeof(CustomStoryboard), new UIPropertyMetadata("Animation"));

        public static readonly DependencyProperty AnimationTypeProperty = DependencyProperty.Register("AnimationType", typeof(AnimType), typeof(CustomStoryboard), new UIPropertyMetadata(AnimType.Animation));

        public AnimType AnimationType { get { return (AnimType)GetValue(AnimationTypeProperty); } set { SetValue(AnimationTypeProperty, value); } }
    }
}
