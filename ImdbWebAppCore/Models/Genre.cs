using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Models
{
    public class Genre
    {
        [Key]
        [Required]
        public int GenreId { get; set; }
        [MinLength(1, ErrorMessage = "Name should be minimum 1 character")]
        [MaxLength(20, ErrorMessage = "Name should be less than 20 characters ")]
        public string Name { get; set; }

        public IList<MovieGenre> MovieGenres { get; set; }
        //public virtual ICollection<Movie> Movies { get; set; }

        public interface IRepository<T>
       where T : class
        {
            IEnumerable<T> GetAll(); // получение всех объектов
            T GetById(int id); // получение одного объекта по id
            void Create(T item); // создание объекта
            void Update(T item); // обновление объекта
            void Delete(int id); // удаление объекта по id
            void Save();  // сохранение изменений
        }
    }
}
