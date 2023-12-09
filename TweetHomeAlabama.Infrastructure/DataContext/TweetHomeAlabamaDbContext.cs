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
                    entity.Property(x => x.Image).HasColumnName("Image");
                    entity.Property(x => x.Color).HasColumnName("Color");
                    entity.Property(x => x.Shape).HasColumnName("Shape");
                    entity.Property(x => x.Habitat).HasColumnName("Habitat");
                    entity.Property(x => x.SecondaryColor).HasColumnName("SecondaryColor");
                    entity.Property(x => x.Size).HasColumnName("Size");
                });

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}


