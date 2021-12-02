using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab152_CreatingAPI.Models;

namespace Lab152_CreatingAPI.Services
{
    public interface IDAL
    {
        IEnumerable<Movie> GetMoviesAll();
        
        Movie GetMovieRandom();
        Movie GetMovieRandomByGenre(string genre);
        //int CreateMovie(Movie m);
        //int DeleteMovieById(int id);
        //Movie GetMovieById(int id);

        IEnumerable<Movie> GetMoviesByGenres(string genres);
        
        string[] GetMovieGenres();
        //int UpdateMovietById(Movie mov);
    }
}
