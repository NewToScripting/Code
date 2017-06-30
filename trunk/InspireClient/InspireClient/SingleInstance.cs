using System;
using System.Threading;
using System.Windows;

namespace Inspire.Client
{
    public static class SingleInstance
    {

        internal static void Make(String name, Window app)
        {

            EventWaitHandle eventWaitHandle = null;
            String eventName = Environment.MachineName + "-" + Environment.CurrentDirectory.Replace('\\', '-') + "-" + name;

            bool isFirstInstance = false;

            try
            {
                eventWaitHandle = EventWaitHandle.OpenExisting(eventName);
            }
            catch
            {
                // it's first instance
                isFirstInstance = true;
            }

            if (isFirstInstance)
            {
                eventWaitHandle = new EventWaitHandle(
                    false,
                    EventResetMode.AutoReset,
                    eventName);

                ThreadPool.RegisterWaitForSingleObject(eventWaitHandle, waitOrTimerCallback, app, Timeout.Infinite, false);

                // not need more
                eventWaitHandle.Close();
            }
            else
            {
                eventWaitHandle.Set();

                // For that exit no interceptions
                Environment.Exit(0);
            }
        }


        private static void waitOrTimerCallback(Object state, Boolean timedOut)
        {
            Window app = (Window)state;
            app.Dispatcher.BeginInvoke(new activate(delegate()
            {
                Application.Current.MainWindow.Activate();
            }), null);
        }


        private delegate void activate();

    }
}
