using BlogApp.Application.Articles;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Writers;
public class WriterDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? WriterImg { get; set; }
    public List<ArticleDto>? Articles { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Writer, WriterDto>();
        }
    }
}
