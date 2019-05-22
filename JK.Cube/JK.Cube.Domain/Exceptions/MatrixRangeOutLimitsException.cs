using System;
using System.Runtime.Serialization;

namespace JK.Cube.Domain.Exceptions
{
    [Serializable]
    public class MatrixRangeOutLimitsException : Exception
    {
        public MatrixRangeOutLimitsException()
        {
        }

        public MatrixRangeOutLimitsException(string message)
            : base(message)
        {
        }

        public MatrixRangeOutLimitsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MatrixRangeOutLimitsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
