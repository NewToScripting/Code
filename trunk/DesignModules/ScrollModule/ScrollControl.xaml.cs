using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Inspire;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for ScrollControl.xaml
    /// </summary>
    public partial class ScrollControl :  INotifyPropertyChanged , IWeakEventListener, IPlayable
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

        private double seconds;

        private double speed;

        private bool _isPlaying;
        public bool IsPlaying()
        {
            return _isPlaying;
        }

        private bool _playerMode = false;

        private DispatcherTimer sbTimer;

        private bool _isLoaded;

        public string ScrollDirection { get; set; }

        public List<FrameworkElement> ScrollItems { get; set; }

        public static DependencyProperty ScrollPanelOrientationProperty = DependencyProperty.Register(
            "ScrollPanelOrientation", typeof(Orientation), typeof(ScrollControl));

        public Orientation ScrollPanelOrientation
        {
            get { return (Orientation)GetValue(ScrollPanelOrientationProperty); }
            set
            {
                SetValue(ScrollPanelOrientationProperty, value);
                OnPropertyChanged("ScrollPanelOrientation");
            }
        }

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

        static ScrollControl()
        {
        //    Timeline.DesiredFrameRateProperty.OverrideMetadata(
        //typeof(Timeline),
        //    new FrameworkPropertyMetadata { DefaultValue = 50 });
        }

        ~ScrollControl()
        {
            try
            {
                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                {
                    Dispose();
                    //LoadedEventManager.RemoveListener(this, this);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Dispose()
        {
            try
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    if (ScrollItems != null)
                        ScrollItems.Clear();

                    if (sbTimer != null)
                    {
                        sbTimer.Stop();

                        sbTimer = null;
                    }

                    if (_sb != null)
                    {
                        _sb.Stop();
                        _sb = null;
                    }
                    ClearValue(ContentProperty);
                }));
            }
            catch
            {
            }
            
        }

        public ScrollControl()
        {
            InitializeComponent();
            ScrollPanelOrientation = Orientation.Horizontal;
            LoadedEventManager.AddListener(this, this);
            ScrollDirection = "Left";
        }

        public ScrollControl(double _speed, List<FrameworkElement> _scrollItems, string _scrollDirection, bool playerMode)
        {
            InitializeComponent();
            _playerMode = playerMode;

            LoadedEventManager.AddListener(this, this);
            ScrollItems = _scrollItems;
            speed = _speed;

            ScrollDirection = _scrollDirection;

            if (_scrollDirection == "Up" || _scrollDirection == "Down")
                ScrollPanelOrientation = Orientation.Vertical;
            else
                ScrollPanelOrientation = Orientation.Horizontal;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (_isPlaying && !_playerMode)
                Play();
        }

        public void Play()
        {
            _isPlaying = true;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                _sb = new Storyboard();
                switch (ScrollDirection)
                {
                    case ("Left"):
                        {
                            daX = new DoubleAnimation(container.ActualWidth, ItemsHolder.ActualWidth * -1, ScrollDuration);
                            daX.RepeatBehavior = RepeatBehavior.Forever;
                            //daX.BeginTime = TimeSpan.FromSeconds(3);
                            ScrollPanelOrientation = Orientation.Horizontal;

                            Storyboard.SetTargetName(daX, "translate");
                            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                            _sb.Children.Add(daX);
                            _sb.Begin(this.ItemsHolder, true);
                            _sb.Pause();
                            UpdateLayout();
                            break;
                        }
                    case ("Right"):
                        {
                            daX = new DoubleAnimation(container.ActualWidth, ItemsHolder.ActualWidth * -1, ScrollDuration);
                            daX.RepeatBehavior = RepeatBehavior.Forever;

                            ScrollPanelOrientation = Orientation.Horizontal;

                            Storyboard.SetTargetName(daX, "translate");
                            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                            _sb.Children.Add(daX);
                            _sb.Begin(this.ItemsHolder, true);
                            _sb.Pause();
                            UpdateLayout();
                            break;
                        }
                    case ("Up"):
                        {
                            daX = new DoubleAnimation(container.ActualHeight, ItemsHolder.ActualHeight * -1, ScrollDuration);
                            daX.RepeatBehavior = RepeatBehavior.Forever;

                            ScrollPanelOrientation = Orientation.Vertical;

                            Storyboard.SetTargetName(daX, "translate");
                            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.YProperty));

                            _sb.Children.Add(daX);
                            _sb.Begin(this.ItemsHolder, true);
                            _sb.Pause();
                            UpdateLayout();
                            break;
                        }
                    case ("Down"):
                        {
                            daX = new DoubleAnimation(container.ActualHeight, ItemsHolder.ActualHeight * -1, ScrollDuration);
                            daX.RepeatBehavior = RepeatBehavior.Forever;

                            ScrollPanelOrientation = Orientation.Vertical;

                            Storyboard.SetTargetName(daX, "translate");
                            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.YProperty));

                            _sb.Children.Add(daX);
                            _sb.Begin(this.ItemsHolder, true);
                            _sb.Pause();
                            UpdateLayout();
                            break;
                        }
                    default:
                        {
                            double toValue = ItemsHolder.ActualWidth*-1;

                            daX = new DoubleAnimation(container.ActualWidth, toValue, ScrollDuration);
                            daX.RepeatBehavior = RepeatBehavior.Forever;
                            //daX.BeginTime = TimeSpan.FromSeconds(3);
                            ScrollPanelOrientation = Orientation.Horizontal;

                            Storyboard.SetTargetName(daX, "translate");
                            Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                            _sb.Children.Add(daX);
                            _sb.Begin(this.ItemsHolder, true);
                            _sb.Pause();
                            UpdateLayout();
                            break;
                        }
                }
            }));

            if(sbTimer == null)
                sbTimer = new DispatcherTimer();
            sbTimer.Interval = TimeSpan.FromSeconds(3);
            sbTimer.Start();

        }

        void sbTimer_Tick(object sender, EventArgs e)
        {
            if(!IsVisible)
            {Dispose(); return;}

            if (sbTimer != null) sbTimer.Stop();
            if (_sb != null) _sb.Resume(ItemsHolder);
        }

        public void Stop()
        {
            if (_isPlaying)
            {
                _sb.Stop(ItemsHolder);
                _isPlaying = false;
            }
        }

        void ScrollControl_Loaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                sbTimer = new DispatcherTimer();
                sbTimer.Interval = TimeSpan.FromSeconds(1.5);
                DispatcherTimerTickEventManager.AddListener(sbTimer, this);

                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                {
                    _isPlaying = true;
                }
                SetScrollSpeed(speed);
                _isLoaded = true;
            }
        }

        public void SetScrollSpeed(double newSpeed)
        {
            if (newSpeed > 0)
            {
                ////newSpeed = newSpeed * 10;
                double fromSecValue = 0;

                if (ScrollItems != null)
                    foreach (var o in ScrollItems)
                    {
                        if (ScrollDirection == "Up" || ScrollDirection == "Down")
                        {
                            //length = length + o.ActualHeight;
                        }
                        else
                        {
                            //length = length + o.ActualWidth;

                            if (o is TextBlock)
                            {
                                fromSecValue = GetFromSecValue(o, fromSecValue);
                            }
                            else if( o is StackPanel)
                            {
                                foreach (var i in ((StackPanel)o).Children)
                                {
                                    if(i is TextBlock)
                                    {
                                        fromSecValue = GetFromSecValue((TextBlock)i, fromSecValue);
                                    }
                                }
                            }
                        }
                    }

                //seconds = length * .6 / newSpeed;


                double manipulatedValue = newSpeed*fromSecValue;

                ScrollDuration = new Duration(TimeSpan.FromSeconds(manipulatedValue));
            }
            if (_isPlaying)
                Play();
        }

        private double GetFromSecValue(FrameworkElement o, double fromSecValue)
        {
            double equSlope = 0.022546419;
            double offSetY = 10.96286472;
            double stringSize;

            var textBlock = (TextBlock) o;

            string text = textBlock.Text;

            int textLen = text.Length;


            //Set the width of the text box according to the width (not length) of the text in it.   

            System.Globalization.CultureInfo enUsCultureInfo;
            Typeface fontTF;
            FormattedText frmmtText;

            if (textLen > 0)
            {
                enUsCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                fontTF = new Typeface(textBlock.FontFamily, textBlock.FontStyle,
                                      textBlock.FontWeight,
                                      textBlock.FontStretch);
                frmmtText = new FormattedText(text, enUsCultureInfo, FlowDirection.LeftToRight,
                                              fontTF, textBlock.FontSize, textBlock.Foreground);

                stringSize = frmmtText.Width;

                fromSecValue += (stringSize*equSlope) + offSetY;
            }
            return fromSecValue;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ScrollControl_Loaded(sender, e);
                return true;
            }
            else if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                sbTimer_Tick(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
