using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilesAssignmentService.DataModels;

namespace FilesAssignmentService.Repositorys
{
    public partial class UserDataRepository
    {
        private static readonly UserDataRepository _instance = new UserDataRepository();

        public UserDataRepository() { }
        public static UserDataRepository Instance
        {
            get { return _instance; }
        }

        

        private List<UserServiceData> _data;


        public List<UserServiceData> userList
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<UserServiceData>();
                    //{            new UserServiceData { FirstName="pierce",LastName="1gaudette",gender="male",DateOfBirth=DateTime.Parse("11/15/2012"),FavoriteColor="blue" },            //new UserServiceData { FirstName="jimmy",LastName="g",gender="male",DateOfBirth=DateTime.Parse("04/25/1971"),FavoriteColor="red" } };               }

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