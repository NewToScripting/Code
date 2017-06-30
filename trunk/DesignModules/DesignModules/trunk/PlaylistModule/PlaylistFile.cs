using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace PlaylistModule
{
    public abstract class PlaylistFile : DependencyObject
    {
       // public string Uri { get; set; }

        public static DependencyProperty UriProperty = DependencyProperty.Register(
            "Uri", typeof(String), typeof(PlaylistFile));

        public string Uri
        {
            get
            {
                return (string)GetValue(UriProperty);
            }
            set
            {
                SetValue(UriProperty, value);
                OnPropertyChanged("Uri");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Stretch Stretch { get; set; }

        public static string[] Extensions;

        public string GUID { get; set; }

        public PlaylistFile()
        {
            GUID = Guid.NewGuid().ToString();
        }
    }
}
