using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Application.Service;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirdController : Controller
    {
        private readonly ITweetHomeAlabamaService _service;
        private readonly ILogger<BirdController> _logger;

        public BirdController(ITweetHomeAlabamaService service, ILogger<BirdController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetBirds")]
        public async Task<ActionResult<Bird>> GetBirds(string color, string secondaryColor, string shape, string size, string habitat)
        {
            if (color is null) throw new ArgumentNullException(nameof(color));
            if (secondaryColor is null) throw new ArgumentNullException(nameof(secondaryColor));
            if (shape is null) throw new ArgumentNullException(nameof(shape));
            if (size is null) throw new ArgumentNullException(nameof(size));
            if (habitat is null) throw new ArgumentNullException(nameof(habitat));

            try
            {
                var birdList
                    = await _service.GetBirds(color, secondaryColor, size, shape, habitat);

                if (birdList.Count.Equals(0))
                { 
                    _logger.LogError("Get request failed to return matching birds.");

                    return BadRequest("Matching bird not found.");
                }
                else
                {
                    return CreatedAtAction(nameof(GetBirds), birdList);

                }
            } catch (Exception ex) {
                {
                    var message = $"Get method failed with exception {ex}";
                    _logger.LogError(message, ex);

                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpPost("AddBird")]
        public async Task<ActionResult<BirdDto>> AddBird(BirdDto bird)
        {
            if (bird is null) throw new ArgumentNullException(nameof(bird));

            try
            {
                var birdId = await _service.AddBird(bird);;

                bird.BirdId = birdId;
                return bird;
            }
            catch (Exception ex)
            {
                var message = $"Post method failed with exception {ex}";
                _logger.LogError(message, ex);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
