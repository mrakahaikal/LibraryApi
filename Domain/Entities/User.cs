namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public enum Role { get, set, }
    public bool IsActive { get; set; }
    public required string CreatedAt { get; set; }

    public ICollection<Loan>? Loans { get; set; }
}