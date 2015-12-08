using EA.Host.ServiceHostEngine.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Host.ServiceHostEngine.Hosting
{
    /// <summary>
    /// Helper class to Host the service using appropriate scheme of hosting.
    /// </summary>
    public class HostingHelper
    {
        IHostScheme _hScheme;

        public IHostScheme HostScheme
        {
            get { return _hScheme; }
            set { _hScheme = value; }
        }

        string _portNumber;

        public string PortNumber
        {
            get { return _portNumber; }
            set { _portNumber = value; }
        }
        bool _enableMetaData;

        public bool EnableMetaData
        {
            get { return _enableMetaData; }
            set { _enableMetaData = value; }
        }

        /// <summary>
        /// Host the service using appropriate scheme of hosting.
        /// </summary>
        /// <param name="scheme">NetTcp, Http or any other binding scheme</param>
        /// <param name="portnumber">Port on which the service has to be hosted</param>
        /// <param name="enableMetaData">True to enable metadata, false otherwise</param>
        public HostingHelper(IHostScheme scheme, string portNumber, bool enableMetaData)
        {
            HostScheme = scheme;
            PortNumber = portNumber;
            EnableMetaData = enableMetaData;

        }
        /// <summary>
        /// Host the service with provided scheme of hosting
        /// </summary>
        /// <returns></returns>
        public ServiceHost Host()
        {

           return HostScheme.Host(PortNumber,EnableMetaData);
        }
    }
}
