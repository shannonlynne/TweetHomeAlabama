using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Api.Models;
using TweetHomeAlabama.Application;

namespace TweetHomeAlabama.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BirdController : Controller
    {
        private readonly TweetHomeAlabamaService _repository;
        private readonly ILogger<BirdController> _logger;

        public BirdController(TweetHomeAlabamaService repository, ILogger<BirdController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{colorPattern}/{size}/{shape}/{date}/{habitat}")]
        public async Task<IActionResult> GetBirds(string colorPattern, string size, string shape, string date, string habitat)
        {
            List<Bird> birdList = new List<Bird>();
            try
            {
                //await call to repo
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
