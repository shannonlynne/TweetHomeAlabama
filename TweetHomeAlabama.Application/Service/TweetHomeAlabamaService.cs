using TweetHomeAlabama.Application.Repository;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.DataContext;
using TweetHomeAlabama.Infrastructure.Entity;

namespace TweetHomeAlabama.Application.Service
{
    public class TweetHomeAlabamaService : ITweetHomeAlabamaService
    {
        private readonly TweetHomeAlabamaDbContext _context;
        private readonly ITweetHomeAlabamaRepository<BirdEntity> _repository;

        public TweetHomeAlabamaService(TweetHomeAlabamaDbContext context, ITweetHomeAlabamaRepository<BirdEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<List<Bird>> GetBirds(List<string> birdTraits)
        {
            var birdList = new List<Bird>();

            var birds = await _repository.GetBirds();

            foreach (var bird in birds)
            {
                //birdList.Add(new Bird(bird.Name, bird.Image, bird.Info));
                int count = 0;
                bool color = false;

                foreach (var trait in birdTraits)
                {
                    if (birds.Any(x => x.Color == trait))
                        color = true;

                    if (bird.Season == trait || bird.Season == "all")
                        count++;
                    else if (bird.Habitat == trait)
                        count++;
                    else if (bird.Shape == trait)
                        count++;
                    else if (bird.SecondaryColor == trait)
                        count++;
                    else if (bird.Size == trait)
                        count++;
                }

                if (color && count > 1)
                    birdList.Add(new Bird(bird.Name, bird.Image, bird.Info));
            }


            return birdList;
        }
    }
}