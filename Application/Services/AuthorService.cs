namespace Application.Services
{
    public class AuthorService(IAuthorRepository repo)
    {
        private readonly IAuthorRepository _repo = repo;

        public Task<IEnumerable<Author>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Author?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Author author) => _repo.AddAsync(author);
        public Task UpdateAsync(Author author) => _repo.UpdateAsync(author);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}