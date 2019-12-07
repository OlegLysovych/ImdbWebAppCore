using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [MinLength(1)]
        [MaxLength(20, ErrorMessage = "Tittle should be less than 20 characters ")]
        public string Tittle { get; set; }
        public int MovieYear { get; set; }
        [MaxLength(50, ErrorMessage = "Description should be less than 50 characters")]
        public string Description { get; set; }
        public string RunTime { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
        public IList<MovieGenre> MovieGenres{ get; set; }

        public interface IRepository<T> 
        where T : class
        {
            IEnumerable<T> GetAll(); 
            T GetById(int id); 
            void Create(T item); 
            void Update(T item); 
            void Delete(int id); 
            void Save();  
        }

        //public virtual ICollection<Actor> Actors { get; set; }
        //public virtual ICollection<Genre> Genres { get; set; }
    }
}
