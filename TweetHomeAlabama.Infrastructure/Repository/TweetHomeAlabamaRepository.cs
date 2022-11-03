using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.DbContext;

namespace TweetHomeAlabama.Infrastructure.Repository
{
    public class TweetHomeAlabamaRepository : ITweetHomeAlabamaRepository, IDisposable
    {
        private TweetHomeAlabamaDataContext context;
        public TweetHomeAlabamaRepository(TweetHomeAlabamaDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bird> GetBirds()
        {
            return context.Birds.ToList();
        }

        public Bird? GetBirdById(int id)
        {
            return context.Birds?.Find(id);
        }

        public Bird GetBirdByTraits(string birdTraits)
        {
            List<Bird> birds = context.Birds.ToList();

            var birdTraitsToFind = birdTraits?.Split(";").Select(x => x.Trim());

            if (birdTraitsToFind != null)
            {
                //compare birdTraits to find to bird list
            }

            //Where(b => b.Traits.Contains(birdtraits)).ToList();

            throw new NotImplementedException();
        }

        public void InsertBird(Bird bird)
        {
            context.Birds.Add(bird);
        }

        public void UpdateBird(Bird bird)
        {
            context.Entry(bird).State = EntityState.Modified;
        }

        public void SaveBird()
        {
            context.SaveChanges();
        }
         
        public void DeleteBird(int id)
        {
            Bird? bird = context.Birds.Find(id);
            var x = bird != null ? context.Birds.Remove(bird) : null;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
