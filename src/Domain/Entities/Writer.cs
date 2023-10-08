namespace BlogApp.Domain.Entities;
public class Writer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Article>? Articles { get; set; }
}
