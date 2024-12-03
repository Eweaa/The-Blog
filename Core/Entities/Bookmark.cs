namespace Core.Entities;

public class Bookmark
{
    // public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; }
    public Guid ArticleId { get; set; }
    public virtual Article? Article { get; set; }
}