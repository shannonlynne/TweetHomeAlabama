using TweetHomeAlabama.Data.Entity;

namespace TweetHomeAlabama.Data.Repository
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
