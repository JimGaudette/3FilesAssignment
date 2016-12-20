
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
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth {
            get
            {
                return DateTime.Parse(sDateOfBirth);
            }
        }
        public string sDateOfBirth { get; set; }
        

    }
}
