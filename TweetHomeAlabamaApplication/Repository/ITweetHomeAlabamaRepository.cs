using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Infrastructure.Repository
{
    public interface ITweetHomeAlabamaRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
