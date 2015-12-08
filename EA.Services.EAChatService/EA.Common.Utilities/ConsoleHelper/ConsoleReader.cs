using EA.Common.Utilities.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities.ConsoleHelper
{
    public class ConsoleReader
    {
        public static string GetPortNumberInput()
        {
            Console.WriteLine("Enter a different port number");
            return GetUserInput();
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static string ParseInput(string[] args)
        {
            if (!Validator.IsValid(args))
                throw new InvalidArgumentException("Please enter the arguments in correct format <app.exe> <port>.");
            else
                return args[0];
        }
    }
}
