namespace Application.Services
{
    using Domain.Entities;
    using Domain.Interfaces;

    public class BookService(IBookRepository repo)
    {
        private readonly IBookRepository _repo = repo;

        public Task<IEnumerable<Book>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Book?> GetByIdAsync(Guid id)
            => _repo.GetByIdAsync(id);

        public Task AddAsync(Book book)
            => _repo.AddAsync(book);

        public Task UpdateAsync(Book book)
            => _repo.UpdateAsync(book);

        public Task DeleteAsync(Guid id)
            => _repo.DeleteAsync(id);
    }
}