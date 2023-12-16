using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Application.Service
{
    public interface ITweetHomeAlabamaService
    {
        Task<List<Bird>> GetBirds(List<string> birdEntities);
        Task AddBird(BirdDto bird);
    }
}
