using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab152_CreatingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab152_CreatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IDAL dal;

        public GenreController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpGet]
        public string[] GetGenres()
        {
            return dal.GetMovieGenres();
        }
    }
}