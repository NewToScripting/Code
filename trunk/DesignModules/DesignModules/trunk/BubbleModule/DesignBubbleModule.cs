using System;
using System.Collections.Generic;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace BubbleModule
{
    public class DesignBubbleModule : MediaModule, IMediaModule
    {
        #region IMediaModule Members

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            designContentControl.IsNew = false;
            return XamlWriter.Save(designContentControl);
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            designContentControl.Content = null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            return null;
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
                    designContentControl.Content = infoBubble;
                    designContentControl.Height = 150;
                    designContentControl.Tag = "Info Bubble";
                }

                if (bubbleChooser.ChoosenType == BubbleChooser.BubbleType.ScrollBubble)
                {
                    ScrollBubble scrollBubble = new ScrollBubble("Title");
                    scrollBubble.IsHitTestVisible = false;
                    designContentControl.Content = scrollBubble;
                    designContentControl.Height = 50;
                    designContentControl.Tag = "Scroll Bubble";
                }

                designContentControl.Width = 200;
                
                // Set rotation to true
                designContentControl.IsRotatable = true;

                designContentControl.IsCopyable = true;

                return designContentControl; 
            }

            return null;
            
        }

        public bool GetIsPanelModule()
        {
            return true;
        }

        public string GetModuleName()
        {
            return "Content Bubble";
        }

        public MediaType GetModuleType()
        {
            return MediaType.XamlElement;
        }

        public System.Windows.Controls.UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            //
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            //
        }

        #endregion
    }
}
