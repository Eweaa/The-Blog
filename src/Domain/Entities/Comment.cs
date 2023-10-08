namespace BlogApp.Domain.Entities;
public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int ArticleId { get; set; }
    public Article? Article { get; set; }
}
