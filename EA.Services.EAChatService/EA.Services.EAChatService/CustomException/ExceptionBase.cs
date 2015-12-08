using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.Services.EAChatService.CustomException
{
    /// <summary>
    /// Base class for all Types of exceptions. 
    /// 
    /// <remarks>Categorizing exceptions based on functional or general type of exceptions. Based on either these exceptions
    /// appropriate Fault contract (EAChatServiceFault or EAChatGeneralFault) will be created for the client. Convertion of 
    /// Exception to Fault happens in <see cref="ErrorHandler"/> and <see cref="FaultHelper"/>.</remarks>
    /// </summary>
    public class ExceptionBase: ApplicationException
    {
        public ExceptionBase(ServiceFaultCode code, string message)
            : base(message)
        {
            Code = code;
        }

        public ServiceFaultCode Code { get; set; }
    }
}