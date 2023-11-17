using The_Blog.Application.Articles;
using The_Blog.Domain.Entities;

namespace The_Blog.Application.Writers;
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
