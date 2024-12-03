namespace Core.DTOs.Article;

public class ArticleToReturn
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? ArticleImg { get; set; }
    public string UserEmail { get; set; }
    public string UserName { get; set; }
}