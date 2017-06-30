using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Transitionals.Controls;

namespace Transitionals.Transitions
{
    // Simple transition that fades out the old content
    [System.Runtime.InteropServices.ComVisible(false)]
    public class NoTransition : Transition
    {
        static NoTransition()
        {
            //AcceptsNullContentProperty.OverrideMetadata(typeof(NoTransition), new FrameworkPropertyMetadata(NullContentSupport.New));
            IsNewContentTopmostProperty.OverrideMetadata(typeof(NoTransition), new FrameworkPropertyMetadata(false));
        }

        //public NoTransition()
        //{
        //    Duration = new Duration(TimeSpan.FromMilliseconds(1));
        //}

        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            DoubleAnimation da = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(.1)));
            da.Completed += delegate
            {
                EndTransition(transitionElement, oldContent, newContent);
            };
            oldContent.BeginAnimation(UIElement.OpacityProperty, da);
        }

        protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            oldContent.BeginAnimation(UIElement.OpacityProperty, null);
        }

    }
}
