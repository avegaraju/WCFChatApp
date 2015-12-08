using EA.Common.Utilities;
using EA.Common.Utilities.ConsoleHelper;
using EA.Host.ServiceHostEngine.Hosting;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Host.ServiceHostEngine
{
    public class ChatHost
    {

        ServiceHost host;
        

        public ChatHost(string port)
        {
            PortNumber = port;
        }

        #region Properties



        String PortNumber { get; set; }
        
        #endregion



        public ServiceHost GetHost()
        {

            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            HostingHelper helper = new HostingHelper(container.Resolve<IHostScheme>(), PortNumber, true);
            host = helper.Host();
            
            return host;
        }


        private string GetPortNumber(string[] args)
        {
            return args[0];
        }
    }
}
