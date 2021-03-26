using System;

namespace Olympo.Domain.Entities
{
    public class User
    {
        private readonly string _email;
        
        public User(string email) => _email = email;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email => _email;

        public string Phone { get; set; }
    }
}
