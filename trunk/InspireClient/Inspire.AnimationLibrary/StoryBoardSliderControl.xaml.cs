using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inspire.AnimationLibrary
{
    /// <summary>
    /// Interaction logic for StoryBoardSliderControl.xaml
    /// </summary>
    public partial class StoryBoardSliderControl : UserControl
    {
        IEnumerable<ContentControl> CanvasItems { get; set; }

        private Storyboard ParentStoryboard;
        private ResourceDictionary _resources;

        public StoryBoardSliderControl()
        {
            InitializeComponent();

            sBSlider.ValueChanged += sBSlider_ValueChanged;

            DataContextChanged += StoryBoardSliderControl_DataContextChanged;

        }

        void ParentStoryboard_Changed(object sender, EventArgs e)
        {
            foreach (var contentControl in CanvasItems)
            {
                var storyboardResources = contentControl.Resources;

                var mainStoryboard = storyboardResources["MainStoryboard"];

                
            }
        }

        void sBSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ParentStoryboard == null) return;

            ClockState csState = ClockState.Stopped;

            ContentControl animatedContent = null;

            if (DataContext is ContentControl)
                animatedContent = DataContext as ContentControl;

            if (animatedContent == null) return;

            //try
            //{

            //    csState = ParentStoryboard.GetCurrentState(animatedContent);

            //}

            //catch
            //{
            //}



            //if ((csState == ClockState.Stopped) || ParentStoryboard.GetIsPaused(animatedContent))
            //{
            //    ParentStoryboard.Begin(animatedContent, true);
            //}



            //ParentStoryboard.Pause();
            //myFrame.PauseMyStoryboard();



            //long lStoryLength;

            //Duration d = ParentStoryboard.Duration;

            //if (d.HasTimeSpan) lStoryLength = (long)d.TimeSpan.TotalMilliseconds;

            //else lStoryLength = 2000;



            //TimeSpan t = new TimeSpan((long)(lStoryLength * e.NewValue * 10000));

            ParentStoryboard.Begin(animatedContent, true);
            ParentStoryboard.Seek(animatedContent, TimeSpan.FromMilliseconds(e.NewValue), TimeSeekOrigin.BeginTime);


            ParentStoryboard.Pause(animatedContent);
        }

        void StoryBoardSliderControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null && DataContext is ContentControl)
            {

                ParentStoryboard = null;

                _resources = ((ContentControl) DataContext).Resources;

                object storyboardEntry = _resources["MainStoryboard"];

                if (storyboardEntry != null)
                {

                    
                    // Storyboard parentStoryboard = storyboardEntry as Storyboard;
                    //if (parentStoryboard != null)
                    //{
                    //    cbStoryBoards.ItemsSource = parentStoryboard.Children;
                    //    //.Clone();
                    //}
                    //else
                    //    parentStoryboard = new Storyboard();

                    ParentStoryboard = storyboardEntry as Storyboard;

                    ParentStoryboard.Changed += new EventHandler(ParentStoryboard_Changed);
                }
            }
        }

        private static TimeSpan? GetMaxStoryboardTime(Storyboard parentStoryboard)
        {
            TimeSpan? timeSpan = TimeSpan.FromSeconds(0);
            foreach (CustomStoryboard customStoryboard in parentStoryboard.Children)
            {
                if (customStoryboard.BeginTime > timeSpan)
                    timeSpan = customStoryboard.BeginTime;
            }
            if (timeSpan != null)
                return timeSpan + TimeSpan.FromSeconds(1);
            return TimeSpan.FromSeconds(0);
        }

        public TimeSpan StoryBoardValue { get { return TimeSpan.FromMilliseconds(sBSlider.Value); } set { sBSlider.Value = value.TotalMilliseconds; } }

        public TimeSpan StoryBoardMaxValue { get { return TimeSpan.FromMilliseconds(sBSlider.Maximum); } set { sBSlider.Maximum = value.TotalMilliseconds; } }

        public TimeSpan StoryBoardMinValuee { get { return TimeSpan.FromMilliseconds(sBSlider.Minimum); } set { sBSlider.Minimum = value.TotalMilliseconds; } }
    }
}
