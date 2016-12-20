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
            if (args.Length == 0)
            {
                Console.WriteLine("You did not enter any arguments.  ");
                Console.WriteLine("  This is what you should enter:");
                Console.WriteLine("   3FilesAssignment <dataFile> ");
                
                return;
            }

            var myData = new FileProcessor(args[0]).ProcessFile();

            var outProcessor = new ConsoleOutputProcessor(myData);
            outProcessor.processOutput();
            Console.ReadLine();



        }
    }
}
