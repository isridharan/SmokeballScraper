using System.Text.RegularExpressions;

namespace Domain.Model
{
   public class Scraper
    {
        public Scraper(string urlToBeMatched, string contentToBeScrapped)
        {
            ContentToBeScrapped = contentToBeScrapped;         
            UrlToBeMatched = urlToBeMatched;
        }       
       
        public string UrlToBeMatched { get; protected set; }

        public string ContentToBeScrapped { get; protected set; }                    

        public int GetCountOfMatches()
        {
            return GetCountByPattern(PatternsToMatch.SearchResult) + GetCountByPattern(PatternsToMatch.AdResult);
        }

        private int GetCountByPattern(string pattern)
        {
            int countOfMatches = 0;
            string builtPattern = patternBuilder(pattern);
            Regex regex = new(builtPattern);
            MatchCollection patternMatches = regex.Matches(ContentToBeScrapped);
            countOfMatches += patternMatches.Count;
            return countOfMatches;
        }

        private string patternBuilder(string pattern)
        {
         string urlToBeMatched = UrlToBeMatched.Replace("\"", "").Replace("http://", "").Replace("https://", "");
          return string.Format(pattern, urlToBeMatched);
        }

        public struct PatternsToMatch
        {
            public const string SearchResult = "<div class=\"kCrYT\"><a href=\"/url\\?q=" + "http(s) ?://{0}";
            public const string AdResult = "<span class=\"jpu5Q VqFMTc NceN9e\">Ad</span><span class=\"Zu0yb qzEoUe\">{0}";
        }

      
    }
}
