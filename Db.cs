using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DotnetMoviesShowcaseApi.Models;

namespace DotnetMoviesShowcaseApi.DB;
public class MoviesShowcaseDB {
    private readonly string _connectionString;
    public MoviesShowcaseDB(string connectionString) {
        _connectionString = connectionString;
    }

    public static List<Movie> GetMoviesShows(string connectionString)
    {
        var movies = new List<Movie>();

        try 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM v_all_movies_shows";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var movie = new Movie
                            {
                                Id = reader.GetInt16(0),
                                Title = reader.GetString(1),
                                Type = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Thumbnail_url = reader.GetString(4),
                                Description = reader.GetString(5),
                            };

                            movies.Add(movie);
                        }
                    }
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

        return movies;
    }

    public static List<Movie> GetMovies(string connectionString)
    {
        var movies = new List<Movie>();

        try 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM movies";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var movie = new Movie
                            {
                                Id = reader.GetInt16(0),
                                Title = reader.GetString(1),
                                Type = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Thumbnail_url = reader.GetString(4),
                                Description = reader.GetString(5),
                            };

                            movies.Add(movie);
                        }
                    }
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

        return movies;
    }

    public static List<Movie> GetShows(string connectionString)
    {
        var movies = new List<Movie>();

        try 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM shows";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var movie = new Movie
                            {
                                Id = reader.GetInt16(0),
                                Title = reader.GetString(1),
                                Type = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Thumbnail_url = reader.GetString(4),
                                Description = reader.GetString(5),
                            };

                            movies.Add(movie);
                        }
                    }
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

        return movies;
    }
}