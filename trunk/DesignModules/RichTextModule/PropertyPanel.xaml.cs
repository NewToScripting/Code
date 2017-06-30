using System;
using System.Windows;
using Inspire.Interfaces;
using Inspire;

namespace RichTextModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable //, IPropertyPanel
    {
        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        //public static readonly RoutedEvent HidePropertiesEvent = EventManager.RegisterRoutedEvent("HideProperties", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(FrameworkElement));

        //// Provide CLR accessors for the event
        //public event RoutedEventHandler HideProperties
        //{
        //    add { AddHandler(HidePropertiesEvent, value); }
        //    remove { RemoveHandler(HidePropertiesEvent, value); }
        //}

        #region IDisposable Members

        public void Dispose()
        {
            DataContext = null;

            if(Content != null)
                Content = null;
            if (PART_sliderGrid != null)
            {
                if (PART_sliderGrid.Child != null)
                    PART_sliderGrid.Child = null;

                PART_sliderGrid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        //#region IPropertyPanel Members

        //public void HidePropertyPanel()
        //{
        //    RaiseEvent(new RoutedEventArgs(HidePropertiesEvent));
        //}

        //#endregion
    }
}
