using System;
using System.Collections.Generic;
using DotnetMoviesShowcaseApi.DB;

public class MoviesShowsDbOperations : BaseDbOperations
{
    public MoviesShowsDbOperations(string connectionString) : base(connectionString) {}

    public override IEnumerable<object> GetMoviesShows()
    {
        LogOperation("GetMoviesShows");
        return MoviesShowcaseDB.GetMoviesShows(ConnectionString);
    }

    public override IEnumerable<object> GetMovies()
    {
        LogOperation("GetMovies");
        return MoviesShowcaseDB.GetMovies(ConnectionString);
    }

    public override IEnumerable<object> GetShows()
    {
        LogOperation("GetShows");
        return MoviesShowcaseDB.GetShows(ConnectionString);
    }

    public override IEnumerable<object> GetMoviesByGenre(string genre)
    {
        LogOperation("GetMoviesByGenre");
        return MoviesShowcaseDB.GetMoviesByGenre(ConnectionString, genre);
    }

    public override IEnumerable<object> GetShowsByGenre(string genre)
    {
        LogOperation("GetShowsByGenre");
        return MoviesShowcaseDB.GetShowsByGenre(ConnectionString, genre);
    }
}