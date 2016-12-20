using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3FilesAssignment
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

            var myProcessor= new FileProcessor();
            myProcessor.AddFile(args[0]);
            myProcessor.AddFile(args[1]);
            myProcessor.AddFile(args[2]);



            var outProcessor = new ConsoleOutputProcessor(myProcessor._dataList);
            outProcessor.processOutput();
            Console.WriteLine("please press return");
            Console.ReadLine();



        }
    }
}
