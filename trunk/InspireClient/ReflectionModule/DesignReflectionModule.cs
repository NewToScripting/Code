using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace ReflectionModule
{
    public class DesignReflectionModule : MediaModule, IMediaModule
    {

        #region IMediaModule Members

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl originalContentControl)
        {
            DesignReflection designReflection = new DesignReflection();
            designReflection.IsHitTestVisible = false;
            designReflection.TargetGuid = ((DesignReflection)originalContentControl.Content).TargetGuid;

           // Viewbox viewbox = new Viewbox();
           // viewbox.Child = designReflection;

            DesignContentControl designContentControl = new DesignContentControl();

            designContentControl.IsHitTestVisible = true;

            designContentControl.Type = MediaType.Reflection;
            designContentControl.Tag = originalContentControl.Tag;
            designContentControl.IsRotatable = true;
            designContentControl.Content = designReflection;
            designContentControl.Width = originalContentControl.Width;
            designContentControl.Height = originalContentControl.Height;
            designContentControl.RotateTransform = originalContentControl.RotateTransform;
            designContentControl.SkewTransform = originalContentControl.SkewTransform;
            designContentControl.ClipContent = originalContentControl.ClipContent;
            designContentControl.BorderBrush = originalContentControl.BorderBrush;
            designContentControl.BorderThickness = originalContentControl.BorderThickness;
            designContentControl.GlassOpacity = originalContentControl.GlassOpacity;
            designContentControl.ContentZIndex = originalContentControl.ContentZIndex;
            designContentControl.GUID = Guid.NewGuid().ToString();
            designContentControl.AssemblyInfo = "ReflectionModule";
            //designContentControl.IsSelected = false;
            Canvas.SetLeft(designContentControl, Canvas.GetLeft(originalContentControl));
            Canvas.SetTop(designContentControl, Canvas.GetTop(originalContentControl));
            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            throw new NotImplementedException();
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            try
            {
                var reflection = designContentControl.Content as DesignReflection;

                string control = string.Empty;

                if (reflection != null)
                {
                    var target = reflection.ReflectionTarget as DesignContentControl;

                    var uiElement = target.Content;

                    target.Content = null;

                    control = XamlWriter.Save(designContentControl);

                    target.Content = uiElement;
                }

                return control;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            return;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            throw new NotImplementedException();
        }

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            throw new NotImplementedException();
        }

        public string GetModuleName()
        {
            return "Reflection";
        }

        public MediaType GetModuleType()
        {
            return MediaType.Reflection;
        }

        public UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
        }

        public List<string> GetSupportedFileTypes()
        {
            throw new NotImplementedException();
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            //throw new NotImplementedException();
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            //throw new NotImplementedException();
        }

        public bool GetIsPanelModule()
        {
            return false;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl, string guid)
        {
            return designContentControl;
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
