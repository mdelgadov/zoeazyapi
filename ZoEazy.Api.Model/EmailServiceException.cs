using System;
using System.Runtime.Serialization;

namespace ZoEazy.Api.Model
{
    public class EmailServiceException : Exception
    {
        public string Body { get;private set; }

        public EmailServiceException(string message, string body) : base(message)
        {
            Body = body;
        }

        public EmailServiceException(string message, string body, Exception innerException) : base(message, innerException)
        {
            Body = body;
        }

        public EmailServiceException()
        {
        }

        public EmailServiceException(string message) : base(message)
        {
        }

        public EmailServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}