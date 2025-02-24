namespace Server.Entities;

public class ApplicationUser
{
    public Guid id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public ApplicationUser? InvitedBy { get; set; }

    public Guid InvitedByUserId { get; set; }

    public ICollection<ApplicationUser> InvitedUsers { get; set; } = [];
}