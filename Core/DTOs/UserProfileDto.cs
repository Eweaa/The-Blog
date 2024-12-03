namespace Core.DTOs;

public class UserProfileDto
{
    public required string UserName { get; set; }
    public string? UserImg { get; set; }
    public List<Entities.Article>? Articles { get; set; }
    public required bool isFollowd { get; set; }
}