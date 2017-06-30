using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Inspire.Services.WeakEventHandlers;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for ScrollControl.xaml
    /// </summary>
    public partial class ScrollControl :  INotifyPropertyChanged , IWeakEventListener
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private Storyboard _sb;
        private DoubleAnimation daX;

        private int seconds;

        private int speed;

        public bool IsPlaying { get; set; }

        private bool _playerMode = false;

        public List<FrameworkElement> ScrollItems { get; set; }

        public static DependencyProperty ScrollDurationProperty = DependencyProperty.Register(
            "ScrollDuration", typeof(Duration), typeof(ScrollControl));

        public Duration ScrollDuration
        {
            get { return (Duration)GetValue(ScrollDurationProperty); }
            set
            {
                SetValue(ScrollDurationProperty, value);
            }
        }

        public ScrollControl()
        {
        }

        public ScrollControl(int _speed, List<FrameworkElement> _scrollItems, bool playerMode)
        {
            InitializeComponent();
            _playerMode = playerMode;
            LoadedEventManager.AddListener(this, this);
            ScrollItems = _scrollItems;
            speed = _speed;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (IsPlaying && !_playerMode)
                Play();
        }

        public void Play()
        {
            IsPlaying = true;

            _sb = new Storyboard();

            daX = new DoubleAnimation(container.ActualWidth, ItemsHolder.ActualWidth * -1, ScrollDuration);
            daX.RepeatBehavior = RepeatBehavior.Forever;


            Storyboard.SetTargetName(daX, "translate");
            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

            _sb.Children.Add(daX);
            _sb.Begin(this.ItemsHolder, true);

        }

        public void Stop()
        {
            if (IsPlaying)
            {
                _sb.Stop(ItemsHolder);
                IsPlaying = false;
            }
        }

        void ScrollControl_Loaded(object sender, EventArgs e)
        {
            SetScrollSpeed(speed);
        }

        public void SetScrollSpeed(int newSpeed)
        {
            if (newSpeed > 0)
            {
                newSpeed = newSpeed * 10;
                double length = 0;

                if (ScrollItems != null)
                    foreach (var o in ScrollItems)
                    {
                        length = length + o.ActualWidth;
                    }

                seconds = Convert.ToInt32((length * .30) / newSpeed);

                ScrollDuration = new Duration(new TimeSpan(0, 0, seconds));
            }
            if(IsPlaying)
                Play();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ScrollControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
