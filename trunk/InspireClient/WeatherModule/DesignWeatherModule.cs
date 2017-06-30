using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace WeatherModule
{
    public class DesignWeatherModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

         public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            var moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true && moduleDialog.Location != null)
            {
                var weatherContentControl = new WeatherContentControl(moduleDialog.Location, moduleDialog.SelectedStyle, moduleDialog.DegreeType);

                weatherContentControl.IsHitTestVisible = false;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = "Weather - " + moduleDialog.tbLocation.Text; // Add zip
                contentControl.Content = weatherContentControl;
                contentControl.IsEditable = true;
                contentControl.Width = canvasWidth - (.5*canvasWidth);
                contentControl.Height = canvasHeight/2;
                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl contentControl)
        {
            var oldControl = contentControl.Content as WeatherContentControl;

            var moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true && moduleDialog.Location != null)
            {
                var weatherContentControl = new WeatherContentControl(moduleDialog.Location, moduleDialog.SelectedStyle, moduleDialog.DegreeType);

                weatherContentControl.IsHitTestVisible = false;

                contentControl.Tag = "Weather - " + moduleDialog.tbLocation.Text; // Add zip
                contentControl.Content = weatherContentControl;

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                if(oldControl != null)
                    oldControl.Dispose();

                return contentControl;
            }
            return contentControl;
        }

        public MediaType GetModuleType()
        {
            return MediaType.XamlElement;
        }

        public string GetModuleName()
        {
            return "Weather";
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
            var weatherContentControl =
                designContentControl.Content as WeatherContentControl;
            
            designContentControl.IsNew = false;
            if (weatherContentControl != null)
            {
                weatherContentControl.Content = null;

                stringControl = XamlWriter.Save(designContentControl);

                weatherContentControl.Content = new WeatherControl(weatherContentControl.Location, weatherContentControl.DegreeType);

                designContentControl.Content = weatherContentControl;
            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
           // var weatherContentControl = designContentControl.Content as WeatherContentControl;
            
            //RSSContentControl newRSSContentControl = new RSSContentControl(rssContentControl, false);
            
           // newRSSContentControl.IsHitTestVisible = false;

            //designContentControl.Content = weatherContentControl;

            designContentControl.IsEditable = true;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            //RSSControlHolder rssControlHolder = designContentControl.Content as RSSControlHolder;
            //if (rssControlHolder != null)
            //{
            //    RSSContentControl rssContentControl = rssControlHolder.Content as RSSContentControl;
            //    if (rssContentControl != null) rssContentControl.Play();

            //}
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
            //RSSControlHolder rssControlHolder = designContentControl.Content as RSSControlHolder;
            //if (rssControlHolder != null)
            //{
            //    RSSContentControl rssContentControl = rssControlHolder.Content as RSSContentControl;
            //    if (rssContentControl != null) rssContentControl.Stop();
            //}
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            WeatherContentControl weatherContentControl = designContentControl.Content as WeatherContentControl;
            if(weatherContentControl != null)
                weatherContentControl.Dispose();
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
