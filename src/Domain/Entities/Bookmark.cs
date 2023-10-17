using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Domain.Entities;
public class Bookmark
{
    public int Id { get; set; }
    [ForeignKey(nameof(WriterId))]
    public virtual Writer? Writer { get; set; }
    public int? WriterId { get; set; }
    //  public ICollection<Article>? Articles { get; set; }
    [ForeignKey(nameof(ArticleId))]
    public virtual Article? Article { get; set; }
   
    public int? ArticleId { get; set; }

}
