namespace Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(Guid id);
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Guid id);
    }
}