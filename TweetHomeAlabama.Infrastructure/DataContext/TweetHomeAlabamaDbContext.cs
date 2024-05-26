using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Data.Entity;

namespace TweetHomeAlabama.Data.DataContext
{
    public class TweetHomeAlabamaDbContext : DbContext
    {
        public DbSet<BirdEntity> Birds => Set<BirdEntity>();
        public DbSet<BirdTraitsEntity> BirdTraits => Set<BirdTraitsEntity>();

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
                        bird.Id
                    });

                    entity.Property(x => x.Id).HasColumnName("Id");
                    entity.Property(x => x.Name).HasColumnName("Name");
                    entity.Property(x => x.Info).HasColumnName("Info");
                    entity.Property(x => x.Image).HasColumnName("Image");
                });

                modelBuilder.Entity<BirdTraitsEntity>(entity =>
                {
                    entity.ToTable("BirdTraits", "Bird");

                    entity.HasKey(bird => new
                    {
                        bird.Id
                    });

                    entity.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                    entity.Property(x => x.BirdId).HasColumnName("BirdId");
                    entity.Property(x => x.Color).HasColumnName("Color");
                    entity.Property(x => x.Shape).HasColumnName("Shape");
                    entity.Property(x => x.Habitat).HasColumnName("Habitat");
                    entity.Property(x => x.SecondaryColor).HasColumnName("SecondaryColor");
                    entity.Property(x => x.Size).HasColumnName("Size");
                });

                modelBuilder.UseIdentityAlwaysColumns();

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}


