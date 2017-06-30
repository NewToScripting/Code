using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Transitionals.Controls;

namespace Transitionals.Transitions
{
    // Applies a Translation to the content.  You can specify the starting point of the new 
    // content or the ending point of the old content using relative coordinates.
    // Set start point to (-1,0) to have the content slide from the left 
    [System.Runtime.InteropServices.ComVisible(false)]
    public class ZoomInTransition : Transition , IFullDurationTransition
    {
        static ZoomInTransition()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(ZoomInTransition), new FrameworkPropertyMetadata(true));
        }

        //public ZoomInTransition()
        //{
        //    Duration = new Duration(TimeSpan.FromSeconds(4));
        //}

        //public ZoomInTransition(Duration duration)
        //{
        //    Duration = duration;
        //}

        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
             DoubleAnimation da = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.01)));
            da.Completed += delegate
                                {
                                    ScaleTransform tt = new ScaleTransform(1, 1, transitionElement.ActualWidth/2,transitionElement. ActualHeight/2);

                                    if (this.IsNewContentTopmost)
                                    {
                                        newContent.RenderTransform = tt;
                                    }
                                    else
                                    {
                                        oldContent.RenderTransform = tt;
                                    }

                                    DoubleAnimation da1 = new DoubleAnimation(1, 2, new Duration(TimeSpan.FromSeconds(2)));
                                    da1.AccelerationRatio = .20;
                                    da1.DecelerationRatio = .20;
                                    tt.BeginAnimation(TranslateTransform.XProperty, da1);

                                    da1.To = 2;
                                    da1.Completed += delegate
                                                        {
                                                            EndTransition(transitionElement, oldContent, newContent);
                                                        };
                                    tt.BeginAnimation(ScaleTransform.ScaleXProperty, da1);
                                    tt.BeginAnimation(ScaleTransform.ScaleYProperty, da1);
                                };
            oldContent.BeginAnimation(UIElement.OpacityProperty, da);
        }

        protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            oldContent.BeginAnimation(UIElement.OpacityProperty, null);
        }
    }
}
