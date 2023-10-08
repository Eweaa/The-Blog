using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Domain.Entities;
public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public int WriterId { get; set; }
    public Writer? Writer { get; set; }
}
