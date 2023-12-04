using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.Infrastructure.DataContext
{
    public class TweetHomeAlabamaDbContext : DbContext
    {
        public DbSet<Bird> Birds => Set<Bird>();

        public TweetHomeAlabamaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Bird>(entity =>
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


