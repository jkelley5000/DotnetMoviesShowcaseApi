public abstract class BaseDbOperations
{
    protected string ConnectionString { get; }

    protected BaseDbOperations(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    protected void LogOperation(string operation)
    {
        Console.WriteLine($"Operation: {operation} at {DateTime.UtcNow}");
    }

    public abstract IEnumerable<object> GetMoviesShows();
    public abstract IEnumerable<object> GetMovies();
    public abstract IEnumerable<object> GetShows();
    public abstract IEnumerable<object> GetMoviesByGenre(string genre);
    public abstract IEnumerable<object> GetShowsByGenre(string genre);
}