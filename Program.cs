using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotnetMoviesShowcaseApi.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(@"C:\Users\da-at\OneDrive\Documents\GitHub\connections\DotnetMoviesShowcaseApiConnectionString.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddSingleton(new MoviesShowcaseDB(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "Movies Showcase API",
         Description = "Swagger documentation for the Movies Showcase API project",
         Version = "v1" });
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

app.MapGet("/", () => "Hello World!");
app.MapGet("/all-movies-shows", () => MoviesShowcaseDB.GetMoviesShows(connectionString));
app.MapGet("/all-movies", () => MoviesShowcaseDB.GetMovies(connectionString));
app.MapGet("/all-shows", () => MoviesShowcaseDB.GetShows(connectionString));
app.MapGet("/movies-by-genre", (string? genre) => 
{
   if (string.IsNullOrEmpty(genre))
   {
      return MoviesShowcaseDB.GetMovies(connectionString);
   }
   return MoviesShowcaseDB.GetMoviesByGenre(connectionString, genre);
});
app.MapGet("/shows-by-genre", (string? genre) => 
{
   if (string.IsNullOrEmpty(genre))
   {
      return MoviesShowcaseDB.GetShows(connectionString);
   }
   return MoviesShowcaseDB.GetShowsByGenre(connectionString, genre);
});


app.Run();
