namespace TweetHomeAlabama.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TweetHomeAlabama.Domain.Model;

public class TweetHomeAlabamaDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)  
    {
        options.UseNpgsql(ConfigurationManager.ConnectionStrings["THAConnection"].ConnectionString);
    }

    public DbSet<Bird> Birds => Set<Bird>();
    public DbSet<BirdTrait> BirdTraits => Set<BirdTrait>();
    public DbSet<Image> Images => Set<Image>();
}
