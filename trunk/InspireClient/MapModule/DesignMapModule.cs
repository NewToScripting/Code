using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using InfoStrat.VE;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace MapModule
{
    class DesignMapModule : MediaModule, IMediaModule
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
            string serializedControl = string.Empty;

            designContentControl.IsNew = false;

            var flightContentControl = designContentControl.Content as MapContentControl;

            flightContentControl.IsHitTestVisible = true;

            var flightPanel = flightContentControl.Content;

            //flightContentControl.FlightTemplate = flightPanel.FlightTemplate;

            //if (flightContentControl.FlightRequest != null)
            //    if (flightContentControl.FlightRequest.AirportCodeOrGuid.Length > 4)
            //        flightContentControl.FlightRequest.FID = flightContentControl.FlightRequest.AirportCodeOrGuid;

            //flightContentControl.PanelAnimation = flightPanel.PanelAnimation;

            flightContentControl.Content = null;

            serializedControl = XamlWriter.Save(designContentControl);

            //if (flightContentControl.PanelStyle == "FlightPanel")
            //    flightContentControl.Content = new FlightPanel(flightContentControl.SecondsPerPage,
            //                                               flightContentControl.IsTouchscreen, flightContentControl.FlightTemplate, flightContentControl.PanelAnimation, flightContentControl.GetFlights());
            //else
            flightContentControl.Content = flightPanel;

            flightContentControl.IsHitTestVisible = false;

            designContentControl.Content = flightContentControl;

            return serializedControl; // Important that this can be serialized and loaded back up.
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            var contentControl = designContentControl.Content;

            if (contentControl is IDisposable)
                ((IDisposable)contentControl).Dispose(); // Cleanup here and remove handles
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            bool edited = false;
            
            if (designContentControl.Content is MapContentControl)
            {
                var mapContentControl = designContentControl.Content as MapContentControl;

                var pushPointPicker = new PushPointPicker(mapContentControl.Home, mapContentControl.InspireMapCategories, mapContentControl.ShowTraffic, mapContentControl.MapStyle, mapContentControl.ShowBuildings, mapContentControl.ShowBuildingTextures, mapContentControl.Show3DCursor, mapContentControl.ShowTouchPanel, mapContentControl.ShowMapControls, mapContentControl.ShowMapOnly, mapContentControl.ShowPrintIcon, mapContentControl.AutoAdvance);
                pushPointPicker.ShowDialog();
                if (pushPointPicker.DialogResult == true && pushPointPicker.MapCategories != null)
                {

                    string mStyle = string.Empty;

                    switch (pushPointPicker.MapStyle)
                    {
                        case (VEMapStyle.Road):
                            mStyle = "Road";
                            break;
                        case (VEMapStyle.Aerial):
                            mStyle = "Aerial";
                            break;
                        case (VEMapStyle.Hybrid):
                            mStyle = "Hybrid";
                            break;
                        default:
                            mStyle = "Hybrid";
                            break;
                    }

                    var mapNewContentControl = new MapContentControl(pushPointPicker.Home, new InspireMapCategories(pushPointPicker.MapCategories),
                                                                  pushPointPicker.ShowTraffic, mStyle,
                                                                  pushPointPicker.ShowBuildings,
                                                                  pushPointPicker.ShowBuildingTextures,
                                                                  pushPointPicker.Show3DCursor,
                                                                  pushPointPicker.ShowTouchPanel,
                                                                  pushPointPicker.ShowMapControls, pushPointPicker.ShowMapOnly, pushPointPicker.ShowPrintIcon, pushPointPicker.AutoAdvanceLocations);

                    edited = true;
                    mapNewContentControl.IsHitTestVisible = false;

                    designContentControl.Content = mapNewContentControl;
                    // }

                    //    designContentControl.Content = flightContentControl;
                    //designContentControl.Height = 600;
                    //designContentControl.Width = 700;
                    //designContentControl.Tag = "Map";

                    // Set rotation to true
                    designContentControl.IsRotatable = true;

                    designContentControl.IsCopyable = true;

                    designContentControl.IsEditable = true;
                }
            }

            if (designContentControl.Content is MapContentControl && !edited)
                ((MapContentControl)designContentControl.Content).InitializeMap();

            return designContentControl;
        }

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            DesignContentControl designContentControl = null;


            var categorySelecter = new CategorySelecter();
            {
                categorySelecter.ShowDialog();
                if (categorySelecter.DialogResult == true)
                {

                    var pushPointPicker = new PushPointPicker(categorySelecter.Categories);
                    pushPointPicker.ShowDialog();
                    if (pushPointPicker.DialogResult == true && pushPointPicker.Home != null)
                    {
                        designContentControl = new DesignContentControl();

                        string mStyle = string.Empty;

                        switch (pushPointPicker.MapStyle)
                        {
                            case (VEMapStyle.Road):
                                mStyle = "Road";
                                break;
                            case (VEMapStyle.Aerial):
                                mStyle = "Aerial";
                                break;
                            case (VEMapStyle.Hybrid):
                                mStyle = "Hybrid";
                                break;
                            default:
                                mStyle = "Hybrid";
                                break;
                        }

                        var mapContentControl = new MapContentControl(pushPointPicker.Home, new InspireMapCategories(pushPointPicker.MapCategories),
                                                                      pushPointPicker.ShowTraffic, mStyle,
                                                                      pushPointPicker.ShowBuildings,
                                                                      pushPointPicker.ShowBuildingTextures,
                                                                      pushPointPicker.Show3DCursor,
                                                                      pushPointPicker.ShowTouchPanel,
                                                                      pushPointPicker.ShowMapControls, pushPointPicker.ShowMapOnly, pushPointPicker.ShowPrintIcon, pushPointPicker.AutoAdvanceLocations);

                        mapContentControl.IsHitTestVisible = false;

                        designContentControl.Content = mapContentControl;
                        // }

                        //    designContentControl.Content = flightContentControl;
                        designContentControl.Height = 600;
                        designContentControl.Width = 700;
                        designContentControl.Tag = "Map";

                        // Set rotation to true
                        designContentControl.IsRotatable = true;

                        designContentControl.IsCopyable = true;

                        designContentControl.IsEditable = true;
                    }
                }
            }

            return designContentControl;
        }

        public bool GetIsPanelModule()
        {
            return true; // always set to true for designer controls
        }

        public string GetModuleName()
        {
            return "Maps"; // The Alias for the control
        }

        public MediaType GetModuleType()
        {
            return MediaType.XamlElement; // Standard type for xaml based elements
        }

        public UserControl GetPropertyPanel()
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
            var contentControl = designContentControl.Content as ContentControl;

            contentControl.IsHitTestVisible = true;

            if (contentControl.Content is IPlayable)
                ((IPlayable)contentControl.Content).Play();
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            var contentControl = designContentControl.Content as ContentControl;

            contentControl.IsHitTestVisible = false;

            if (contentControl.Content is IPlayable)
                ((IPlayable)contentControl.Content).Stop();
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
