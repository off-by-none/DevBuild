using Dapper;
using Lab152_CreatingAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lab152_CreatingAPI.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("movieDB");
        }

        //public int CreateMovie(Movie m)
        //{
        //    SqlConnection connection = null;
        //    string queryString = "INSERT INTO Products (Name, Price, Description, Category)";
        //    queryString += " VALUES (@Name, @Price, @Description, @Category);";
        //    queryString += " SELECT SCOPE_IDENTITY();";
        //    int newId;

        //    try
        //    {
        //        connection = new SqlConnection(connectionString);
        //        newId = connection.ExecuteScalar<int>(queryString, m);
        //    }
        //    catch (Exception e)
        //    {
        //        newId = -1;
        //        //log the error--get details from e
        //    }
        //    finally //cleanup!
        //    {
        //        if (connection != null)
        //        {
        //            connection.Close(); //explicitly closing the connection
        //        }
        //    }

        //    return newId;
        //}

        //public int DeleteMovieById(int id)
        //{
        //    //TODO: Refactor with try/catch
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string deleteCommand = "DELETE FROM Products WHERE ID = @id";

        //    int rows = connection.Execute(deleteCommand, new { id = id });

        //    return rows;
        //}

        public string[] GetMovieGenres()
        {
            SqlConnection connection = null;
            string queryString = "SELECT DISTINCT genres FROM Movies";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            if (Movies == null)
            {
                return null;
            }
            else
            {
                string[] genres = new string[Movies.Count()];
                int count = 0;

                foreach (Movie m in Movies)
                {
                    genres[count] = m.Genres;
                    count++;
                }

                return genres;
            }

        }

        public IEnumerable<Movie> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }

        public IEnumerable<Movie> GetMoviesByGenres(string genres)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies WHERE genres = @val";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString, new { val = genres });
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }


        public Movie GetMovieRandom()
        {
            SqlConnection connection = null;
            string queryString = "SELECT TOP 1 * FROM Movies ORDER BY NEWID()";
            Movie movie = null;

            try
            {
                connection = new SqlConnection(connectionString);
                movie = connection.QueryFirstOrDefault<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return movie;
        }


        public Movie GetMovieRandomByGenre(string genre)
        {
            SqlConnection connection = null;
            string queryString = "SELECT TOP 1 * FROM Movies WHERE genres = @val ORDER BY NEWID()";
            Movie movie = null;

            try
            {
                connection = new SqlConnection(connectionString);
                movie = connection.QueryFirstOrDefault<Movie>(queryString, new { val = genre } );
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return movie;
        }

        //public Movie GetMovieById(int id)
        //{
        //    SqlConnection connection = null;
        //    string queryString = "SELECT * FROM Products WHERE Id = @id";
        //    Movie movie = null;

        //    try
        //    {
        //        connection = new SqlConnection(connectionString);
        //        movie = connection.QueryFirstOrDefault<Movie>(queryString, new { id = id });
        //    }
        //    catch (Exception e)
        //    {
        //        //log the error--get details from e
        //    }
        //    finally //cleanup!
        //    {
        //        if (connection != null)
        //        {
        //            connection.Close(); //explicitly closing the connection
        //        }
        //    }

        //    return movie;
        //}
    }
}