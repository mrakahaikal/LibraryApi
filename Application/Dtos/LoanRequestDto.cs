namespace Application.Dtos
{
    public class LoanRequestDto
    {
        public Guid UserId { get; set; }
        public DateTime DueDate { get; set; }
        public List<LoanBookDto> Books { get; set; }
    }

    public class LoanBookDto
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}