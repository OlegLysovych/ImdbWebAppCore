using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ImdbWebAppCore.Models.Movie;

namespace ImdbWebAppCore.Models
{
    public class MovieData : IRepository<Movie>
    {
        //private imdbContext db;
        public imdbContext db;
        public MovieData(imdbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
