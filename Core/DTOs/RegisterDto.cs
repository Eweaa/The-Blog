namespace Core.DTOs;

public class RegisterDto
{
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}