using EA.Common.Contract.Callback;
using EA.Common.Contract.Fault;
using EA.Common.Contract.Request;
using EA.Common.Utilities.Contract.Request;
using EA.Common.Utilities.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;

namespace EA.Common.Contract.Service
{
    
    [ServiceContract(
        SessionMode = SessionMode.Required, 
        CallbackContract= typeof(IChatCallback))]
    public interface IEAChatService
    {


        [OperationContract(IsInitiating=true)]
        [FaultContract(typeof(FaultBase), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatServiceFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatGeneralFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        bool Connect();

        [OperationContract]
        [FaultContract(typeof(FaultBase), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatServiceFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatGeneralFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        void Register(User userHandle);

      
        [OperationContract]
        [FaultContract(typeof(FaultBase), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatServiceFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatGeneralFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        void Send(Message message);

        [OperationContract]
        [FaultContract(typeof(FaultBase), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatServiceFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        [FaultContract(typeof(EAChatGeneralFault), Namespace = "http://schemas.ea.com/chat/eachatservice/")]
        void DeRegister(User userHandle);

    }

}
