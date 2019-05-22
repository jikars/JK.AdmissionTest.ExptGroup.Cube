using System;
using System.Runtime.Serialization;

namespace JK.Cube.Domain.Exceptions
{
    [Serializable]
    public class ValueNodeAssignOutLimitsException : Exception
    {
        public ValueNodeAssignOutLimitsException()
        {
        }

        public ValueNodeAssignOutLimitsException(string message)
            : base(message)
        {
        }

        public ValueNodeAssignOutLimitsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ValueNodeAssignOutLimitsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
