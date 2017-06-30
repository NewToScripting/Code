using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule.Dialogs
{
    /// <summary>
    /// Interaction logic for DirectionalImageSelector.xaml
    /// </summary>
    public partial class DirectionalImageSelector : IWeakEventListener
    {
        private List<DirectionalImage> directionalImages;

        public string ImageID { get; set; }
        public string ImageUrl { get; set; }

        public DirectionalImageSelector()
        {
            InitializeComponent();
            directionalImages = new List<DirectionalImage>();
            LoadedEventManager.AddListener(this, this);
        }

        void DirectionalImageSelector_Loaded(object sender, EventArgs e)
        {
            directionalImages = DirectionProxy.GetDirectionalImages();

            lbDirectionalImages.ItemsSource = directionalImages;
        }

        private void DirectionalImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImageUrl = ((DirectionalImage)((Border)sender).DataContext).WebPath;
            ImageID = ((DirectionalImage)((Border)sender).DataContext).Guid;
            DialogResult = true;
            Close();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                DirectionalImageSelector_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
