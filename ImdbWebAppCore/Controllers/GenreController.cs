using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImdbWebAppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ImdbWebAppCore.Models.Genre;

namespace ImdbWebAppCore.Controllers
{
    [Authorize]
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _genreRepository;

        public GenreController(IRepository<Genre> genreRepository) { _genreRepository = genreRepository; }

        //Get: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            var genres = _genreRepository.GetAll();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> GetMovieById(int id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        // POST api/Genre
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Parameter cannot be null");
            }
            _genreRepository.Create(genre);
            _genreRepository.Save();
            return CreatedAtRoute("GetGenre", new { id = genre.GenreId }, genre);
        }

        [HttpPut]
        public ActionResult Update(int id, Genre newGenre)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            _genreRepository.Update(genre);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            _genreRepository.Delete(id);
            return Ok();
        }
    }
}