using Microsoft.EntityFrameworkCore;
using System.Web.Http;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();



