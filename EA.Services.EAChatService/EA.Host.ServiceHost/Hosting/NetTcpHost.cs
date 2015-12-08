using EA.Common.Contract.Service;
using EA.Services.EAChatService;
using EA.Common.Contract.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace EA.Host.ServiceHostEngine.Hosting
{
    /// <summary>
    /// NetTcp Hosting scheme.
    /// </summary>
    public class NetTcpHost : IHostScheme
    {
        public ServiceHost Host(string portNumber, bool enableMetaData)
        {
            Type contractType = typeof(IEAChatService);
            Type serviceType = typeof(EAChatService);

            Uri baseAddress = GetBaseAddress(portNumber);

            ServiceHost serviceHost = new ServiceHost(serviceType, baseAddress);
            serviceHost.AddServiceEndpoint(contractType, new NetTcpBinding(), baseAddress.AbsoluteUri);

            ServiceMetadataBehavior metaDataBehavior = new ServiceMetadataBehavior();
            metaDataBehavior.HttpGetEnabled = false;
            serviceHost.Description.Behaviors.Add(metaDataBehavior);

            if (enableMetaData)
            {
                serviceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            }
            

            return serviceHost;
        }

        private Uri GetBaseAddress(string portNumber)
        {
            string prefix = ConfigurationManager.AppSettings["nettcp_prefix"];
            string chatServicePath = ConfigurationManager.AppSettings["EAChatServicePath"];

            return new Uri(prefix + portNumber + chatServicePath);


        }
    }
}
