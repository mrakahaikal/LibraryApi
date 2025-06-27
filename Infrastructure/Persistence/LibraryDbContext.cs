namespace Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Entities;

    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options), DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<LoanDetail> LoanDetails => Set<LoanDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}