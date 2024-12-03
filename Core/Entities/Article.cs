namespace Core.Entities;

public class Article
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? ArticleImg { get; set; }
    public required string UserEmail { get; set; }
    public required string UserName { get; set; }
    public string? UserImg { get; set; }
}