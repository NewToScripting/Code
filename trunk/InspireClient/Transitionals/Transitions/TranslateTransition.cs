#region License Revision: 0 Last Revised: 3/29/2006 8:21 AM
/******************************************************************************
Copyright (c) Microsoft Corporation.  All rights reserved.


This file is licensed under the Microsoft Public License (Ms-PL). A copy of the Ms-PL should accompany this file. 
If it does not, you can obtain a copy from: 

http://www.microsoft.com/resources/sharedsource/licensingbasics/publiclicense.mspx
******************************************************************************/
#endregion // License
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
    public class TranslateTransition : Transition
    {
        static TranslateTransition()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(TranslateTransition), new FrameworkPropertyMetadata(true));
        }

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(TranslateTransition), new UIPropertyMetadata(Duration.Automatic));


        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point), typeof(TranslateTransition), new UIPropertyMetadata(new Point()));

        public Point EndPoint
        {
            get { return (Point)GetValue(EndPointProperty); }
            set { SetValue(EndPointProperty, value); }
        }

        public static readonly DependencyProperty EndPointProperty =
            DependencyProperty.Register("EndPoint", typeof(Point), typeof(TranslateTransition), new UIPropertyMetadata(new Point()));


        protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            TranslateTransform tt = new TranslateTransform(StartPoint.X * transitionElement.ActualWidth, StartPoint.Y * transitionElement.ActualHeight);

            if (IsNewContentTopmost)
                newContent.RenderTransform = tt;
            else
                oldContent.RenderTransform = tt;

            DoubleAnimation da = new DoubleAnimation(EndPoint.X * transitionElement.ActualWidth, Duration);
            tt.BeginAnimation(TranslateTransform.XProperty, da);

            da.To = EndPoint.Y * transitionElement.ActualHeight;
            da.Completed += delegate
            {
                EndTransition(transitionElement, oldContent, newContent);
            };
            tt.BeginAnimation(TranslateTransform.YProperty, da);
        }

        protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
        {
            newContent.ClearValue(ContentPresenter.RenderTransformProperty);
            oldContent.ClearValue(ContentPresenter.RenderTransformProperty);
        }
    }


    //// Applies a Translation to the content.  You can specify the starting point of the new 
    //// content or the ending point of the old content using relative coordinates.
    //// Set start point to (-1,0) to have the content slide from the left 
    //[System.Runtime.InteropServices.ComVisible(false)]
    //public class TranslateTransition : Transition
    //{
    //    static TranslateTransition()
    //    {
    //        ClipToBoundsProperty.OverrideMetadata(typeof(TranslateTransition), new FrameworkPropertyMetadata(true));
    //    }

    //    public TranslateTransition()
    //    {
    //        this.Duration = new Duration(TimeSpan.FromSeconds(0.5));
    //        this.StartPoint = new Point(-1, 0);
    //    }

    //    public Point StartPoint
    //    {
    //        get { return (Point)GetValue(StartPointProperty); }
    //        set { SetValue(StartPointProperty, value); }
    //    }

    //    public static readonly DependencyProperty StartPointProperty =
    //        DependencyProperty.Register("StartPoint", typeof(Point), typeof(TranslateTransition), new UIPropertyMetadata(new Point()));

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "EndPoint")]
    //    public Point EndPoint
    //    {
    //        get { return (Point)GetValue(EndPointProperty); }
    //        set { SetValue(EndPointProperty, value); }
    //    }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "EndPoint")]
    //    public static readonly DependencyProperty EndPointProperty =
    //        DependencyProperty.Register("EndPoint", typeof(Point), typeof(TranslateTransition), new UIPropertyMetadata(new Point()));

        
    //    protected internal override void BeginTransition(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
    //    {
    //        TranslateTransform tt = new TranslateTransform(StartPoint.X * transitionElement.ActualWidth, StartPoint.Y * transitionElement.ActualHeight);

    //        if (this.IsNewContentTopmost)
    //        {
    //            newContent.RenderTransform = tt;
    //        }
    //        else
    //        {
    //            oldContent.RenderTransform = tt;
    //        }

    //        DoubleAnimation da = new DoubleAnimation(EndPoint.X * transitionElement.ActualWidth, Duration);
    //        da.AccelerationRatio = .20;
    //        da.DecelerationRatio = .20;
    //        tt.BeginAnimation(TranslateTransform.XProperty, da);

    //        da.To = EndPoint.Y * transitionElement.ActualHeight;
    //        da.Completed += delegate
    //        {
    //           EndTransition(transitionElement, oldContent, newContent);
    //        };
    //        tt.BeginAnimation(TranslateTransform.YProperty, da);
    //    }

    //    protected override void OnTransitionEnded(TransitionElement transitionElement, ContentPresenter oldContent, ContentPresenter newContent)
    //    {
    //        oldContent.BeginAnimation(UIElement.OpacityProperty, null);
    //    }
    //}
}
