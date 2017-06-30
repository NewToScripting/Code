using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Properties;
using Inspire.Services;

namespace Inspire
{
    /// <summary>
    /// Class that holds Global Settings for the Client and Display Apps.
    /// </summary>
    public static class InspireApp
    {   
        /// <summary>
        /// This flag determines if the modules should load up and play after being serialized.
        /// </summary>
        public static bool IsPlayer { get; set; }
        public static bool IsCopying { get; set; }
        public static int CurrentSlideDuration { get; set; }
        public static string CurrentSlideGuid { get; set; }
        public static string DisplaySlidePath { get; set; }
        public static string CurrentScheduleGuidLoaded { get; set; }
        public static string PlaybackHostName { get; set; }
        public static bool IsPreviewMode { get; set; }
        public static DateTime PlaybackDateTime { get; set; }
        public static bool DisplaySleepModeOn { get; set; }
        public static ZoomService DesignerZoomService { get; set; }
        public static bool PlayNextSlide { get; set; }
        public static UserControl CurrentDragCanvas { get; set; }
        public static Canvas CurrentPreviewCanvas { get; set; }
        public static Canvas CurrentPlayerCanvas { get; set; }
        public static bool CanvasExists { get; set; }
        public static object SelectedContext { get; set; }
        public static List<string> SlideSkipList { get; private set; }
        public static List<string> SlideDontSkipList { get; private set; }
        public static bool IsPlaying { get; set; }

        public static ResourceManager ResourceManager
        {
            get { return Resources.ResourceManager; }
        }

        //public static UndoService UndoService = new UndoService();

        static InspireApp()
        {
            SlideSkipList = new List<string>();
            SlideDontSkipList = new List<string>();
        }

        public static Size GetCanvasSize()
        {
            double canvasWidth = 0d;
            double canvasHeight = 0d;

            if (CurrentPlayerCanvas != null)
            {
                canvasHeight = CurrentPlayerCanvas.Height;
                canvasWidth = CurrentPlayerCanvas.Width;
            }

            if (CurrentDragCanvas != null)
            {
                if (CurrentDragCanvas.Height > canvasHeight)
                {
                    canvasHeight = CurrentDragCanvas.Height;
                    canvasWidth = CurrentDragCanvas.Width;
                }
            }

            if (CurrentPreviewCanvas != null)
            {
                if (CurrentPreviewCanvas.Height > canvasHeight)
                {
                    canvasHeight = CurrentPreviewCanvas.Height;
                    canvasWidth = CurrentPreviewCanvas.Width;
                }
            }
            return new Size(canvasWidth, canvasHeight);
        }

        public static void AddSkipSlide(string skipSlide)
        {
            if(!SlideSkipList.Contains(skipSlide))
                SlideSkipList.Add(skipSlide);
        }

        public static void AddDontSkipSlide(string dontSkipSlide)
        {
            if (!SlideDontSkipList.Contains(dontSkipSlide))
                SlideDontSkipList.Add(dontSkipSlide);
        }

        public static void RemoveSkipSlide(string skipSlide)
        {
            if (SlideSkipList.Contains(skipSlide))
                SlideSkipList.Remove(skipSlide);
        }

        public static void RemoveDontSkipSlide(string dontSkipSlide)
        {
            if (SlideDontSkipList.Contains(dontSkipSlide))
                SlideDontSkipList.Remove(dontSkipSlide);
        }

        public static void PrepControlPositions(ContentControl control)
        {
            if (control is DesignControlHolder)
            {
                ((DesignControlHolder) control).Left = Canvas.GetLeft(control);
                ((DesignControlHolder) control).Top = Canvas.GetTop(control);
                ((DesignControlHolder) control).StartOpacity = control.Opacity;

                var transformGroup = control.RenderTransform as TransformGroup;

                if (transformGroup != null)
                {
                    var scaleTransform = transformGroup.Children[0] as ScaleTransform;
                    if (scaleTransform != null)
                    {
                        ((DesignControlHolder) control).BeginScaleX = scaleTransform.ScaleX;
                        ((DesignControlHolder) control).BeginScaleY = scaleTransform.ScaleY;
                    }
                }
            }
        }

        public static void StopAnimations(ContentControl control)
        {
            BeginStoryboard beginStoryboard = null;

            foreach (DictionaryEntry item in control.Resources)
            {
                if (item.Key.Equals("Test"))
                    beginStoryboard = item.Value as BeginStoryboard;
            }

            if (beginStoryboard != null) beginStoryboard.Storyboard.Stop(control);

            control.Resources.Remove("Test");
            control.Resources.Remove("StopTest");
            control.Triggers.Clear();

            if (control is DesignControlHolder)
            {
                control.Visibility = Visibility.Visible;
                //Canvas.SetLeft(control, ((DesignControlHolder)control).Left);
                //Canvas.SetTop(control, ((DesignControlHolder)control).Top);
                //control.Opacity = ((DesignControlHolder) control).StartOpacity;

                //var transformGroup = control.RenderTransform as TransformGroup;

                //if (transformGroup != null)
                //{
                //    var scaleTransform = transformGroup.Children[0] as ScaleTransform;
                //    if (scaleTransform != null)
                //    {
                //        scaleTransform.ScaleX = ((DesignControlHolder)control).BeginScaleX;
                //        scaleTransform.ScaleY = ((DesignControlHolder)control).BeginScaleY;
                //    }
                //}
            }
        }

        public static IEnumerable<ContentControl> GetCurrentPreviewDesignItems()
        {
            return CurrentPreviewCanvas != null ? CurrentPreviewCanvas.Children.OfType<ContentControl>() : null;
        }

        public static IEnumerable<ContentControl> GetDesignItems()
        {
            return CanvasExists ? ((IInspireCanvas)CurrentDragCanvas).GetDesignItems() : null;
        }

        public static IEnumerable<ContentControl> GetPlayerDesignItems()
        {
            return CurrentPlayerCanvas != null ? CurrentPlayerCanvas.Children.OfType<ContentControl>() : null;
        }

        public static bool IsDemoMode { get; set; }
    }
}
