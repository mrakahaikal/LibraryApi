namespace Application.Services
{
    using Domain.Entities;
    using Domain.Interfaces;

    public class CategoryService(ICategoryRepository repo)
    {
        private readonly ICategoryRepository _repo = repo;

        public Task<IEnumerable<Category>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Category?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Category category) => _repo.AddAsync(category);
        public Task UpdateAsync(Category category) => _repo.UpdateAsync(category);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}