namespace Bloggy.Domain.Entites;

public class RefreshToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Value { get; set; }
    public DateTime ExpiryDate { get; set; }
}