﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Proxy.SlidesServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Slides", Namespace="http://schemas.inspiredisplays.com", ItemName="Slides")]
    [System.SerializableAttribute()]
    public class Slides : System.Collections.Generic.List<Server.Proxy.SlidesServiceReference.Slide> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Slide", Namespace="http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class Slide : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ThumbnailField;
        
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
        public string Source {
            get {
                return this.SourceField;
            }
            set {
                if ((object.ReferenceEquals(this.SourceField, value) != true)) {
                    this.SourceField = value;
                    this.RaisePropertyChanged("Source");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Thumbnail {
            get {
                return this.ThumbnailField;
            }
            set {
                if ((object.ReferenceEquals(this.ThumbnailField, value) != true)) {
                    this.ThumbnailField = value;
                    this.RaisePropertyChanged("Thumbnail");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DefaultFaultContract", Namespace="http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class DefaultFaultContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.inspiredisplays.com", ConfigurationName="SlidesServiceReference.SlideManagerServiceContract")]
    public interface SlideManagerServiceContract {
        
        // CODEGEN: Generating message contract since the operation GetAllSlides is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlides", ReplyAction="http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlidesRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(Server.Proxy.SlidesServiceReference.DefaultFaultContract), Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlidesDefaul" +
            "tFaultContractFault", Name="DefaultFaultContract")]
        Server.Proxy.SlidesServiceReference.GetAllSlidesResponseMessage GetAllSlides(Server.Proxy.SlidesServiceReference.GetAllSlidesRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlide", ReplyAction="http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlideResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Server.Proxy.SlidesServiceReference.DefaultFaultContract), Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlideDefaultFau" +
            "ltContractFault", Name="DefaultFaultContract")]
        Server.Proxy.SlidesServiceReference.AddSlideResponseMessage AddSlide(Server.Proxy.SlidesServiceReference.AddSlideRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation UpdateSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlide", ReplyAction="http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlideRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(Server.Proxy.SlidesServiceReference.DefaultFaultContract), Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlideDefault" +
            "FaultContractFault", Name="DefaultFaultContract")]
        Server.Proxy.SlidesServiceReference.UpdateSlideResponseMessage UpdateSlide(Server.Proxy.SlidesServiceReference.UpdateSlideRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlide", ReplyAction="http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlideRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(Server.Proxy.SlidesServiceReference.DefaultFaultContract), Action="http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlideDefault" +
            "FaultContractFault", Name="DefaultFaultContract")]
        Server.Proxy.SlidesServiceReference.DeleteSlideResponseMessage DeleteSlide(Server.Proxy.SlidesServiceReference.DeleteSlideRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllSlidesRequestMessage {
        
        public GetAllSlidesRequestMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllSlidesResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public Server.Proxy.SlidesServiceReference.Slides Slides;
        
        public GetAllSlidesResponseMessage() {
        }
        
        public GetAllSlidesResponseMessage(Server.Proxy.SlidesServiceReference.Slides Slides) {
            this.Slides = Slides;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSlideRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public Server.Proxy.SlidesServiceReference.Slide Slide;
        
        public AddSlideRequestMessage() {
        }
        
        public AddSlideRequestMessage(Server.Proxy.SlidesServiceReference.Slide Slide) {
            this.Slide = Slide;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSlideResponseMessage {
        
        public AddSlideResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSlideRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public Server.Proxy.SlidesServiceReference.Slide Slide;
        
        public UpdateSlideRequestMessage() {
        }
        
        public UpdateSlideRequestMessage(Server.Proxy.SlidesServiceReference.Slide Slide) {
            this.Slide = Slide;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateSlideResponseMessage {
        
        public UpdateSlideResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSlideRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string SlideID;
        
        public DeleteSlideRequestMessage() {
        }
        
        public DeleteSlideRequestMessage(string SlideID) {
            this.SlideID = SlideID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSlideResponseMessage {
        
        public DeleteSlideResponseMessage() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface SlideManagerServiceContractChannel : Server.Proxy.SlidesServiceReference.SlideManagerServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SlideManagerServiceContractClient : System.ServiceModel.ClientBase<Server.Proxy.SlidesServiceReference.SlideManagerServiceContract>, Server.Proxy.SlidesServiceReference.SlideManagerServiceContract {
        
        public SlideManagerServiceContractClient() {
        }
        
        public SlideManagerServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SlideManagerServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SlideManagerServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SlideManagerServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Server.Proxy.SlidesServiceReference.GetAllSlidesResponseMessage Server.Proxy.SlidesServiceReference.SlideManagerServiceContract.GetAllSlides(Server.Proxy.SlidesServiceReference.GetAllSlidesRequestMessage request) {
            return base.Channel.GetAllSlides(request);
        }
        
        public Server.Proxy.SlidesServiceReference.Slides GetAllSlides() {
            Server.Proxy.SlidesServiceReference.GetAllSlidesRequestMessage inValue = new Server.Proxy.SlidesServiceReference.GetAllSlidesRequestMessage();
            Server.Proxy.SlidesServiceReference.GetAllSlidesResponseMessage retVal = ((Server.Proxy.SlidesServiceReference.SlideManagerServiceContract)(this)).GetAllSlides(inValue);
            return retVal.Slides;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Server.Proxy.SlidesServiceReference.AddSlideResponseMessage Server.Proxy.SlidesServiceReference.SlideManagerServiceContract.AddSlide(Server.Proxy.SlidesServiceReference.AddSlideRequestMessage request) {
            return base.Channel.AddSlide(request);
        }
        
        public void AddSlide(Server.Proxy.SlidesServiceReference.Slide Slide) {
            Server.Proxy.SlidesServiceReference.AddSlideRequestMessage inValue = new Server.Proxy.SlidesServiceReference.AddSlideRequestMessage();
            inValue.Slide = Slide;
            Server.Proxy.SlidesServiceReference.AddSlideResponseMessage retVal = ((Server.Proxy.SlidesServiceReference.SlideManagerServiceContract)(this)).AddSlide(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Server.Proxy.SlidesServiceReference.UpdateSlideResponseMessage Server.Proxy.SlidesServiceReference.SlideManagerServiceContract.UpdateSlide(Server.Proxy.SlidesServiceReference.UpdateSlideRequestMessage request) {
            return base.Channel.UpdateSlide(request);
        }
        
        public void UpdateSlide(Server.Proxy.SlidesServiceReference.Slide Slide) {
            Server.Proxy.SlidesServiceReference.UpdateSlideRequestMessage inValue = new Server.Proxy.SlidesServiceReference.UpdateSlideRequestMessage();
            inValue.Slide = Slide;
            Server.Proxy.SlidesServiceReference.UpdateSlideResponseMessage retVal = ((Server.Proxy.SlidesServiceReference.SlideManagerServiceContract)(this)).UpdateSlide(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Server.Proxy.SlidesServiceReference.DeleteSlideResponseMessage Server.Proxy.SlidesServiceReference.SlideManagerServiceContract.DeleteSlide(Server.Proxy.SlidesServiceReference.DeleteSlideRequestMessage request) {
            return base.Channel.DeleteSlide(request);
        }
        
        public void DeleteSlide(string SlideID) {
            Server.Proxy.SlidesServiceReference.DeleteSlideRequestMessage inValue = new Server.Proxy.SlidesServiceReference.DeleteSlideRequestMessage();
            inValue.SlideID = SlideID;
            Server.Proxy.SlidesServiceReference.DeleteSlideResponseMessage retVal = ((Server.Proxy.SlidesServiceReference.SlideManagerServiceContract)(this)).DeleteSlide(inValue);
        }
    }
}
