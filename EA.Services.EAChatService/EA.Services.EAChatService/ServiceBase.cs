using EA.Common.Contract.Callback;
using EA.Common.Utilities.Contract.Request;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace EA.Services.EAChatService.Contract.Service
{
    /// <summary>
    /// Base class for service to inherit common properties.
    /// </summary>
    public class ServiceBase
    {
        protected Dictionary<string, IChatCallback> registeredUser = new Dictionary<string, IChatCallback>();
        protected List<User> onlineUsers = new List<User>();
        protected Object syncObject = new object();

        public ServiceBase()
        {
            XmlConfigurator.Configure();
        }

        protected IChatCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IChatCallback>();
            }
        }

        protected string ServerMessage
        {
            get
            {

                return "Hello!";
            }
        }

        protected DateTime TimeStamp
        {
            get { return DateTime.Now; }
        }
    }
}