using BlogApp.Application.Common.Interfaces;

namespace BlogApp.Application.Articles.Queries;
public record GetBookmarkArticleListQuery(int Id) : IRequest<List<BookmarkDto>>;
public class GetBookmarkArticleListQueryHandler : IRequestHandler<GetBookmarkArticleListQuery, List<BookmarkDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBookmarkArticleListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<BookmarkDto>> Handle(GetBookmarkArticleListQuery request, CancellationToken cancellationToken)
    {
        var Bookmarks = await _context.Bookmarks
            .Where(b => b.WriterId == request.Id)
            .Include(b => b.Article!.Writer)
            .Include(b => b.Writer)
            .ToListAsync();

        var BookmarksVM = _mapper.Map<List<BookmarkDto>>(Bookmarks);
        return BookmarksVM;
    }
}
