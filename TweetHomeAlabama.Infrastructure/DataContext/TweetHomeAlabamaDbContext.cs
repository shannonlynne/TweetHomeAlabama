using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;
using TweetHomeAlabama.Infrastructure.Entity;

namespace TweetHomeAlabama.Infrastructure.DataContext
{
    public class TweetHomeAlabamaDbContext : DbContext
    {
        public DbSet<BirdEntity> Birds => Set<BirdEntity>();

        public TweetHomeAlabamaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<BirdEntity>(entity =>
                {
                    entity.ToTable("Bird", "Bird");

                    entity.HasKey(bird => new
                    {
                        bird.BirdId
                    });

                    entity.Property(x => x.BirdId).HasColumnName("BirdId");
                    entity.Property(x => x.Info).HasColumnName("Info");
                    entity.Property(x => x.ImageId).HasColumnName("ImageId");
                    entity.Property(x => x.Traits).HasColumnName("Traits");
                });

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}


