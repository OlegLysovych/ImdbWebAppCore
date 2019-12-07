using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Models
{
    public class imdbContext : DbContext
    {
        
        public imdbContext(DbContextOptions<imdbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
        }
    }
}
