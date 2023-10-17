using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Queries;
public record GetBookmarkArticleListQuery(int Id) : IRequest<List<Bookmark>>;
public class GetBookmarkArticleListQueryHandler : IRequestHandler<GetBookmarkArticleListQuery, List<Bookmark>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBookmarkArticleListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Bookmark>> Handle(GetBookmarkArticleListQuery request, CancellationToken cancellationToken)
    {
        var Bookmarks = await _context.Bookmarks.Where(b => b.WriterId == request.Id).Include(b => b.Article).ToListAsync();
        return Bookmarks;
    }
}
