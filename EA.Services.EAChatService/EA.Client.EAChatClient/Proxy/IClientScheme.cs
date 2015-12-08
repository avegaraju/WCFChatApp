using EA.Common.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Client.EAChatClient.Proxy
{
    /// <summary>
    /// Type of binding for the client.
    /// </summary>
    public interface IClientScheme
    {
        IEAChatService GetProxy(string portNumber);
    }
}
