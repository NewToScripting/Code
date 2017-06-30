﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspire.Server.Proxy.DisplayAdminServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ServiceContract.InspireDisplays.com", ConfigurationName="DisplayAdminServiceReference1.DisplayAdminServiceContract")]
    public interface DisplayAdminServiceContract {
        
        // CODEGEN: Generating message contract since the operation CheckAndUpdateDisplays is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ServiceContract.InspireDisplays.com/DisplayAdminContract/CheckAndUpdateDis" +
            "playsRequest")]
        void CheckAndUpdateDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.CheckAndUpdateDisplaysRequest request);
        
        // CODEGEN: Generating message contract since the operation UpdateDisplays is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ServiceContract.InspireDisplays.com/DisplayAdminServiceContract/UpdateDisp" +
            "laysRequest")]
        void UpdateDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.UpdateDisplaysRequest request);
        
        // CODEGEN: Generating message contract since the operation PingDisplays is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ServiceContract.InspireDisplays.com/DisplayAdminServiceContract/PingDispla" +
            "ys")]
        void PingDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.PingDisplaysRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckAndUpdateDisplaysRequest {
        
        public CheckAndUpdateDisplaysRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateDisplaysRequest {
        
        public UpdateDisplaysRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PingDisplaysRequest {
        
        public PingDisplaysRequest() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DisplayAdminServiceContractChannel : Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DisplayAdminServiceContractClient : System.ServiceModel.ClientBase<Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract>, Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract {
        
        public DisplayAdminServiceContractClient() {
        }
        
        public DisplayAdminServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DisplayAdminServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DisplayAdminServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DisplayAdminServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract.CheckAndUpdateDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.CheckAndUpdateDisplaysRequest request) {
            base.Channel.CheckAndUpdateDisplays(request);
        }
        
        public void CheckAndUpdateDisplays() {
            Inspire.Server.Proxy.DisplayAdminServiceReference1.CheckAndUpdateDisplaysRequest inValue = new Inspire.Server.Proxy.DisplayAdminServiceReference1.CheckAndUpdateDisplaysRequest();
            ((Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract)(this)).CheckAndUpdateDisplays(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract.UpdateDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.UpdateDisplaysRequest request) {
            base.Channel.UpdateDisplays(request);
        }
        
        public void UpdateDisplays() {
            Inspire.Server.Proxy.DisplayAdminServiceReference1.UpdateDisplaysRequest inValue = new Inspire.Server.Proxy.DisplayAdminServiceReference1.UpdateDisplaysRequest();
            ((Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract)(this)).UpdateDisplays(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract.PingDisplays(Inspire.Server.Proxy.DisplayAdminServiceReference1.PingDisplaysRequest request) {
            base.Channel.PingDisplays(request);
        }
        
        public void PingDisplays() {
            Inspire.Server.Proxy.DisplayAdminServiceReference1.PingDisplaysRequest inValue = new Inspire.Server.Proxy.DisplayAdminServiceReference1.PingDisplaysRequest();
            ((Inspire.Server.Proxy.DisplayAdminServiceReference1.DisplayAdminServiceContract)(this)).PingDisplays(inValue);
        }
    }
}