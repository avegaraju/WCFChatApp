using EA.Common.Contract.Fault;
using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace EA.Common.Contract.Fault
{
    [DataContract]
    public class EAChatGeneralFault : FaultBase
    {
        public EAChatGeneralFault()
        {

        }
         public EAChatGeneralFault(ServiceFaultCode code, string message)
            : base(code, message)
        {
        }
    }
}
