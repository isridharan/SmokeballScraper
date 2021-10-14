using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common;
using static Common.Constants;
using Domain.Query.Handler;
using Domain.Query;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapperController : ControllerBase
    {
        private readonly IQueryHandler<SearchMatchQuery, SearchMatchResponse> _handler;
        public ScrapperController(IQueryHandler<SearchMatchQuery, SearchMatchResponse> handler)
        {
            _handler = handler;
        }

        [Route("/search")]
        [HttpGet]
        public async Task<ActionResult> GetNumberOfHits([FromQuery]  string searchcontent, [FromQuery] string url)
        {
            try
            {
                // input validation is encapsulated here
                SearchMatchQuery query = new(searchcontent, url);
                SearchMatchResponse response = await _handler.HandleAsync(query);
                return Ok(response.CountOfMatches);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        private ActionResult HandleException(Exception ex)
        {
            if (ex is InvalidInputException)
            {
                return BadRequest(ex.Message);
            }
            if (ex is InvalidUrlFormatException)
            {
                return BadRequest(ex.Message);
            }
            if (ex is InvalidSearchStringException)
            {
                return BadRequest(ex.Message);
            }
            if (ex is ClientException || ex is NoResponseException)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(500, ExceptionMessages.ApplicationException + ex.Message);
        }
    }
}
