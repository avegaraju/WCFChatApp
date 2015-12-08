using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EA.Common.Contract.Fault
{
    [DataContract]
    public class EAChatServiceFault : FaultBase
    {
        public EAChatServiceFault()
        {

        }
        public EAChatServiceFault(ServiceFaultCode code, string message)
            : base(code, message)
        {
        }

    }
}