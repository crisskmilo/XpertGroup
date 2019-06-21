using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http.Cors;

namespace WsService
{
    
    [DataContract]
    public class wsdata
    {
        [DataMember]
        public string data { get; set; }
    }

    [ServiceContract]
    public interface IWsXpertGroup
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/sumData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<string> SumData(wsdata wsdata);
    }
}
