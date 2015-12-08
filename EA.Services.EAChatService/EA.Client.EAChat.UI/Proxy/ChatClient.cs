using EA.Client.EAChat.UI.Proxy;
using EA.Common.Contract.Service;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EA.Client.EAChat.UI.Proxy
{
    public class ChatClient
    {
        string PortNumber { get; set; }
        Object ChatWindowRef { get; set; }

        public ChatClient(string portNumber, Object chatWindow)
        {
            PortNumber = portNumber;
            ChatWindowRef = chatWindow;
        }

        public IEAChatService GetProxy()
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            ChatClientHelper helper = new ChatClientHelper(container.Resolve<IClientScheme>(), PortNumber);
            return helper.GetProxy(ChatWindowRef);
        }

    }
}
