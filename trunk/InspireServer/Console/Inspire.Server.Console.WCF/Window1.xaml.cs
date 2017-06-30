using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inspire.Server.Console.Interface.DisplayServiceReference;
using System.Configuration;

namespace Inspire.Server.Console.Interface
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private ServiceController service;
        private Displays displays;
        private string serviceName;

        public Window1()
        {

            InitializeComponent();
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipText = "Inspire Displays Server Console has been minimized. Click the tray icon to restore.";
            m_notifyIcon.BalloonTipTitle = "Inspire Displays Server Console";
            m_notifyIcon.Text = "Inspire Console";
            m_notifyIcon.Icon = new System.Drawing.Icon("AllIcons.ico");
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
            serviceName = ConfigurationManager.AppSettings["ServiceName"].ToString();                   
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        { 
            lblHostName.Content = "Server: " + System.Environment.MachineName.ToString();

            try
            {
                service = new ServiceController(serviceName);
            }
            catch
            {
                MessageBox.Show("Error loading service...");
            }
           
            
            lblServiceStatusValue.Content = service.Status;
            displays = DisplayProxy.GetDisplays();
            grdDisplaysGrid.ItemsSource = displays;
            
        }
         
        private void btnGetEvents_Click(object sender, RoutedEventArgs e)
        {
            grdEventsGrid.ItemsSource = EventLogAdmin.getLog();
            btnGetEvents.Content = "Refresh Inspire Event Log";

        }

        #region Window Events Control
        //Contol window events
     

        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }


        void OnClose(object sender, CancelEventArgs args)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }

        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }


        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        #endregion


        #region Service Control 
        //Contol windows service

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            service = new ServiceController("InspireConsoleService"); 
            lblServiceStatusValue.Content = ServiceAdmin.StartService(service);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            lblServiceStatusValue.Content = ServiceAdmin.StopService(service);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            service.Refresh();
            lblServiceStatusValue.Content = service.Status;
        }
    
        #endregion

        private void btnDisplaysRefresh_Click(object sender, RoutedEventArgs e)
        {
            displays = DisplayProxy.GetDisplays();
            grdDisplaysGrid.ItemsSource = displays;
        }





    }
}
