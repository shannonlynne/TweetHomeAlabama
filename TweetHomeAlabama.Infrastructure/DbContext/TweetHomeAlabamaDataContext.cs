namespace TweetHomeAlabama.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TweetHomeAlabama.Domain.Model;

public class TweetHomeAlabamaDataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TweetHomeAlabamaDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("THAConnection"));
    }

    public DbSet<Bird> Birds => Set<Bird>();
    public DbSet<BirdTrait> BirdTraits => Set<BirdTrait>();
    public DbSet<Image> Images => Set<Image>();
}
