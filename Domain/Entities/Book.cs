namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Publisher { get; set; }
        public int Stock { get; set; }
        public bool IsReferenceOnly { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        public Author? Author { get; set; }
        public Category? Category { get; set; }
        public ICollection<LoanDetail>? LoanDetails { get; set; }
    }
    
}
