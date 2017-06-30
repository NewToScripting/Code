using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace ShapesModule
{
    public class DesignShapesModule : MediaModule, IMediaModule
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

            var shapeControl = designContentControl.Content as ShapeControl;

            ResourceDictionary resourceDictionary = new ResourceDictionary();

            if (shapeControl != null)
            {
                foreach (DictionaryEntry entry in shapeControl.Resources)
                {
                    DictionaryEntry entry2 = entry;
                    resourceDictionary.Add(entry2.Key, entry2.Value);
                }

                shapeControl.Resources.Clear();


                serializedControl = XamlWriter.Save(designContentControl);

                shapeControl.Resources = resourceDictionary;
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
            ShapeChooser bubbleChooser = new ShapeChooser();
            bubbleChooser.ShowDialog();
            if (bubbleChooser.DialogResult == true)
            {
                DesignContentControl designContentControl = new DesignContentControl();

                
                ShapeControl shapeControl = new ShapeControl();
                shapeControl.IsHitTestVisible = false;
                shapeControl.SelectedTemplate = bubbleChooser.ShapeStyle;
                designContentControl.Content = shapeControl;
                designContentControl.Height = 150;
                designContentControl.Width = 150;
                designContentControl.Tag = shapeControl.SelectedTemplate;
                

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
            return "Shapes"; // The Alias for the control
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
