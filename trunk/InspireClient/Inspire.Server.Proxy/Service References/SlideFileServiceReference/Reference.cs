﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspire.Server.Proxy.SlideFileServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.inspiredisplays.com", ConfigurationName="SlideFileServiceReference.SlideFileManagerServiceContract")]
    public interface SlideFileManagerServiceContract {
        
        // CODEGEN: Generating message contract since the operation GetSlideFile is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/GetSlideFile", ReplyAction="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/GetSlideFileRe" +
            "sponse")]
        Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileResponseMessage GetSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddSlideFile is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/AddSlideFile", ReplyAction="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/AddSlideFileRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Proxy.SlideFileServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/AddSlideFileGe" +
            "neralFaultContractFault", Name="GeneralFaultContract")]
        Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileResponseMessage AddSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation UpdateSlideFile is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/UpdateSlideFile", ReplyAction="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/UpdateSlideFil" +
            "eResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Proxy.SlideFileServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/UpdateSlideFil" +
            "eGeneralFaultContractFault", Name="GeneralFaultContract")]
        Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileResponseMessage UpdateSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteSlideFile is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/ServiceContract1/DeleteSlideFile", ReplyAction="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/DeleteSlideFil" +
            "eResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Proxy.SlideFileServiceReference.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SlideFileManagerServiceContract/DeleteSlideFil" +
            "eGeneralFaultContractFault", Name="GeneralFaultContract")]
        Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileResponseMessage DeleteSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSlideFileRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string SlideID;
        
        public GetSlideFileRequestMessage() {
        }
        
        public GetSlideFileRequestMessage(string SlideID) {
            this.SlideID = SlideID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSlideFileResponseMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public string SlideFileID;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public int SlideFileSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public System.IO.Stream SlideFileStream;
        
        public GetSlideFileResponseMessage() {
        }
        
        public GetSlideFileResponseMessage(string SlideFileID, int SlideFileSize, System.IO.Stream SlideFileStream) {
            this.SlideFileID = SlideFileID;
            this.SlideFileSize = SlideFileSize;
            this.SlideFileStream = SlideFileStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSlideFileRequestMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public string SlideFileID;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public int SlideFileSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public System.IO.Stream SlideFileStream;
        
        public AddSlideFileRequestMessage() {
        }
        
        public AddSlideFileRequestMessage(string SlideFileID, int SlideFileSize, System.IO.Stream SlideFileStream) {
            this.SlideFileID = SlideFileID;
            this.SlideFileSize = SlideFileSize;
            this.SlideFileStream = SlideFileStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSlideFileResponseMessage {
        
        public AddSlideFileResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSlideFileRequestMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public string SlideFileID;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.inspiredisplays.com")]
        public int SlideFileSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public System.IO.Stream SlideFileStream;
        
        public UpdateSlideFileRequestMessage() {
        }
        
        public UpdateSlideFileRequestMessage(string SlideFileID, int SlideFileSize, System.IO.Stream SlideFileStream) {
            this.SlideFileID = SlideFileID;
            this.SlideFileSize = SlideFileSize;
            this.SlideFileStream = SlideFileStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSlideFileResponseMessage {
        
        public UpdateSlideFileResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSlideFileRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string SlideID;
        
        public DeleteSlideFileRequestMessage() {
        }
        
        public DeleteSlideFileRequestMessage(string SlideID) {
            this.SlideID = SlideID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSlideFileResponseMessage {
        
        public DeleteSlideFileResponseMessage() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SlideFileManagerServiceContractChannel : Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SlideFileManagerServiceContractClient : System.ServiceModel.ClientBase<Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract>, Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract {
        
        public SlideFileManagerServiceContractClient() {
        }
        
        public SlideFileManagerServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SlideFileManagerServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SlideFileManagerServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SlideFileManagerServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileResponseMessage Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract.GetSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileRequestMessage request) {
            return base.Channel.GetSlideFile(request);
        }
        
        public string GetSlideFile(string SlideID, out int SlideFileSize, out System.IO.Stream SlideFileStream) {
            Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileRequestMessage inValue = new Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileRequestMessage();
            inValue.SlideID = SlideID;
            Inspire.Server.Proxy.SlideFileServiceReference.GetSlideFileResponseMessage retVal = ((Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract)(this)).GetSlideFile(inValue);
            SlideFileSize = retVal.SlideFileSize;
            SlideFileStream = retVal.SlideFileStream;
            return retVal.SlideFileID;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileResponseMessage Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract.AddSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileRequestMessage request) {
            return base.Channel.AddSlideFile(request);
        }
        
        public void AddSlideFile(string SlideFileID, int SlideFileSize, System.IO.Stream SlideFileStream) {
            Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileRequestMessage inValue = new Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileRequestMessage();
            inValue.SlideFileID = SlideFileID;
            inValue.SlideFileSize = SlideFileSize;
            inValue.SlideFileStream = SlideFileStream;
            Inspire.Server.Proxy.SlideFileServiceReference.AddSlideFileResponseMessage retVal = ((Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract)(this)).AddSlideFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileResponseMessage Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract.UpdateSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileRequestMessage request) {
            return base.Channel.UpdateSlideFile(request);
        }
        
        public void UpdateSlideFile(string SlideFileID, int SlideFileSize, System.IO.Stream SlideFileStream) {
            Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileRequestMessage inValue = new Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileRequestMessage();
            inValue.SlideFileID = SlideFileID;
            inValue.SlideFileSize = SlideFileSize;
            inValue.SlideFileStream = SlideFileStream;
            Inspire.Server.Proxy.SlideFileServiceReference.UpdateSlideFileResponseMessage retVal = ((Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract)(this)).UpdateSlideFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileResponseMessage Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract.DeleteSlideFile(Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileRequestMessage request) {
            return base.Channel.DeleteSlideFile(request);
        }
        
        public void DeleteSlideFile(string SlideID) {
            Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileRequestMessage inValue = new Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileRequestMessage();
            inValue.SlideID = SlideID;
            Inspire.Server.Proxy.SlideFileServiceReference.DeleteSlideFileResponseMessage retVal = ((Inspire.Server.Proxy.SlideFileServiceReference.SlideFileManagerServiceContract)(this)).DeleteSlideFile(inValue);
        }
    }
}
