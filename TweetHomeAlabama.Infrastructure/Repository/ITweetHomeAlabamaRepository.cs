using TweetHomeAlabama.Data.Entity;

namespace TweetHomeAlabama.Data.Repository
{
    public interface ITweetHomeAlabamaRepository<T> where T : class
    {
        Task<List<Entity.BirdEntity>> GetAllBirds();
        Task<List<Entity.BirdEntity>> GetBirdMatches(List<int> ids);
        Task<Entity.BirdEntity?> GetById(int id);
        Task<List<int>> GetIdsUsingTraits(string color, string secondaryColor, string size, string shape, string habitat);
        int Insert(Entity.BirdEntity bird);
        void Insert(Entity.BirdTraitsEntity birdTraits);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
