using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    public class MovieDB
    {
        private List<Movie> movies;
        public List<Movie> Movies { get => movies; set => movies = value; }
        public MovieDB() { movies = new List<Movie>(); }
        public int index;


        #region methods
        public void AddMovie(Movie m)
        {
            movies.Add(m);
        }


        public void RemoveMovie(Movie m)
        {
            movies.Remove(m);
        }


        public MovieDB SortMovies(MovieDB movies, string cat, string sortOrder)
        {
            MovieDB sortedMovies = new MovieDB();

            if (cat == "Title" && sortOrder == "asc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderBy(movie => movie.Title);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "Title" && sortOrder == "desc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderByDescending(movie => movie.Title);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "Year" && sortOrder == "asc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderBy(movie => movie.Year);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "Year" && sortOrder == "desc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderByDescending(movie => movie.Year);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "Runtime" && sortOrder == "asc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderBy(movie => movie.RunTime);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "Runtime" && sortOrder == "desc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderByDescending(movie => movie.RunTime);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "IMDb Rating" && sortOrder == "asc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderBy(movie => movie.ImdbRating);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            if (cat == "IMDb Rating" && sortOrder == "desc")
            {
                IEnumerable<Movie> query = movies.Movies.OrderByDescending(movie => movie.ImdbRating);
                foreach (Movie m in query) { sortedMovies.AddMovie(m); }
            }

            return sortedMovies;
        }


        public void ListMovies(int index)
        {
            if (index < movies.Count && index >= 0)
            {
                for (int i = index; i < index + 7; i++)
                {
                    if (i < movies.Count)
                    {
                        Console.WriteLine(movies[i]);
                    }
                }
            }
        }
        #endregion methods
    }
}
