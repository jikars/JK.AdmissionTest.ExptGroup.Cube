using System;
using System.Runtime.Serialization;

namespace JK.Cube.Domain.Exceptions
{
    [Serializable]
    public class QueryOutRangeException : Exception
    {
        public QueryOutRangeException()
        {
        }

        public QueryOutRangeException(string message)
            : base(message)
        {
        }

        public QueryOutRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected QueryOutRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
