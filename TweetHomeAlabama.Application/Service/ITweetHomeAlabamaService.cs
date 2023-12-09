using TweetHomeAlabama.Infrastructure.Entity;

namespace TweetHomeAlabama.Application.Service
{
    public interface ITweetHomeAlabamaService
    {
        Task<List<BirdEntity>> GetBirds(List<string> birdTraits);
    }
}
