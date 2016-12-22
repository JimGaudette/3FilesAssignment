using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilesAssignmentService.Repositorys;
using FilesAssignment.OutputProcessor;


namespace FilesAssignmentTester
{
    [TestClass]
    public class FileProcessorTests
    {




        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // this method is setting up some test files for the unit tests to use
            // it is setting up a test file for the ' ', ',', and '|' delimiters
 
            using (StreamWriter writer = File.CreateText("FileProcessorTestsspaceFile.txt"))
            {
                writer.WriteLine("FP1gaudette james Male brown 04/25/1971");
                writer.WriteLine("FP1gaudette jimmy Male red 11/15/2012");
                writer.WriteLine("FP1gaudette pierce Male red 11/15/2012");
                writer.WriteLine("FP1gaudette kady female red 11/15/2012");
            }

            using (StreamWriter writer = File.CreateText("FileProcessorTestscommaFile.txt"))
            {
                writer.WriteLine("FP2gaudette,james,Male,brown,04/25/1971");
                writer.WriteLine("FP2gaudette,jimmy,Male,red,11/15/2012");
                writer.WriteLine("FP2gaudette,pierce,Male,red,11/15/2012");
                writer.WriteLine("FP2gaudette,kady,female,red,11/15/2012");
            }



            using (StreamWriter writer = File.CreateText("FileProcessorTestspipeFile.txt"))
            {
                writer.WriteLine("FP3gaudette|james|Male|brown|04/25/1971");
                writer.WriteLine("FP3gaudette|jimmy|Male|red|11/15/2012");
                writer.WriteLine("FP3gaudette|pierce|Male|red|11/15/2012");
                writer.WriteLine("FP3gaudette|kady|female|red|11/15/2012");
            }

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // this method will remove the test files that were created for the testing 
            
            File.Delete("FileProcessorTestsspaceFile.txt");
            File.Delete("FileProcessorTestscommaFile.txt");
            File.Delete("FileProcessorTestspipeFile.txt");
        }
        [TestMethod]
        public void ParseCharacterIdentificationTests()
        {
            
            var parseChar= FileProcessor.DetermineParseCharacter("FileProcessorTestsspaceFile.txt");
            Assert.AreEqual(parseChar, " ");

            parseChar = FileProcessor.DetermineParseCharacter("FileProcessorTestscommaFile.txt");
            Assert.AreEqual(parseChar, ",");

            parseChar = FileProcessor.DetermineParseCharacter("FileProcessorTestspipeFile.txt");
            Assert.AreEqual(parseChar, "|");

            parseChar = FileProcessor.DetermineParseCharacterforLine("FP3gaudette|kady|female|red|11/15/2012");
            Assert.AreEqual(parseChar, "|");

        }


        [TestMethod]
        public void ParseFileTests()
        {
            var userDataRepo = new UserDataRepository();
            userDataRepo.AddFile("FileProcessorTestsspaceFile.txt");
            userDataRepo.AddFile("FileProcessorTestscommaFile.txt");
            userDataRepo.AddFile("FileProcessorTestspipeFile.txt");


            Assert.AreEqual("FP1gaudette", userDataRepo.userList[2].LastName);
            Assert.AreEqual(12, userDataRepo.userList.Count);




        }
    }
}
