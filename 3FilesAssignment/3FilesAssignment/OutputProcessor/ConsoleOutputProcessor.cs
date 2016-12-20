
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _3FilesAssignment.DataModels;
using System.Data;


namespace _3FilesAssignment
{
   

    public class ConsoleOutputProcessor
    {

        private IList<UserData> _data;
        public ConsoleOutputProcessor(IList<UserData> data)
        {
            _data = data;
        }


        public IList<UserData> ArrangeDataforOutput1()
        {

            return _data.OrderBy(u => u.Gender).ThenBy(u => u.LastName).ToList();
            
        }

        public IList<UserData> ArrangeDataforOutput2()
        {

            return _data.OrderBy(u => u.DateOfBirth).ToList();

        }


        public IList<UserData> ArrangeDataforOutput3()
        {

            return _data.OrderByDescending(u => u.LastName).ToList();

        }


        public void logData(IList<UserData> userData)
        {

            foreach (var user in userData)
            {
                string.Format("{0}; {1}; {2}; {3}; {4}; {5};", user.LastName, user.FirstName, user.Gender,user.FavoriteColor,user.DateOfBirth.ToString("d"));


            }

        }



    }
}