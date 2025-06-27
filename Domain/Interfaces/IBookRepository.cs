namespace Domain.Interfaces
{
    using Domain.Entities;

    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(Guid Id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
        // Task FindByTitleAsync(string title);
    }
}