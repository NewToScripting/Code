using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace BrowserModule
{
    public class DesignBrowserModule : MediaModule, IMediaModule
    {
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
            string stringControl = XamlWriter.Save(designContentControl);
            return stringControl;
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
