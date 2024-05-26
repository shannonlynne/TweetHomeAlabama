using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Application.Service;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]  
    public class BirdController : Controller
    {
        private readonly ITweetHomeAlabamaService _service;
        private readonly ILogger<BirdController> _logger;

        public BirdController(ITweetHomeAlabamaService service, ILogger<BirdController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult AddBirdHome()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBirds(string color, string secondaryColor, string shape, string size, string habitat)
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

                return View(birdList);
            }
            catch (System.Web.Http.HttpResponseException ex)
            {
                _logger.LogError("There was a failure retrieving the bird list with {message}", ex.Message);

                return View("Error");
            }
            catch (Exception ex)
            {
                _logger.LogError("Get Request failed with message: { message }", ex.Message);

                if (ex.InnerException is not null)
                    _logger.LogError("Get Request failed with message: { message }", ex.InnerException);

                return View("Error");
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddBird(BirdDto bird)
        {
            if (bird is null) throw new ArgumentNullException(nameof(bird));

            try
            {
                await Task.Run(() => _service.AddBird(bird));

                return new JsonResult(new { message = "Bird saved successfully" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException is not null)
                    _logger.LogError("Post Request failed with message: { message }", ex.InnerException.Message);
                else
                    _logger.LogError("Post Request failed with message: { message }", ex.Message);

                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

