using TweetHomeAlabama.Data.Entity;
using TweetHomeAlabama.Data.Repository;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Application.Service
{
    public class TweetHomeAlabamaService : ITweetHomeAlabamaService
    {
        private readonly ITweetHomeAlabamaRepository<BirdEntity> _repository;

        public TweetHomeAlabamaService(ITweetHomeAlabamaRepository<BirdEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<Bird>> GetBirds(List<string> birdTraits)
        {
            var birdList = new List<Bird>();

            var birds = await _repository.GetBirds();

            foreach (var bird in birds)
            {
                int count = 0;
                bool color = false;


                foreach (var trait in birdTraits)
                {
                    if (bird.Color.Equals(trait))
                        color = true;
                    else if (bird.Habitat.Equals(trait))
                        count++;
                    else if (bird.Shape.Equals(trait))
                        count++;
                    else if (bird.SecondaryColor.Equals(trait))
                        count++;
                    else if (bird.Size.Equals(trait))
                        count++;
                }

                if (color && count > 0)
                    birdList.Add(new Bird(bird.Name, bird.Image, bird.Info));
            }

            return birdList;
        }
    }
}