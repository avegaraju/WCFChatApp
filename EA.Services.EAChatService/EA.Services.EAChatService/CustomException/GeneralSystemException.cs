using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.Services.EAChatService.CustomException
{
    /// <summary>
    /// Any general (non-functional) exception from chat service should be derived from GeneralSystemException.
    /// </summary>
    public class GeneralSystemException: ExceptionBase
    {
        public GeneralSystemException():base(ServiceFaultCode.UNKNOWN_FAULT,"Unknown Error. Please refer logs.")
        {

        }
    }
}