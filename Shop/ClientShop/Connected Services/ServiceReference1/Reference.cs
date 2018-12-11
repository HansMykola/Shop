﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientShop.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServiceShop", CallbackContract=typeof(ClientShop.ServiceReference1.IServiceShopCallback))]
    public interface IServiceShop {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/Connect", ReplyAction="http://tempuri.org/IServiceShop/ConnectResponse")]
        int Connect(string nameShop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/Connect", ReplyAction="http://tempuri.org/IServiceShop/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string nameShop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/IsElements", ReplyAction="http://tempuri.org/IServiceShop/IsElementsResponse")]
        bool IsElements(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/IsElements", ReplyAction="http://tempuri.org/IServiceShop/IsElementsResponse")]
        System.Threading.Tasks.Task<bool> IsElementsAsync(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/UpdateAllDate")]
        void UpdateAllDate(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/UpdateAllDate")]
        System.Threading.Tasks.Task UpdateAllDateAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/SaveData")]
        void SaveData(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/SaveData")]
        System.Threading.Tasks.Task SaveDataAsync(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/SaveDataImage")]
        void SaveDataImage(string textCommand, byte[] image);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/SaveDataImage")]
        System.Threading.Tasks.Task SaveDataImageAsync(string textCommand, byte[] image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetListData", ReplyAction="http://tempuri.org/IServiceShop/GetListDataResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[][]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[][]))]
        object[] GetListData(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetListData", ReplyAction="http://tempuri.org/IServiceShop/GetListDataResponse")]
        System.Threading.Tasks.Task<object[]> GetListDataAsync(string textCommand);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetListChooseElem", ReplyAction="http://tempuri.org/IServiceShop/GetListChooseElemResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[][]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[][]))]
        object[][] GetListChooseElem(string textCommand, short number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetListChooseElem", ReplyAction="http://tempuri.org/IServiceShop/GetListChooseElemResponse")]
        System.Threading.Tasks.Task<object[][]> GetListChooseElemAsync(string textCommand, short number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetImageBytes", ReplyAction="http://tempuri.org/IServiceShop/GetImageBytesResponse")]
        byte[][] GetImageBytes(string comandSql);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceShop/GetImageBytes", ReplyAction="http://tempuri.org/IServiceShop/GetImageBytesResponse")]
        System.Threading.Tasks.Task<byte[][]> GetImageBytesAsync(string comandSql);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceShopCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceShop/CallBackUpdate")]
        void CallBackUpdate();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceShopChannel : ClientShop.ServiceReference1.IServiceShop, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceShopClient : System.ServiceModel.DuplexClientBase<ClientShop.ServiceReference1.IServiceShop>, ClientShop.ServiceReference1.IServiceShop {
        
        public ServiceShopClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceShopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceShopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceShopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceShopClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(string nameShop) {
            return base.Channel.Connect(nameShop);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string nameShop) {
            return base.Channel.ConnectAsync(nameShop);
        }
        
        public bool IsElements(string textCommand) {
            return base.Channel.IsElements(textCommand);
        }
        
        public System.Threading.Tasks.Task<bool> IsElementsAsync(string textCommand) {
            return base.Channel.IsElementsAsync(textCommand);
        }
        
        public void UpdateAllDate(string name) {
            base.Channel.UpdateAllDate(name);
        }
        
        public System.Threading.Tasks.Task UpdateAllDateAsync(string name) {
            return base.Channel.UpdateAllDateAsync(name);
        }
        
        public void SaveData(string textCommand) {
            base.Channel.SaveData(textCommand);
        }
        
        public System.Threading.Tasks.Task SaveDataAsync(string textCommand) {
            return base.Channel.SaveDataAsync(textCommand);
        }
        
        public void SaveDataImage(string textCommand, byte[] image) {
            base.Channel.SaveDataImage(textCommand, image);
        }
        
        public System.Threading.Tasks.Task SaveDataImageAsync(string textCommand, byte[] image) {
            return base.Channel.SaveDataImageAsync(textCommand, image);
        }
        
        public object[] GetListData(string textCommand) {
            return base.Channel.GetListData(textCommand);
        }
        
        public System.Threading.Tasks.Task<object[]> GetListDataAsync(string textCommand) {
            return base.Channel.GetListDataAsync(textCommand);
        }
        
        public object[][] GetListChooseElem(string textCommand, short number) {
            return base.Channel.GetListChooseElem(textCommand, number);
        }
        
        public System.Threading.Tasks.Task<object[][]> GetListChooseElemAsync(string textCommand, short number) {
            return base.Channel.GetListChooseElemAsync(textCommand, number);
        }
        
        public byte[][] GetImageBytes(string comandSql) {
            return base.Channel.GetImageBytes(comandSql);
        }
        
        public System.Threading.Tasks.Task<byte[][]> GetImageBytesAsync(string comandSql) {
            return base.Channel.GetImageBytesAsync(comandSql);
        }
    }
}
