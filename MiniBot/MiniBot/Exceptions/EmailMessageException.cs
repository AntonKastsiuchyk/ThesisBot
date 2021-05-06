using System;
using System.Runtime.Serialization;

namespace MiniBot.Exceptions
{
    [Serializable]
    class EmailMessageException : Exception
    {
        public EmailMessageException()
        {
        }

        public EmailMessageException(string message) : base(message)
        {
        }

        public EmailMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
