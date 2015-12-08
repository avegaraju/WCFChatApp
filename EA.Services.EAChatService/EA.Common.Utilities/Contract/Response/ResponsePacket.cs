using EA.Common.Utilities.Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EA.Common.Contract.Response
{
    [DataContract]
    public class ResponsePacket
    {
        [DataMember]
        public string ResponseMessage { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}