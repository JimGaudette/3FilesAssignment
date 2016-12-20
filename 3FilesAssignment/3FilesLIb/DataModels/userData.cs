
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

        public DateTime birthdate
        {
            get
            {
                return DateTime.Parse(sDateOfBirth);
            }
        }

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
