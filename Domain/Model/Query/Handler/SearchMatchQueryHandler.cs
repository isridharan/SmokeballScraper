using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client;
using Client.Request;
using Domain.Model;

namespace Domain.Query.Handler
{
    public interface IQueryHandler<SearchMatchQuery, SearchMatchResponse>
    {
         Task<SearchMatchResponse> HandleAsync(SearchMatchQuery query);
    }

    public class SearchMatchQueryHandler : IQueryHandler<SearchMatchQuery, SearchMatchResponse>
    {
        private readonly IScraperClient _scraperClient;
        public SearchMatchQueryHandler(IScraperClient scraperClient)
        {
            _scraperClient = scraperClient;
        }
        public async Task<SearchMatchResponse> HandleAsync(SearchMatchQuery query)
        {
            // vaidation of input is encapsulated here
            ScrapperRequest request = new(query.SearchInput, query.NumberOfRows);
            // client request is created.
            ClientRequest clientRequest = new(request.QueryString);
            string content = await _scraperClient.GetContentAsync(clientRequest);
            // scrapping logic is encapsulated inside
            Scrapper scrapper = new(query.Url, content);
            return new SearchMatchResponse(scrapper.GetCountOfMatches());
        }
    }
}
