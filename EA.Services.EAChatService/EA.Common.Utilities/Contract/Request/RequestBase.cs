using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace EA.Common.Contract.Request
{
    /// <summary>
    /// Base class for any type of Request Objects.
    /// </summary>
    /// <remarks>If a class is inherited from this base class all common properties 
    /// will be available to it.</remarks>
    [Serializable]
    public class RequestBase
    {
        /// <summary>
        /// Get User's Identity
        /// </summary>
        public string User
        {
            get 
            {
                return ServiceSecurityContext.Current.WindowsIdentity.Name;
            }
        }
        /// <summary>
        /// Get the current Time.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        

    }
}