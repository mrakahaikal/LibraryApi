using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService(IUserRepository repo, IPasswordHasher<User> hasher)
    {
        private readonly IUserRepository _repo = repo;
        private readonly IPasswordHasher<User> _hasher = hasher;

        public Task<IEnumerable<User>> GetAllAsync() => _repo.GetAllAsync();
        public Task<User?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public async Task AddAsync(User user)
        {
            user.PasswordHash = _hasher.HashPassword(user, user.PasswordHash);
            await _repo.AddAsync(user);
        }
        public Task UpdateAsync(User user) => _repo.UpdateAsync(user);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }

}