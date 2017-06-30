using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true)
            {
                if (moduleDialog.ScrollItems.Count > 0)
                {
                    var scrollContentControl = new ScrollContentControl(moduleDialog.ScrollSpeed,
                                                                        moduleDialog.ScrollItems,
                                                                        moduleDialog.ScrollDirection,
                                                                        moduleDialog.ScrollStyle);

                    scrollContentControl.IsHitTestVisible = false;

                    scrollContentControl.Tag = moduleDialog.ScrollStyle;

                    DesignContentControl contentControl = new DesignContentControl();

                    contentControl.Tag = "Scrolling Content";
                    contentControl.Content = scrollContentControl;
                    contentControl.IsEditable = true;

                    contentControl.Width = canvasWidth - 50;
                    contentControl.Height = 100;

                    // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                    contentControl.IsRotatable = true;

                    return contentControl;
                }
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
                ScrollContentControl scrollContentControl2 = new ScrollContentControl(moduleDialog.ScrollSpeed, moduleDialog.ScrollItems, moduleDialog.ScrollDirection, moduleDialog.ScrollStyle);

                scrollContentControl.IsHitTestVisible = false;

                _designContentControl.Content = scrollContentControl2;
                scrollContentControl.Dispose();
                scrollContentControl = null;
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
                    frameworkElements.AddRange(item.GetScrollItems(scrollContentControl.ScrollDirection));
                }

                designContentControl.Content = new ScrollContentControl(scrollContentControl);

                scrollContentControl.Dispose();

                //scrollContentControl.Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements, scrollContentControl.ScrollDirection, false);

            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            ScrollContentControl scrollContentControl = (ScrollContentControl)designContentControl.Content;

            string scrollStyle = string.Empty;

            if (scrollContentControl.Tag != null)
                scrollStyle = scrollContentControl.Tag.ToString();

            ScrollContentControl scrollContentControl2 = new ScrollContentControl(scrollContentControl.ScrollSpeed, scrollContentControl.ScrollItems, scrollContentControl.ScrollDirection, scrollStyle);

            scrollContentControl2.IsHitTestVisible = false;

            designContentControl.Content = scrollContentControl2;
            
            scrollContentControl.Dispose();
            scrollContentControl = null;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
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
            ScrollContentControl scrollContentControl = designContentControl.Content as ScrollContentControl;
            if (scrollContentControl != null)
            {
                scrollContentControl.Dispose();
                scrollContentControl = null;
            }
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
