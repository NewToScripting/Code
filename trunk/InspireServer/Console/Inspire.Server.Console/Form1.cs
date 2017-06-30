using System;
using System.Drawing;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Inspire.Server.Console
{
    public partial class Form1 : Form
    {
        private ServiceController service;
        private Point mouseOffset;
        private bool isMouseDown = false;

        public Form1()
          {
            InitializeComponent();
            //txtPingInterval.Text = InspireServerConfig.GetValue("PingInterval");
            //txtEventInterval.Text = InspireServerConfig.GetValue("UpdateInterval");
            service = new ServiceController("InspireConsoleService");
           }
            private void btnPingInterval_Click(object sender, EventArgs e)
            {     
                //InspireServerConfig.UpdateValue("PingInterval", txtPingInterval.Text);
                //txtPingInterval.Text = InspireServerConfig.GetValue("PingInterval");
            }

            private void button4_Click(object sender, EventArgs e)
            {
                //InspireServerConfig.UpdateValue("UpdateInterval", txtEventInterval.Text);
                //txtEventInterval.Text = InspireServerConfig.GetValue("UpdateInterval");
            }

            private void btnStartService_Click(object sender, EventArgs e)
            {
                //lblServiceStatus.Text = ServiceAdmin.StartService(service);
            }

            private void btnEndService_Click(object sender, EventArgs e)
            {
                //lblServiceStatus.Text = ServiceAdmin.StopService(service);
            }

            private void btnRefresh_Click(object sender, EventArgs e)
            {
                //service.Refresh();
                //lblServiceStatus.Text = service.Status.ToString();
            }

            private void btnRefreshGrid_Click(object sender, EventArgs e)
            {
                //grdSystemEvents.DataSource = EventLogAdmin.getLog();
            }

            private void Form1_Resize(object sender, System.EventArgs e)
            {
                if (FormWindowState.Minimized == WindowState)
                    Hide();
            }
            private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }

          
            private void btnMinimize_Click(object sender, EventArgs e)
            {
                Hide();
            }

            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                int xOffset;
                int yOffset;
                if (e.Button == MouseButtons.Left)
                {
                    xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                    yOffset = -e.Y -
                        SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;

                    mouseOffset = new Point(xOffset, yOffset);
                    isMouseDown = true;
                }
            }

            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }

            }

            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (isMouseDown)
                {
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                    Location = mousePos;
                }
            }

         




    }
}
