using System.Threading.Tasks;
using Olympo.Domain.Entities;
using Olympo.Domain.Repositories;
using MongoDB.Driver;

namespace Olympo.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public Task<User> FindAsync(string email)
        {
            return null;
        }

        public Task SaveAsync(User user)
        {
            return null;
        }
    }
}
