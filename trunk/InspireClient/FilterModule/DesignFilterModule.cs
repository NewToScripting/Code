using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace FilterModule
{
    public class DesignFilterModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        #region IMediaModule Members

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl; // Dont worry about this
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            var content = designContentControl.Content as FrameworkElement;
            content.IsHitTestVisible = false;
            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null; // Dont worry about this
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            var filter = designContentControl.Content as FilterControl;

            var iFilter = filter.Content as IFilter;

            filter.SelectedCharacterBrush = iFilter.SelectedCharacterBrush;
            filter.SelectedFontFamily = iFilter.SelectedFontFamily;
            filter.CharacterForeground = iFilter.CharacterForeground;
            filter.GlowForeground= iFilter.GlowForeground;

            filter.Content = null;

            filter.IsHitTestVisible = true;

            string returnString = XamlWriter.Save(designContentControl);

            var newFiltCont = new FilterControl(filter.GuidToFilterOn, filter.CharacterForeground, filter.GlowForeground,
                                                filter.SelectedCharacterBrush, filter.SelectedFontFamily);

            newFiltCont.IsHitTestVisible = false;

            designContentControl.Content = newFiltCont;

            return returnString; // Important that this can be serialized and loaded back up.
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

                DesignContentControl designContentControl = new DesignContentControl();


                FilterControl alphabitFilter = new FilterControl();
                alphabitFilter.IsHitTestVisible = false;
                designContentControl.Content = alphabitFilter;
                designContentControl.Height = 150;
                designContentControl.Width = 400;
                designContentControl.Tag = "Data Filter";

                // Set rotation to true
                designContentControl.IsRotatable = true;

                designContentControl.IsCopyable = true;

                return designContentControl;
        }

        public bool GetIsPanelModule()
        {
            return true; // always set to true for designer controls
        }

        public string GetModuleName()
        {
            return "Data Filter"; // The Alias for the control
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
            var contentControl = designContentControl.Content as FrameworkElement;

            contentControl.IsHitTestVisible = true;
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            var contentControl = designContentControl.Content as FrameworkElement;

            contentControl.IsHitTestVisible = false;
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
