using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ImdbWebAppCore.Models.Genre;

namespace ImdbWebAppCore.Models
{
    public class GenreData : IRepository<Genre>
    {
        //private imdbContext db;
        private imdbContext db;
        public GenreData(imdbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre GetById(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
