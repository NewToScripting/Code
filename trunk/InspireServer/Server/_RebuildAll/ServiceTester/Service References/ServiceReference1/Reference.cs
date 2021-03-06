﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceTester.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.inspiredisplays.com", ConfigurationName="ServiceReference1.SettingServiceContract")]
    public interface SettingServiceContract {
        
        // CODEGEN: Generating message contract since the operation GetSetting is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/UserServiceContract/GetSetting", ReplyAction="http://schemas.inspiredisplays.com/SettingServiceContract/GetSettingResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SettingServiceContract/GetSettingGeneralFaultC" +
            "ontractFault", Name="GeneralFaultContract")]
        ServiceTester.ServiceReference1.GetSettingsResponseMessage GetSetting(ServiceTester.ServiceReference1.GetSettingsRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation AddSetting is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/UserServiceContract/AddSetting", ReplyAction="http://schemas.inspiredisplays.com/SettingServiceContract/AddSettingResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SettingServiceContract/AddSettingGeneralFaultC" +
            "ontractFault", Name="GeneralFaultContract")]
        ServiceTester.ServiceReference1.AddSettingResponseMessage AddSetting(ServiceTester.ServiceReference1.AddSettingRequestMessage request);
        
        // CODEGEN: Generating message contract since the operation DeleteSetting is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.inspiredisplays.com/UserServiceContract/DeleteSetting", ReplyAction="http://schemas.inspiredisplays.com/SettingServiceContract/DeleteSettingResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inspire.Server.Common.FaultContracts.GeneralFaultContract), Action="http://schemas.inspiredisplays.com/SettingServiceContract/DeleteSettingGeneralFau" +
            "ltContractFault", Name="GeneralFaultContract")]
        ServiceTester.ServiceReference1.DeleteSettingResponseMessage DeleteSetting(ServiceTester.ServiceReference1.DeleteSettingRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSettingsRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string Key;
        
        public GetSettingsRequestMessage() {
        }
        
        public GetSettingsRequestMessage(string Key) {
            this.Key = Key;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSettingsResponseMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public Inspire.Settings.DataContracts.Setting Setting;
        
        public GetSettingsResponseMessage() {
        }
        
        public GetSettingsResponseMessage(Inspire.Settings.DataContracts.Setting Setting) {
            this.Setting = Setting;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSettingRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public Inspire.Settings.DataContracts.Setting Setting;
        
        public AddSettingRequestMessage() {
        }
        
        public AddSettingRequestMessage(Inspire.Settings.DataContracts.Setting Setting) {
            this.Setting = Setting;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddSettingResponseMessage {
        
        public AddSettingResponseMessage() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSettingRequestMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.inspiredisplays.com", Order=0)]
        public string Key;
        
        public DeleteSettingRequestMessage() {
        }
        
        public DeleteSettingRequestMessage(string Key) {
            this.Key = Key;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteSettingResponseMessage {
        
        public DeleteSettingResponseMessage() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SettingServiceContractChannel : ServiceTester.ServiceReference1.SettingServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SettingServiceContractClient : System.ServiceModel.ClientBase<ServiceTester.ServiceReference1.SettingServiceContract>, ServiceTester.ServiceReference1.SettingServiceContract {
        
        public SettingServiceContractClient() {
        }
        
        public SettingServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SettingServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceTester.ServiceReference1.GetSettingsResponseMessage ServiceTester.ServiceReference1.SettingServiceContract.GetSetting(ServiceTester.ServiceReference1.GetSettingsRequestMessage request) {
            return base.Channel.GetSetting(request);
        }
        
        public Inspire.Settings.DataContracts.Setting GetSetting(string Key) {
            ServiceTester.ServiceReference1.GetSettingsRequestMessage inValue = new ServiceTester.ServiceReference1.GetSettingsRequestMessage();
            inValue.Key = Key;
            ServiceTester.ServiceReference1.GetSettingsResponseMessage retVal = ((ServiceTester.ServiceReference1.SettingServiceContract)(this)).GetSetting(inValue);
            return retVal.Setting;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceTester.ServiceReference1.AddSettingResponseMessage ServiceTester.ServiceReference1.SettingServiceContract.AddSetting(ServiceTester.ServiceReference1.AddSettingRequestMessage request) {
            return base.Channel.AddSetting(request);
        }
        
        public void AddSetting(Inspire.Settings.DataContracts.Setting Setting) {
            ServiceTester.ServiceReference1.AddSettingRequestMessage inValue = new ServiceTester.ServiceReference1.AddSettingRequestMessage();
            inValue.Setting = Setting;
            ServiceTester.ServiceReference1.AddSettingResponseMessage retVal = ((ServiceTester.ServiceReference1.SettingServiceContract)(this)).AddSetting(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceTester.ServiceReference1.DeleteSettingResponseMessage ServiceTester.ServiceReference1.SettingServiceContract.DeleteSetting(ServiceTester.ServiceReference1.DeleteSettingRequestMessage request) {
            return base.Channel.DeleteSetting(request);
        }
        
        public void DeleteSetting(string Key) {
            ServiceTester.ServiceReference1.DeleteSettingRequestMessage inValue = new ServiceTester.ServiceReference1.DeleteSettingRequestMessage();
            inValue.Key = Key;
            ServiceTester.ServiceReference1.DeleteSettingResponseMessage retVal = ((ServiceTester.ServiceReference1.SettingServiceContract)(this)).DeleteSetting(inValue);
        }
    }
}
