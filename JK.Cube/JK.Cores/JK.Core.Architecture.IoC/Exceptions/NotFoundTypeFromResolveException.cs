using System;
using System.Runtime.Serialization;

namespace JK.Core.Architecture.IoC.Exceptions
{
    [Serializable]
    public class NotFoundTypeFromResolveException : Exception
    {
        public NotFoundTypeFromResolveException()
        {
        }

        public NotFoundTypeFromResolveException(string message)
            : base(message)
        {
        }

        public NotFoundTypeFromResolveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NotFoundTypeFromResolveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
