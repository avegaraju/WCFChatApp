using EA.Common.Utilities.Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Utilities.Contract.Response
{
    [DataContract]
    public class OnlineUsers
    {
        [DataMember]
        public List<User> UserHandles { get; set; }
    }
}
