using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3FilesAssignment;


namespace _3FilesAssignmentTester
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
            var myfileProcessor = new FileProcessor();
            myfileProcessor.AddFile("RESTTestsspaceFile.txt");
            
            var restProcessor = new RESTProcessor(myfileProcessor._dataList);

            restProcessor.ProcessRESTString("POST /records 7gaudette DADDY male red 11/15/1971");

            var rtrn=restProcessor.ProcessRESTString("GET /records/birthdate");

            var outputCheck=
            "[{\"LastName\":\"1gaudette\",\"FirstName\":\"james\",\"Gender\":\"Male\",\"gender\":\"Male\",\"FavoriteColor\":\"brown\",\"DateOfBirth\":\"1971-04-25T00:00:00\",\"birthdate\":\"1971-04-25T00:00:00\",\"name\":\"1gaudette james\",\"sDateOfBirth\":\"04/25/1971\"},{\"LastName\":\"7gaudette\",\"FirstName\":\"DADDY\",\"Gender\":\"male\",\"gender\":\"male\",\"FavoriteColor\":\"red\",\"DateOfBirth\":\"1971-11-15T00:00:00\",\"birthdate\":\"1971-11-15T00:00:00\",\"name\":\"7gaudette DADDY\",\"sDateOfBirth\":\"11/15/1971\"},{\"LastName\":\"4gaudette\",\"FirstName\":\"kady\",\"Gender\":\"Female\",\"gender\":\"Female\",\"FavoriteColor\":\"red\",\"DateOfBirth\":\"2006-11-15T00:00:00\",\"birthdate\":\"2006-11-15T00:00:00\",\"name\":\"4gaudette kady\",\"sDateOfBirth\":\"11/15/2006\"},{\"LastName\":\"2gaudette\",\"FirstName\":\"jimmy\",\"Gender\":\"Male\",\"gender\":\"Male\",\"FavoriteColor\":\"red\",\"DateOfBirth\":\"2012-11-15T00:00:00\",\"birthdate\":\"2012-11-15T00:00:00\",\"name\":\"2gaudette jimmy\",\"sDateOfBirth\":\"11/15/2012\"},{\"LastName\":\"3gaudette\",\"FirstName\":\"pierce\",\"Gender\":\"Male\",\"gender\":\"Male\",\"FavoriteColor\":\"red\",\"DateOfBirth\":\"2012-11-15T00:00:00\",\"birthdate\":\"2012-11-15T00:00:00\",\"name\":\"3gaudette pierce\",\"sDateOfBirth\":\"11/15/2012\"}]";
            
            Assert.AreEqual(rtrn, outputCheck);










        }


    }
}
