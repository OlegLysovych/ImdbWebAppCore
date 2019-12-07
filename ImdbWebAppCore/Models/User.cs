using ImdbWebAppCore.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore.Models
{
    public class User
    {
        //[Key]
        //public int UserId { get; set; }
        //[MaxLength(16)]
        //[Required]
        //public string Login { get; set; }
        //[MaxLength(128)]
        //[Required]
        //public byte[] PasswordHashed { get; set; }
        //[MaxLength(128)]
        //[Required]
        //public byte[] Salt { get; set; }


        //[NotMapped]
        //public string Password
        //{
        //    set
        //    {
        //        Salt = PasswordHasher.GetSalt();
        //        PasswordHashed = PasswordHasher.GetHashed(value, Salt);
        //    }
        //}
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public interface IAuthRepository
    {
        User Get(string login);
        void Add(string login, string password);
    }
}
