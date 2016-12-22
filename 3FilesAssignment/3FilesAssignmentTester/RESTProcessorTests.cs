using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilesAssignmentService.Repositorys;
using FilesAssignment.OutputProcessor;


namespace FilesAssignmentTester
{
    [TestClass]
    public class RESTTests
    {




        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // this method is setting up some test files for the unit tests to use
            // it is setting up a test file for the ' ', ',', and '|' delimiters
 
            using (StreamWriter writer = File.CreateText("RESTTestsspaceFile.txt"))
            {
                writer.WriteLine("1gaudette james Male brown 04/25/1971");
                writer.WriteLine("2gaudette jimmy Male red 11/15/2012");
                writer.WriteLine("3gaudette pierce Male red 11/15/2012");
                writer.WriteLine("4gaudette kady Female red 11/15/2006");
            }

           

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // this method will remove the test files that were created for the testing 
            
            File.Delete("RESTTestsspaceFile.txt");
            
        }
        /// <summary>
        /// this method tests the REST API implementation by adding a record through the REST POST and then performs a get ordering the records by birthdate
        /// </summary>
        [TestMethod]
        public void RESTProcessorTests()
        {
            var userDataRepo = UserDataRepository.Instance;
            userDataRepo.AddFile("RESTTestsspaceFile.txt");


            var svrc = new FilesAssignmentService.RestServices.UserRESTService();
            svrc.AddRecord("111newRecord,kady,Female,red,11/15/2006");
            var rslt=svrc.Getrecords("name");

            Assert.AreEqual("111newRecord", rslt[0].LastName);








        }


    }
}
