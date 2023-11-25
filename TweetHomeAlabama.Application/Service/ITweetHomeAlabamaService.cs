using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Application.Service
{
    public interface ITweetHomeAlabamaService
    {
        Task<List<Bird>> GetBirds(List<string> birdTraits);
    }
}
