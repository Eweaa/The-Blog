using The_Blog.Domain.Entities;

namespace The_Blog.Application.Articles;
public class BookmarkDto
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ArticleImg { get; set; }
    public string? Date { get; set; }
    public int WriterId { get; set; }
    public string? WriterName { get; set; }
    public string? WriterImg { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Bookmark, BookmarkDto>()
                .AfterMap((src, dest) => dest.Title = src.Article?.Title)
                .AfterMap((src, dest) => dest.Content = src.Article?.Content)
                .AfterMap((src, dest) => dest.ArticleImg = src.Article?.ArticleImg)
                .AfterMap((src, dest) => dest.Date = src.Article?.Date.ToString("MM/dd/yyyy"))
                .AfterMap((src, dest) => dest.WriterName = src.Article?.Writer?.Name)
                .AfterMap((src, dest) => dest.WriterImg = src.Article?.Writer?.WriterImg);
        }
    }
}
