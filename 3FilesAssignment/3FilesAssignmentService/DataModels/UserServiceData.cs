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
    /// this is a separate implementation of the primary record.  The field names in the step 2 section differ and 
    /// this class allows for those differences.  Also when querying by name it needs to sort by the concatenated last name first name
    /// </summary>

    [DataContract]
    public class UserServiceData:UserData
    {
        [DataMember]
        public string gender { get { return Gender; } set { Gender = value; }}
        [DataMember]
        public string favoriteColor { get { return FavoriteColor; } set { favoriteColor = value; } }

        [DataMember]
        public DateTime birthdate
        {
            get
            {
                return DateOfBirth;
            }
            set { DateOfBirth = value; }
        }
        
    

        /// <summary>
        /// this is the lastname concatenated with the first name for use with the REST API
        /// </summary>
        [DataMember]
        public string name
        {
            get
            {
                return LastName + " " + FirstName;
            }
            set {

            }
        }

        



    }
}