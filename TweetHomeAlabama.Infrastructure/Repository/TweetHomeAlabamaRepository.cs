using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.CodeDom;
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

        public async Task<List<Entity.BirdEntity>> GetBirdMatches(List<int> ids)
        {
            var birds = new List<Entity.BirdEntity>();

            foreach (var id in ids)
            {
                var bird = await GetById(id);
                if (bird is not null)
                    birds.Add(bird);
            }

            return birds;
        }

        public async Task<List<int>> GetIdsUsingTraits(string color, string secondaryColor, string size, string shape, string habitat)
        {
            var birdIds = new List<int>();

            var birdsByColor = await _context.BirdTraits.Where(b => b.Color == color).ToListAsync();
            var birdsByColor2 = await _context.BirdTraits.Where(b => b.SecondaryColor == secondaryColor).ToListAsync();   
            var birdsBySize = await _context.BirdTraits.Where(b => b.Size == size).ToListAsync();
            var birdsByShape = await _context.BirdTraits.Where(b => b.Shape == shape).ToListAsync();
            var birdsByHabitat = await _context.BirdTraits.Where(b => b.Habitat == habitat).ToListAsync();

            foreach (var bird in birdsByColor)
                birdIds.Add(bird.BirdId);
            foreach (var bird in birdsByColor2)
                birdIds.Add(bird.BirdId);
            foreach (var bird in birdsBySize)
                birdIds.Add(bird.BirdId);
            foreach (var bird in birdsByShape)
                birdIds.Add(bird.BirdId);
            foreach (var bird in birdsByHabitat)
                birdIds.Add(bird.BirdId);

            if (birdIds.Count > 0)
            {
                var groups = birdIds.GroupBy(b => b);
                
                foreach (var group in groups)
                {
                    if (group.Count() > 2)
                        birdIds.Add(group.Key);
                }
            }

            return birdIds;
        }

        public async Task<List<Entity.BirdEntity>> GetAllBirds()   
        {
            var birdList = await _context.Birds.ToListAsync();

            return birdList;
        }

        public async Task<Entity.BirdEntity?> GetById(int id)
        {
            var bird = await _context.Birds.FirstOrDefaultAsync(x => x.Id == id);
            if (bird is not null)
                return bird;
            return null;
        }

        public int Insert(Entity.BirdEntity bird)
        {
            _context.Birds.Add(bird);
            Save();

            return bird.Id;
        }

        public void Insert(Entity.BirdTraitsEntity birdTraits)
        {
            _context.BirdTraits.Add(birdTraits);
            Save();
        }

        public void Update(BirdEntity bird)
        {
            dbSet.Update(bird);
            Save();
        }
         
        public void Delete(int id)
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
