using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Application.Service;

namespace TweetHomeAlabama.Web.Controllers
{
    [ApiController]
	[Route("[controller]/[action]")]  
	public class AddBirdController : Controller
    {
        private readonly ITweetHomeAlabamaService _service;
        private readonly ILogger<BirdController> _logger;

        public AddBirdController(ITweetHomeAlabamaService service, ILogger<BirdController> logger)
        {
            _service = service;
            _logger = logger;
        }

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<BirdDto> PostBird(BirdDto bird)
		{
			if (bird is null) throw new ArgumentNullException(nameof(bird));
			try
			{
                await _service.AddBird(bird);
                return bird;

            }
            catch (Exception ex)
			{
                _logger.LogError("Post Request failed with message: { message }", ex.Message);

                if (ex.InnerException is not null)
                    _logger.LogError("Post Request failed with message: { message }", ex.InnerException);

                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);


            }
        }
	}
}
