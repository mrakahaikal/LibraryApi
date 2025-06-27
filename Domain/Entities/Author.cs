namespace Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Bio { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}