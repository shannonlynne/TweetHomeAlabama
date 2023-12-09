using TweetHomeAlabama.Infrastructure.Entity;

namespace TweetHomeAlabama.Application.Repository
{
    public interface ITweetHomeAlabamaRepository<T> where T : class
    {
        Task<List<BirdEntity>> GetBirds();
        T? GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
