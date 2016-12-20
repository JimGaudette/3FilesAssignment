
using System;

namespace _3FilesAssignment.DataModels
{
    /// <summary>
    /// the user data is the representation of each file record in memory
    /// </summary>
    public class UserData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        /// <summary>
        /// this is a getter for lowercase gender for the rest API
        /// </summary>
        public string gender
        {
            get
            {
                return Gender;
            }
        }

        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth {
            get
            {
                return DateTime.Parse(sDateOfBirth);
            }
        }
        /// <summary>
        /// this is a lower case implementation of the DateOFBirth method for the REST API
        /// </summary>
        public DateTime birthdate
        {
            get
            {
                return DateOfBirth;
            }
        }

        /// <summary>
        /// this is the lastname concatenated with the first name for use with the REST API
        /// </summary>
        public string name
        {
            get
            {
                return LastName +" "+ FirstName;
            }
        }

        public string sDateOfBirth { get; set; }
        

    }
}
