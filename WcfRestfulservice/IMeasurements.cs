using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfRestfulservice
{
    [ServiceContract]
    public interface IMeasurements
    {

        // dette regex udtryk betyder bare at der ikke tillades mere end det antal digits der står i \\d{x}
        // dvs 2016-02-12 er gyldig, 
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "date/{time}")]
        Task<IQueryable<Measurement>> GetDateTask(string time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "measurements/")]
        IQueryable<Measurement> GetMeasurements();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "measurement/{id}")]
        Measurement GetMeasurement(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            // RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "measurement/{id}")]
        Measurement DeleteMeasurement(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "measurements/")]
        Measurement AddMeasurement(Measurement measurement);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "measurements/")]
        Measurement UpdateMeasurement(Measurement measurement);
    }
}
