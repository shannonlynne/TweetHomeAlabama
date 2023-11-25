using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Infrastructure.DataContext
{
    public class TweetHomeAlabamaDbContext : DbContext
    {
        public TweetHomeAlabamaDbContext(DbContextOptions<TweetHomeAlabamaDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Bird> Birds => Set<Bird>();
        public DbSet<BirdTrait> BirdTraits => Set<BirdTrait>();
        public DbSet<Image> Images => Set<Image>();
    }
}


