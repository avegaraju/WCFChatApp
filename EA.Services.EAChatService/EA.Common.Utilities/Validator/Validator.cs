using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities
{
    public class Validator
    {
        public static bool IsValid(string[] args)
        {
            int result;
            bool isValid;

            if (args.Length == 0 || args.Length > 1)
                isValid = false;
            else
            {
                isValid = Int32.TryParse(args[0], out result); //if port is not int !
            }

            return isValid;
        }

        public static bool isValidPort(string portNumber)
        {

            int result;
            bool isValid;

            isValid = Int32.TryParse(portNumber, out result);

            return isValid;
        }
    }
}
