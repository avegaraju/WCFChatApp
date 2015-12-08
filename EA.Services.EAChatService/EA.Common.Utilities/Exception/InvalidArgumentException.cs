using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities.Exception
{
    public class InvalidArgumentException: ApplicationException
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}
