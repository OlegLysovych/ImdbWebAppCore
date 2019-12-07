using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Models
{
    public class Actor
    {
        [Key]
        [Required]
        public int ActorId { get; set; }
        [MinLength(1, ErrorMessage = "FirstName should be minimum 1 character")]
        public string FirstName { get; set; }
        [MinLength(1, ErrorMessage = "FirstName should be minimum 1 character")]
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Bio { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
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
