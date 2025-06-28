namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public bool IsReturned { get; set; }

        public User? User { get; set; }
        public ICollection<LoanDetail>? LoanDetails { get; set; }
    }
}