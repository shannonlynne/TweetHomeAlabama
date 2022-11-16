using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
    //[Route("api/[controller]/[action]")]  //TODO: cleanup
    [Route("[controller]")]
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

        [HttpGet("getbirds")] 
        public async Task<IActionResult> GetBirds(string? color, string? shape, string season, string size)
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
