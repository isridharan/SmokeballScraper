using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Constants
    {

        public const int DefaultNumberOfRowsToBeReturned = 100;

        public struct ExceptionMessages
        {
            public const string ClientException = "Error Occured While Fetching data from Client";
            public const string NoResponseException = "No response was returned from the Client";
            public const string InvalidUrlFormatException = "The url format is not acceptable";
            public const string ApplicationException = "Error occured while processing the data";
            public const string InvalidSearchStringException = "Search string format is incorrect. It has to start with alphabet and can only contain alphabets and spaces";
            public const string InvalidInputException = "Search string format is incorrect. It has to start with alphabet and can only contain alphabets and spaces. The url format is not acceptable";
        }

        public struct PatternsToMatch
        {
            public const string ValidUrl = @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            public const string ValidAlphabetsAndSpaceOnly = "[a-zA-Z][a-zA-Z ]+[a-zA-Z]$";
        }
    }
}
