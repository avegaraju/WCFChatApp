using EA.Common.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EA.Client.EAChat.UI.Proxy
{
    /// <summary>
    /// Type of binding for the client.
    /// </summary>
    public interface IClientScheme
    {
        IEAChatService GetProxy(string portNumber, Object chatWindowRef);
    }
}
