using System;
using System.ComponentModel;
using System.Windows;

namespace EventsModule.EventTemplates.RoomEvents
{
    /// <summary>
    /// Interaction logic for RoomEvent.xaml
    /// </summary>
    public partial class RoomEvent : INotifyPropertyChanged, IWeakEventListener, IDisposable
    {
        public RoomEvent()
        {
            InitializeComponent();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
