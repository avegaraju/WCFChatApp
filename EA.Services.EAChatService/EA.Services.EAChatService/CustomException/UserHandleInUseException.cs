using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Services.EAChatService.CustomException
{
    public class UserHandleInUseException : FunctionalException
    {
        public UserHandleInUseException(ServiceFaultCode code, string message)
            : base(code, message)
        {

        }
    }
}
