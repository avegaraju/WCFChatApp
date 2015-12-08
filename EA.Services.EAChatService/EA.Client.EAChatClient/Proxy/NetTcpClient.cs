using EA.Client.EAChatClient.Callback;
using EA.Common.Contract.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient.Proxy
{
    /// <summary>
    /// Client which connects to a Service hosted on nettcp.
    /// </summary>
    public class NetTcpClient: IClientScheme
    {

        public IEAChatService GetProxy(string portNumber)
        {
            var binding = new NetTcpBinding();
            var endPointAddress = new EndpointAddress(GetEndPointAddress(portNumber));
            var channelFactory = new DuplexChannelFactory<IEAChatService>(new ChatCallBackHandler(), binding, endPointAddress);

            return channelFactory.CreateChannel();
            
        }

        private Uri GetEndPointAddress(string portNumber)
        {
            string prefix = ConfigurationManager.AppSettings["nettcp_prefix"];
            string chatServicePath = ConfigurationManager.AppSettings["EAChatServicePath"];

            return new Uri(prefix + portNumber + chatServicePath);
        }
    }
}
