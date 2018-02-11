using System;
using System.Runtime.Serialization;

namespace BBI.Common.Exceptions
{
    public class PluginNotRegisteredException : Exception
    {
        public PluginNotRegisteredException()
        {
        }

        protected PluginNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PluginNotRegisteredException(string message) : base(message)
        {
        }

        public PluginNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}