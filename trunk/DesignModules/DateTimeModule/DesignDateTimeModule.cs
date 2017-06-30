using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using System.Collections;

namespace DateTimeModule
{
    public class DesignDateTimeModule : MediaModule, IMediaModule
    {

        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            DateTimeChooser dateTimeChooser = new DateTimeChooser();
            dateTimeChooser.ShowDialog();
            if (dateTimeChooser.DialogResult == true)
            {
                DesignContentControl designContentControl = new DesignContentControl();


                ClockControl clockControl = new ClockControl(Convert.ToInt32(dateTimeChooser.cbFormat.SelectedValue), dateTimeChooser.chooseClock.Content);
                clockControl.IsHitTestVisible = false;
                designContentControl.Content = clockControl;
                //designContentControl.Height = 150;
                designContentControl.Tag = "Date / Time"; 

                //designContentControl.Width = 200;

                // Set rotation to true
                designContentControl.IsRotatable = true;

                designContentControl.IsCopyable = false;

                return designContentControl;
            }

            return null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string serializedContent = string.Empty;

            designContentControl.IsNew = false;
            var clockControl = designContentControl.Content as ClockControl;

            if (clockControl != null)
            {

                ResourceDictionary resourceDictionary = new ResourceDictionary();

                foreach (DictionaryEntry entry in clockControl.Resources)
                {
                    DictionaryEntry entry2 = entry;
                    resourceDictionary.Add(entry2.Key,entry2.Value);
                }

                clockControl.Resources.Clear();

                serializedContent = XamlWriter.Save(designContentControl);

                clockControl.Resources = resourceDictionary;
            }

            return serializedContent;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null;
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            designContentControl.Content = null;
        }

        public MediaType GetModuleType()
        {
            return MediaType.XamlElement;
        }

        public string GetModuleName()
        {
            return "Date / Time";
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public UserControl GetPropertyPanel()
        {
            if(_propertyPanel == null)
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
            return false;
        }
    }
}
