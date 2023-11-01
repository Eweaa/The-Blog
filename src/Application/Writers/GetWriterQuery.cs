using BlogApp.Application.Articles;
using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;
namespace BlogApp.Application.Writers;
public record GetWriterQuery(int Id) : IRequest<WriterDto>;
public class GetWriterQueryHandler : IRequestHandler<GetWriterQuery, WriterDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetWriterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<WriterDto> Handle(GetWriterQuery request, CancellationToken cancellationToken)
    {
        var WriterArticles = await _context.Articles.Where(a => a.WriterId == request.Id).Include(w => w.Writer).ToListAsync();
        var WriterArticlesVM = _mapper.Map<List<ArticleDto>>(WriterArticles);
        var writer = await  _context.Writers.Where(w => w.Id == request.Id).FirstOrDefaultAsync();
        Writer writer2 = new Writer { };
        writer2 = writer!;

        var writerDto = new WriterDto
        {
            Id = writer2.Id,
            Name = writer2?.Name,
            WriterImg = writer2?.WriterImg,
            Articles = WriterArticlesVM
        };
        return writerDto!;
    }
}
