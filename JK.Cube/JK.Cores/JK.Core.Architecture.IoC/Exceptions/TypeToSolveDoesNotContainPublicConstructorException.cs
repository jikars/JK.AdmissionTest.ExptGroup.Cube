using System;
using System.Runtime.Serialization;

namespace JK.Core.Architecture.IoC.Exceptions
{
    [Serializable]
    public class TypeToSolveDoesNotContainPublicConstructorException : Exception
    {
        public TypeToSolveDoesNotContainPublicConstructorException()
        {
        }

        public TypeToSolveDoesNotContainPublicConstructorException(string message)
            : base(message)
        {
        }

        public TypeToSolveDoesNotContainPublicConstructorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TypeToSolveDoesNotContainPublicConstructorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
