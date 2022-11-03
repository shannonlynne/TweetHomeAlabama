using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Infrastructure.Repository
{
    public interface ITweetHomeAlabamaRepository : IDisposable 
    {
        IEnumerable<Bird> GetBirds();
        Bird? GetBirdById(int id);
        Bird? GetBirdByTraits(string birdtraits);
        void InsertBird(Bird bird);
        void UpdateBird(Bird bird);
        void DeleteBird(int id);
        void SaveBird();
    }
}
