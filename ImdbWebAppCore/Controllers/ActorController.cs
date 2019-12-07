using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImdbWebAppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ImdbWebAppCore.Models.Actor;

namespace ImdbWebAppCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IRepository<Actor> _actorRepository;

        public ActorController(IRepository<Actor> actorRepository) { _actorRepository = actorRepository; }

        //Get: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Actor>> Get()
        {
            var actors = _actorRepository.GetAll();
            if (actors == null)
            {
                return NotFound();
            }
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> GetMovieById(int id)
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        // POST api/Actor
        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (actor == null)
            {
                return BadRequest("Parameter cannot be null");
            }
            _actorRepository.Create(actor);
            _actorRepository.Save();
            return CreatedAtRoute("GetActor", new { id = actor.ActorId }, actor);
        }

        [HttpPut]
        public ActionResult Update(int id, Actor newActor)
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                return NotFound();
            }
            _actorRepository.Update(actor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                return NotFound();
            }
            _actorRepository.Delete(id);
            return Ok();
        }
    }
}