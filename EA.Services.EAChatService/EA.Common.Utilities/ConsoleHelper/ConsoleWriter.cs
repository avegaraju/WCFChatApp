using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities.ConsoleHelper
{
    public class ConsoleWriter
    {

        public static readonly string INV_ARG = "INVALID ARGUMENTS. Example Usage: <application.exe> <port_number>";

        public static void WriteOnNewLine(String message)
        {
            Console.WriteLine(message);
        }

        public static void WriteOnSameLine(String message)
        {
            Console.Write(message);
        }

        public static void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
        public static void WriteInvalidArguments()
        {
            Console.WriteLine(INV_ARG);
        }

        public static void WriteException(string message)
        {
            Console.WriteLine("There is an Exception: " + message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

    
    }
}
