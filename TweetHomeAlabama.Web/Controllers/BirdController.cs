using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]  //TODO: change routing
    public class BirdController : Controller
    {
        private readonly TweetHomeAlabamaService _repository;
        private readonly ILogger<BirdController> _logger;

        //TODO:add dependencies
        public BirdController() //TweetHomeAlabamaService repository, ILogger<BirdController> logger)
        {
            //TODO: implement
            //_repository = repository;
            //_logger = logger;
        }

        [HttpGet] 
        public async Task<IActionResult> GetBirds(string? color, string? shape, string season, string size) //TODO: Do I really want nulls?
        {
            List<Bird> birdList = new List<Bird>();
            try
            {
                //TODO: don't forget await
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }

            return Ok(birdList);
        }
    }
}
