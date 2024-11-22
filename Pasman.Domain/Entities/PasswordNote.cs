namespace Pasman.Domain.Entities;

public class PasswordNote
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public required string PasswordEncrypted { get; set; }
    public DateTime Created { get; set; }

    public static PasswordNote Create(string description, string passwordEncrypted)
    {
        return new PasswordNote
        {
            Id = Guid.NewGuid(),
            Description = description,
            PasswordEncrypted = passwordEncrypted,
            Created = DateTime.UtcNow
        };
    }
}