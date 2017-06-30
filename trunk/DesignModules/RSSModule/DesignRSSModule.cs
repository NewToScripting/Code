using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace RSSModule
{
    public class DesignRSSModule : MediaModule, IMediaModule
    {
        
        private static PropertyPanel _propertyPanel;
        
        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true && moduleDialog.RSSFeedItems.Count > 0)
            {
                RSSControlHolder scrollContentControl = new RSSControlHolder(new List<string>(moduleDialog.RSSFeedItems), moduleDialog.RSSSpeed, moduleDialog.RSSTitle, moduleDialog.RSSDescription, moduleDialog.IsTouchPanel);

                scrollContentControl.IsHitTestVisible = false;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = "RSS Feeds";
                contentControl.Content = scrollContentControl;
                contentControl.IsEditable = true;
                contentControl.Width = canvasWidth - (.5*canvasWidth);
                contentControl.Height = canvasHeight/2;
                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl _designContentControl)
        {
            RSSControlHolder rssContentControl = _designContentControl.Content as RSSControlHolder;
            rssContentControl.IsHitTestVisible = false;
            _designContentControl.Content = null;
            ModuleDialog moduleDialog = new ModuleDialog(rssContentControl);
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                RSSControlHolder rssContentControl2 = new RSSControlHolder(new List<string>(moduleDialog.RSSFeedItems), moduleDialog.RSSSpeed, moduleDialog.RSSTitle, moduleDialog.RSSDescription, moduleDialog.IsTouchPanel);

                rssContentControl2.IsHitTestVisible = false;

                _designContentControl.Content = rssContentControl2;

                rssContentControl.Dispose();

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
            var rssControlHolder =
                designContentControl.Content as RSSControlHolder; 

            designContentControl.IsNew = false;
            if (rssControlHolder != null)
            {
                rssControlHolder.IsHitTestVisible = true;
                var rssContentControl = rssControlHolder.Content;
                rssControlHolder.Content = null;

                stringControl = XamlWriter.Save(designContentControl);

                rssControlHolder.Content = rssContentControl;
                rssControlHolder.IsHitTestVisible = false;

                designContentControl.Content = rssControlHolder;

            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            RSSControlHolder rssContentControl = designContentControl.Content as RSSControlHolder;

            designContentControl.Content = rssContentControl;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            RSSControlHolder rssControlHolder = designContentControl.Content as RSSControlHolder;
            if (rssControlHolder != null)
            {
                rssControlHolder.IsHitTestVisible = true;
                RSSContentControl rssContentControl = rssControlHolder.Content as RSSContentControl;
                if (rssContentControl != null) rssContentControl.Play();

            }
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
            RSSControlHolder rssControlHolder = designContentControl.Content as RSSControlHolder;
            if (rssControlHolder != null)
            {
                rssControlHolder.IsHitTestVisible = false;
                RSSContentControl rssContentControl = rssControlHolder.Content as RSSContentControl;
                if (rssContentControl != null) rssContentControl.Stop();
            }
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            RSSControlHolder rssControlHolder = designContentControl.Content as RSSControlHolder;
            rssControlHolder.Dispose();
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
            return null;
        }

        public bool GetIsApp()
        {
            return true;
        }

        #endregion
    }
}
