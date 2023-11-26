using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Service;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]  //TODO: change routing
    public class BirdController : Controller
    {
        private readonly ITweetHomeAlabamaService _service;
        private readonly ILogger<BirdController> _logger;

        //TODO:add dependencies
        public BirdController(ITweetHomeAlabamaService service, ILogger<BirdController> logger)
        {
            //TODO: implement
            _service = service;
            _logger = logger;
        }

        [HttpGet] 
        public async Task<IActionResult> GetBirds(List<string>? colors, string? shape, string size, string season, string habitat) //TODO: Do I really want nulls?
        {
            var traitList = new List<string>();

            if (colors != null)
            {
                foreach (var color in colors)
                    traitList.Add(color);
            }

            if (shape is not null)
                traitList.Add(shape);

            traitList.Add(season);
            traitList.Add(size);
            traitList.Add(habitat);

            try
            {
                var birdList = await _service.GetBirds(traitList);
                return Ok(birdList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
    }
}
