using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Queries;
public record GetArticleListQuery : IRequest<List<Article>>;
public class GetArticleListQueryHandler : IRequestHandler<GetArticleListQuery, List<Article>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetArticleListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Article>> Handle(GetArticleListQuery request, CancellationToken cancellationToken)
    {
        var Articles = await _context.Articles.ToListAsync(cancellationToken);
        var ArticlesVM  = _mapper.Map<List<Article>>(Articles);
        return ArticlesVM;
    }
}
