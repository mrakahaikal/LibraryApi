namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public datetime LoanDate { get; set; }
        public datetime DueDate { get; set; }
        public datetime ReturnDate { get; set; }
        public enum Status { get, set }
        public string Notes { get; set; }
    }
}