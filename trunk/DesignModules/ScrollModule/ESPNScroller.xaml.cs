using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Inspire;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using System.Collections.ObjectModel;

namespace ScrollModule
{
    /// <summary>
    /// Interaction logic for ESPNScroller.xaml
    /// </summary>
    public partial class ESPNScroller : INotifyPropertyChanged, IWeakEventListener, IPlayable
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
            private DoubleAnimation daU;
            private DoubleAnimation daY;
            private DoubleAnimation daS;

            private double seconds;

            private double speed;

            private bool _isPlaying;
            public bool IsPlaying()
            {
                return _isPlaying;
            }

        private bool _playerMode = false;

            private ObservableCollection<FrameworkElement> _totalItems;

            private DispatcherTimer sbTimer;

            private bool _isLoaded;

            private int _currentItem;

            public ObservableCollection<FrameworkElement> ScrollItems { get; set; }

            public static DependencyProperty ESPNScrollDurationProperty = DependencyProperty.Register(
                "ESPNScrollDuration", typeof(Duration), typeof(ESPNScroller));
            private int _tickCounter;

            public Duration ESPNScrollDuration
            {
                get { return (Duration)GetValue(ESPNScrollDurationProperty); }
                set
                {
                    SetValue(ESPNScrollDurationProperty, value);
                }
            }

            //static ESPNScroller()
            //{
                
            ////    Timeline.DesiredFrameRateProperty.OverrideMetadata(
            ////typeof(Timeline),
            ////    new FrameworkPropertyMetadata { DefaultValue = 50 });
            //}

            ~ESPNScroller()
            {
                try
                {
                    if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            if (ScrollItems != null)
                                ScrollItems.Clear();
                            if (_sb != null)
                            {
                                _sb.Stop();
                                _sb = null;
                            }
                            ClearValue(ContentProperty);
                        }));
                        //LoadedEventManager.RemoveListener(this, this);
                    }
                }
                catch (Exception)
                {
                }
            }

            public ESPNScroller()
            {
                InitializeComponent();
                LoadedEventManager.AddListener(this, this);
                _sb = new Storyboard();
                _sb.Completed += new EventHandler(_sb_Completed);
               
            }

            void _sb_Completed(object sender, EventArgs e)
            {
                if (!IsVisible)
                    _tickCounter++;

                if (_tickCounter > 2)
                {
                    Dispose();
                    return;
                }
                if (sbTimer != null)
                {
                    sbTimer.Stop();
                    sbTimer.Interval = TimeSpan.FromSeconds(1.5);
                }

                if (_totalItems == null) return;
 
                if (_currentItem >= _totalItems.Count - 1)
                    _currentItem = 0;
                else
                {
                    _currentItem++;
                }

                if (ScrollItems != null)
                {
                    ScrollItems.Clear();

                    if(_totalItems.Count == 0) return;
                    ScrollItems.Add(_totalItems.ElementAt(_currentItem));
                }
                SetScrollSpeed(speed);
                Play();
            }

        private void Dispose()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                try
                {
                    if(sbTimer != null)
                        sbTimer.Stop();
                    sbTimer = null;

                    if (ScrollItems != null)
                        ScrollItems.Clear();

                    if(_totalItems != null)
                        _totalItems.Clear();

                    if (_sb != null)
                    {
                        _sb.Stop();
                        _sb = null;
                    }
                    ClearValue(ContentProperty);
                }
                catch
                {
                }
                
            }));
        }

        public ESPNScroller(double _speed, List<FrameworkElement> _scrollItems, string _scrollDirection, bool playerMode) : this()
            {
                InitializeComponent();
                _playerMode = playerMode;
               
                _currentItem = 0;
                _totalItems = new ObservableCollection<FrameworkElement>(_scrollItems);
                ScrollItems = new ObservableCollection<FrameworkElement>(_totalItems.Take(1).ToList());
                ESPNItemsHolder.ItemsSource = ScrollItems;
                speed = _speed;
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

                if (ScrollItems.Count > 0)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    _sb.Children.Clear();

                    daS = new DoubleAnimation(0,0, new Duration(TimeSpan.FromSeconds(.5)));

                    Storyboard.SetTargetName(daS, "translate");
                    Storyboard.SetTargetProperty(daS, new PropertyPath(TranslateTransform.XProperty));

                    _sb.Children.Add(daS);

                    double actualWidth = 0d;

                    if (!double.IsNaN(((ScrollItems[0]).Width)))
                        if (((ScrollItems[0]).ActualWidth > ((ScrollItems[0]).Width)))
                            actualWidth = (ScrollItems[0]).ActualWidth;
                        else
                            actualWidth = (ScrollItems[0]).Width;
                    else
                        actualWidth = ((ScrollItems[0]).ActualWidth);

                    daY = new DoubleAnimation((ActualHeight), 0, new Duration(TimeSpan.FromSeconds(.7)));
                    //daX.BeginTime = TimeSpan.FromSeconds(1.5);

                    Storyboard.SetTargetName(daY, "translate");
                    Storyboard.SetTargetProperty(daY, new PropertyPath(TranslateTransform.YProperty));

                    _sb.Children.Add(daY);

                    if (ActualWidth > actualWidth)
                    {
                        daU = new DoubleAnimation(0, (ActualHeight) * -1, new Duration(TimeSpan.FromSeconds(.7)));
                        daU.BeginTime = TimeSpan.FromSeconds(4);

                        Storyboard.SetTargetName(daU, "translate");
                        Storyboard.SetTargetProperty(daU, new PropertyPath(TranslateTransform.YProperty));

                        _sb.Children.Add(daU);
                    }
                    else
                    {
                        daX = new DoubleAnimation(0, (actualWidth) * -1, ESPNScrollDuration);//(actualWidth + 20) * -1, ESPNScrollDuration);
                        daX.BeginTime = TimeSpan.FromSeconds(1);
                       // daX.AccelerationRatio = .1;
                        var ease = new PowerEase();
                        //ease.
                        ease.Power = 1.1;
                        ease.EasingMode = EasingMode.EaseIn;
                        daX.EasingFunction = ease;
                        //daX.Completed   

                        Storyboard.SetTargetName(daX, "translate");
                        Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                        _sb.Children.Add(daX);
                    }
                    

                    

                    _sb.FillBehavior = FillBehavior.HoldEnd;
                    
                    _sb.Begin(this.ESPNItemsHolder, true);

                    UpdateLayout();
                }));

                //sbTimer.Interval = TimeSpan.FromSeconds(1.5);
                if(sbTimer == null)
                {
                    sbTimer = new DispatcherTimer();
                }
                sbTimer.Start();

            }

            void sbTimer_Tick(object sender, EventArgs e)
            {
                if (!IsVisible)
                {
                    Dispose();
                    return;
                }

                if (sbTimer != null) sbTimer.Stop();
                if (_sb != null) _sb.Resume(ESPNItemsHolder);
            }

            public void Stop()
            {
                if (_isPlaying)
                {
                    _sb.Stop(ESPNItemsHolder);
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
                            if (o is TextBlock)
                            {
                                fromSecValue = GetFromSecValue(o, fromSecValue);
                            }
                            else if (o is StackPanel)
                            {
                                foreach (var i in ((StackPanel)o).Children)
                                {
                                    if (i is TextBlock)
                                    {
                                        fromSecValue = GetFromSecValue((TextBlock)i, fromSecValue);
                                    }
                                }
                            }
                        }

                    //seconds = length * .6 / newSpeed;


                    double manipulatedValue = newSpeed*fromSecValue;

                    ESPNScrollDuration = new Duration(TimeSpan.FromSeconds(manipulatedValue));
                }
                if (_isPlaying)
                    Play();
            }

            private static double GetFromSecValue(FrameworkElement o, double fromSecValue)
            {
                double equSlope = 0.022546419;
                double offSetY = 10.96286472;
                double stringSize;

                var textBlock = (TextBlock)o;

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

                    fromSecValue += (stringSize * equSlope) + offSetY;
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
