using System;
using System.Runtime.Serialization;

namespace JK.Core.Architecture.IoC.Exceptions
{
    [Serializable]
    public class RegisterTypeIncorrectFromInstanceException  : Exception
    {
        public RegisterTypeIncorrectFromInstanceException()
        {
        }

        public RegisterTypeIncorrectFromInstanceException(string message)
            : base(message)
        {
        }

        public RegisterTypeIncorrectFromInstanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RegisterTypeIncorrectFromInstanceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
