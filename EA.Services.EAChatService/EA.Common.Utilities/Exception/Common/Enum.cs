using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.Common.Exception.Common
{
    public enum ServiceFaultCode
    {
        PORT_NOT_AVAILABLE,
        UNKNOWN_FAULT,
        USER_LEFT,
        HANDLE_IN_USE
    }
}