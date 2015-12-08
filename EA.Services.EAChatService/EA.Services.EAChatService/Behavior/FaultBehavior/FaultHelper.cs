using EA.Common.Contract.Fault;
using EA.Common.Exception.Common;
using EA.Services.EAChatService.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace EA.Services.EAChatService.Behavior.FaultBehavior
{
    public class FaultHelper
    {
        /// <summary>
        /// Method to convert an exception to Fault.
        /// </summary>
        /// <typeparam name="TFault">Type of Fault</typeparam>
        /// <param name="tFault">instance of a fault</param>
        /// <param name="error">The actual exception (either functional or general)</param>
        /// <param name="version">Message version</param>
        /// <returns></returns>
        public Message CreateFaultMessage<TFault>(ExceptionBase error, MessageVersion version)
            where TFault : IFault, new()
        {
            TFault bFault = new TFault();
            bFault.Message = error.Message;
            bFault.Code = error.Code;

            Message fault = null;
            FaultException fException = new FaultException<TFault>(bFault, new FaultReason(error.Message), new FaultCode(error.Code.ToString()));
            MessageFault mFault = fException.CreateMessageFault();

            fault = Message.CreateMessage(version, mFault, null);

            return fault;
        }
    }
}