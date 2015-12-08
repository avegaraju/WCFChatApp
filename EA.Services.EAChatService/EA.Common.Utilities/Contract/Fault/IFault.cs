using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Contract.Fault
{
    public interface IFault
    {
        ServiceFaultCode Code { get; set; }
        string Message { get; set; }
    }
}
