using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.DataContext;

namespace TweetHomeAlabama.Application.Repository
{
    public class TweetHomeAlabamaRepository<Bird> : ITweetHomeAlabamaRepository<Bird> where Bird : class
    {
        private TweetHomeAlabamaDbContext _context;
        DbContextOptions<TweetHomeAlabamaDbContext> _options;
        DbSet<Bird> dbSet;

        public TweetHomeAlabamaRepository(TweetHomeAlabamaDbContext context, DbContextOptions<TweetHomeAlabamaDbContext> options)
        {
            _options = options;
            this._context = new TweetHomeAlabamaDbContext(_options);
            dbSet = _context.Set<Bird>();
        }

        public IEnumerable<Bird> GetAll()
        {
            return dbSet.ToList();
        }

        public Bird? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public Bird GetBirdByTraits(BirdTrait birdTraits)
        {
            List<Bird> birds = dbSet.ToList();

            
            
            //Where(b => b.Traits.Contains(birdtraits)).ToList();

            throw new NotImplementedException();
        }

        public void Insert(Bird obj)
        {
            dbSet.Add(obj);
        }

        public void Update(Bird obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;    
        }
         
        public void Delete(object id)
        {
            Bird? existing = dbSet.Find(id);
            if (existing != null)
                dbSet.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;  //TODO: include this dispose section?
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
