using EA.Services.EAChatService.Behavior.FaultBehaviour;
using EA.Common.Contract.Request;
using EA.Common.Contract.Response;
using EA.Common.Contract.Service;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EA.Services.EAChatService.Contract.Service;
using EA.Common.Utilities.Contract.Request;
using EA.Common.Utilities.Contract.Response;
using EA.Common.Contract.Callback;
using EA.Services.EAChatService.CustomException;
using EA.Common.Exception.Common;

namespace EA.Services.EAChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ErrorHandler]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EAChatService : ServiceBase, IEAChatService
    {
        ILog log = LogManager.GetLogger(typeof(EAChatService));


        public bool Connect()
        {
            log.Info("Client connected to the service.");
            return true;
        }

        public void Register(User userHandle)
        {
            try
            {
                if (!registeredUser.ContainsKey(userHandle.UserId) &&
                    !registeredUser.ContainsValue(Callback))
                {
                    lock (syncObject)
                    {
                        registeredUser.Add(userHandle.UserId, Callback);
                        onlineUsers.Add(userHandle);

                        foreach (KeyValuePair<string, IChatCallback> kvp in registeredUser)
                        {
                            IChatCallback callback = kvp.Value;
                            callback.RefreshUserList(onlineUsers);
                        }
                    }

                }
                else
                {
                    throw new UserHandleInUseException(ServiceFaultCode.HANDLE_IN_USE, "User with this handle already exist. Please choose a different handle.");
                }
            }
            catch (UserHandleInUseException uEx)
            {
                log.Error("User handle is alread in use. Error Detail: " + uEx.Message);
                throw;

            }
            
            
        }

        public void Send(Message message)
        {
            log.Info("Send method called. Message = " + message.SimpleMessage + " From User " + message.Self.UserId );
            try
            {
                lock (syncObject)
                {
                    if (String.IsNullOrEmpty(message.ToUser.UserId))
                    {
                        ResponsePacket resp = new ResponsePacket()
                        {
                            ResponseMessage = base.ServerMessage,
                            TimeStamp = base.TimeStamp,
                            UserId = "EA Chat Server "
                        };
                        Callback.ResponseMessage(resp);
                    }
                    else
                    {
                        foreach (User user in onlineUsers)
                        {
                            if (user.UserId.Equals(message.ToUser.UserId))
                            {
                                IChatCallback callback = registeredUser[message.ToUser.UserId];
                                ResponsePacket toMessage = new ResponsePacket()
                                {
                                    ResponseMessage = message.SimpleMessage,
                                    TimeStamp = DateTime.Now,
                                    UserId = message.Self.UserId
                                };
                                callback.ResponseMessage(toMessage);
                            }
                        }
                    }
                }
            }
            catch (ObjectDisposedException oEx)
            {
                log.Error("Error: " + oEx.Message);
                throw new UserLeftConversationException(ServiceFaultCode.USER_LEFT, "Couldn't deliver message. User '" + message.ToUser.UserId + "' Left the conversation");
            }
        }
        public void DeRegister(User userHandle)
        {

            lock (syncObject)
            {
                onlineUsers.RemoveAll(rem => rem.UserId.Equals(userHandle.UserId));
                registeredUser.Remove(userHandle.UserId);
            }

            foreach (IChatCallback callback in registeredUser.Values)
            {
                callback.RefreshUserList(onlineUsers);
            }
        }
    }
}
