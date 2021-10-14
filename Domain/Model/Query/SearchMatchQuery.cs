using Common;
using System.Text.RegularExpressions;
using static Common.Constants;

namespace Domain.Query
{
    public class SearchMatchQuery
    {
        public SearchMatchQuery(string input, string url, int numberOfRows=100)
        {
            SearchInput = input.Replace("\"", "");
            Url = url.Replace("\"", "").Replace("http://", "").Replace("https://", "").Replace("ftp://", "");
            NumberOfRows = numberOfRows;
            Validate();
        }
        public string SearchInput { get; protected set; }
        public string Url { get; protected set; }
        public int NumberOfRows { get; protected set; }
        public void Validate()
        {
            bool isSearchStringValid = IsValidInput();
            bool isUrlValid = IsValidUrl();

            if (!isSearchStringValid && !isUrlValid)
            {
                throw new InvalidInputException(ExceptionMessages.InvalidInputException);
            }

            if (!isSearchStringValid)
            {
                throw new InvalidSearchStringException(ExceptionMessages.InvalidSearchStringException);
            }
            if (!isUrlValid)
            {
                throw new InvalidUrlFormatException(ExceptionMessages.InvalidUrlFormatException);
            }
        }

        private bool IsValidUrl()
        {
            Regex regex = new(PatternsToMatch.ValidUrl);
            Match match = regex.Match(this.Url);
            return match.Success;
        }

        private bool IsValidInput()
        {
            Regex regex = new(PatternsToMatch.ValidAlphabetsAndSpaceOnly);
            Match match = regex.Match(this.SearchInput);
            return match.Success;
        }

        public struct PatternsToMatch
        {
            public const string ValidUrl = @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            public const string ValidAlphabetsAndSpaceOnly = "[a-zA-Z][a-zA-Z ]+[a-zA-Z]$";
        }
    }

    public class SearchMatchResponse
    {
        public SearchMatchResponse(int countOfMatches)
        {
            this.CountOfMatches = countOfMatches;            
        }
        public int CountOfMatches { get; set; }        
    }
}
