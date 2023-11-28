using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Infrastructure.DataContext
{
    public class TweetHomeAlabamaDbContext : DbContext
    {
        public TweetHomeAlabamaDbContext(DbContextOptions<TweetHomeAlabamaDbContext> options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = _configuration.GetConnectionString("ShannonApps");

        //    if (connectionString is not null)
        //        optionsBuilder.UseNpgsql(connectionString);

        //}
        //    // => optionsBuilder.UseNpgsql("Server = localHost:5433; Database=ShannonApps;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bird>(entity =>
            {
                entity.ToTable("Bird");

                entity.Property<int>("BirdId")
                 .ValueGeneratedOnAdd();
                entity.HasKey("BirdId");

                entity.Property(x => x.Name);
                entity.Property(x => x.Info);
                entity.Property(x => x.Traits);
                entity.Property(x => x.ImageId);
            });
        }

        public DbSet<Bird> Birds => Set<Bird>();
    }
}


