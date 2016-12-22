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
