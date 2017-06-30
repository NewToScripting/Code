using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using FlightInfoModule.Proxy;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Transitionals.Controls;

namespace FlightInfoModule
{
    public class FlightControl : MediaModule, IMediaModule
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

            var flightContentControl = designContentControl.Content as FlightContentControl;

            var flightPanel = flightContentControl.Content as IFlightPanel;

            flightContentControl.FlightTemplate = flightPanel.FlightTemplate;

            if (flightContentControl.FlightRequest != null)
                if (flightContentControl.FlightRequest.AirportCodeOrGuid.Length > 4)
                    flightContentControl.FlightRequest.FID = flightContentControl.FlightRequest.AirportCodeOrGuid;

            flightContentControl.PanelAnimation = flightPanel.PanelAnimation;

            flightContentControl.Content = null;

            var resources = flightContentControl.Resources;

            flightContentControl.Resources.Clear();

            serializedControl = XamlWriter.Save(designContentControl);

            if (flightContentControl.PanelStyle == "FlightPanel")
                flightContentControl.Content = new FlightPanel(flightContentControl.SecondsPerPage,
                                                           flightContentControl.IsTouchscreen, flightContentControl.FlightTemplate, flightContentControl.PanelAnimation, flightContentControl.GetFlights(), flightContentControl.AdvanceOnEnd, flightContentControl.AdvanceAfterLoops);
            else
                flightContentControl.Content = new DoublePaneFlightPanel(flightContentControl.SecondsPerPage, flightContentControl.FlightTemplate, flightContentControl.PanelAnimation, flightContentControl.GetFlights(), flightContentControl.AdvanceOnEnd, flightContentControl.AdvanceAfterLoops);

            flightContentControl.SetResourceTemplate();

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
            return null; // No edit for this. if there were more properties, we could reopen the ModuleDialog. Properties can be set in the PropertyPanel
        }

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            FlightContentControl flightContentControl = null;
            DesignContentControl designContentControl = null;

            var flightChooser = new FlightChooser();
            flightChooser.ShowDialog();
            if (flightChooser.DialogResult == true)
            {
                if (flightChooser.PanelType == "FlightPanel")
                {
                    var flightControlDetails = new FlightControlDetails();
                    flightControlDetails.ShowDialog();
                    if (flightControlDetails.DialogResult == true)
                    {
                        flightContentControl = new FlightContentControl(flightChooser.PanelType,
                                                                        new FlightRequest
                                                                            {
                                                                                AirportCodeOrGuid =
                                                                                    flightControlDetails.AirportCode,
                                                                                LookBehindCurrentTime =
                                                                                    flightControlDetails.ShowBehind, LookAheadCurrentTime = flightControlDetails.ShowAhead, ShowNameInsteadOfImage = flightControlDetails.ShowNameInsteadOfImage },
                                                                                                                    flightControlDetails.SecondsPerPage, new TemplatedFlight(),
                                                                                                                    flightControlDetails.IsTouchscreen, flightControlDetails.FlightStyle,
                                                                                                                    flightControlDetails.PanelAnimation);
                    }
                }
                else if (flightChooser.PanelType == "DoubleFlightPanel")
                {
                    var flightControlDetails = new FlightControlDetails(false);
                    flightControlDetails.ShowDialog();
                    if (flightControlDetails.DialogResult == true)
                    {
                        flightContentControl = new FlightContentControl(flightChooser.PanelType, new FlightRequest { AirportCodeOrGuid = flightControlDetails.AirportCode, LookAheadCurrentTime = flightControlDetails.ShowAhead, ShowNameInsteadOfImage = flightControlDetails.ShowNameInsteadOfImage }, flightControlDetails.SecondsPerPage, new TemplatedFlight(), false, flightControlDetails.FlightStyle, flightControlDetails.PanelAnimation);
                    }
                }
            }

            if (flightContentControl != null)
            {
                designContentControl = new DesignContentControl();

                flightContentControl.IsHitTestVisible = false;

                designContentControl.Content = flightContentControl;
                designContentControl.Height = 600;
                designContentControl.Width = flightContentControl.PanelStyle == "DoubleFlightPanel" ? 1300 : 700;
                designContentControl.Tag = "Flight Info";

                // Set rotation to true
                designContentControl.IsRotatable = true;

                designContentControl.IsCopyable = true;
            }

            return designContentControl;
        }

        public bool GetIsPanelModule()
        {
            return true; // always set to true for designer controls
        }

        public string GetModuleName()
        {
            return "Flight Information"; // The Alias for the control
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
            var contentControl = designContentControl.Content as TransitionElement;

            contentControl.IsHitTestVisible = true;

            if (contentControl.Content is IPlayable)
                ((IPlayable)contentControl.Content).Play();
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            var contentControl = designContentControl.Content as TransitionElement;

            contentControl.IsHitTestVisible = false;

            if (contentControl.Content is IPlayable)
                ((IPlayable)contentControl.Content).Stop();
        }

        public IEnumerable<string> GetRules(DesignContentControl designContentControl)
        {
            var contentControl = designContentControl.Content as FlightContentControl;

            if (contentControl == null) return null;

            if(contentControl.AdvanceOnEnd && contentControl.AdvanceAfterLoops > 0)
                return new List<string>()
                           {
                               designContentControl.Tag +
                               ": The slide is advanced after " + contentControl.AdvanceAfterLoops + " loops of flight information."
                           };

            return null;
        }

        public bool GetIsApp()
        {
            return true;
        }

        #endregion
    }
}
