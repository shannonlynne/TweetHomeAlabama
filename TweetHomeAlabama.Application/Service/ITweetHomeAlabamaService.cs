using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Application.Service
{
    public interface ITweetHomeAlabamaService
    {
        Task<List<Bird>> GetBirds(string color, string secondaryColor, string size, string shape, string habitat);
        Task<int> AddBird(BirdDto bird);
    }
}
