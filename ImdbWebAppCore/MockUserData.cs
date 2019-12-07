using ImdbWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbWebAppCore
{
    public class MockUserData : IAuthRepository
    {
        private readonly List<User> users;
        public MockUserData()
        {

            users = new List<User>()
            {
                new User{ Id = 1, Username = "admin",Password="admin" }
            };
        }
        public void Add(string login, string password)
        {
            throw new NotImplementedException();
        }

        public User Get(string login)
        {
            throw new NotImplementedException();
        }
    }
}
