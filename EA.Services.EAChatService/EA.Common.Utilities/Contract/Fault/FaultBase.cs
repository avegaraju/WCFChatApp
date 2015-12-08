using EA.Common.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EA.Common.Contract.Fault
{
    [DataContract]
    public class FaultBase : IFault
    {

        public FaultBase()
        {

        }

        public FaultBase(ServiceFaultCode code, string message)
        {
            Code = code;
            Message = message;
            TimeStamp = DateTime.Now;
        }

        [DataMember]
        public ServiceFaultCode Code { get; set; }


        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}