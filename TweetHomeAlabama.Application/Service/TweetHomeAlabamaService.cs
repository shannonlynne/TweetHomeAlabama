using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Infrastructure.DataContext;
using TweetHomeAlabama.Infrastructure.Entity;

namespace TweetHomeAlabama.Application.Service
{
    public class TweetHomeAlabamaService : ITweetHomeAlabamaService
    {
        private readonly TweetHomeAlabamaDbContext _context;

        public TweetHomeAlabamaService(TweetHomeAlabamaDbContext context)
        {
            _context = context;
        }

        public async Task<List<BirdEntity>> GetBirds(List<string> birdTraits)
        {
            var birdList = new List<BirdEntity>();

            foreach (var birdTrait in birdTraits)
            {
                birdList = await _context.Birds.ToListAsync();
            }
            
            //filter list for multiple values or something?
            return birdList;
        }
    }
}