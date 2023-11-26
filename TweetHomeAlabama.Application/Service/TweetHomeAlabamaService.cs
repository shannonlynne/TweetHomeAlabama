using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.DataContext;

namespace TweetHomeAlabama.Application.Service
{
    public class TweetHomeAlabamaService : ITweetHomeAlabamaService
    {
        private readonly TweetHomeAlabamaDbContext _context;

        public TweetHomeAlabamaService(TweetHomeAlabamaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bird>> GetBirds(List<string> birdTraits)
        {
            var birdList = new List<Bird>();

            foreach (var birdTrait in birdTraits)
            {
                birdList = await _context.Birds.Where(x => x.Traits.Contains(birdTrait)).ToListAsync();
            }
            
            //filter list for multiple values or something?
            return birdList;
        }
    }
}