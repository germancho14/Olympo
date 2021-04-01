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

        public async Task<User> FindAsync(string email)
        {
            var filter = Builders<DatabaseUser>.Filter.Eq("_id", email);
            var dbUser = await _users.Find(filter).FirstOrDefaultAsync();
            
            if(dbUser == null)
            {
                return null;
            }

            var user = new User(email);
            user.FirstName = dbUser.FirstName;
            user.LastName = dbUser.LastName;
            user.Phone = dbUser.Phone;
            user.Password = dbUser.Password;
            return user;
        }

        public async Task SaveAsync(User user)
        {
            var dbUser = new DatabaseUser
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Password = user.Password,
            };

            await _users.InsertOneAsync(dbUser);
        }
    }
}
