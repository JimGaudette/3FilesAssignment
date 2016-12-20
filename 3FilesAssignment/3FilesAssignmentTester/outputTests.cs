using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3FilesAssignment;


namespace _3FilesAssignmentTester
{
    [TestClass]
    public class OutputTests
    {




        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // this method is setting up some test files for the unit tests to use
            // it is setting up a test file for the ' ', ',', and '|' delimiters
 
            using (StreamWriter writer = File.CreateText("OutputTestsspaceFile.txt"))
            {
                writer.WriteLine("1gaudette james Male brown 04/25/1971");
                writer.WriteLine("2gaudette jimmy Male red 11/15/2012");
                writer.WriteLine("3gaudette pierce Male red 11/15/2012");
                writer.WriteLine("4gaudette kady Female red 11/15/2006");
            }

            using (StreamWriter writer = File.CreateText("OutputTestscommaFile.txt"))
            {
                writer.WriteLine("1gaudette,james,Male,brown,04/25/1971");
                writer.WriteLine("2gaudette,jimmy,Male,red,11/15/2012");
                writer.WriteLine("3gaudette,pierce,Male,red,11/15/2012");
                writer.WriteLine("4gaudette,kady,Female,red,11/15/2006");
            }



            using (StreamWriter writer = File.CreateText("OutputTestspipeFile.txt"))
            {
                writer.WriteLine("1gaudette|james|Male|brown|04/25/1971");
                writer.WriteLine("2gaudette|jimmy|Male|red|11/15/2012");
                writer.WriteLine("3gaudette|pierce|Male|red|11/15/2012");
                writer.WriteLine("4gaudette|kady|Female|red|11/15/2006");
            }

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // this method will remove the test files that were created for the testing 
            
            File.Delete("OutputTestsspaceFile.txt");
            File.Delete("OutputTestscommaFile.txt");
            File.Delete("OutputTestspipeFile.txt");
        }
        [TestMethod]
        public void OutputConsoleTests()
        {
            var myData = new FileProcessor("OutputTestscommaFile.txt").ProcessFile();

            var outProcessor = new ConsoleOutputProcessor(myData);

            // test for females first and last name acending
            var out1Data=outProcessor.ArrangeDataforOutput1();

            Assert.AreEqual(out1Data[0].Gender, "female");
            Assert.AreEqual(out1Data[1].LastName, "1gaudette");

            // test for sorted by birthday 
            var out2Data = outProcessor.ArrangeDataforOutput2();

            Assert.AreEqual(out2Data[1].FirstName, "kady");

            // test for sorted by last name descending 
            var out3Data = outProcessor.ArrangeDataforOutput3();

            Assert.AreEqual(out3Data[0].LastName, "4gaudette");










        }


    }
}
