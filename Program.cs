using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotnetMoviesShowcaseApi.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(@"C:\Users\da-at\OneDrive\Documents\GitHub\connections\DotnetMoviesShowcaseApiConnectionString.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddSingleton<MoviesShowsDbOperations>(provider => new MoviesShowsDbOperations(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "Movies Showcase API",
         Description = "Swagger documentation for the Movies Showcase API project",
         Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:8000", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetMoviesShowcaseApi API V1");
   });
}

app.UseCors("AllowSpecificOrigin");
app.MapGet("/", () => "Hello World!");
app.MapGet("/all-movies-shows", (MoviesShowsDbOperations dbOps) => dbOps.GetMoviesShows());
app.MapGet("/all-movies", (MoviesShowsDbOperations dbOps) => dbOps.GetMovies());
app.MapGet("/all-shows", (MoviesShowsDbOperations dbOps) => dbOps.GetShows());
app.MapGet("/movies-by-genre", (string? genre, MoviesShowsDbOperations dbOps) => 
{
   if (string.IsNullOrEmpty(genre))
   {
      return dbOps.GetMovies();
   }
   return dbOps.GetMoviesByGenre(genre);
});
app.MapGet("/shows-by-genre", (string? genre, MoviesShowsDbOperations dbOps) => 
{
   if (string.IsNullOrEmpty(genre))
   {
      return dbOps.GetShows();
   }
   return dbOps.GetShowsByGenre(genre);
});
app.MapGet("/search", (string? searchTerm, MoviesShowsDbOperations dbOps) =>
{
   if (string.IsNullOrEmpty(searchTerm))
   {
      return dbOps.GetMoviesShows();
   }
   return dbOps.GetMoviesShowsBySearch(searchTerm);
});

app.Run();
