using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilesAssignmentService.Repositorys;
using FilesAssignment.OutputProcessor;


namespace FilesAssignmentTester
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
                writer.WriteLine("ot11gaudette james Male brown 04/25/1971");
                writer.WriteLine("ot12gaudette jimmy Male red 11/15/2012");
                writer.WriteLine("ot13gaudette pierce Male red 11/15/2012");
                writer.WriteLine("ot14gaudette kady Female red 11/15/2006");
            }

            using (StreamWriter writer = File.CreateText("OutputTestscommaFile.txt"))
            {
                writer.WriteLine("ot21gaudette,james,Male,brown,04/25/1971");
                writer.WriteLine("ot22gaudette,jimmy,Male,red,11/15/2012");
                writer.WriteLine("ot23gaudette,pierce,Male,red,11/15/2012");
                writer.WriteLine("ot24gaudette,kady,Female,red,11/15/2006");
            }



            using (StreamWriter writer = File.CreateText("OutputTestspipeFile.txt"))
            {
                writer.WriteLine("ot31gaudette|james|Male|brown|04/25/1971");
                writer.WriteLine("ot32gaudette|jimmy|Male|red|11/15/2012");
                writer.WriteLine("ot33gaudette|pierce|Male|red|11/15/2012");
                writer.WriteLine("ot34gaudette|kady|Female|red|11/15/2006");
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

            var userDataRepo = UserDataRepository.Instance;
            userDataRepo.AddFile("OutputTestsspaceFile.txt");
            userDataRepo.AddFile("OutputTestscommaFile.txt");
            userDataRepo.AddFile("OutputTestspipeFile.txt");




            var outProcessor = new ConsoleOutputProcessor(userDataRepo);

            // test for females first and last name ascending
            var out1Data=outProcessor.ArrangeDataforOutput1();

            
            Assert.AreEqual(out1Data[0].LastName, "ot14gaudette");

            // test for sorted by birthday 
            var out2Data = outProcessor.ArrangeDataforOutput2();

            Assert.AreEqual(out2Data[0].LastName, "ot11gaudette");

            // test for sorted by last name descending 
            var out3Data = outProcessor.ArrangeDataforOutput3();

            Assert.AreEqual(out3Data[0].LastName, "ot34gaudette");










        }


    }
}
