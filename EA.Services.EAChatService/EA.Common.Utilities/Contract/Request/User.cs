using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities.Contract.Request
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string UserId { get; set; }
    }
}
