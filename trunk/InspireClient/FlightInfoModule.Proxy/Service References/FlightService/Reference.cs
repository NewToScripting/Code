﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightInfoModule.Proxy.FlightService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightRequest", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    [System.SerializableAttribute()]
    public partial class FlightRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AirlineCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AirportCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DnsHostNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FyteTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IpAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> LookAheadCurrentTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> LookBehindCurrentTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ShowNameInsteadOfImageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AirlineCode {
            get {
                return this.AirlineCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AirlineCodeField, value) != true)) {
                    this.AirlineCodeField = value;
                    this.RaisePropertyChanged("AirlineCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AirportCode {
            get {
                return this.AirportCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AirportCodeField, value) != true)) {
                    this.AirportCodeField = value;
                    this.RaisePropertyChanged("AirportCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerGuid {
            get {
                return this.CustomerGuidField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerGuidField, value) != true)) {
                    this.CustomerGuidField = value;
                    this.RaisePropertyChanged("CustomerGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DnsHostName {
            get {
                return this.DnsHostNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DnsHostNameField, value) != true)) {
                    this.DnsHostNameField = value;
                    this.RaisePropertyChanged("DnsHostName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FID {
            get {
                return this.FIDField;
            }
            set {
                if ((object.ReferenceEquals(this.FIDField, value) != true)) {
                    this.FIDField = value;
                    this.RaisePropertyChanged("FID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FyteType {
            get {
                return this.FyteTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.FyteTypeField, value) != true)) {
                    this.FyteTypeField = value;
                    this.RaisePropertyChanged("FyteType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IpAddress {
            get {
                return this.IpAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.IpAddressField, value) != true)) {
                    this.IpAddressField = value;
                    this.RaisePropertyChanged("IpAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.TimeSpan> LookAheadCurrentTime {
            get {
                return this.LookAheadCurrentTimeField;
            }
            set {
                if ((this.LookAheadCurrentTimeField.Equals(value) != true)) {
                    this.LookAheadCurrentTimeField = value;
                    this.RaisePropertyChanged("LookAheadCurrentTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.TimeSpan> LookBehindCurrentTime {
            get {
                return this.LookBehindCurrentTimeField;
            }
            set {
                if ((this.LookBehindCurrentTimeField.Equals(value) != true)) {
                    this.LookBehindCurrentTimeField = value;
                    this.RaisePropertyChanged("LookBehindCurrentTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ShowNameInsteadOfImage {
            get {
                return this.ShowNameInsteadOfImageField;
            }
            set {
                if ((this.ShowNameInsteadOfImageField.Equals(value) != true)) {
                    this.ShowNameInsteadOfImageField = value;
                    this.RaisePropertyChanged("ShowNameInsteadOfImage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Airport", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    [System.SerializableAttribute()]
    public partial class Airport : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AirportCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FAACodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IATACodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ICACodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> IsMajorAirportField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LongitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostalCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WeatherStationCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WeatherZoneField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AirportCode {
            get {
                return this.AirportCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AirportCodeField, value) != true)) {
                    this.AirportCodeField = value;
                    this.RaisePropertyChanged("AirportCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryCode {
            get {
                return this.CountryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCodeField, value) != true)) {
                    this.CountryCodeField = value;
                    this.RaisePropertyChanged("CountryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FAACode {
            get {
                return this.FAACodeField;
            }
            set {
                if ((object.ReferenceEquals(this.FAACodeField, value) != true)) {
                    this.FAACodeField = value;
                    this.RaisePropertyChanged("FAACode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IATACode {
            get {
                return this.IATACodeField;
            }
            set {
                if ((object.ReferenceEquals(this.IATACodeField, value) != true)) {
                    this.IATACodeField = value;
                    this.RaisePropertyChanged("IATACode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ICACode {
            get {
                return this.ICACodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ICACodeField, value) != true)) {
                    this.ICACodeField = value;
                    this.RaisePropertyChanged("ICACode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsMajorAirport {
            get {
                return this.IsMajorAirportField;
            }
            set {
                if ((this.IsMajorAirportField.Equals(value) != true)) {
                    this.IsMajorAirportField = value;
                    this.RaisePropertyChanged("IsMajorAirport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Latitude {
            get {
                return this.LatitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LatitudeField, value) != true)) {
                    this.LatitudeField = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LongitudeField, value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostalCode {
            get {
                return this.PostalCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostalCodeField, value) != true)) {
                    this.PostalCodeField = value;
                    this.RaisePropertyChanged("PostalCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WeatherStationCode {
            get {
                return this.WeatherStationCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.WeatherStationCodeField, value) != true)) {
                    this.WeatherStationCodeField = value;
                    this.RaisePropertyChanged("WeatherStationCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WeatherZone {
            get {
                return this.WeatherZoneField;
            }
            set {
                if ((object.ReferenceEquals(this.WeatherZoneField, value) != true)) {
                    this.WeatherZoneField = value;
                    this.RaisePropertyChanged("WeatherZone");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Flight", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    [System.SerializableAttribute()]
    public partial class Flight : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ActualArrivalDepartureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightInfoModule.Proxy.FlightService.Airline AirlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> DelayMinutesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightInfoModule.Proxy.FlightService.Airport DestinationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EstimatedArrivalDepartureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlightNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightInfoModule.Proxy.FlightService.Flight.FlightTypes FlyteTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightInfoModule.Proxy.FlightService.Airport OriginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ScheduleArrivalDepartureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ActualArrivalDeparture {
            get {
                return this.ActualArrivalDepartureField;
            }
            set {
                if ((this.ActualArrivalDepartureField.Equals(value) != true)) {
                    this.ActualArrivalDepartureField = value;
                    this.RaisePropertyChanged("ActualArrivalDeparture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightInfoModule.Proxy.FlightService.Airline Airline {
            get {
                return this.AirlineField;
            }
            set {
                if ((object.ReferenceEquals(this.AirlineField, value) != true)) {
                    this.AirlineField = value;
                    this.RaisePropertyChanged("Airline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> DelayMinutes {
            get {
                return this.DelayMinutesField;
            }
            set {
                if ((this.DelayMinutesField.Equals(value) != true)) {
                    this.DelayMinutesField = value;
                    this.RaisePropertyChanged("DelayMinutes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightInfoModule.Proxy.FlightService.Airport Destination {
            get {
                return this.DestinationField;
            }
            set {
                if ((object.ReferenceEquals(this.DestinationField, value) != true)) {
                    this.DestinationField = value;
                    this.RaisePropertyChanged("Destination");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> EstimatedArrivalDeparture {
            get {
                return this.EstimatedArrivalDepartureField;
            }
            set {
                if ((this.EstimatedArrivalDepartureField.Equals(value) != true)) {
                    this.EstimatedArrivalDepartureField = value;
                    this.RaisePropertyChanged("EstimatedArrivalDeparture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightNumber {
            get {
                return this.FlightNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.FlightNumberField, value) != true)) {
                    this.FlightNumberField = value;
                    this.RaisePropertyChanged("FlightNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightInfoModule.Proxy.FlightService.Flight.FlightTypes FlyteType {
            get {
                return this.FlyteTypeField;
            }
            set {
                if ((this.FlyteTypeField.Equals(value) != true)) {
                    this.FlyteTypeField = value;
                    this.RaisePropertyChanged("FlyteType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gate {
            get {
                return this.GateField;
            }
            set {
                if ((object.ReferenceEquals(this.GateField, value) != true)) {
                    this.GateField = value;
                    this.RaisePropertyChanged("Gate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightInfoModule.Proxy.FlightService.Airport Origin {
            get {
                return this.OriginField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginField, value) != true)) {
                    this.OriginField = value;
                    this.RaisePropertyChanged("Origin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ScheduleArrivalDeparture {
            get {
                return this.ScheduleArrivalDepartureField;
            }
            set {
                if ((this.ScheduleArrivalDepartureField.Equals(value) != true)) {
                    this.ScheduleArrivalDepartureField = value;
                    this.RaisePropertyChanged("ScheduleArrivalDeparture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCode {
            get {
                return this.StatusCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusCodeField, value) != true)) {
                    this.StatusCodeField = value;
                    this.RaisePropertyChanged("StatusCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Flight.FlightTypes", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
        public enum FlightTypes : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            Arrival = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            Departure = 1,
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Airline", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    [System.SerializableAttribute()]
    public partial class Airline : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AirlineCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IATACodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ICACodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AirlineCode {
            get {
                return this.AirlineCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AirlineCodeField, value) != true)) {
                    this.AirlineCodeField = value;
                    this.RaisePropertyChanged("AirlineCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IATACode {
            get {
                return this.IATACodeField;
            }
            set {
                if ((object.ReferenceEquals(this.IATACodeField, value) != true)) {
                    this.IATACodeField = value;
                    this.RaisePropertyChanged("IATACode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ICACode {
            get {
                return this.ICACodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ICACodeField, value) != true)) {
                    this.ICACodeField = value;
                    this.RaisePropertyChanged("ICACode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageUrl {
            get {
                return this.ImageUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageUrlField, value) != true)) {
                    this.ImageUrlField = value;
                    this.RaisePropertyChanged("ImageUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FlightService.IFlightInfoService")]
    public interface IFlightInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightInfoService/GetAirports", ReplyAction="http://tempuri.org/IFlightInfoService/GetAirportsResponse")]
        FlightInfoModule.Proxy.FlightService.Airport[] GetAirports(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightInfoService/GetFlights", ReplyAction="http://tempuri.org/IFlightInfoService/GetFlightsResponse")]
        FlightInfoModule.Proxy.FlightService.Flight[] GetFlights(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFlightInfoService/GetAirlines", ReplyAction="http://tempuri.org/IFlightInfoService/GetAirlinesResponse")]
        FlightInfoModule.Proxy.FlightService.Airline[] GetAirlines(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFlightInfoServiceChannel : FlightInfoModule.Proxy.FlightService.IFlightInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FlightInfoServiceClient : System.ServiceModel.ClientBase<FlightInfoModule.Proxy.FlightService.IFlightInfoService>, FlightInfoModule.Proxy.FlightService.IFlightInfoService {
        
        public FlightInfoServiceClient() {
        }
        
        public FlightInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FlightInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FlightInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FlightInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FlightInfoModule.Proxy.FlightService.Airport[] GetAirports(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest) {
            return base.Channel.GetAirports(flightRequest);
        }
        
        public FlightInfoModule.Proxy.FlightService.Flight[] GetFlights(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest) {
            return base.Channel.GetFlights(flightRequest);
        }
        
        public FlightInfoModule.Proxy.FlightService.Airline[] GetAirlines(FlightInfoModule.Proxy.FlightService.FlightRequest flightRequest) {
            return base.Channel.GetAirlines(flightRequest);
        }
    }
}
