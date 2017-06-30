using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace BubbleModule
{
    public class DesignBubbleModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        #region IMediaModule Members

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl; // Dont worry about this
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            return designContentControl; // Dont worry about this
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null; // Dont worry about this
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string serializedControl = string.Empty;

            designContentControl.IsNew = false;
            
            var infoBubble = designContentControl.Content as InfoBubble;

            ResourceDictionary resourceDictionary = new ResourceDictionary();

            if (infoBubble != null)
            {
                foreach (DictionaryEntry entry in infoBubble.Resources)
                {
                    DictionaryEntry entry2 = entry;
                    resourceDictionary.Add(entry2.Key, entry2.Value);
                }

                infoBubble.Resources.Clear();


                serializedControl = XamlWriter.Save(designContentControl);

                infoBubble.Resources = resourceDictionary;
            }

            return serializedControl; // Important that this can be serialized and loaded back up.
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            designContentControl.Content = null; // Cleanup here and remove handles
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            return null; // No edit for this. if there were more properties, we could reopen the ModuleDialog
        }

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            BubbleChooser bubbleChooser = new BubbleChooser();
            bubbleChooser.ShowDialog();
            if(bubbleChooser.DialogResult == true)
            {
                DesignContentControl designContentControl = new DesignContentControl();

                if(bubbleChooser.ChoosenType == BubbleChooser.BubbleType.InfoBubble)
                {
                    InfoBubble infoBubble = new InfoBubble("Title");
                    infoBubble.IsHitTestVisible = false;
                    infoBubble.SelectedTemplate = bubbleChooser.BubbleStyle;
                    designContentControl.Content = infoBubble;
                    designContentControl.Height = 150;
                    designContentControl.Width = 200;
                    designContentControl.Tag = "Info Bubble";
                }

                if (bubbleChooser.ChoosenType == BubbleChooser.BubbleType.ScrollBubble)
                {
                    InfoBubble scrollBubble = new InfoBubble("Title");
                    scrollBubble.IsHitTestVisible = false;
                    scrollBubble.SelectedTemplate = bubbleChooser.BubbleStyle;
                    designContentControl.Content = scrollBubble;
                    designContentControl.Height = 50;
                    designContentControl.Width = canvasWidth - 50;
                    designContentControl.Tag = "Scroll Bubble";
                }

                // Set rotation to true
                designContentControl.IsRotatable = true;

                designContentControl.IsCopyable = true;

                return designContentControl; 
            }

            return null;
            
        }

        public bool GetIsPanelModule()
        {
            return true; // always set to true for designer controls
        }

        public string GetModuleName()
        {
            return "Content Bubble"; // The Alias for the control
        }

        public MediaType GetModuleType()
        {
            return MediaType.XamlElement; // Standard type for xaml based elements
        }

        public System.Windows.Controls.UserControl GetPropertyPanel()
        {
            if (_propertyPanel == null)
                _propertyPanel = new PropertyPanel();
            return _propertyPanel;
        }

        public List<string> GetSupportedFileTypes()
        {
            return null; // There are no file types for this control
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            // This Control only has one state
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            // This Control only has one state
        }

        public IEnumerable<string> GetRules(DesignContentControl designContentControl)
        {
            return null;
        }

        public bool GetIsApp()
        {
            return false;
        }

        #endregion
    }
}
