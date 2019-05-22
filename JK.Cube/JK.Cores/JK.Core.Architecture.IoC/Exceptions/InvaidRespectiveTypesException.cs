using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JK.Core.Architecture.IoC.Exceptions
{
    [Serializable]
    public class InvaidRespectiveTypesException : Exception
    {
        public InvaidRespectiveTypesException()
        {
        }

        public InvaidRespectiveTypesException(string message)
            : base(message)
        {
        }

        public InvaidRespectiveTypesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvaidRespectiveTypesException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
