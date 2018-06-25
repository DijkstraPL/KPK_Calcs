using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using TestData.MyRef;

namespace TestData
{
    public class ServiceRestClient
    {
        const string ServiceUrlBase = "http://localhost:5460";
        const string ServiceUrlRest = "/Service.svc/v1/MaterialWeights";

        public string ServiceUrl { get; private set; }

        public ServiceRestClient()
        {
            ServiceUrl = ServiceUrlBase + ServiceUrlRest;
        }

        public ServiceRestClient(string urlHostPort)
        {
            ServiceUrl = urlHostPort + ServiceUrlRest;
        }

        public MaterialWeight[] GetMaterialWeights()
        {
            WebRequest request = WebRequest.Create(ServiceUrl);
            WebResponse response = request.GetResponse();
            DataContractSerializer serializer =
                new DataContractSerializer(typeof(MaterialWeight[]));
            var result = serializer.ReadObject(response.GetResponseStream());
            return result as MaterialWeight[];
        }

        public MaterialWeight[] GetMaterialWeightsJson()
        {
            WebRequest request = WebRequest.Create(ServiceUrl);
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof(MaterialWeight[]));
            var result = serializer.ReadObject(response.GetResponseStream());
            return result as MaterialWeight[];
        }


    }

}
