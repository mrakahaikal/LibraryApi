namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string LoanDate { get; set; }
        public required string DueDate { get; set; }
        public string? ReturnDate { get; set; }
        public enum Status { get, set }
        public string? Notes { get; set; }
    }
}