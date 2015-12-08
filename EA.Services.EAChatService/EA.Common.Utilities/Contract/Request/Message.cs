using EA.Common.Utilities.Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EA.Common.Contract.Request
{
    [DataContract]
    public class Message : RequestBase
    {
        [DataMember]
        public string SimpleMessage { get; set; }
        [DataMember]
        public User ToUser { get; set; }
        [DataMember(IsRequired=true)]
        public User Self { get; set; }

    }
}