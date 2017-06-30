using System;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace Inspire.WatchDog.Interface
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Thread workerThread;
        private AppManagerTimer pingTimer;
        private WindowState m_storedWindowState = WindowState.Normal;
        
        public Window1()
        {
            InitializeComponent();

            WindowState = WindowState.Minimized;
            Hide();
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Begin Init
        /// </summary>
        public override void BeginInit()            
        {
            this.pingTimer = new AppManagerTimer();
            this.pingTimer.Name = "PingTimer";            
            this.workerThread = new Thread(new System.Threading.ThreadStart(this.pingTimer.StartTimer));
            this.workerThread.Start();

            base.BeginInit();
          
        }
   
        /// <summary>
        /// On Closing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.pingTimer.StopTimer();
        }
        
        #region Window Events Control
        //Contol window events

        /// <summary>
        /// Drag Window Move Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        /// <summary>
        /// On Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnClose(object sender, System.ComponentModel.CancelEventArgs args)
        {
           // m_notifyIcon.Dispose();
          //  m_notifyIcon = null;
        }

        /// <summary>
        /// On State Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                //if (m_notifyIcon != null)
                //    m_notifyIcon.ShowBalloonTip(6000);
            }
            else
                m_storedWindowState = WindowState;
        }

        /// <summary>
        /// On is Visible Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }

        /// <summary>
        /// m_notifyIcon_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        
        /// <summary>
        /// Check Tray Icon
        /// </summary>
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        /// <summary>
        /// Show Tray Icon
        /// </summary>
        /// <param name="show"></param>
        void ShowTrayIcon(bool show)
        {
            //if (m_notifyIcon != null)
            //    m_notifyIcon.Visible = show;
        }

        /// <summary>
        /// btnMinimize_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// btnClose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

    }
}
