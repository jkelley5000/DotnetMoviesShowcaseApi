namespace DotnetMoviesShowcaseApi.Models 
{
    public record Movie
    {
          public int Id { get; set; }
          public string? Title { get; set; }
          public string? Type { get; set; }
          public string? Genre { get; set; }
          public string? Thumbnail_url { get; set; }
          public string? Description { get; set; }
    }
}