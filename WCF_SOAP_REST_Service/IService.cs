using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_SOAP_REST_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        //[WebGet(UriTemplate = "/Employees", ResponseFormat = WebMessageFormat.Xml)]
        //[WebGet(UriTemplate = "/Employees", ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "/MaterialWeights")]
        MaterialWeight[] GetMaterialWeights();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/MaterialWeights")]
        int InsertMaterialWeight(MaterialWeight materialWeight);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/MaterialWeights?id={matweightno}")]
        MaterialWeight SelectMaterialWeight(int matWeightNo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/MaterialWeights?id={matweightno}")]
        int UpdateMaterialWeight(int matWeightNo, MaterialWeight materialWeight);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/MaterialWeights?id={matweightno}")]
        int DeleteMaterialWeight(int matWeightNo);

    }

    [DataContract]
    public class MaterialWeight
    {
        [DataMember]
        public int MatWeightNo { get; set; }
        [DataMember]
        public string MaterialName { get; set; }
        [DataMember]
        public double MinimumWeight { get; set; }
        [DataMember]
        public double MaximumWeight { get; set; }
    }

}
