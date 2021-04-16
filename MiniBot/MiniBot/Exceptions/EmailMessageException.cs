using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
