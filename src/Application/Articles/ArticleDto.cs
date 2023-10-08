using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles;
public class ArticleDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public string? WriterName { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Article, ArticleDto>().AfterMap((src, dest) => dest.WriterName = src.Writer!.Name);
        }
    }
}
