using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient
{
    public class InvalidArgumentException: ApplicationException
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}
