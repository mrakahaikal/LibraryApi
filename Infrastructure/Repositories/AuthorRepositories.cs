namespace Infrastructure.Repositories
{
    public class AuthorRepositories(LibraryDbContext context) : IAuthorRepositry
    {
        private readonly LibraryDbContext _context = context;

        public Task<IEnumerable<Author>> GetAllAsync()
            => Task.FromResult<IEnumerable<Author>>(_context.Authors);

        public async Task<Author?> GetByIdAsync(Guid id)
            => await _context.Authors.FindAsync(id);

        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author is not null)
            {
                _context.Author.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}