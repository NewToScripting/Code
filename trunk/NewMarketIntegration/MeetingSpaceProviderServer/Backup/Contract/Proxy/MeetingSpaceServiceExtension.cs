using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web.Services.Protocols;
using Newmarket.WebServices.MeetingSpaceFaults;

namespace Newmarket.WebServices.MeetingSpace.client
{
    
    /// <summary>
    /// Extend the generated proxy so that we can intercept the SoapException exception
    /// and see if the exception detail corresponds to a known exception.
    /// </summary>
    public partial class MeetingSpaceService : Microsoft.Web.Services3.WebServicesClientProtocol 
    {
        private ExceptionHelper.ProxyExceptionHelper mProxyExceptionHelper =
            new ExceptionHelper.ProxyExceptionHelper( new FaultExceptionMapper() );
                
        /// <summary>
        /// Implement the Invoke method here so that we can intercept and translate
        /// known exceptions for asynchronous operations as well.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected new object[] Invoke(string methodName, object[] parameters)
        {
            return mProxyExceptionHelper.HandleInvoke(base.Invoke, methodName, parameters);
        }

        /// <summary>
        /// Implement the EndAccept method here so that we can intercept and translate
        /// known exceptions for asynchronous operations as well.
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        protected new object[] EndInvoke(IAsyncResult asyncResult)
        {
            return mProxyExceptionHelper.EndInvoke(base.EndInvoke, asyncResult);
        }

        /// <summary>
        /// Implement the InvokeAsync method here so that we can intercept and translate
        /// known exceptions for asynchronous operations as well.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <param name="callback"></param>
        /// <param name="userState"></param>
        protected new void InvokeAsync(string methodName, object[] parameters,
            SendOrPostCallback callback, object userState)
        {
            mProxyExceptionHelper.InvokeAsync(base.InvokeAsync, methodName, parameters,
                callback, userState);
        }
    }
}
