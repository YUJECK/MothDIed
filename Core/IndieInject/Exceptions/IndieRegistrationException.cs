using System;

namespace MothDIed.DI
{
    public class IndieRegistrationException : Exception
    {
        public IndieRegistrationException() : base()
        {
        }

        public IndieRegistrationException(string message) : base(message)
        {
        }

        public IndieRegistrationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}