namespace BlogApp.Domain.Entities;
public class Bookmark
{
    public int Id { get; set; }
    public Writer? Writer { get; set; }
    public int WriterId { get; set; }
    public ICollection<Article>? Articles { get; set; }
}
