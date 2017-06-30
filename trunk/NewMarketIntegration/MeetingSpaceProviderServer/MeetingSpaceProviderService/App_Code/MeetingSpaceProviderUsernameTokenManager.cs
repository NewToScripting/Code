using System;
using System.Xml;
using System.Web.Services.Protocols;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;


namespace Newmarket.WebServices
{
    /// <summary>
    /// By implementing UsernameTokenManager we can verify the signature
    /// on messages received.
    /// </summary>
    /// <remarks>
    /// This class includes this demand to ensure that any untrusted
    /// assemblies cannot invoke this code. This helps mitigate
    /// brute-force discovery attacks.
    /// </remarks>
    public class MeetingSpaceProviderServiceUsernameTokenManager : UsernameTokenManager
    {        
        public static string _user;
        public static string _pwd;

        /// <summary>
        /// Constructs an instance of this security token manager.
        /// </summary>
        public MeetingSpaceProviderServiceUsernameTokenManager()
        {
        }

        /// <summary>
        /// Constructs an instance of this security token manager.
        /// </summary>
        /// <param name="nodes">An XmlNodeList containing XML elements from a configuration file.</param>
        public MeetingSpaceProviderServiceUsernameTokenManager( XmlNodeList nodes )
            : base(nodes)
        {
        }

        /// <summary>
        /// Returns the password or password equivalent for the username provided.
        /// </summary>
        /// <param name="token">The username token</param>
        /// <returns>The password (or password equivalent) for the username</returns>
        protected override string AuthenticateToken( UsernameToken token )
        {
           // Set these static vars here to be used in the service method
            _user = token.Username;
            _pwd =  token.Password;
            
            // Return the password that was sent in to the service here.  
            return token.Password;
       }

        /// <summary>
        /// Verify the security token.  Overridden to catch password errors.
        /// </summary>
        /// <param name="token"></param>
        public override void VerifyToken(SecurityToken token)
        {            
            base.VerifyToken(token);
       }
    }
}
 