using EA.Services.EAChatService.Behavior.FaultBehavior;
using EA.Common.Contract.Fault;
using EA.Services.EAChatService.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace EA.Services.EAChatService.Behavior.FaultBehaviour
{
    /// <summary>
    /// An Attribute for handling errors on the service side.
    /// </summary>
    public class ErrorHandler : Attribute, IServiceBehavior, IErrorHandler
    {

        #region IErrorHandler Methods
        public bool HandleError(System.Exception error)
        {
            return true;
        }

        public void ProvideFault(System.Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            
            //already a fault exception return as is.
            if (error is FaultException)
                return;

            /*if its an exception derived from FunctionalException 
            *then start converting that to appropriate fault type.*/
            if (error is FunctionalException)
            {
                FunctionalException fEx = error as FunctionalException; 
                fault = new FaultHelper().CreateFaultMessage<EAChatServiceFault>(fEx, version);

            }
            else if (error is GeneralSystemException)
            {
                GeneralSystemException gEx = error as GeneralSystemException;
                fault = new FaultHelper().CreateFaultMessage<EAChatGeneralFault>(gEx, version);
            }
        }
        #endregion

        #region IServiceBehavior Methods

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
           //left blank intentionally
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler = new ErrorHandler();

            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(new ErrorHandler());
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            //left blank intentionally
        }
        #endregion
    }
}