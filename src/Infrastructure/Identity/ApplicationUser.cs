using Microsoft.AspNetCore.Identity;

namespace The_Blog.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? UserImg { get; set; }
}
