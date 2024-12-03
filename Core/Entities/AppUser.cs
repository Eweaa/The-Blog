using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public required string DisplayName { get; set; }
    public string? UserImg { get; set; }
    public virtual List<string> FollowedUsers { get; set; } = [];
}