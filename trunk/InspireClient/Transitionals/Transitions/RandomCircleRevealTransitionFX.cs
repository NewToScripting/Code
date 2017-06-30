using System;
using Transitionals.Controls;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace Transitionals.Transitions
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public class RandomCircleRevealTransitionFX : Transition
    {
        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            TransitionEffect effect = new RandomCircleRevealTransitionEffect();

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(2.0)), FillBehavior.HoldEnd);
            da.AccelerationRatio = 0.5;
            da.DecelerationRatio = 0.5;
            da.Completed += delegate
            {
                EndTransition(transitionElement, oldContent, newContent);
            };
            effect.BeginAnimation(TransitionEffect.ProgressProperty, da);

            VisualBrush vb = new VisualBrush(oldContent);
            vb.Viewbox = new Rect(0, 0, oldContent.ActualWidth, oldContent.ActualHeight);
            vb.ViewboxUnits = BrushMappingMode.Absolute;

            effect.OldImage = vb;
            transitionElement.Effect = effect;
        }

        protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            newContent.ClearValue(ContentPresenter.RenderTransformProperty);
            oldContent.ClearValue(ContentPresenter.RenderTransformProperty);
            transitionElement.Effect = null;
        }
    }
}
