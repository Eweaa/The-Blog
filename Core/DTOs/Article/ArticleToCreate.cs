using Microsoft.AspNetCore.Http;

namespace Core.DTOs.Article;

public class ArticleToCreate
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public IFormFile image { get; set; }
}