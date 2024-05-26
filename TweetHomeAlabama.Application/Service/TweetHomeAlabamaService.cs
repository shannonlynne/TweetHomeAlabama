using Microsoft.Extensions.Logging;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Data.Entity;
using TweetHomeAlabama.Data.Repository;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Application.Service
{
    public class TweetHomeAlabamaService : ITweetHomeAlabamaService
    {
        private readonly ITweetHomeAlabamaRepository<BirdEntity> _repository;
        private readonly ILogger<TweetHomeAlabamaService> _logger;

        public TweetHomeAlabamaService(ITweetHomeAlabamaRepository<BirdEntity> repository, ILogger<TweetHomeAlabamaService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Bird>> GetBirds(string color, string secondaryColor, string size, string shape, string habitat)
        {
            var birdIds = new List<int>();

            var birdList = new List<BirdEntity>();

            try
            {
                birdIds = await _repository.GetIdsUsingTraits(color, secondaryColor, size, shape, habitat);
                birdList = await _repository.GetBirdMatches(birdIds);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is not null)
                    _logger.LogError("Failed to get birds from respository with { message }", ex.InnerException.Message);
                else 
                    _logger.LogError("Failed to get birds from respository with { message }", ex.Message);
            }

            var result = new List<Bird>();

            foreach (var bird in birdList)
                result.Add(new Bird(bird.Name, bird.Image, bird.Info));

            return result;
        }

        public async Task<int> AddBird(BirdDto bird)
        {
            var birdEntity = new BirdEntity(bird.Name, bird.Url, bird.Info);

            var birdId = await Task.Run(() => _repository.Insert(birdEntity));

            var birdTraitsEntity = new BirdTraitsEntity(birdId, bird.Color, bird.SecondaryColor,
                bird.Size, bird.Shape, bird.Habitat);

            await Task.Run(() => _repository.Insert(birdTraitsEntity));

            return birdId;
        }
    }
}