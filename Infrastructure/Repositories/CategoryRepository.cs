namespace Infrastructure.Persistence
{
    using Infrastructure.Persistence;
    using Domain.Entities;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    public class CategoryRepository(LibraryDbContext context) : ICategoryRepository
    {
        private readonly LibraryDbContext _context = context;

        public Task<IEnumerable<Category>> GetAllAsync()
            => Task.FromResult<IEnumerable<Category>>(_context.Categories);

        public async Task<Category?> GetByIdAsync(Guid id)
            => await _context.Categories.FindAsync(id);

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat is not null)
            {
                _context.Categories.Remove(cat);
                await _context.SaveChangesAsync();
            }
        }
    }

}