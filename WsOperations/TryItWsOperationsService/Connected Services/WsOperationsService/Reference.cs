﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryItWsOperationsService.WsOperationsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsOperationsService.IWsOperationsService")]
    public interface IWsOperationsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsOperationsService/WsOperations", ReplyAction="http://tempuri.org/IWsOperationsService/WsOperationsResponse")]
        string[] WsOperations(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsOperationsService/WsOperations", ReplyAction="http://tempuri.org/IWsOperationsService/WsOperationsResponse")]
        System.Threading.Tasks.Task<string[]> WsOperationsAsync(string url);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWsOperationsServiceChannel : TryItWsOperationsService.WsOperationsService.IWsOperationsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsOperationsServiceClient : System.ServiceModel.ClientBase<TryItWsOperationsService.WsOperationsService.IWsOperationsService>, TryItWsOperationsService.WsOperationsService.IWsOperationsService {
        
        public WsOperationsServiceClient() {
        }
        
        public WsOperationsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsOperationsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsOperationsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsOperationsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] WsOperations(string url) {
            return base.Channel.WsOperations(url);
        }
        
        public System.Threading.Tasks.Task<string[]> WsOperationsAsync(string url) {
            return base.Channel.WsOperationsAsync(url);
        }
    }
}
