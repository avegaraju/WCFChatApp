using EA.Common.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient.Proxy
{
    public class ChatClientHelper
    {
        IClientScheme ClientScheme { get; set; }
        string PortNumber { get; set; }

        public ChatClientHelper(IClientScheme clientScheme, string portNumber)
        {
            ClientScheme = clientScheme;
            PortNumber = portNumber;
        }

        public IEAChatService GetProxy()
        {
            return ClientScheme.GetProxy(PortNumber);
        }

    }
}
