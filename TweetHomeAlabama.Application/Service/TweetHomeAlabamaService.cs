using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task<List<Bird>> GetBirds(List<string> birdTraits)
        {
            if (birdTraits is null) throw new ArgumentNullException(nameof(birdTraits));

            var birdList = new List<Bird>();

            var birds = new List<BirdEntity>();

            try
            {
                birds = await _repository.GetBirds();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get birds from respository with { message }", ex.Message);
            }

            foreach (var bird in birds)
            {
                int count = 0;
                bool color = false;
                bool size = false;

                foreach (var trait in birdTraits)
                {
                    if (bird.Color.Equals(trait))
                    {
                        color = true;
                        count++;
                    }
                    else if (bird.Habitat.Equals(trait))
                        count++;
                    else if (bird.Shape.Equals(trait))
                        count++;
                    else if (bird.SecondaryColor.Equals(trait))
                        count++;
                    else if (bird.Size.Equals(trait))
                    {
                        size = true;
                        count++;
                    }
                }

                if ((color && size) || count > 3)
                    birdList.Add(new Bird(bird.Name, bird.Image, bird.Info));
            }

            return birdList;
        }
    }
}