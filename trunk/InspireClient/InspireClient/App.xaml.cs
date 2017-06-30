using System;
using System.Windows;

namespace Inspire.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public App()
        //{
        //    //Startup += new StartupEventHandler(App_Startup);
        //}

        

        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args != null && e.Args.Length > 0)
                Properties["StartupFileName"] = e.Args[0];

            base.OnStartup(e);

        }
    }
}
