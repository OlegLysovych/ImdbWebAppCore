using ImdbWebAppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ImdbWebAppCore.Models.Movie;

namespace ImdbWebAppCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        
        public IRepository<Movie> _movieRepository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            
            var movies = movieRepository.GetAll();
            if (movies == null)
            {
                movieRepository.Create(new Movie { Tittle = "Friends", MovieYear = 2001, Description = "NY city apartament without black people", RunTime = "1000plus hours" });
                movieRepository.Create(new Movie { Tittle = "GodFather", MovieYear = 1971, Description = "Italian Mafia in US", RunTime = "3 amazing hours" });
                movieRepository.Create(new Movie { Tittle = "Memento", MovieYear = 2004, Description = "To much hard detective", RunTime = "2 hours" });
                movieRepository.Save();
            }
            _movieRepository = movieRepository;
        }

        //Get: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _movieRepository.GetAll();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // POST api/Movie
        [HttpPost]
        public ActionResult Post(Movie movie)
        {
            if(movie == null)
            {
                return BadRequest("Parameter cannot be null");
            }
            _movieRepository.Create(movie);
            _movieRepository.Save();
            return CreatedAtRoute("GetMovie", new { id = movie.MovieId }, movie);
        }

        [HttpPut]
        public ActionResult Put(int id, Movie newMovie)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            _movieRepository.Update(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            _movieRepository.Delete(id);
            return Ok();
        }

    }
}
