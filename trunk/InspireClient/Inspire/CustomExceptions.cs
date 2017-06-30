using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inspire
{
    public class FailedToCreateModuleException : Exception, ISerializable
    {
        public FailedToCreateModuleException()
        {
            // Add implementation.
        }
        public FailedToCreateModuleException(string message)
        {
            // Add implementation.
        }
        public FailedToCreateModuleException(string message, Exception inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        protected FailedToCreateModuleException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    }

}
