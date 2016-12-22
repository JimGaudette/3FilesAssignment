using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FilesAssignmentService.DataModels
{
    /// <summary>
    /// the user data is the representation of each file record in memory
    /// </summary>
    /// 
    [DataContract]
    public class UserData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
     
    }
}
