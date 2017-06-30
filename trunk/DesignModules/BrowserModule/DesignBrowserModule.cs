using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace BrowserModule
{
    public class DesignBrowserModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                DesignContentControl designContentControl = new DesignContentControl();

                DesignWebControl designWebControl = new DesignWebControl(moduleDialog.Url, moduleDialog.ShowScrollBars, moduleDialog.RefreshInterval);

                designContentControl.Tag = moduleDialog.Url;
                
                designContentControl.IsRotatable = false;

                designContentControl.Width = 400;
                designWebControl.Height = 400;

                designContentControl.Content = designWebControl;

                return designContentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            throw new System.NotImplementedException();
        }

        public MediaType GetModuleType()
        {
            return MediaType.Web;
        }

        public string GetModuleName()
        {
            return "Web Content";
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
            designContentControl.IsNew = false;

            string stringControl = "";
            DesignWebControl designBrowser = designContentControl.Content as DesignWebControl;

            if (designBrowser != null)
            {
                DesignerImage designerImage = designBrowser.Content as DesignerImage;

                designBrowser.Content = null;

                stringControl = XamlWriter.Save(designContentControl);

                designBrowser.Content = designerImage;
            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackPath, string _displayGuid)
        {
            DesignWebControl designWebControl = designContentControl.Content as DesignWebControl;
            if (designWebControl != null) designWebControl.Play();
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackPath, string _displayGuid)
        {
            DesignWebControl designWebControl = designContentControl.Content as DesignWebControl;
            if (designWebControl != null) designWebControl.Stop();
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            DesignWebControl designWebControl = designContentControl.Content as DesignWebControl;
            if (designWebControl != null) designWebControl.Dispose();
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
