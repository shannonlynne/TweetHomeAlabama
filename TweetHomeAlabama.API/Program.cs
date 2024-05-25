using Microsoft.EntityFrameworkCore;
using TweetHomeAlabama.Application.Service;
using TweetHomeAlabama.Data.DataContext;
using TweetHomeAlabama.Data.Entity;
using TweetHomeAlabama.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITweetHomeAlabamaService, TweetHomeAlabamaService>();

var connectionString = builder.Configuration.GetConnectionString("Birds");

if (connectionString is not null)
    builder.Services.AddDbContext<TweetHomeAlabamaDbContext>(options =>
        options.UseNpgsql(connectionString));

builder.Services.AddTransient<ITweetHomeAlabamaRepository<BirdEntity>, TweetHomeAlabamaRepository<BirdEntity>>();
builder.Services.AddTransient<ITweetHomeAlabamaService, TweetHomeAlabamaService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

////builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//app.UseEndpoints(endpoints =>

//app.MapControllers();

app.Run();



