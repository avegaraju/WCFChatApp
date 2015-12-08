using EA.Common.Contract.Callback;
using EA.Common.Contract.Response;
//using EA.Client.EAChatClient.EAChatServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient.Callback
{
    /// <summary>
    /// Call back handler implementing service callback interface.
    /// </summary>
    public class ChatCallBackHandler : IChatCallback
    {
        public void ResponseMessage(ResponsePacket response)
        {
            Console.WriteLine(response.ResponseMessage);
        }

        public void RefreshUserList(List<Common.Utilities.Contract.Request.User> onlineUsers)
        {
            throw new NotImplementedException();
        }
    }
}
