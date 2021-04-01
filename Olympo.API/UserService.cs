using System.Threading.Tasks;
using Olympo.Domain.Entities;
using Olympo.Domain.Repositories;

namespace Olympo.API
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo) => _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));

        public async Task RegisterUserAsync(User user)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            await _repo.SaveAsync(user);
        }

        public async Task<bool> IsExistingUserAsync(string email)
        {
            var user = await _repo.FindAsync(email);
            return user != null;
        }
    }
}