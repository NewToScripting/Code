﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service.Client.SlideProxy
{
    using System.Runtime.Serialization;
    using System;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name = "Slides", Namespace = "http://schemas.inspiredisplays.com", ItemName = "Slides")]
    [System.SerializableAttribute()]
    public class Slides : System.Collections.Generic.List<Service.Client.SlideProxy.Slide>
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Slide", Namespace = "http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class Slide : object, System.Runtime.Serialization.IExtensibleDataObject
    {

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

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GUID
        {
            get
            {
                return this.GUIDField;
            }
            set
            {
                this.GUIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Source
        {
            get
            {
                return this.SourceField;
            }
            set
            {
                this.SourceField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Thumbnail
        {
            get
            {
                return this.ThumbnailField;
            }
            set
            {
                this.ThumbnailField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "DefaultFaultContract", Namespace = "http://schemas.inspiredisplays.com")]
    [System.SerializableAttribute()]
    public partial class DefaultFaultContract : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorDescField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorCode
        {
            get
            {
                return this.ErrorCodeField;
            }
            set
            {
                this.ErrorCodeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorDesc
        {
            get
            {
                return this.ErrorDescField;
            }
            set
            {
                this.ErrorDescField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://schemas.inspiredisplays.com", ConfigurationName = "Service.Client.SlideProxy.SlideManagerServiceContract")]
    public interface SlideManagerServiceContract
    {

        // CODEGEN: Generating message contract since the operation GetAllSlides is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlides", ReplyAction = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlidesRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(Service.Client.SlideProxy.DefaultFaultContract), Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/GetAllSlidesDefaul" +
            "tFaultContractFault", Name = "DefaultFaultContract")]
        Service.Client.SlideProxy.GetAllSlidesResponseMessage GetAllSlides(Service.Client.SlideProxy.GetAllSlidesRequestMessage request);

        // CODEGEN: Generating message contract since the operation AddSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlide", ReplyAction = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlideResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Service.Client.SlideProxy.DefaultFaultContract), Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/AddSlideDefaultFau" +
            "ltContractFault", Name = "DefaultFaultContract")]
        Service.Client.SlideProxy.AddSlideResponseMessage AddSlide(Service.Client.SlideProxy.AddSlideRequestMessage request);

        // CODEGEN: Generating message contract since the operation UpdateSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlide", ReplyAction = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlideRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(Service.Client.SlideProxy.DefaultFaultContract), Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/UpdateSlideDefault" +
            "FaultContractFault", Name = "DefaultFaultContract")]
        Service.Client.SlideProxy.UpdateSlideResponseMessage UpdateSlide(Service.Client.SlideProxy.UpdateSlideRequestMessage request);

        // CODEGEN: Generating message contract since the operation DeleteSlide is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlide", ReplyAction = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlideRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(Service.Client.SlideProxy.DefaultFaultContract), Action = "http://schemas.inspiredisplays.com/SlideManagerServiceContract/DeleteSlideDefault" +
            "FaultContractFault", Name = "DefaultFaultContract")]
        Service.Client.SlideProxy.DeleteSlideResponseMessage DeleteSlide(Service.Client.SlideProxy.DeleteSlideRequestMessage request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAllSlidesRequestMessage
    {

        public GetAllSlidesRequestMessage()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAllSlidesResponseMessage
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://schemas.inspiredisplays.com", Order = 0)]
        public Service.Client.SlideProxy.Slides Slides;

        public GetAllSlidesResponseMessage()
        {
        }

        public GetAllSlidesResponseMessage(Service.Client.SlideProxy.Slides Slides)
        {
            this.Slides = Slides;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddSlideRequestMessage
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://schemas.inspiredisplays.com", Order = 0)]
        public Service.Client.SlideProxy.Slide Slide;

        public AddSlideRequestMessage()
        {
        }

        public AddSlideRequestMessage(Service.Client.SlideProxy.Slide Slide)
        {
            this.Slide = Slide;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddSlideResponseMessage
    {

        public AddSlideResponseMessage()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateSlideRequestMessage
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://schemas.inspiredisplays.com", Order = 0)]
        public Service.Client.SlideProxy.Slide Slide;

        public UpdateSlideRequestMessage()
        {
        }

        public UpdateSlideRequestMessage(Service.Client.SlideProxy.Slide Slide)
        {
            this.Slide = Slide;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateSlideResponseMessage
    {

        public UpdateSlideResponseMessage()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteSlideRequestMessage
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://schemas.inspiredisplays.com", Order = 0)]
        public string SlideID;

        public DeleteSlideRequestMessage()
        {
        }

        public DeleteSlideRequestMessage(string SlideID)
        {
            this.SlideID = SlideID;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteSlideResponseMessage
    {

        public DeleteSlideResponseMessage()
        {
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface SlideManagerServiceContractChannel : Service.Client.SlideProxy.SlideManagerServiceContract, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SlideManagerServiceContractClient : System.ServiceModel.ClientBase<Service.Client.SlideProxy.SlideManagerServiceContract>, Service.Client.SlideProxy.SlideManagerServiceContract
    {

        public SlideManagerServiceContractClient()
        {
        }

        public SlideManagerServiceContractClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public SlideManagerServiceContractClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SlideManagerServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SlideManagerServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Service.Client.SlideProxy.GetAllSlidesResponseMessage Service.Client.SlideProxy.SlideManagerServiceContract.GetAllSlides(Service.Client.SlideProxy.GetAllSlidesRequestMessage request)
        {
            return base.Channel.GetAllSlides(request);
        }

        public Service.Client.SlideProxy.Slides GetAllSlides()
        {
            Service.Client.SlideProxy.GetAllSlidesRequestMessage inValue = new Service.Client.SlideProxy.GetAllSlidesRequestMessage();
            Service.Client.SlideProxy.GetAllSlidesResponseMessage retVal = ((Service.Client.SlideProxy.SlideManagerServiceContract)(this)).GetAllSlides(inValue);
            return retVal.Slides;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Service.Client.SlideProxy.AddSlideResponseMessage Service.Client.SlideProxy.SlideManagerServiceContract.AddSlide(Service.Client.SlideProxy.AddSlideRequestMessage request)
        {
            return base.Channel.AddSlide(request);
        }

        public void AddSlide(Service.Client.SlideProxy.Slide Slide)
        {
            Service.Client.SlideProxy.AddSlideRequestMessage inValue = new Service.Client.SlideProxy.AddSlideRequestMessage();
            inValue.Slide = Slide;
            Service.Client.SlideProxy.AddSlideResponseMessage retVal = ((Service.Client.SlideProxy.SlideManagerServiceContract)(this)).AddSlide(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Service.Client.SlideProxy.UpdateSlideResponseMessage Service.Client.SlideProxy.SlideManagerServiceContract.UpdateSlide(Service.Client.SlideProxy.UpdateSlideRequestMessage request)
        {
            return base.Channel.UpdateSlide(request);
        }

        public void UpdateSlide(Service.Client.SlideProxy.Slide Slide)
        {
            Service.Client.SlideProxy.UpdateSlideRequestMessage inValue = new Service.Client.SlideProxy.UpdateSlideRequestMessage();
            inValue.Slide = Slide;
            Service.Client.SlideProxy.UpdateSlideResponseMessage retVal = ((Service.Client.SlideProxy.SlideManagerServiceContract)(this)).UpdateSlide(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Service.Client.SlideProxy.DeleteSlideResponseMessage Service.Client.SlideProxy.SlideManagerServiceContract.DeleteSlide(Service.Client.SlideProxy.DeleteSlideRequestMessage request)
        {
            return base.Channel.DeleteSlide(request);
        }

        public void DeleteSlide(string SlideID)
        {
            Service.Client.SlideProxy.DeleteSlideRequestMessage inValue = new Service.Client.SlideProxy.DeleteSlideRequestMessage();
            inValue.SlideID = SlideID;
            Service.Client.SlideProxy.DeleteSlideResponseMessage retVal = ((Service.Client.SlideProxy.SlideManagerServiceContract)(this)).DeleteSlide(inValue);
        }
    }
}
