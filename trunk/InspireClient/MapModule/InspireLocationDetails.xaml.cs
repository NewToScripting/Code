using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;
using Transitionals.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for InspireLocationDetails.xaml
    /// </summary>
    public partial class InspireLocationDetails : IWeakEventListener
    {
        private readonly TransitionElement _parent;

        private readonly DispatcherTimer _closeTimer = new DispatcherTimer();

        private readonly DateTime _startedTime;

        public InspireLocationDetails(InspireMapLocation inspireMapLocation, TransitionElement transitionElement)
        {
            InitializeComponent();
            DataContext = inspireMapLocation;
            _parent = transitionElement;
            _closeTimer.Stop();
            _closeTimer.Interval = TimeSpan.FromSeconds(29);
            DispatcherTimerTickEventManager.AddListener(_closeTimer, this);
            _closeTimer.Start();
            _startedTime = DateTime.Now;
            if (inspireMapLocation != null)
                if (inspireMapLocation.RatingCount == 0)
                {
                    PART_RatingControl.Visibility = Visibility.Collapsed;
                    PART_NumOfRatings.Visibility = Visibility.Collapsed;
                }
                //if (!inspireMapLocation.ShowPriceRating)
                //    amtControl.Visibility = Visibility.Collapsed;
        }

        void _closeTimer_Tick(object sender, EventArgs e)
        {
            if (IsVisible && (DateTime.Now - _startedTime) > TimeSpan.FromSeconds(25)) // Make sure the box has showed for more than 9 seconds
            {
                _closeTimer.Stop();
                if (_parent != null) _parent.Content = null;
                try
                {
                    DispatcherTimerTickEventManager.RemoveListener(_closeTimer, this);
                }
                catch (Exception)
                {

                }
            }
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                _closeTimer_Tick(sender, e);
                return true;
            }
            return false;
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _closeTimer.Stop();
            if (_parent != null) _parent.Content = null;
            try
            {
                DispatcherTimerTickEventManager.RemoveListener(_closeTimer, this);
            }
            catch (Exception)
            {

            }
        }

        private void Border_TouchDown(object sender, TouchEventArgs e)
        {
            _closeTimer.Stop();
            if (_parent != null) _parent.Content = null;
            try
            {
                DispatcherTimerTickEventManager.RemoveListener(_closeTimer, this);
            }
            catch (Exception)
            {

            }
        }
    }
}
