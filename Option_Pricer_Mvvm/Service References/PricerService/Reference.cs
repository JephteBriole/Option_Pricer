﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Option_Pricer_Mvvm.PricerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Option", Namespace="http://schemas.datacontract.org/2004/07/WcfWebService")]
    [System.SerializableAttribute()]
    public partial class Option : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Option_Pricer_Mvvm.PricerService.Price CallPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Option_Pricer_Mvvm.PricerService.ErrorType ErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MaturityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NbrOfSimulationsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Option_Pricer_Mvvm.PricerService.Price PutPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double RiskFreeInterestRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double StrikeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double UnderlyingPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double VolatilityField;
        
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
        public Option_Pricer_Mvvm.PricerService.Price CallPrice {
            get {
                return this.CallPriceField;
            }
            set {
                if ((object.ReferenceEquals(this.CallPriceField, value) != true)) {
                    this.CallPriceField = value;
                    this.RaisePropertyChanged("CallPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Option_Pricer_Mvvm.PricerService.ErrorType Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorField, value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Maturity {
            get {
                return this.MaturityField;
            }
            set {
                if ((this.MaturityField.Equals(value) != true)) {
                    this.MaturityField = value;
                    this.RaisePropertyChanged("Maturity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NbrOfSimulations {
            get {
                return this.NbrOfSimulationsField;
            }
            set {
                if ((this.NbrOfSimulationsField.Equals(value) != true)) {
                    this.NbrOfSimulationsField = value;
                    this.RaisePropertyChanged("NbrOfSimulations");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Option_Pricer_Mvvm.PricerService.Price PutPrice {
            get {
                return this.PutPriceField;
            }
            set {
                if ((object.ReferenceEquals(this.PutPriceField, value) != true)) {
                    this.PutPriceField = value;
                    this.RaisePropertyChanged("PutPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RiskFreeInterestRate {
            get {
                return this.RiskFreeInterestRateField;
            }
            set {
                if ((this.RiskFreeInterestRateField.Equals(value) != true)) {
                    this.RiskFreeInterestRateField = value;
                    this.RaisePropertyChanged("RiskFreeInterestRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Strike {
            get {
                return this.StrikeField;
            }
            set {
                if ((this.StrikeField.Equals(value) != true)) {
                    this.StrikeField = value;
                    this.RaisePropertyChanged("Strike");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double UnderlyingPrice {
            get {
                return this.UnderlyingPriceField;
            }
            set {
                if ((this.UnderlyingPriceField.Equals(value) != true)) {
                    this.UnderlyingPriceField = value;
                    this.RaisePropertyChanged("UnderlyingPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Volatility {
            get {
                return this.VolatilityField;
            }
            set {
                if ((this.VolatilityField.Equals(value) != true)) {
                    this.VolatilityField = value;
                    this.RaisePropertyChanged("Volatility");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Price", Namespace="http://schemas.datacontract.org/2004/07/WcfWebService")]
    [System.SerializableAttribute()]
    public partial class Price : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> BSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> MCField;
        
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
        public System.Nullable<double> BS {
            get {
                return this.BSField;
            }
            set {
                if ((this.BSField.Equals(value) != true)) {
                    this.BSField = value;
                    this.RaisePropertyChanged("BS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> MC {
            get {
                return this.MCField;
            }
            set {
                if ((this.MCField.Equals(value) != true)) {
                    this.MCField = value;
                    this.RaisePropertyChanged("MC");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ErrorType", Namespace="http://schemas.datacontract.org/2004/07/WcfWebService")]
    [System.SerializableAttribute()]
    public partial class ErrorType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> CallField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> PutField;
        
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
        public System.Nullable<double> Call {
            get {
                return this.CallField;
            }
            set {
                if ((this.CallField.Equals(value) != true)) {
                    this.CallField = value;
                    this.RaisePropertyChanged("Call");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> Put {
            get {
                return this.PutField;
            }
            set {
                if ((this.PutField.Equals(value) != true)) {
                    this.PutField = value;
                    this.RaisePropertyChanged("Put");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PricerService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BlackScholesModel", ReplyAction="http://tempuri.org/IService/BlackScholesModelResponse")]
        Option_Pricer_Mvvm.PricerService.Option BlackScholesModel(double d1, double d2, Option_Pricer_Mvvm.PricerService.Option option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BlackScholesModel", ReplyAction="http://tempuri.org/IService/BlackScholesModelResponse")]
        System.Threading.Tasks.Task<Option_Pricer_Mvvm.PricerService.Option> BlackScholesModelAsync(double d1, double d2, Option_Pricer_Mvvm.PricerService.Option option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MonteCarloModel", ReplyAction="http://tempuri.org/IService/MonteCarloModelResponse")]
        Option_Pricer_Mvvm.PricerService.Option MonteCarloModel(Option_Pricer_Mvvm.PricerService.Option option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MonteCarloModel", ReplyAction="http://tempuri.org/IService/MonteCarloModelResponse")]
        System.Threading.Tasks.Task<Option_Pricer_Mvvm.PricerService.Option> MonteCarloModelAsync(Option_Pricer_Mvvm.PricerService.Option option);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Option_Pricer_Mvvm.PricerService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Option_Pricer_Mvvm.PricerService.IService>, Option_Pricer_Mvvm.PricerService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Option_Pricer_Mvvm.PricerService.Option BlackScholesModel(double d1, double d2, Option_Pricer_Mvvm.PricerService.Option option) {
            return base.Channel.BlackScholesModel(d1, d2, option);
        }
        
        public System.Threading.Tasks.Task<Option_Pricer_Mvvm.PricerService.Option> BlackScholesModelAsync(double d1, double d2, Option_Pricer_Mvvm.PricerService.Option option) {
            return base.Channel.BlackScholesModelAsync(d1, d2, option);
        }
        
        public Option_Pricer_Mvvm.PricerService.Option MonteCarloModel(Option_Pricer_Mvvm.PricerService.Option option) {
            return base.Channel.MonteCarloModel(option);
        }
        
        public System.Threading.Tasks.Task<Option_Pricer_Mvvm.PricerService.Option> MonteCarloModelAsync(Option_Pricer_Mvvm.PricerService.Option option) {
            return base.Channel.MonteCarloModelAsync(option);
        }
    }
}
