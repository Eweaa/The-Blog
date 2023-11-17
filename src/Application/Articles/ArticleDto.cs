using The_Blog.Domain.Entities;

namespace The_Blog.Application.Articles;
public class ArticleDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Date { get; set; }
    public string? WriterName { get; set; }
    public int WriterId { get; set; }
    public string? WriterImg { get; set; }
    public string? ArticleImg { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Article, ArticleDto>()
                .AfterMap((src, dest) => dest.WriterName = src.Writer!.Name)
                .AfterMap((src, dest) => dest.WriterImg = src.Writer!.WriterImg)
                .AfterMap((src, dest) => dest.Date = src.Date.ToString("MM/dd/yyyy"))
                .AfterMap((src, dest) => dest.WriterId = src.WriterId);
        }
    }
}
