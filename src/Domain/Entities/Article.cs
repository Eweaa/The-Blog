namespace BlogApp.Domain.Entities;
public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public string? ArticleImg { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public int WriterId { get; set; }
    public Writer? Writer { get; set; }
    //public int? BookmarkId { get; set; }
    //public Bookmark? Bookmark { get; set; }
    //public virtual ICollection<Bookmark>? Bookmarks { get; set; } 
}
