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
        if(ArticlesVM is null)
        {
            var a1 = new Article() { Title = "null"};
            var a2 = _mapper.Map<ArticleDto>(a1);
            var alist = new List<ArticleDto>();
            alist.Add(a2);
            return alist;
        }
        return ArticlesVM;
    }
}
