﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InspireEventsEntry.RoomServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Rooms", Namespace="http://schemas.inspiredisplays.com", ItemName="Rooms")]
    [System.SerializableAttribute()]
    public class Rooms : System.Collections.Generic.List<InspireEventsEntry.RoomServiceReference.Room> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Room", Namespace="http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class Room : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private InspireEventsEntry.RoomServiceReference.RoomAliases RoomAliasesField;
        
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
        public InspireEventsEntry.RoomServiceReference.RoomAliases RoomAliases {
            get {
                return this.RoomAliasesField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomAliasesField, value) != true)) {
                    this.RoomAliasesField = value;
                    this.RaisePropertyChanged("RoomAliases");
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
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="RoomAliases", Namespace="http://schemas.inspiredisplays.com", ItemName="RoomAliases")]
    [System.SerializableAttribute()]
    public class RoomAliases : System.Collections.Generic.List<InspireEventsEntry.RoomServiceReference.RoomAlias> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoomAlias", Namespace="http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class RoomAlias : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoomIDField;
        
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
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string RoomID {
            get {
                return this.RoomIDField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomIDField, value) != true)) {
                    this.RoomIDField = value;
                    this.RaisePropertyChanged("RoomID");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.inspiredisplays.com", ConfigurationName="RoomServiceReference.RoomsServiceContract")]
    public interface RoomsServiceContract {
        
        // CODEGEN: Generating message contract since the operation GetRooms is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/GetRooms", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/GetRoomsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/GetRoomsGeneralFaultContr" +
            "actFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.GetRoomsResponseMessage GetRooms(InspireEventsEntry.RoomServiceReference.GetRoomsRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetRoomsFromDisplayID is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/GetRoomsFromDisplayID", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/GetRoomsFromDisplayIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/GetRoomsFromDisplayIDGene" +
            "ralFaultContractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDResponseMessage GetRoomsFromDisplayID(InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddRoom is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/AddRoom", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/AddRoomResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/AddRoomGeneralFaultContra" +
            "ctFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.AddRoomResponseMessage AddRoom(InspireEventsEntry.RoomServiceReference.AddRoomRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddRoomToDisplayAssn is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/AddRoomToDisplayAssn", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/AddRoomToDisplayAssnRespo" +
            "nse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/AddRoomToDisplayAssnGener" +
            "alFaultContractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnResponseMessage AddRoomToDisplayAssn(InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteRoomToDisplayAssn is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoomToDisplayAssn", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoomToDisplayAssnRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoomToDisplayAssnGe" +
            "neralFaultContractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnResponseMessage DeleteRoomToDisplayAssn(InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteRoom is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoom", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoomResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteRoomGeneralFaultCon" +
            "tractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.DeleteRoomResponseMessage DeleteRoom(InspireEventsEntry.RoomServiceReference.DeleteRoomRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation GetAliases is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/GetAliases", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/GetAliasesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/GetAliasesGeneralFaultCon" +
            "tractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.GetAliasesResponseMessage GetAliases(InspireEventsEntry.RoomServiceReference.GetAliasesRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddAlias is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/AddAlias", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/AddAliasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/AddAliasGeneralFaultContr" +
            "actFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.AddAliasResponseMessage AddAlias(InspireEventsEntry.RoomServiceReference.AddAliasRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteAlias is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteAlias", ReplyAction="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteAliasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InspireEventsEntry.RoomServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/RoomsServiceContract/DeleteAliasGeneralFaultCo" +
            "ntractFault", Name="GeneralFaultContract")]
        InspireEventsEntry.RoomServiceReference.DeleteAliasResponseMessage DeleteAlias(InspireEventsEntry.RoomServiceReference.DeleteAliasRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRoomsRequestMessage {
        
        public GetRoomsRequestMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRoomsResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public InspireEventsEntry.RoomServiceReference.Rooms Rooms;
        
        public GetRoomsResponseMessage() {
        }
        
        public GetRoomsResponseMessage(InspireEventsEntry.RoomServiceReference.Rooms Rooms) {
            this.Rooms = Rooms;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRoomsFromDisplayIDRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string DisplayID;
        
        public GetRoomsFromDisplayIDRequestMessage() {
        }
        
        public GetRoomsFromDisplayIDRequestMessage(string DisplayID) {
            this.DisplayID = DisplayID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRoomsFromDisplayIDResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public InspireEventsEntry.RoomServiceReference.Rooms Rooms;
        
        public GetRoomsFromDisplayIDResponseMessage() {
        }
        
        public GetRoomsFromDisplayIDResponseMessage(InspireEventsEntry.RoomServiceReference.Rooms Rooms) {
            this.Rooms = Rooms;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddRoomRequestMessage", WrapperNamespace="http://schemas.inspiredisplays.com", IsWrapped=true)]
    public partial class AddRoomRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public InspireEventsEntry.RoomServiceReference.Room Room;
        
        public AddRoomRequestMessage() {
        }
        
        public AddRoomRequestMessage(InspireEventsEntry.RoomServiceReference.Room Room) {
            this.Room = Room;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddRoomResponseMessage {
        
        public AddRoomResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddRoomToDisplayAssnRequestMessage", WrapperNamespace="http://schemas.inspiredisplays.com", IsWrapped=true)]
    public partial class AddRoomToDisplayAssnRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string DisplayID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=1)]
        public string RoomID;
        
        public AddRoomToDisplayAssnRequestMessage() {
        }
        
        public AddRoomToDisplayAssnRequestMessage(string DisplayID, string RoomID) {
            this.DisplayID = DisplayID;
            this.RoomID = RoomID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddRoomToDisplayAssnResponseMessage {
        
        public AddRoomToDisplayAssnResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteRoomToDisplayAssnRequestMessage", WrapperNamespace="http://schemas.inspiredisplays.com", IsWrapped=true)]
    public partial class DeleteRoomToDisplayAssnRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string DisplayID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=1)]
        public string RoomID;
        
        public DeleteRoomToDisplayAssnRequestMessage() {
        }
        
        public DeleteRoomToDisplayAssnRequestMessage(string DisplayID, string RoomID) {
            this.DisplayID = DisplayID;
            this.RoomID = RoomID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteRoomToDisplayAssnResponseMessage {
        
        public DeleteRoomToDisplayAssnResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteRoomRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string GUID;
        
        public DeleteRoomRequestMessage() {
        }
        
        public DeleteRoomRequestMessage(string GUID) {
            this.GUID = GUID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteRoomResponseMessage {
        
        public DeleteRoomResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAliasesRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string RoomID;
        
        public GetAliasesRequestMessage() {
        }
        
        public GetAliasesRequestMessage(string RoomID) {
            this.RoomID = RoomID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAliasesResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public InspireEventsEntry.RoomServiceReference.RoomAliases Aliases;
        
        public GetAliasesResponseMessage() {
        }
        
        public GetAliasesResponseMessage(InspireEventsEntry.RoomServiceReference.RoomAliases Aliases) {
            this.Aliases = Aliases;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddAliasRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public InspireEventsEntry.RoomServiceReference.RoomAlias GroupAlias;
        
        public AddAliasRequestMessage() {
        }
        
        public AddAliasRequestMessage(InspireEventsEntry.RoomServiceReference.RoomAlias GroupAlias) {
            this.GroupAlias = GroupAlias;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddAliasResponseMessage {
        
        public AddAliasResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteAliasRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string AliasID;
        
        public DeleteAliasRequestMessage() {
        }
        
        public DeleteAliasRequestMessage(string AliasID) {
            this.AliasID = AliasID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteAliasResponseMessage {
        
        public DeleteAliasResponseMessage() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface RoomsServiceContractChannel : InspireEventsEntry.RoomServiceReference.RoomsServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomsServiceContractClient : System.ServiceModel.ClientBase<InspireEventsEntry.RoomServiceReference.RoomsServiceContract>, InspireEventsEntry.RoomServiceReference.RoomsServiceContract {
        
        public RoomsServiceContractClient() {
        }
        
        public RoomsServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomsServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomsServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomsServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.GetRoomsResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.GetRooms(InspireEventsEntry.RoomServiceReference.GetRoomsRequestMessage request) {
            return base.Channel.GetRooms(request);
        }
        
        public InspireEventsEntry.RoomServiceReference.Rooms GetRooms() {
            InspireEventsEntry.RoomServiceReference.GetRoomsRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.GetRoomsRequestMessage();
            InspireEventsEntry.RoomServiceReference.GetRoomsResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).GetRooms(inValue);
            return retVal.Rooms;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.GetRoomsFromDisplayID(InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDRequestMessage request) {
            return base.Channel.GetRoomsFromDisplayID(request);
        }
        
        public InspireEventsEntry.RoomServiceReference.Rooms GetRoomsFromDisplayID(string DisplayID) {
            InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDRequestMessage();
            inValue.DisplayID = DisplayID;
            InspireEventsEntry.RoomServiceReference.GetRoomsFromDisplayIDResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).GetRoomsFromDisplayID(inValue);
            return retVal.Rooms;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.AddRoomResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.AddRoom(InspireEventsEntry.RoomServiceReference.AddRoomRequestMessage request) {
            return base.Channel.AddRoom(request);
        }
        
        public void AddRoom(InspireEventsEntry.RoomServiceReference.Room Room) {
            InspireEventsEntry.RoomServiceReference.AddRoomRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.AddRoomRequestMessage();
            inValue.Room = Room;
            InspireEventsEntry.RoomServiceReference.AddRoomResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).AddRoom(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.AddRoomToDisplayAssn(InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnRequestMessage request) {
            return base.Channel.AddRoomToDisplayAssn(request);
        }
        
        public void AddRoomToDisplayAssn(string DisplayID, string RoomID) {
            InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnRequestMessage();
            inValue.DisplayID = DisplayID;
            inValue.RoomID = RoomID;
            InspireEventsEntry.RoomServiceReference.AddRoomToDisplayAssnResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).AddRoomToDisplayAssn(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.DeleteRoomToDisplayAssn(InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnRequestMessage request) {
            return base.Channel.DeleteRoomToDisplayAssn(request);
        }
        
        public void DeleteRoomToDisplayAssn(string DisplayID, string RoomID) {
            InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnRequestMessage();
            inValue.DisplayID = DisplayID;
            inValue.RoomID = RoomID;
            InspireEventsEntry.RoomServiceReference.DeleteRoomToDisplayAssnResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).DeleteRoomToDisplayAssn(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.DeleteRoomResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.DeleteRoom(InspireEventsEntry.RoomServiceReference.DeleteRoomRequestMessage request) {
            return base.Channel.DeleteRoom(request);
        }
        
        public void DeleteRoom(string GUID) {
            InspireEventsEntry.RoomServiceReference.DeleteRoomRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.DeleteRoomRequestMessage();
            inValue.GUID = GUID;
            InspireEventsEntry.RoomServiceReference.DeleteRoomResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).DeleteRoom(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.GetAliasesResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.GetAliases(InspireEventsEntry.RoomServiceReference.GetAliasesRequestMessage request) {
            return base.Channel.GetAliases(request);
        }
        
        public InspireEventsEntry.RoomServiceReference.RoomAliases GetAliases(string RoomID) {
            InspireEventsEntry.RoomServiceReference.GetAliasesRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.GetAliasesRequestMessage();
            inValue.RoomID = RoomID;
            InspireEventsEntry.RoomServiceReference.GetAliasesResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).GetAliases(inValue);
            return retVal.Aliases;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.AddAliasResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.AddAlias(InspireEventsEntry.RoomServiceReference.AddAliasRequestMessage request) {
            return base.Channel.AddAlias(request);
        }
        
        public void AddAlias(InspireEventsEntry.RoomServiceReference.RoomAlias GroupAlias) {
            InspireEventsEntry.RoomServiceReference.AddAliasRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.AddAliasRequestMessage();
            inValue.GroupAlias = GroupAlias;
            InspireEventsEntry.RoomServiceReference.AddAliasResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).AddAlias(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InspireEventsEntry.RoomServiceReference.DeleteAliasResponseMessage InspireEventsEntry.RoomServiceReference.RoomsServiceContract.DeleteAlias(InspireEventsEntry.RoomServiceReference.DeleteAliasRequestMessage request) {
            return base.Channel.DeleteAlias(request);
        }
        
        public void DeleteAlias(string AliasID) {
            InspireEventsEntry.RoomServiceReference.DeleteAliasRequestMessage inValue = new InspireEventsEntry.RoomServiceReference.DeleteAliasRequestMessage();
            inValue.AliasID = AliasID;
            InspireEventsEntry.RoomServiceReference.DeleteAliasResponseMessage retVal = ((InspireEventsEntry.RoomServiceReference.RoomsServiceContract)(this)).DeleteAlias(inValue);
        }
    }
}
