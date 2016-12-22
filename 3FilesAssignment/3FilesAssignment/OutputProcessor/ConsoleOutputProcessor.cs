
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using FilesAssignmentService.DataModels;
using FilesAssignmentService.Repositorys;

namespace FilesAssignment.OutputProcessor
{
   
    /// <summary>
    /// this class arranges the data in three different views and writes each of those views to the console out
    /// </summary>
    public class ConsoleOutputProcessor
    {

        private IList<UserServiceData> _data;
        public ConsoleOutputProcessor(UserDataRepository userRepo)
        {
            _data = userRepo.userList;
        }

        /// <summary>
        /// this method returns data that is sorted by gender and then by last name
        /// </summary>
        /// <returns></returns>
        public IList<UserServiceData> ArrangeDataforOutput1()
        {

            return _data.OrderBy(u => u.Gender).ThenBy(u => u.LastName).ToList();
            
        }


        /// <summary>
        /// this method returns data that is sorted by birthday 
        /// </summary>
        /// <returns></returns>
        public IList<UserServiceData> ArrangeDataforOutput2()
        {

            return _data.OrderBy(u => u.DateOfBirth).ToList();

        }

        /// <summary>
        /// this method returns data that is descending by last name
        /// </summary>
        /// <returns></returns>
        public IList<UserServiceData> ArrangeDataforOutput3()
        {

            return _data.OrderByDescending(u => u.LastName).ToList();

        }

        /// <summary>
        /// this is a generic method to log the data list to the console
        /// </summary>
        /// <param name="userData"></param>
        public void logData(IList<UserServiceData> userData)
        {
            foreach (var user in userData)
            {
                Console.WriteLine(string.Format("{0,20}; {1,20}; {2,8}; {3};\t {4}; ", user.LastName, user.FirstName, user.Gender,user.FavoriteColor,user.DateOfBirth.ToString("d")));                
            }
        }
        public void processOutput()
        {
            Console.WriteLine("Data sorted by gender then by last name:");
            logData(ArrangeDataforOutput1());
            Console.WriteLine();
            Console.WriteLine("Data sorted by date of birth:");
            logData(ArrangeDataforOutput2());
            Console.WriteLine();
            Console.WriteLine("Data sorted by last name descending:");
            logData(ArrangeDataforOutput3());
            Console.WriteLine();

        }



    }
}