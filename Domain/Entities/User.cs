namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public enum Role { get, set, }
    public bool IsActive { get; set; }
    public datetime CreatedAt { get; set; }

    public ICollection<Loan>? Loans { get; set; }
}