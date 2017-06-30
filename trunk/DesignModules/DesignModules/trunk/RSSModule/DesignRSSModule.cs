using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace RSSModule
{
    public class DesignRSSModule : MediaModule, IMediaModule
    {
        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true)
            {
                RSSContentControl scrollContentControl = new RSSContentControl(new List<string>(moduleDialog.RSSFeedItems), moduleDialog.RSSSpeed, moduleDialog.RSSTitle, moduleDialog.RSSDescription);

                scrollContentControl.IsHitTestVisible = false;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = "RSS Feeds";
                contentControl.Content = scrollContentControl;
                contentControl.IsEditable = true;
                contentControl.Width = canvasWidth - (.5*canvasWidth);

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl _designContentControl)
        {
            RSSContentControl rssContentControl = (RSSContentControl)_designContentControl.Content;
            rssContentControl.IsHitTestVisible = false;
            _designContentControl.Content = null;
            ModuleDialog moduleDialog = new ModuleDialog(rssContentControl);
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                RSSContentControl rssContentControl2 = new RSSContentControl(new List<string>(moduleDialog.RSSFeedItems), moduleDialog.RSSSpeed, moduleDialog.RSSTitle, moduleDialog.RSSDescription);

                rssContentControl2.IsHitTestVisible = false;

                _designContentControl.Content = rssContentControl2;
                return _designContentControl;
            }

            _designContentControl.Content = rssContentControl;
            _designContentControl.IsEditable = true;
            return _designContentControl;
        }

        public MediaType GetModuleType()
        {
            return MediaType.RSSFeed;
        }

        public string GetModuleName()
        {
            return "RSS Feeds";
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
            var rssContentControl =
                designContentControl.Content as RSSContentControl; 

            designContentControl.IsNew = false;
            if (rssContentControl != null)
            {
                ResourceDictionary resourceses = rssContentControl.Resources;
                rssContentControl.Resources.Clear();

                stringControl = XamlWriter.Save(designContentControl);

               rssContentControl.Resources = resourceses;

                var newRssContentControl = new RSSContentControl(rssContentControl);

                newRssContentControl.IsHitTestVisible = false;

                designContentControl.Content = newRssContentControl;
                //rssContentControl.Content = new RSSContentControl(rssContentControl);
               // rssContentControl.Content = new RSSControl(feeditems, rssContentControl.RSSSpeed, rssContentControl.RSSTitleFSize, rssContentControl.RSSTitleFFamily, rssContentControl.RSSTitleFForeground, rssContentControl.RSSDescriptionFSize, rssContentControl.RSSDescriptionFFamily, rssContentControl.RSSDescriptionFForeground);
            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            RSSContentControl rssContentControl = designContentControl.Content as RSSContentControl;
            
            RSSContentControl newRSSContentControl = new RSSContentControl(rssContentControl);
            
            newRSSContentControl.IsHitTestVisible = false;

            designContentControl.Content = newRSSContentControl;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            RSSContentControl rssContentControl = designContentControl.Content as RSSContentControl;
            if (rssContentControl != null) rssContentControl.Play();
            //RSSContentControl directoryContentControl = (RSSContentControl)designContentControl.Content;

            //List<string> frameworkElements = new List<string>();

            //foreach (var o in directoryContentControl.RSSItems.Items)
            //{
            //    frameworkElements.Add((string)o);
            //}

            //RSSControl scrollControl = new RSSControl(frameworkElements,
            //                                          directoryContentControl.RSSSpeed,
            //                                          directoryContentControl.RSSTitleFSize,
            //                                          directoryContentControl.RSSTitleFFamily,
            //                                          directoryContentControl.RSSTitleFForeground,
            //                                          directoryContentControl.RSSDescriptionFSize,
            //                                          directoryContentControl.RSSDescriptionFFamily,
            //                                          directoryContentControl.
            //                                              RSSDescriptionFForeground);
            //scrollControl.Start();
            //directoryContentControl.Content = scrollControl;
            //designContentControl.Content = directoryContentControl;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            RSSContentControl rssContentControl = designContentControl.Content as RSSContentControl;
            if (rssContentControl != null) rssContentControl.Stop();
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            
        }

        public UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
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
