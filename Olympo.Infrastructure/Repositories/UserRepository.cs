using System.Threading.Tasks;
using Olympo.Domain.Entities;
using Olympo.Domain.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;

namespace Olympo.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

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
            _users = db.GetCollection<User>("users");
        }

        public Task<User> FindAsync(string email)
        {
            return null;
        }

        public async Task SaveAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}
