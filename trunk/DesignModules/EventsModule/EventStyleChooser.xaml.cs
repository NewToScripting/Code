using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Inspire.MediaObjects;
using Inspire.Events.Proxy;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for EventStyleChooser.xaml
    /// </summary>
    public partial class EventStyleChooser : Window
    {
        private double canvasWidth;
        private double canvasHeight;

        public DesignContentControl EvntContentControl { get; set; }

        public EventStyleChooser()
        {
            InitializeComponent();
        }

        public EventStyleChooser(double canvasWidth, double canvasHeight): this()
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
        }

        private void btnRoomBoard_Click(object sender, RoutedEventArgs e)
        {
            RoomDialog roomDialog = new RoomDialog();
            roomDialog.ShowDialog();
            if (roomDialog.DialogResult == true)
            {

                TimeSpan showAhead = new TimeSpan(roomDialog.dtShowAhead.Value.Value.Hour, roomDialog.dtShowAhead.Value.Value.Minute, roomDialog.dtShowAhead.Value.Value.Second);
                TimeSpan showBehind = new TimeSpan(roomDialog.dtShowAfterEnded.Value.Value.Hour, roomDialog.dtShowAfterEnded.Value.Value.Minute, roomDialog.dtShowAfterEnded.Value.Value.Second);

                int eventToShow = 0;

                if (roomDialog.cbEventToShow.SelectedIndex > 0)
                    eventToShow = roomDialog.cbEventToShow.SelectedIndex; 

                var roomEvt = roomDialog.RoomEventHolder.Content as RoomEvent;

                RoomEvent roomEventControl = new RoomEvent(roomEvt.EventColumns, showAhead, showBehind, eventToShow, (bool)roomDialog.showAllEvents.IsChecked, (bool)roomDialog.cbShowIfNoEvents.IsChecked);

                DesignContentControl designContentControl = new DesignContentControl();

                designContentControl.Content = roomEventControl;
                designContentControl.IsEditable = true;
                designContentControl.IsNew = false;
                designContentControl.Width = canvasWidth - 30;
                designContentControl.Height = canvasHeight / 2;
                designContentControl.Tag = "Room Event";
                //Canvas.SetTop(designContentControl, 20);
                //Canvas.SetLeft(designContentControl, 20);
                designContentControl.SnapsToDevicePixels = true;

                //// Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                designContentControl.IsRotatable = true;

                EvntContentControl = designContentControl;

                DialogResult = true;
            }
            else
                DialogResult = false;
            
            Close();
        }

        private void btnDirectory_Click(object sender, RoutedEventArgs e)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                ListBox eventColumns = new ListBox();

                foreach (TextBlock textBlock in moduleDialog.EventTextBlocks)
                {
                    textBlock.TextWrapping = TextWrapping.Wrap; // TODO: Add this to the options in the ModuleDialog
                    textBlock.TextAlignment = TextAlignment.Left; // TODO: Add this to the options in the ModuleDialog
                    eventColumns.Items.Add(textBlock);
                }

                string eventDefGuid = string.Empty;

                if (moduleDialog.cbDataSource != null)
                {
                    if (moduleDialog.cbDataSource.SelectedItem != null)
                        eventDefGuid = (moduleDialog.cbDataSource.SelectedItem as HospitalityEventDefinition).EventDefinitionGUID;
                }

                eventColumns.Tag = moduleDialog.SelectedAnimation;

                TimeSpan showAhead = new TimeSpan(moduleDialog.dtShowAhead.Value.Value.Hour, moduleDialog.dtShowAhead.Value.Value.Minute, moduleDialog.dtShowAhead.Value.Value.Second);
                TimeSpan showBehind = new TimeSpan(moduleDialog.dtShowAfterEnded.Value.Value.Hour, moduleDialog.dtShowAfterEnded.Value.Value.Minute, moduleDialog.dtShowAfterEnded.Value.Value.Second);

                if (moduleDialog.ShowAllEventsToday)
                    showAhead = new TimeSpan(23, 59, 0);

                if (moduleDialog.DontShowExpiredEvents)
                    showBehind = new TimeSpan(0, 0, 0);

                var eventControl = new EventControl(eventDefGuid, eventColumns, moduleDialog.HeaderTextBlock, moduleDialog.SecondsPerPage, showAhead, showBehind, moduleDialog.ShowAllEventsToday, (bool)moduleDialog.cbShowEventsForAllDisplays.IsChecked);  // TODO: FIX When we implement DataSource Config


                DesignContentControl designContentControl = new DesignContentControl();


                designContentControl.Content = eventControl;
                designContentControl.IsEditable = true;
                designContentControl.IsNew = false;
                designContentControl.Width = canvasWidth / 2;
                designContentControl.Height = canvasHeight / 2;
                designContentControl.Tag = "Directory Events ";

                designContentControl.SnapsToDevicePixels = true;

                //// Mark as Rotatable so this control can be rotated. Only WindowsForm Controls Cannot be rotated.
                designContentControl.IsRotatable = true;

                EvntContentControl = designContentControl;

                DialogResult = true;
            }
        }
    }
}
