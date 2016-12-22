using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilesAssignmentService.DataModels;

namespace FilesAssignmentService.Repositorys
{

    /// <summary>
    /// this class provides the project with methods of data access.  It provides methods to load the repository from files or from individual records
    /// it is set up to be a singleton instance allowing the data and changes to the data to be persisted across calls.  this must be taken into consideration 
    /// when unit testing.  for unit testing the singleton instance should be avoided when loading from test file sets.  Otherwise an object built for a separate 
    /// test will be evaluated and this will not provide accurate results.
    /// 
    /// 
    /// </summary>
    public partial class UserDataRepository
    {
        private static readonly UserDataRepository _instance = new UserDataRepository();

        private List<UserServiceData> _data;

        public UserDataRepository() { }
        public static UserDataRepository Instance
        {
            get { return _instance; }
        }
        
        public List<UserServiceData> userList
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<UserServiceData>();
                }
                return _data;
            }
        }

        public void AddFile(string fileName)
        {
            FileProcessor.AddFile(fileName,userList);                         
        }

        public void AddRecord(string recordData)
        {
            userList.Add(FileProcessor.ProcessLine(recordData,""));
        }


    }
}