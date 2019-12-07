using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImdbWebAppCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImdbWebAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imdbController : ControllerBase
    {
        private readonly imdbContext _context;
        public imdbController(imdbContext context)
        {
            _context = context;

            if (_context.Movies.Count() == 0)
            {
                _context.Movies.Add(new Movie { Tittle = "Friends", MovieYear = 2001, Description = "NY city apartament without black people", RunTime = "1000plus hours" });
                _context.Movies.Add(new Movie { Tittle = "GodFather", MovieYear = 1971, Description = "Italian Mafia in US", RunTime = "3 amazing hours" });
                _context.Movies.Add(new Movie { Tittle = "Memento", MovieYear = 2004, Description = "To much hard detective", RunTime = "2 hours" });
                _context.SaveChanges();
            }
        }

        //Movie Section
        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return _context.Movies.ToList();
        }

        [HttpGet ("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            var mov = _context.Movies.Find(id);
            if (mov == null)
            {
                return NotFound();
            }
            return mov;
        }
        
        // POST api/<controller>
        [HttpPost]
        public IActionResult Create (Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtRoute("GetMovie", new { id = movie.MovieId }, movie);
        }        
    }
}
