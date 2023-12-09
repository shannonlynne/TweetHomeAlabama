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

            }
            
            return birdList;
        }
    }
}