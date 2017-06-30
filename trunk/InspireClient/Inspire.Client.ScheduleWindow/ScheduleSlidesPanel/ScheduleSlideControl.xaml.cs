using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;
using Inspire.Server.Proxy;
using Transitionals.Controls;

namespace Inspire.Client.ScheduleWindow.ScheduleSlidePanel
{
    /// <summary>
    /// Interaction logic for ScheduleSlideControl.xaml
    /// </summary>
    public partial class ScheduleSlideControl
    {
        public ScheduleSlideControl()
        {
            InitializeComponent();
            SlideWrapPanel.ItemsSource = SlideItemCollection.Slides;
        }

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                UserControl schedulerWindow = mainApp.FindName("SchedulerWindow") as UserControl;

                if (schedulerWindow != null)
                {
                    var scheduledSlideControl = schedulerWindow.FindName("SchedulerHolder") as TransitionElement;

                    if (scheduledSlideControl != null)
                    {
                        if (scheduledSlideControl.Content is ScheduleInfo)
                        {
                            Rectangle DropPanel = ((ScheduleInfo)scheduledSlideControl.Content).FindName("DropGrabber") as Rectangle;

                        if (DropPanel != null) DropPanel.Visibility = Visibility.Visible;
                        }
                    }
                }
            }

            Slide _slide = (Slide)((Grid)sender).DataContext;

            var schedSlide = new ScheduledSlide(_slide);

            //SlideControlItem slideControlItem = new SlideControlItem(new ScheduledSlide(_slide));

            DragDrop.DoDragDrop(this, schedSlide, DragDropEffects.Copy);

           // e.Handled = true;
        }

        private void RefreshSlidesExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnRefresh.IsEnabled = false;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {

                    SlideWrapPanel.ItemsSource = null;

                    SlideItemCollection.UpdateOnlineSlideCollection(SlideManager.GetSlides());

                    SlideItemCollection.LoadOffLineSlides();

                    SlideWrapPanel.ItemsSource = SlideItemCollection.Slides;
                    btnRefresh.IsEnabled = true;

                    SlideItemCollection.SortSlidesByName();
                }));

            }
            catch (Exception)
            {
                btnRefresh.IsEnabled = true;
            }
        }

        private void RefreshSlidesCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
