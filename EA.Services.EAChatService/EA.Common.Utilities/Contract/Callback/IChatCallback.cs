using EA.Common.Contract.Response;
using EA.Common.Utilities.Contract.Request;
using EA.Common.Utilities.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Common.Contract.Callback
{
    /// <summary>
    /// Call back interface to communicate with the client.
    /// </summary>
    [ServiceContract]
    public interface IChatCallback
    {
        [OperationContract(IsOneWay=true)]
        void RefreshUserList(List<User> onlineUsers);

        [OperationContract]
        void ResponseMessage(ResponsePacket response);
    }
}
