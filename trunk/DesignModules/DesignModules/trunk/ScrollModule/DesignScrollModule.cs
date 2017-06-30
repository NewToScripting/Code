using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace ScrollModule
{
    public class DesignScrollModule : MediaModule, IMediaModule
    {
        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true)
            {
                var scrollContentControl = new ScrollContentControl(moduleDialog.ScrollSpeed, moduleDialog.ScrollItems);

                scrollContentControl.IsHitTestVisible = false;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = "Scrolling Content";
                contentControl.Content = scrollContentControl;
                contentControl.IsEditable = true;
                contentControl.Width = canvasWidth - 50;

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl _designContentControl)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)_designContentControl.Content;
            scrollContentControl.IsHitTestVisible = false;
            _designContentControl.Content = null;
            ModuleDialog moduleDialog = new ModuleDialog(scrollContentControl);
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                ScrollContentControl scrollContentControl2 = new ScrollContentControl(moduleDialog.ScrollSpeed, moduleDialog.ScrollItems);

                scrollContentControl.IsHitTestVisible = false;

                _designContentControl.Content = scrollContentControl2;
                return _designContentControl;
            }

            _designContentControl.Content = scrollContentControl;
            _designContentControl.IsEditable = true;
            return _designContentControl;
        }

        public MediaType GetModuleType()
        {
            return MediaType.ScrollText;
        }

        public string GetModuleName()
        {
            return "Scrolling Content";
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
            var scrollContentControl =
                designContentControl.Content as ScrollContentControl;

            designContentControl.IsNew = false;

            if (scrollContentControl != null)
            {
                scrollContentControl.Content = null;

                stringControl = XamlWriter.Save(designContentControl);

                var frameworkElements = new List<FrameworkElement>();

                foreach (var item in scrollContentControl.ScrollItems)
                {
                    frameworkElements.Add(item.GetScrollItem());
                }

                scrollContentControl.Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements, false);

            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)designContentControl.Content;

            ScrollContentControl scrollContentControl2 = new ScrollContentControl(scrollContentControl.ScrollSpeed, scrollContentControl.ScrollItems);

            scrollContentControl2.IsHitTestVisible = false;

            designContentControl.Content = scrollContentControl2; ;

            //var frameworkElements = new List<FrameworkElement>();

            //foreach (var item in scrollContentControl.ScrollItems)
            //{
            //    frameworkElements.Add(item.GetScrollItem());
            //}

            //scrollContentControl.Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements);

            //designContentControl.Content = scrollContentControl;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            //ScrollContentControl directoryContentControl = (ScrollContentControl)designContentControl.Content;
            //List<FrameworkElement> frameworkElements = new List<FrameworkElement>();

            //foreach (var o in directoryContentControl.ScrollItems.Items)
            //{
            //    frameworkElements.Add((FrameworkElement)o);
            //}

            //ScrollControl scrollControl = new ScrollControl(directoryContentControl.ScrollSpeed,
            //                                                frameworkElements);
            //directoryContentControl.Content = scrollControl;
            //designContentControl.Content = directoryContentControl;
            ScrollContentControl scrollContentControl = designContentControl.Content as ScrollContentControl;
            if (scrollContentControl != null) scrollContentControl.Play();

        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            ScrollContentControl scrollContentControl = designContentControl.Content as ScrollContentControl;
            if (scrollContentControl != null) scrollContentControl.Stop();
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
