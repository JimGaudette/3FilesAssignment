using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3FilesAssignment;


namespace _3FilesAssignmentTester
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
                writer.WriteLine("gaudette james Male brown 04/25/1971");
                writer.WriteLine("gaudette jimmy Male red 11/15/2012");
                writer.WriteLine("gaudette pierce Male red 11/15/2012");
            }

            using (StreamWriter writer = File.CreateText("FileProcessorTestscommaFile.txt"))
            {
                writer.WriteLine("gaudette,james,Male,brown,04/25/1971");
                writer.WriteLine("gaudette,jimmy,Male,red,11/15/2012");
                writer.WriteLine("gaudette,pierce,Male,red,11/15/2012");
            }



            using (StreamWriter writer = File.CreateText("FileProcessorTestspipeFile.txt"))
            {
                writer.WriteLine("gaudette|james|Male|brown|04/25/1971");
                writer.WriteLine("gaudette|jimmy|Male|red|11/15/2012");
                writer.WriteLine("gaudette|pierce|Male|red|11/15/2012");
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
            var myfileProcessor = new FileProcessor("FileProcessorTestsspaceFile.txt");
            myfileProcessor.DetermineParseCharacter();

            Assert.AreEqual(myfileProcessor.ParseCharacter,' ');

            myfileProcessor = new FileProcessor("FileProcessorTestscommaFile.txt");
            myfileProcessor.DetermineParseCharacter();

            Assert.AreEqual(myfileProcessor.ParseCharacter, ',');

            myfileProcessor = new FileProcessor("FileProcessorTestspipeFile.txt");
            myfileProcessor.DetermineParseCharacter();

            Assert.AreEqual(myfileProcessor.ParseCharacter, '|');

        }


        [TestMethod]
        public void ParseFileTests()
        {
            var myfileProcessor = new FileProcessor("FileProcessorTestsspaceFile.txt");
            var myData=myfileProcessor.ProcessFile();
            
            Assert.AreEqual(myData[2].FirstName, "pierce");




        }
    }
}
