using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Infrastructure.DataContext;

namespace TweetHomeAlabama.Application.Repository
{
    public class TweetHomeAlabamaRepository<BirdEntity> : ITweetHomeAlabamaRepository<BirdEntity> where BirdEntity : class
    {
        private TweetHomeAlabamaDbContext _context;
        DbContextOptions<TweetHomeAlabamaDbContext> _options;
        DbSet<BirdEntity> dbSet;

        public TweetHomeAlabamaRepository(TweetHomeAlabamaDbContext context, DbContextOptions<TweetHomeAlabamaDbContext> options)
        {
            _context = context;
            _options = options;
            dbSet = _context.Set<BirdEntity>();
        }

        public async Task<List<Infrastructure.Entity.BirdEntity>> GetBirds()
        {
            List<Infrastructure.Entity.BirdEntity>  birdList = await _context.Birds.ToListAsync();
                
            return birdList;
        }

        public BirdEntity? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(BirdEntity obj)
        {
            dbSet.Add(obj);
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
