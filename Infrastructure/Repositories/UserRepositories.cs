namespace Infrastructure.Repositories
{
    using Domain.Entities;
    using Domain.Interfaces;
    using Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    
    public class UserRepository(LibraryDbContext context) : IUserRepository
    {
        private readonly LibraryDbContext _context = context;

        public Task<IEnumerable<User>> GetAllAsync()
        => Task.FromResult<IEnumerable<User>>(_context.Users);

        public async Task<User?> GetByIdAsync(Guid id)
            => await _context.Users.FindAsync(id);

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}