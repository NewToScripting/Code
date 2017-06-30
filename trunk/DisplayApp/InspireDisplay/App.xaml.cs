using System;
using System.Windows;

namespace InspireDisplay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        public App()
        {
            //Handle any un-handled errors here 

            //DispatcherUnhandledException += Current_DispatcherUnhandledException;
            //System.Windows.Forms.Application.ThreadException += Application_ThreadException;
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //ProxyErrorHandler.LogAndRestart(e.Exception, "The application crashed at " + DateTime.Now + ". Restarting...");
        }

        static void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //ProxyErrorHandler.LogAndRestart(e.Exception, "The application crashed at " + DateTime.Now + ". Restarting...");
        }

        
    }
}
