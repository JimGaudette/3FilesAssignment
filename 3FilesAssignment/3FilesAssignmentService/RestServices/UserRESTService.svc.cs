using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Linq.Dynamic;
using FilesAssignmentService.DataModels;
using FilesAssignmentService.Repositorys;


namespace FilesAssignmentService.RestServices
{
    /// <summary>
    /// this class provides the REST API methods of access.  The description asks that the get requests provide the ability
    /// to specify sort field name on the requests.  The functionality for the dynamic sort based on parameter is provided by the 
    /// dynamic linq package from nuget.
    /// </summary>
    public class UserRESTService : IUserRESTService
    {
        public void AddRecord(string recordData)
        {
            UserDataRepository.Instance.AddRecord(recordData);
        }

        public List<UserServiceData> Getrecords(string fieldName){
            return UserDataRepository.Instance.userList.OrderBy(fieldName).ToList();

        }

    }
}
