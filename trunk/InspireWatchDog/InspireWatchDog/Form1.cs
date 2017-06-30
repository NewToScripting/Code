using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Inspire.WatchDog.Service;

namespace InspireWatchDog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Process[] processes = Process.GetProcessesByName("firefox");
                if (processes.Length > 0)
                {
                    foreach( Process item in processes)
                    {
                        item.Kill();
                        item.Dispose();
                    }


                }
                        
                

                   
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process proc = new Process();

            proc.StartInfo.FileName = "firefox.exe";
            //proc.StartInfo.Arguments = "ProcessStart.cs";

            proc.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppChecker checker = new AppChecker();

            try
            {
                if (checker.IsApplicationRunning())
                {
                    if (!checker.IsApplicationResponding())
                    {
                        checker.KillApplication();
                        checker.StartApplication();
                    }
                }
                else
                {
                    checker.StartApplication();
                }

            }
            catch (Exception)
            {

                throw;
            }
            


        }
    }
}
