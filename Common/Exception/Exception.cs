using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ClientException : Exception
    {
        public ClientException(string message) : base(message)
        {

        }
    }

    public class NoResponseException : Exception
    {
        public NoResponseException(string message) : base(message)
        {

        }
    }

    public class InvalidUrlFormatException : Exception
    {
        public InvalidUrlFormatException(string message) : base(message)
        {

        }
    }
    public class InvalidSearchStringException : Exception
    {
        public InvalidSearchStringException(string message) : base(message)
        {

        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }
}
