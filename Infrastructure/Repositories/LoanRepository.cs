using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class LoanRepository(LibraryDbContext context) : ILoanRepository
    {
        private readonly LibraryDbContext _context = context;

        public async Task<IEnumerable<Loan>> GetAllAsync()
        => await _context.Loans
            .Include(l => l.User)
            .Include(l => l.LoanDetails!)
                .ThenInclude(d => d.Book)
            .ToListAsync();

        public async Task<Loan?> GetByIdAsync(Guid id)
            => await _context.Loans
                .Include(l => l.User)
                .Include(l => l.LoanDetails!)
                    .ThenInclude(d => d.Book)
                .FirstOrDefaultAsync(l => l.Id == id);

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan is not null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}