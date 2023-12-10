using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Application.Service;
using TweetHomeAlabama.Data.DataContext;
using TweetHomeAlabama.Data.Entity;
using TweetHomeAlabama.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddTransient<ITweetHomeAlabamaService, TweetHomeAlabamaService>();

var connectionString = builder.Configuration.GetConnectionString("ShannonApps");

if (connectionString is not null)
    builder.Services.AddDbContext<TweetHomeAlabamaDbContext>(options =>
        options.UseNpgsql(connectionString));

builder.Services.AddTransient<ITweetHomeAlabamaRepository<BirdEntity> , TweetHomeAlabamaRepository<BirdEntity>>();
builder.Services.AddTransient<ITweetHomeAlabamaService, TweetHomeAlabamaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
