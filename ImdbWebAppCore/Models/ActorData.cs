using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ImdbWebAppCore.Models.Actor;

namespace ImdbWebAppCore.Models
{
    public class ActorData : IRepository<Actor>
    {
        //private imdbContext db;// = new imdbContext();
        private imdbContext db;
        public ActorData(imdbContext context)
        {
            this.db = context;
        }

            public IEnumerable<Actor> GetAll()
        {
            return db.Actors;
        }

        public Actor GetById(int id)
        {
            return db.Actors.Find(id);
        }

        public void Create(Actor actor)
        {
            db.Actors.Add(actor);
        }

        public void Update(Actor actor)
        {
            db.Entry(actor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Actor actor = db.Actors.Find(id);
            if (actor != null)
                db.Actors.Remove(actor);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
