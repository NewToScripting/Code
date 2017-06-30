using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Markup;
using EventsModule.Dialogs;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace EventsModule
{
    public class DesignEventsModule : MediaModule, IMediaModule, IConfigurable
    {

        
        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                var eventControl = new EventControl(EventSource.GetEventData(@"S:\Share\Data\Fixed\Events.NSS",
                                                              @"S:\Share\Data\Fixed\FileMap.xml"), "GroupName");
                
                
                DesignContentControl designContentControl = new DesignContentControl();

                //FeedContentControl feedContentControl = new FeedContentControl(moduleDialog.EventControlHolder.SecondsPerPage ,moduleDialog.EventControlHolder.TemplateRows, "Client", moduleDialog.EventControlHolder.TemplateGuid, moduleDialog.EventControlHolder.TemplateFileName, moduleDialog.EventControlHolder.TemplateDataSource, moduleDialog.EventControlHolder.ShowAllRooms);

                //if (moduleDialog.EventControlHolder.ShowAllRooms)
                //    designContentControl.Tag = "Directory Events";
                //else
                //    designContentControl.Tag = "Room Events";

                //feedContentControl.SetFontValues(moduleDialog.EventControlHolder);

                //feedContentControl.TemplateFields = moduleDialog.EventControlHolder.TemplateFields;

                //feedContentControl.IsHitTestVisible = false;

                //moduleDialog.EventControlHolder.Dispose();

                designContentControl.Content = eventControl;
                designContentControl.IsEditable = true;
                designContentControl.IsNew = false;
                designContentControl.Width = canvasWidth;
                designContentControl.Height = canvasHeight;
                designContentControl.SnapsToDevicePixels = true;

                //// Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                designContentControl.IsRotatable = true;

                return designContentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl _designContentControl)
        {
            //FeedContentControl feedContentControl = (FeedContentControl)_designContentControl.Content;
            //_designContentControl.Content = null;
            //ConfigureEvents configureEvents = new ConfigureEvents(feedContentControl);
            //configureEvents.ShowDialog();
            //if(configureEvents.DialogResult == true)
            //{
            //    FeedContentControl newFeedContentControl = new FeedContentControl(configureEvents.EvntControl);

            //    if (configureEvents.EvntControl.ShowAllRooms)
            //        _designContentControl.Tag = "Directory Events";
            //    else
            //        _designContentControl.Tag = "Room Events";

            //    newFeedContentControl.SetFontValues(configureEvents.EvntControl);

            //    newFeedContentControl.TemplateFields = configureEvents.EvntControl.TemplateFields;

            //    newFeedContentControl.IsHitTestVisible = false;

            //    configureEvents.EvntControl.Dispose();

            //    _designContentControl.Content = newFeedContentControl;
            //    return _designContentControl;
            //}
            //configureEvents.EvntControl = null;
            //_designContentControl.Content = feedContentControl;
            //_designContentControl.IsEditable = true;
            return _designContentControl;
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
            FeedContentControl directoryContentControl = designContentControl.Content as FeedContentControl;
            if (directoryContentControl != null)
            {
                Files.CopyTemplateToSlide(directoryContentControl.TemplateGuid);
                string tempSource = Paths.ClientTempDirectory + directoryContentControl.TemplateGuid +
                                    @"/" + directoryContentControl.TemplateGuid + ".xaml";
                string saveSource = directoryContentControl.TemplateGuid + @"/" + directoryContentControl.TemplateGuid + ".xaml";
                FeedContentControl directoryContentControlNew = new FeedContentControl(directoryContentControl.SecondsPerPage, directoryContentControl.TemplateRows, null, directoryContentControl.TemplateGuid, new Uri(tempSource, UriKind.RelativeOrAbsolute), directoryContentControl.TemplateDataSource, directoryContentControl.ShowAllRooms);
                directoryContentControlNew.SetFontValues(directoryContentControl);
                directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
                directoryContentControlNew.TemplateFileName = new Uri(saveSource, UriKind.Relative);
                directoryContentControlNew.Content = null;
                designContentControl.Content = directoryContentControlNew;

                stringControl = XamlWriter.Save(designContentControl);

                directoryContentControlNew.Content = directoryContentControl;

                directoryContentControlNew.TemplateFileName = new Uri(tempSource, UriKind.RelativeOrAbsolute);
            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            string templateFile = Paths.ClientTempDirectory + designContentControl.SlideID + @"\" +
                                  directoryContentControl.TemplateFileName;
            FeedContentControl directoryContentControlNew =
                new FeedContentControl(directoryContentControl.SecondsPerPage,
                                       directoryContentControl.TemplateRows, "Client",
                                       directoryContentControl.TemplateGuid,
                                       new Uri(templateFile, UriKind.Absolute),
                                       directoryContentControl.TemplateDataSource,
                                       directoryContentControl.ShowAllRooms);
            directoryContentControlNew.SetFontValues(directoryContentControl);
            directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            designContentControl.Content = directoryContentControlNew;

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            designContentControl.IsRotatable = true;

            return designContentControl;
        }

        #region IMediaModule Members

        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            if (_displayGuid == null)
                _displayGuid = "";
            FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            string templateFile;

            if(designContentControl.SlideID != null)
            {
                templateFile = _playbackFolder + designContentControl.SlideID + @"\" +
                                 Path.GetFileNameWithoutExtension(directoryContentControl.TemplateFileName.ToString()) + @"\" + Path.GetFileName(directoryContentControl.TemplateFileName.ToString()) ;
            }
            else
            {
                templateFile = directoryContentControl.TemplateFileName.ToString();
            }

            FeedContentControl directoryContentControlNew =
                new FeedContentControl(directoryContentControl.SecondsPerPage,
                                       directoryContentControl.TemplateRows, _displayGuid,
                                       directoryContentControl.TemplateGuid,
                                       new Uri(templateFile, UriKind.Absolute),
                                       directoryContentControl.TemplateDataSource,
                                       directoryContentControl.ShowAllRooms);
            directoryContentControlNew.SetFontValues(directoryContentControl);
            directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            designContentControl.Content = directoryContentControlNew;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            if (_displayGuid == null)
                _displayGuid = "";
            FeedContentControl directoryContentControl = (FeedContentControl)designContentControl.Content;

            string templateFile = directoryContentControl.TemplateFileName.ToString();
            FeedContentControl directoryContentControlNew = new FeedContentControl(directoryContentControl.SecondsPerPage, directoryContentControl.TemplateRows, _displayGuid, directoryContentControl.TemplateGuid, new Uri(templateFile, UriKind.Absolute), directoryContentControl.TemplateDataSource, directoryContentControl.ShowAllRooms);
            directoryContentControlNew.TemplateFields = directoryContentControl.TemplateFields;
            directoryContentControlNew.SetFontValues(directoryContentControl);
            designContentControl.Content = directoryContentControlNew;
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            FeedContentControl feedContentControl = (FeedContentControl)designContentControl.Content;
            feedContentControl.Dispose();
        }

        public UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
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

        #region IMediaModule Members


        public bool GetIsPanelModule()
        {
            return true;
        }

        #endregion
    }
}
