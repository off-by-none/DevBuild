using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab152_CreatingAPI.Models;
using Lab152_CreatingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab152_CreatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IDAL dal;

        public MovieController(IDAL dalObject)
        {
            dal = dalObject;
        }

        //[HttpDelete("{id}")]
        //public Object Delete(int id)
        //{
        //    int result = dal.DeleteMovieById(id);

        //    if (result > 0)
        //    {
        //        return new { success = true };
        //    }
        //    else
        //    {
        //        return new { success = false };
        //    }
        //}

        //[HttpGet("{id}")]
        //public Movie GetSingleMovie(int id)
        //{
        //    Movie mov = dal.GetMovieById(id);
        //    return mov; //serialize the parameter into JSON and return an Ok (20x)
        //}

        [HttpGet("random")]
        public Movie GetMovieRandom(string genre = null)
        {
            if (genre == null)
            {
                Movie mov = dal.GetMovieRandom();
                if (mov == null)
                {
                    return new Movie(); //serialize the parameter into JSON and return an Ok (20x)
                }
                else
                {
                    return mov; //serialize the parameter into JSON and return an Ok (20x)
                }
            }
            else
            {
                Movie mov = dal.GetMovieRandomByGenre(genre);
                if (mov == null)
                {
                    return new Movie(); //serialize the parameter into JSON and return an Ok (20x)
                }
                else
                {
                    return mov; //serialize the parameter into JSON and return an Ok (20x)
                }
            }
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string genres = null)
        {
            if (genres == null)
            {
                IEnumerable<Movie> Movies = dal.GetMoviesAll();
                if (Movies == null)
                {
                    return new List<Movie>(); //serialize the parameter into JSON and return an Ok (20x)
                }
                else
                {
                    return Movies; //serialize the parameter into JSON and return an Ok (20x)
                }
            }
            else
            {
                IEnumerable<Movie> Movies = dal.GetMoviesByGenres(genres);
                if (Movies == null)
                {
                    return new List<Movie>(); //serialize the parameter into JSON and return an Ok (20x)
                }
                else
                {
                    return Movies; //serialize the parameter into JSON and return an Ok (20x)
                }
            }
        }

        //valid but superceded by Category controller
        [HttpGet("genres")]
        public string[] GetGenres()
        {
            return dal.GetMovieGenres();
        }

        //[HttpPost]
        //public Object Post(Movie m)
        //{
        //    int newId = dal.CreateMovie(m);

        //    if (newId < 0)
        //    {
        //        return new { success = false };
        //    }
        //    return new { success = true, id = newId };
        //}
    }
}