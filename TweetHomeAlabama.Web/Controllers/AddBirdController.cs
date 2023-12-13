using Microsoft.AspNetCore.Mvc;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Application.Service;

namespace TweetHomeAlabama.Web.Controllers
{
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
		public async Task AddBird(BirdDto bird)
		{
			if (bird is null) throw new ArgumentNullException(nameof(bird));

			await _service.AddBird(bird);
		}
	}
}
