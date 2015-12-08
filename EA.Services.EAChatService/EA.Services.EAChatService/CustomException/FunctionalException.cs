using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.Services.EAChatService.CustomException
{
    /// <summary>
    /// All functional exceptions (related to functionality of chat service) must inherit from
    /// FunctionalException class.
    /// </summary>
    public class FunctionalException : ExceptionBase
    {
        public FunctionalException(ServiceFaultCode code, string message)
            : base(code, message)
        {
        }
    }
}