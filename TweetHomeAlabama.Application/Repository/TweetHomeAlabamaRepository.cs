using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.DbContext;

namespace TweetHomeAlabama.Application.Repository
{
    public class TweetHomeAlabamaRepository<T> : ITweetHomeAlabamaRepository<T> where T : class
    {
        private TweetHomeAlabamaDataContext _context;
        DbSet<T> dbSet;

        public TweetHomeAlabamaRepository(TweetHomeAlabamaDataContext context)
        {
            this._context = new TweetHomeAlabamaDataContext();
            dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public T GetBirdByTraits(BirdTrait birdTraits)
        {
            List<T> birds = dbSet.ToList();

            var colors = birdTraits.Color.Split(";").Select(x => x.Trim());
            var shape = birdTraits.Shape.Split(";").Select(x => x.Trim());
            
            //Where(b => b.Traits.Contains(birdtraits)).ToList();

            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;    
        }
         
        public void Delete(object id)
        {
            T? existing = dbSet.Find(id);
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
