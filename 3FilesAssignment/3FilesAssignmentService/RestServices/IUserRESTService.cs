using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FilesAssignmentService.DataModels;

namespace FilesAssignmentService.RestServices
{
    [ServiceContract]
    public interface IUserRESTService
    {                
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "records/{fieldName}")]
        List<UserServiceData> Getrecords(string fieldName);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "records/")]
        void AddRecord(string recordData);


    }

    
}
