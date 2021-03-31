using System.Threading.Tasks;
using Olympo.Domain.Entities;
using Olympo.Domain.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;
using Olympo.Infrastructure.Repositories.DataModel;

namespace Olympo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<DatabaseUser> _users;

        public UserRepository(IOptions<UserRepositoryOptions> options)
        {
            var connStr = options?.Value?.Olympo_Conn_Str;
            Console.WriteLine(connStr);
            if(string.IsNullOrWhiteSpace(connStr))
            {
                throw new ArgumentException("The connection string to the db is required");
            }

            var client = new MongoClient(connStr);
            var db = client.GetDatabase("olympo");
            _users = db.GetCollection<DatabaseUser>("users");
        }

        public Task<User> FindAsync(string email)
        {
            return null;
        }

        public async Task SaveAsync(User user)
        {
            var dbUser = new DatabaseUser
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
            };

            await _users.InsertOneAsync(dbUser);
        }
    }
}
