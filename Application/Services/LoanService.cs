using Application.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LoanService(
        ILoanRepository loanRepo,
        IBookRepository bookRepo,
        IUserRepository userRepo)
    {
        private readonly ILoanRepository _loanRepo = loanRepo;
        private readonly IBookRepository _bookRepo = bookRepo;
        private readonly IUserRepository _userRepo = userRepo;

        public async Task<IEnumerable<Loan>> GetAllAsync() => await _loanRepo.GetAllAsync();
        public async Task<Loan?> GetByIdAsync(Guid id) => await _loanRepo.GetByIdAsync(id);

        public async Task CreateAsync(LoanRequestDto dto)
        {
            // Validasi user
            var user = await _userRepo.GetByIdAsync(dto.UserId) ?? throw new Exception("User tidak ditemukan.");

            // Buat loan entity
            var loan = new Loan
            {
                UserId = dto.UserId,
                LoanDate = DateTime.UtcNow,
                DueDate = dto.DueDate,
                IsReturned = false,
                LoanDetails = new List<LoanDetail>()
            };

            foreach (var item in dto.Books)
            {
                var book = await _bookRepo.GetByIdAsync(item.BookId);
                if (book is null || book.Stock < item.Quantity)
                    throw new Exception($"Buku {item.BookId} tidak tersedia atau stok tidak cukup.");

                // Kurangi stok buku
                book.Stock -= item.Quantity;
                await _bookRepo.UpdateAsync(book);

                loan.LoanDetails.Add(new LoanDetail
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity
                });

                await _loanRepo.AddAsync(loan);
            }
        }
    }
}