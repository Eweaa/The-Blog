using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Queries;
public record GetBookmarkArticleListQuery(int Id) : IRequest<List<ArticleDto>>;
public class GetBookmarkArticleListQueryHandler : IRequestHandler<GetBookmarkArticleListQuery, List<ArticleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBookmarkArticleListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ArticleDto>> Handle(GetBookmarkArticleListQuery request, CancellationToken cancellationToken)
    {
        var bookmark = _context.Bookmarks.Where(B => B.WriterId == request.Id).FirstOrDefaultAsync();
        var articles = await _context.Articles.Where(a => a.BookmarkId == bookmark!.Id).ToListAsync();
        var articlesVM = _mapper.Map<List<ArticleDto>>(articles);
        return articlesVM;
    }
}
