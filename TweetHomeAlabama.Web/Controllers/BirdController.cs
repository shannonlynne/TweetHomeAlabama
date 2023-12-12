using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Service;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]  //TODO: change routing
    public class BirdController : Controller
    {
        private readonly ITweetHomeAlabamaService _service;
        private readonly ILogger<BirdController> _logger;

        public BirdController(ITweetHomeAlabamaService service, ILogger<BirdController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetBirds(string color, string secondaryColor, string shape, string size, string habitat) 
        {
            if (color is null) throw new ArgumentNullException(nameof(color));
            if (secondaryColor is null) throw new ArgumentNullException(nameof(secondaryColor));
            if (shape is null) throw new ArgumentNullException(nameof(shape));
            if (size is null) throw new ArgumentNullException(nameof(size));
            if (habitat is null) throw new ArgumentNullException(nameof(habitat));

            var traitList = new List<string>();

            traitList.Add(color);
            traitList.Add(secondaryColor);
            traitList.Add(shape);
            traitList.Add(size);
            traitList.Add(habitat);

            try
            {
                var birdList = await _service.GetBirds(traitList);

                return View(birdList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get Request failed with exception message: { message }", ex.Message);

                if (ex.InnerException is not null)
                    _logger.LogError("Inner exception message: { message }", ex.InnerException);
                         
                return new ViewResult() { ViewName = "Error" };
            }
        }
    }
}
