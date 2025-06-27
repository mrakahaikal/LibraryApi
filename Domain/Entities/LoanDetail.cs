namespace Domain.Entities
{
    public class LoanDetail
    {
        public Guid Id { get; set; }
        public Guid LoanId { get; set; }
        public Guid BookId { get; set; }
    }
}