using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Queries;
public record GetArticleListQuery : IRequest<List<ArticleDto>>;
public class GetArticleListQueryHandler : IRequestHandler<GetArticleListQuery, List<ArticleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetArticleListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ArticleDto>> Handle(GetArticleListQuery request, CancellationToken cancellationToken)
    {
        var Articles = await _context.Articles.Include(a => a.Writer).ToListAsync(cancellationToken);
        var ArticlesVM  = _mapper.Map<List<ArticleDto>>(Articles);
        return ArticlesVM;
    }
}
