using EA.Client.EAChatClient.Proxy;
using EA.Common.Contract.Service;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient
{
    public class ChatClient
    {
        string PortNumber { get; set; }
        
        public ChatClient(string portNumber)
        {
            PortNumber = portNumber;
        }

        public IEAChatService GetProxy()
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            ChatClientHelper helper = new ChatClientHelper(container.Resolve<IClientScheme>(), PortNumber);
            return helper.GetProxy();
        }

    }
}
