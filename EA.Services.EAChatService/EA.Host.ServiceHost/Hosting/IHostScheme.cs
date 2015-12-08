using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Host.ServiceHostEngine.Hosting
{
    /// <summary>
    /// Any scheme of hosting must implement this Interface.
    /// </summary>
    public interface IHostScheme
    {
        ServiceHost Host(string portNumber, bool enableMetaData);
    }
}
