namespace BlogApp.Domain.Entities;
public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public string? ArticleImg { get; set; }
    public string? WriterImg { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public int WriterId { get; set; }
    public Writer? Writer { get; set; }
}
