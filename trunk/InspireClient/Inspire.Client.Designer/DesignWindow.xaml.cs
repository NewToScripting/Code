using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using Inspire.Services;
using Inspire.Services.WeakEventHandlers;
using System.Diagnostics;

namespace Inspire.Client.Designer
{
    /// <summary>
    /// Interaction logic for DesignWindow.xaml
    /// </summary>
    public partial class DesignWindow : IWeakEventListener
    {
        private static DesignWindow _thisDesigner;

        public DesignWindow()
        {
            InitializeComponent();
            DesignerDragCanvasHolder.SelectionChanged += DesignerDragCanvasHolder_SelectionChanged;
            InspireApp.DesignerZoomService = new ZoomService();
            LoadedEventManager.AddListener(this, this);
            slideTimer = new DateTime();
            slideTimer = DateTime.Today.Date;
            InspireApp.DesignerZoomService.CurrentZoom = Slider.Value;
            Slider.ValueChanged += delegate { InspireApp.DesignerZoomService.CurrentZoom = Slider.Value; };

            AddHandler(CloseableTabItem.CloseTabEvent, new RoutedEventHandler(CloseTab));
            _thisDesigner = this;
        }

        void DesignerDragCanvasHolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DesignerDragCanvasHolder.Items.Count < 1)
            {
                InspireApp.CurrentDragCanvas = null;
                PART_WidthLabel.Content = null;
                PART_HeightLabel.Content = null;
            }
            if (DesignerDragCanvasHolder.SelectedValue == null)
                DesignerDragCanvasHolder.SelectedIndex = 0;

            if (DesignerDragCanvasHolder.SelectedValue != null)
            {
                InspireApp.CurrentDragCanvas =
                    (DragCanvas.DragCanvas) ((TabItem) DesignerDragCanvasHolder.SelectedValue).Content;

                InspirePropertyControl.ReloadLayers(InspireApp.CurrentDragCanvas);
                PART_WidthLabel.Content = InspireApp.CurrentDragCanvas.Width;
                PART_HeightLabel.Content = InspireApp.CurrentDragCanvas.Height;
            }

            InspirePropertyControl.ClearPropertyPanel();

        }

        protected static Timer _timer = new Timer();
        private Stopwatch _sw = new Stopwatch();
        private string _timeString = String.Empty;



        public bool IsPlaying
        {
            get { return (bool)GetValue(IsPlayingProperty); }
            set { SetValue(IsPlayingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPlaying.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPlayingProperty =
            DependencyProperty.Register("IsPlaying", typeof(bool), typeof(DesignWindow), new UIPropertyMetadata(false));

        

        public static bool IsDesignerMode { get; set; }

        protected static DateTime slideTimer;

        private double InitialZoom { get; set; }

        void DesignWindow_Loaded(object sender, EventArgs e)
        {
            tbTimer.Text = "00:00:00";
            _timer.Interval = 100;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void CloseTab(object source, RoutedEventArgs args)
        {
            TabItem tabItem = args.OriginalSource as TabItem;
            if (tabItem != null)
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                if (tabControl != null)
                {
                    var dragCanvas = tabItem.Content as DragCanvas.DragCanvas;
                    tabControl.Items.Remove(tabItem);

                    if (dragCanvas != null) dragCanvas.Dispose();

                    if (tabControl.Items.Count == 0)
                        lblNewSlide.Visibility = Visibility;
                }
            }
        }

        public void PlayLock(bool lockMe)
        {
            InspirePropertyControl.IsHitTestVisible = !lockMe;
            statusBar.IsHitTestVisible = !lockMe;
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeString = _sw.Elapsed.Minutes.ToString("00") + ":" + _sw.Elapsed.Seconds.ToString("00") + ":" +
                          _sw.Elapsed.Milliseconds.ToString("00").Substring(0, 2);
            SetTimer(_timeString);
        }

        public void ResetZoom()
        {
            Slider.Value = InitialZoom;
        }


        private void SetTimer(string timeString)
        {
            Dispatcher.BeginInvoke(new Action(() => tbTimer.Text = timeString));
        }


        public void StartTimer()
        {
            _sw.Reset();
            _timeString = "00:00:00";
            _sw.Start();
            _timer.Enabled = true;
        }

        public void StopTimer()
        {
            _sw.Stop();
            _sw.Reset();
            _timer.Enabled = false;
        }

        public void SetZoom(Size designerWindow, Size canvasWindow)
        {

            InitialZoom = Slider.Value;

            var zoomHeight = (Slider.Value * 1.16)*canvasWindow.Height;
            var zoomWidth = (Slider.Value * 1.266)*canvasWindow.Width;

            double widthZoom = InitialZoom;
            double heightZoom = InitialZoom;

            if (zoomWidth > ActualWidth)
                widthZoom = (Slider.Value / (zoomWidth / ActualWidth)) / 1.16;

            if (zoomHeight > ActualHeight)
                heightZoom = (Slider.Value / (zoomHeight / ActualHeight)) / 1.266;

            Slider.Value = widthZoom < heightZoom ? widthZoom : heightZoom;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                DesignWindow_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion


        public static DesignWindow GetDesignerWindow()
        {
            return _thisDesigner;
        }
    }
}
