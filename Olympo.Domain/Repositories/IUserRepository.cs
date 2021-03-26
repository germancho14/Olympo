using System.Threading.Tasks;
using Olympo.Domain.Entities;

namespace Olympo.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindAsync(string email);

        Task SaveAsync(User user);
    }
}