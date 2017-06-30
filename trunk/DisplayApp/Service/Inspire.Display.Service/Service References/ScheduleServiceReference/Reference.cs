﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspire.Display.Service.ScheduleServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Schedules", Namespace="http://schemas.inspiredisplays.com/DataContract/", ItemName="Schedules")]
    [System.SerializableAttribute()]
    public class Schedules : System.Collections.Generic.List<Inspire.Display.Service.ScheduleServiceReference.Schedule> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Schedule", Namespace="http://schemas.inspiredisplays.com/DataContract/")]
    [System.SerializableAttribute()]
    public partial class Schedule : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StartTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DaysField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModeField;
        
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
        public string GUID {
            get {
                return this.GUIDField;
            }
            set {
                if ((object.ReferenceEquals(this.GUIDField, value) != true)) {
                    this.GUIDField = value;
                    this.RaisePropertyChanged("GUID");
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
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<System.DateTime> StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public System.Nullable<System.DateTime> EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public System.Nullable<System.DateTime> StartTime {
            get {
                return this.StartTimeField;
            }
            set {
                if ((this.StartTimeField.Equals(value) != true)) {
                    this.StartTimeField = value;
                    this.RaisePropertyChanged("StartTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public System.Nullable<System.DateTime> EndTime {
            get {
                return this.EndTimeField;
            }
            set {
                if ((this.EndTimeField.Equals(value) != true)) {
                    this.EndTimeField = value;
                    this.RaisePropertyChanged("EndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public int Days {
            get {
                return this.DaysField;
            }
            set {
                if ((this.DaysField.Equals(value) != true)) {
                    this.DaysField = value;
                    this.RaisePropertyChanged("Days");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public string Mode {
            get {
                return this.ModeField;
            }
            set {
                if ((object.ReferenceEquals(this.ModeField, value) != true)) {
                    this.ModeField = value;
                    this.RaisePropertyChanged("Mode");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class GeneralFaultContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorDescField;
        
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
        public string ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorCodeField, value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorDesc {
            get {
                return this.ErrorDescField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorDescField, value) != true)) {
                    this.ErrorDescField = value;
                    this.RaisePropertyChanged("ErrorDesc");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", ConfigurationName="ScheduleServiceReference.ServiceManagerServiceContract")]
    public interface ServiceManagerServiceContract {
        
        // CODEGEN: Generating message contract since the operation GetSchedules is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/GetSchedules", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSchedulesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSchedulesGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage GetSchedules(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetCurrentSchedules is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/GetCurrentSch" +
            "edules", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetCurrentSchedulesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetCurrentSchedulesGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage GetCurrentSchedules(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetSingleSchedule is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/GetSingleSche" +
            "dules", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSingleScheduleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSingleScheduleGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.GetSingleScheduleResponseMessage GetSingleSchedule(Inspire.Display.Service.ScheduleServiceReference.GetSingleSchedulesRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetDisplaysInSchedule is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/GetDisplaysIn" +
            "Schedule", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetDisplaysInScheduleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetDisplaysInScheduleGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleResponseMessage GetDisplaysInSchedule(Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddSchedule is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/AddSchedule", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "AddScheduleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "AddScheduleGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.AddScheduleResponseMessage AddSchedule(Inspire.Display.Service.ScheduleServiceReference.AddScheduleRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation UpdateSchedule is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/UpdateSchedul" +
            "e", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "UpdateScheduleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "UpdateScheduleGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleResponseMessage UpdateSchedule(Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleRequestSchedule request);
        
        // CODEGEN: Generating message contract since the operation DeleteSchedule is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/DeleteSchedul" +
            "e", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "DeleteScheduleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "DeleteScheduleGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleResponseMessage DeleteSchedule(Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetSchedulesFromHostName is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceContract1/GetSchedulesF" +
            "romHostname", ReplyAction="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSchedulesFromHostNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Display.Service.ScheduleServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/ServiceContract/ServiceManagerServiceContract/" +
            "GetSchedulesFromHostNameGeneralFaultContractFault", Name="GeneralFaultContract", Namespace="http://schemas.inspiredisplays.com")]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleFromHostnameResponseMessage GetSchedulesFromHostName(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesFromHostnameRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSchedulesRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string DisplayID;
        
        public GetSchedulesRequestMessage() {
        }
        
        public GetSchedulesRequestMessage(string DisplayID) {
            this.DisplayID = DisplayID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetScheduleResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public Inspire.Display.Service.ScheduleServiceReference.Schedules Schedules;
        
        public GetScheduleResponseMessage() {
        }
        
        public GetScheduleResponseMessage(Inspire.Display.Service.ScheduleServiceReference.Schedules Schedules) {
            this.Schedules = Schedules;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSingleSchedulesRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string ScheduleID;
        
        public GetSingleSchedulesRequestMessage() {
        }
        
        public GetSingleSchedulesRequestMessage(string ScheduleID) {
            this.ScheduleID = ScheduleID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSingleScheduleResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule;
        
        public GetSingleScheduleResponseMessage() {
        }
        
        public GetSingleScheduleResponseMessage(Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule) {
            this.Schedule = Schedule;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDisplaysInScheduleRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string ScheduleID;
        
        public GetDisplaysInScheduleRequestMessage() {
        }
        
        public GetDisplaysInScheduleRequestMessage(string ScheduleID) {
            this.ScheduleID = ScheduleID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDisplaysInScheduleResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string[] Displays;
        
        public GetDisplaysInScheduleResponseMessage() {
        }
        
        public GetDisplaysInScheduleResponseMessage(string[] Displays) {
            this.Displays = Displays;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddScheduleRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string[] DisplayIDs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=1)]
        public Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule;
        
        public AddScheduleRequestMessage() {
        }
        
        public AddScheduleRequestMessage(string[] DisplayIDs, Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule) {
            this.DisplayIDs = DisplayIDs;
            this.Schedule = Schedule;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddScheduleResponseMessage {
        
        public AddScheduleResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateScheduleRequestSchedule {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string[] DisplayIDs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=1)]
        public Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule;
        
        public UpdateScheduleRequestSchedule() {
        }
        
        public UpdateScheduleRequestSchedule(string[] DisplayIDs, Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule) {
            this.DisplayIDs = DisplayIDs;
            this.Schedule = Schedule;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateScheduleResponseMessage {
        
        public UpdateScheduleResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteScheduleRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public string ScheduleID;
        
        public DeleteScheduleRequestMessage() {
        }
        
        public DeleteScheduleRequestMessage(string ScheduleID) {
            this.ScheduleID = ScheduleID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteScheduleResponseMessage {
        
        public DeleteScheduleResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSchedulesFromHostnameRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public bool AlwaysSendSchedule;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=1)]
        public string Hostname;
        
        public GetSchedulesFromHostnameRequestMessage() {
        }
        
        public GetSchedulesFromHostnameRequestMessage(bool AlwaysSendSchedule, string Hostname) {
            this.AlwaysSendSchedule = AlwaysSendSchedule;
            this.Hostname = Hostname;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetScheduleFromHostnameResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=0)]
        public Inspire.Display.Service.ScheduleServiceReference.Schedules Schedules;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com/ServiceContract/", Order=1)]
        public bool Updated;
        
        public GetScheduleFromHostnameResponseMessage() {
        }
        
        public GetScheduleFromHostnameResponseMessage(Inspire.Display.Service.ScheduleServiceReference.Schedules Schedules, bool Updated) {
            this.Schedules = Schedules;
            this.Updated = Updated;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceManagerServiceContractChannel : Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceManagerServiceContractClient : System.ServiceModel.ClientBase<Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract>, Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract {
        
        public ServiceManagerServiceContractClient() {
        }
        
        public ServiceManagerServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceManagerServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceManagerServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceManagerServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.GetSchedules(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage request) {
            return base.Channel.GetSchedules(request);
        }
        
        public Inspire.Display.Service.ScheduleServiceReference.Schedules GetSchedules(string DisplayID) {
            Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage();
            inValue.DisplayID = DisplayID;
            Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).GetSchedules(inValue);
            return retVal.Schedules;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.GetCurrentSchedules(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage request) {
            return base.Channel.GetCurrentSchedules(request);
        }
        
        public Inspire.Display.Service.ScheduleServiceReference.Schedules GetCurrentSchedules(string DisplayID) {
            Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.GetSchedulesRequestMessage();
            inValue.DisplayID = DisplayID;
            Inspire.Display.Service.ScheduleServiceReference.GetScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).GetCurrentSchedules(inValue);
            return retVal.Schedules;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.GetSingleScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.GetSingleSchedule(Inspire.Display.Service.ScheduleServiceReference.GetSingleSchedulesRequestMessage request) {
            return base.Channel.GetSingleSchedule(request);
        }
        
        public Inspire.Display.Service.ScheduleServiceReference.Schedule GetSingleSchedule(string ScheduleID) {
            Inspire.Display.Service.ScheduleServiceReference.GetSingleSchedulesRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.GetSingleSchedulesRequestMessage();
            inValue.ScheduleID = ScheduleID;
            Inspire.Display.Service.ScheduleServiceReference.GetSingleScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).GetSingleSchedule(inValue);
            return retVal.Schedule;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.GetDisplaysInSchedule(Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleRequestMessage request) {
            return base.Channel.GetDisplaysInSchedule(request);
        }
        
        public string[] GetDisplaysInSchedule(string ScheduleID) {
            Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleRequestMessage();
            inValue.ScheduleID = ScheduleID;
            Inspire.Display.Service.ScheduleServiceReference.GetDisplaysInScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).GetDisplaysInSchedule(inValue);
            return retVal.Displays;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.AddScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.AddSchedule(Inspire.Display.Service.ScheduleServiceReference.AddScheduleRequestMessage request) {
            return base.Channel.AddSchedule(request);
        }
        
        public void AddSchedule(string[] DisplayIDs, Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule) {
            Inspire.Display.Service.ScheduleServiceReference.AddScheduleRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.AddScheduleRequestMessage();
            inValue.DisplayIDs = DisplayIDs;
            inValue.Schedule = Schedule;
            Inspire.Display.Service.ScheduleServiceReference.AddScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).AddSchedule(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.UpdateSchedule(Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleRequestSchedule request) {
            return base.Channel.UpdateSchedule(request);
        }
        
        public void UpdateSchedule(string[] DisplayIDs, Inspire.Display.Service.ScheduleServiceReference.Schedule Schedule) {
            Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleRequestSchedule inValue = new Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleRequestSchedule();
            inValue.DisplayIDs = DisplayIDs;
            inValue.Schedule = Schedule;
            Inspire.Display.Service.ScheduleServiceReference.UpdateScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).UpdateSchedule(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.DeleteSchedule(Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleRequestMessage request) {
            return base.Channel.DeleteSchedule(request);
        }
        
        public void DeleteSchedule(string ScheduleID) {
            Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleRequestMessage();
            inValue.ScheduleID = ScheduleID;
            Inspire.Display.Service.ScheduleServiceReference.DeleteScheduleResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).DeleteSchedule(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Display.Service.ScheduleServiceReference.GetScheduleFromHostnameResponseMessage Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract.GetSchedulesFromHostName(Inspire.Display.Service.ScheduleServiceReference.GetSchedulesFromHostnameRequestMessage request) {
            return base.Channel.GetSchedulesFromHostName(request);
        }
        
        public Inspire.Display.Service.ScheduleServiceReference.Schedules GetSchedulesFromHostName(bool AlwaysSendSchedule, string Hostname, out bool Updated) {
            Inspire.Display.Service.ScheduleServiceReference.GetSchedulesFromHostnameRequestMessage inValue = new Inspire.Display.Service.ScheduleServiceReference.GetSchedulesFromHostnameRequestMessage();
            inValue.AlwaysSendSchedule = AlwaysSendSchedule;
            inValue.Hostname = Hostname;
            Inspire.Display.Service.ScheduleServiceReference.GetScheduleFromHostnameResponseMessage retVal = ((Inspire.Display.Service.ScheduleServiceReference.ServiceManagerServiceContract)(this)).GetSchedulesFromHostName(inValue);
            Updated = retVal.Updated;
            return retVal.Schedules;
        }
    }
}
