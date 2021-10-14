using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Request;
using Common;
using Microsoft.Extensions.Configuration;

namespace Client
{
   public interface IScraperClient
    {
        Task<string> GetContentAsync(ClientRequest request);
    }

    public class ScraperClient : IScraperClient
    {
        private readonly IConfiguration _configuration;
        private readonly string _uri;
        public ScraperClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _uri = Convert.ToString(_configuration["GoogleUri"]);
        }
        public async Task<string> GetContentAsync(ClientRequest request)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = await client.GetStringAsync(_uri + "/search" + request.QueryString);
                    if (string.IsNullOrEmpty(response))
                    {
                        throw new NoResponseException(Constants.ExceptionMessages.NoResponseException);
                    }
                    return response;
                }
                catch (Exception)
                {
                    throw new ClientException(Constants.ExceptionMessages.ClientException);
                }
            }
        }
    }
}
