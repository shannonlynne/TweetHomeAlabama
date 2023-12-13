using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TweetHomeAlabama.Data.DataContext;

namespace TweetHomeAlabama.Data.Repository
{
    public class TweetHomeAlabamaRepository<BirdEntity> : ITweetHomeAlabamaRepository<BirdEntity> where BirdEntity : class
    {
        private TweetHomeAlabamaDbContext _context;
        private readonly DbContextOptions<TweetHomeAlabamaDbContext> _options;
        private readonly ILogger<TweetHomeAlabamaRepository<BirdEntity>> _logger;
        private readonly DbSet<BirdEntity> dbSet;

        public TweetHomeAlabamaRepository(TweetHomeAlabamaDbContext context, DbContextOptions<TweetHomeAlabamaDbContext> options,
            ILogger<TweetHomeAlabamaRepository<BirdEntity>> logger)
        {
            _context = context;
            _options = options;
            _logger = logger;
            dbSet = _context.Set<BirdEntity>();
        }

        public async Task<List<Entity.BirdEntity>> GetBirds()
        {
            var birdList = await _context.Birds.ToListAsync();

            return birdList;
        }

        public BirdEntity? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(BirdEntity obj)
        {
            dbSet.Add(obj);
            Save();
        }

        public void Update(BirdEntity obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;    
        }
         
        public void Delete(object id)
        {
            BirdEntity? existing = dbSet.Find(id);
            if (existing != null)
                dbSet.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
