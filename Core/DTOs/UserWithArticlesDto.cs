namespace Core.DTOs;

public class UserWithArticlesDto
{
    public required string UserName { get; set; }
    public string? UserImg { get; set; }
    public List<Entities.Article> Articles { get; set; }
}