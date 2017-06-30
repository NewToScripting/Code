using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Events.Proxy;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace EventsModule
{
    public class DesignEventsModule : MediaModule, IMediaModule, IConfigurable
    {
        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {

            EventStyleChooser eventStyleChooser = new EventStyleChooser(canvasWidth, canvasHeight);
            eventStyleChooser.ShowDialog();
            if (eventStyleChooser.DialogResult == true)
            {
                if (eventStyleChooser.EvntContentControl != null)
                    return eventStyleChooser.EvntContentControl; 
            }

            return null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {

            if (designContentControl.Content is EventControl)
            {
                EventControl oldEventControl = designContentControl.Content as EventControl;

                ModuleDialog moduleDialog = new ModuleDialog(designContentControl.Content as EventControl);
                moduleDialog.ShowDialog();
                if (moduleDialog.DialogResult == true)
                {
                    ListBox eventColumns = new ListBox();

                    foreach (TextBlock textBlock in moduleDialog.EventTextBlocks)
                    {
                        textBlock.TextWrapping = TextWrapping.Wrap; // TODO: Add this to the options in the ModuleDialog
                        //textBlock.TextAlignment = TextAlignment.Left; // TODO: Add this to the options in the ModuleDialog
                        eventColumns.Items.Add(textBlock);
                    }

                    string eventDefGuid = string.Empty;

                    if (moduleDialog.cbDataSource != null)
                    {
                        if (moduleDialog.cbDataSource.SelectedItem != null)
                            eventDefGuid = (moduleDialog.cbDataSource.SelectedItem as HospitalityEventDefinition).EventDefinitionGUID;
                    }
                    TimeSpan showEventsAhead;
                    TimeSpan showEventsBehind;

                    if(moduleDialog.ShowAllEventsToday)
                        showEventsAhead = new TimeSpan(23,59,0);
                    else
                        showEventsAhead = new TimeSpan(moduleDialog.dtShowAhead.Value.Value.Hour, moduleDialog.dtShowAhead.Value.Value.Minute, moduleDialog.dtShowAhead.Value.Value.Second);

                    if (moduleDialog.DontShowExpiredEvents)
                        showEventsBehind = new TimeSpan(0, 0, 0);
                    else
                        showEventsBehind = new TimeSpan(moduleDialog.dtShowAfterEnded.Value.Value.Hour, moduleDialog.dtShowAfterEnded.Value.Value.Minute, moduleDialog.dtShowAfterEnded.Value.Value.Second);

                    var eventControl = new EventControl(eventDefGuid, eventColumns, moduleDialog.HeaderTextBlock, moduleDialog.SecondsPerPage, showEventsAhead, showEventsBehind, moduleDialog.ShowAllEventsToday,  (bool)moduleDialog.ShowEventsForAllDisplays);  // TODO: FIX When we implement DataSource Config

                    designContentControl.Content = eventControl;
                }
                else
                {
                    designContentControl.Content = oldEventControl;
                }
            }
            else if (designContentControl.Content is RoomEvent)
            {
                RoomEvent oldEventControl = designContentControl.Content as RoomEvent;

                RoomDialog roomDialog = new RoomDialog(designContentControl.Content as RoomEvent);
                roomDialog.ShowDialog();
                if (roomDialog.DialogResult == true)
                {
                    TimeSpan showAhead; 
                    TimeSpan showBehind;

                    if((bool)roomDialog.showAllEvents.IsChecked)
                        showAhead = new TimeSpan(23,59,0);
                    else
                        showAhead = new TimeSpan(roomDialog.dtShowAhead.Value.Value.Hour, roomDialog.dtShowAhead.Value.Value.Minute, roomDialog.dtShowAhead.Value.Value.Second);
                    
                    if((bool)roomDialog.dontShowExpired.IsChecked)
                        showBehind = new TimeSpan(0, 0, 0);
                    else
                        showBehind = new TimeSpan(roomDialog.dtShowAfterEnded.Value.Value.Hour, roomDialog.dtShowAfterEnded.Value.Value.Minute, roomDialog.dtShowAfterEnded.Value.Value.Second);

                    int eventToShow = 0;

                    if (roomDialog.cbEventToShow.SelectedIndex > 0)
                        eventToShow = roomDialog.cbEventToShow.SelectedIndex;

                    var roomEvt = roomDialog.RoomEventHolder.Content as RoomEvent;

                    RoomEvent roomEventControl = new RoomEvent(roomEvt.EventColumns, showAhead, showBehind, eventToShow, roomEvt.ShowAllTodaysEvents, roomEvt.ShowIfNoEvents);

                    designContentControl.Content = roomEventControl;
                }
                else
                {
                    designContentControl.Content = oldEventControl;
                }
            }

            return designContentControl;
        }

        public MediaType GetModuleType()
        {
            return MediaType.Events;
        }

        public string GetModuleName()
        {
            return "Meetings & WayFinding";
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";

            if(designContentControl.Content is EventControl)
            {
                EventControl eventContentControl = designContentControl.Content as EventControl;
                if (eventContentControl != null)
                {

                    eventContentControl.Children.Clear();

                    stringControl = XamlWriter.Save(designContentControl);

                    EventControl newEventControl = new EventControl(eventContentControl);

                    designContentControl.Content = newEventControl;

                }
            }
            else if(designContentControl.Content is RoomEvent)
            {
                RoomEvent eventContentControl = designContentControl.Content as RoomEvent;
                if (eventContentControl != null)
                {
                    stringControl = XamlWriter.Save(designContentControl);

                    RoomEvent newEventControl = new RoomEvent(eventContentControl);

                    eventContentControl.Content = null;
                    eventContentControl = null;

                    designContentControl.Content = newEventControl;

                }
            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
                designContentControl.IsRotatable = true;
            

            //FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            //string templateFile = Paths.ClientTempDirectory + designContentControl.SlideID + @"\" +
            //                      directoryContentControl.TemplateFileName;
            //FeedContentControl directoryContentControlNew =
            //    new FeedContentControl(directoryContentControl.SecondsPerPage,
            //                           directoryContentControl.TemplateRows, "Client",
            //                           directoryContentControl.TemplateGuid,
            //                           new Uri(templateFile, UriKind.Absolute),
            //                           directoryContentControl.TemplateDataSource,
            //                           directoryContentControl.ShowAllRooms);
            //directoryContentControlNew.SetFontValues(directoryContentControl);
            //directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            

            return designContentControl;
        }

        #region IMediaModule Members

        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            if(designContentControl.Content is IPlayable)
                ((IPlayable)designContentControl.Content).Play();
            //if (_displayGuid == null)
            //    _displayGuid = "";
            //FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            //string templateFile;

            //if(designContentControl.SlideID != null)
            //{
            //    templateFile = _playbackFolder + designContentControl.SlideID + @"\" +
            //                     Path.GetFileNameWithoutExtension(directoryContentControl.TemplateFileName.ToString()) + @"\" + Path.GetFileName(directoryContentControl.TemplateFileName.ToString()) ;
            //}
            //else
            //{
            //    templateFile = directoryContentControl.TemplateFileName.ToString();
            //}

            //FeedContentControl directoryContentControlNew =
            //    new FeedContentControl(directoryContentControl.SecondsPerPage,
            //                           directoryContentControl.TemplateRows, _displayGuid,
            //                           directoryContentControl.TemplateGuid,
            //                           new Uri(templateFile, UriKind.Absolute),
            //                           directoryContentControl.TemplateDataSource,
            //                           directoryContentControl.ShowAllRooms);
            //directoryContentControlNew.SetFontValues(directoryContentControl);
            //directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            //designContentControl.Content = directoryContentControlNew;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            if (designContentControl.Content is IPlayable)
                ((IPlayable)designContentControl.Content).Stop();
            //if (_displayGuid == null)
            //    _displayGuid = "";
            //FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            //string templateFile = directoryContentControl.TemplateFileName.ToString();
            //FeedContentControl directoryContentControlNew = new FeedContentControl(directoryContentControl.SecondsPerPage, directoryContentControl.TemplateRows, _displayGuid, directoryContentControl.TemplateGuid, new Uri(templateFile, UriKind.Absolute), directoryContentControl.TemplateDataSource, directoryContentControl.ShowAllRooms);
            //directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            //directoryContentControlNew.SetFontValues(directoryContentControl);
            //designContentControl.Content = directoryContentControlNew;
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            IDisposable eventControl = designContentControl.Content as IDisposable;
            if (eventControl != null) eventControl.Dispose();
        }

        public UserControl GetPropertyPanel()
        {
            if (_propertyPanel == null)
                _propertyPanel = new PropertyPanel();
            return _propertyPanel;
        }

        public bool GetIsPanelModule()
        {
            return true;
        }

        public IEnumerable<string> GetRules(DesignContentControl designContentControl)
        {
            var contentControl = designContentControl.Content as EventControl;

            if (contentControl == null) return null;

            if (contentControl.AdvanceOnEnd && contentControl.AdvanceAfterLoops > 0)
                return new List<string>()
                           {
                               designContentControl.Tag +
                               ": The slide is advanced after " + contentControl.AdvanceAfterLoops + " loops of event information."
                           };

            return null;
        }

        public bool GetIsApp()
        {
            return true;
        }

        #endregion

        #region IConfigurable Members

        public string GetConfigurationTitle()
        {
            return "Meeting Room Properties";
        }

        public UserControl GetConfigurationWindow()
        {
            return new ConfigurationControl();
        }

        #endregion

    }
}
