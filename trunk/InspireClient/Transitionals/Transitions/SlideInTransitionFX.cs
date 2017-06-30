using System;
using Transitionals.Controls;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace Transitionals.Transitions
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public class SlideInTransitionFX : Transition
    {
        public enum SlideDirection
        {
            RightToLeft,
            LeftToRight
        }

        

        public SlideDirection Direction
        {
            get { return (SlideDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(SlideDirection), typeof(SlideInTransitionFX), new UIPropertyMetadata(SlideDirection.RightToLeft));



        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            TransitionEffect effect = new SlideInTransitionEffect();

            double from;
            double to;

            if (Direction == SlideDirection.RightToLeft)
            {
                from = 0.0;
                to = 1.0;
            }
            else
            {
                from = 1.0;
                to = 0.0;
            }


            DoubleAnimation da = new DoubleAnimation(from, to, new Duration(TimeSpan.FromSeconds(1.5)), FillBehavior.HoldEnd);
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

            VisualBrush vi = new VisualBrush(newContent);
            vi.Viewbox = new Rect(0, 0, newContent.ActualWidth, newContent.ActualHeight);
            vi.ViewboxUnits = BrushMappingMode.Absolute;

            //oldContent.Visibility = Visibility.Hidden;

            if (Direction == SlideDirection.RightToLeft)
            {
                effect.OldImage = vb;
                effect.Input = vi;
            }
            else
            {
                effect.OldImage = vi;
                effect.Input = vb;
            }
            //effect.Input = CreateBrush(newContent);
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
