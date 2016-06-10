using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfWebService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Option BlackScholesModel(double d1, double d2, Option option);
        [OperationContract]
        Option MonteCarloModel(Option option);
    }

    [DataContract]
    public class Option
    {
        [DataMember]
        public double UnderlyingPrice { get; set; }
        [DataMember]
        public double Strike { get; set; }
        [DataMember]
        public double RiskFreeInterestRate { get; set; }
        [DataMember]
        public double Maturity { get; set; }
        [DataMember]
        public double Volatility { get; set; }
        [DataMember]
        public int NbrOfSimulations { get; set; }
        [DataMember]
        public ErrorType Error { get; set; }
        [DataMember]
        public Price CallPrice { get; set; }
        [DataMember]
        public Price PutPrice { get; set; }
    }

    [DataContract]
    public class Price
    {
        [DataMember]
        public double? MC { get; set; }
        [DataMember]
        public double? BS { get; set; }

        public Price() { }
        public Price(double? mc, double? bs)
        {
            this.BS = bs;
            this.MC = mc;
        }
    }

    [DataContract]
    public class ErrorType
    {
        [DataMember]
        public double? Call { get; set; }
        [DataMember]
        public double? Put { get; set; }

        public ErrorType() { }
        public ErrorType(double? call, double? put)
        {
            this.Call = call;
            this.Put = put;
        }
    }
}
