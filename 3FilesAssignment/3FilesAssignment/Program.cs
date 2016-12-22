using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesAssignmentService.Repositorys;
using FilesAssignment.OutputProcessor;


namespace FilesAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("You did not enter enough arguments.  ");
                Console.WriteLine("  This is what you should enter:");
                Console.WriteLine("   3FilesAssignment <dataFile> <dataFile> <dataFile> ");
                Console.WriteLine("please press return");
                Console.ReadLine();
                return;
            }

            var userDataRepo= UserDataRepository.Instance;
            userDataRepo.AddFile(args[0]);
            userDataRepo.AddFile(args[1]);
            userDataRepo.AddFile(args[2]);



            var outProcessor = new ConsoleOutputProcessor(userDataRepo);
            outProcessor.processOutput();
            Console.WriteLine("please press return");
            Console.ReadLine();



        }
    }
}
